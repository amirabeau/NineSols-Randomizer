﻿using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using RCGFSM.Items;
using static RCGFSM.Items.PickItemAction;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using static UnityEngine.ParticleSystem.PlaybackState;
using System.Linq;
using static RCGFSM.Items.ItemGetUIShowAction;
using UnityEngine;
using RCGMaker.AddressableAssets;
using static MerchandiseData;
using RCGMaker.Core;
using System.Drawing;

namespace NineSolsRandomizer;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInProcess("NineSols.exe")]
public class NineSolsRandomizerPlugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    // Reference to the SaveManager.allFlags.flagDict we can use to access flags by ID at any time
    internal static Dictionary<string, GameFlagBase> flagDict;

    // Map to track which items get mapped where
    internal static Dictionary<string, string> ItemRemap = new Dictionary<string, string>();

    // Flags we'll need to access that aren't randomized
    internal static Dictionary<string, string> HelperFlags = new Dictionary<string, string>();

    private ConfigEntry<int> Seed;
    private ConfigEntry<bool> UseFixedSeed;

    private ConfigEntry<bool> randomizeAbilities;
    private ConfigEntry<bool> randomizeKeyItems;
    private ConfigEntry<bool> randomizeJades;
    private ConfigEntry<bool> randomizeArtifacts;
    private ConfigEntry<bool> randomizePoisons;
    private ConfigEntry<bool> randomizeEncyclopedia;
    private ConfigEntry<bool> randomizeMapChips;
    private ConfigEntry<bool> randomizeRecyclables;

    private bool IsInvalidArrangement(List<RandomizerItemData> sourceItems, List<RandomizerItemData> targetItems)
    {
        int mysticNymphIndex = targetItems.FindIndex(item => item.finalSaveId == HelperFlags["ability_mysticnymph"]);
        int taiChiKickIndex = targetItems.FindIndex(item => item.finalSaveId == HelperFlags["ability_taichikick"]);
        int unboundedCounterIndex = targetItems.FindIndex(item => item.finalSaveId == HelperFlags["ability_unboundedcounter"]);

        // Check if upgrades require themselves
        var nymphRequirements = sourceItems[mysticNymphIndex].requirements;
        var taiChiKickRequirements = sourceItems[taiChiKickIndex].requirements;
        var ucRequirements = sourceItems[unboundedCounterIndex].requirements;

        if (nymphRequirements.Contains(Requirement.MysticNymph)
            || taiChiKickRequirements.Contains(Requirement.TaiChiKick)
            || ucRequirements.Contains(Requirement.UnboundedCounter))
        {
            return true;
        }

        // Check for requirement cycles
        if (nymphRequirements.Contains(Requirement.TaiChiKick) && taiChiKickRequirements.Contains(Requirement.MysticNymph)
            || nymphRequirements.Contains(Requirement.UnboundedCounter) && ucRequirements.Contains(Requirement.MysticNymph)
            || taiChiKickRequirements.Contains(Requirement.UnboundedCounter) && ucRequirements.Contains(Requirement.TaiChiKick))
        {
            return true;
        }

        // 3-way cycle
        if (nymphRequirements.Contains(Requirement.TaiChiKick) && taiChiKickRequirements.Contains(Requirement.UnboundedCounter) && ucRequirements.Contains(Requirement.MysticNymph)
            || nymphRequirements.Contains(Requirement.UnboundedCounter) && ucRequirements.Contains(Requirement.TaiChiKick) && taiChiKickRequirements.Contains(Requirement.MysticNymph))
        {
            return true;
        }

        // Don't put the first 3 seals in places that require prison access
        int kuafuSealIndex = targetItems.FindIndex(item => item.finalSaveId == HelperFlags["seal_kuafu"]);
        int goumangSealIndex = targetItems.FindIndex(item => item.finalSaveId == HelperFlags["seal_goumang"]);
        int yanlaoSealIndex = targetItems.FindIndex(item => item.finalSaveId == HelperFlags["seal_yanlao"]);
        var kuafuRequirements = sourceItems[kuafuSealIndex].requirements;
        var goumangRequirements = sourceItems[goumangSealIndex].requirements;
        var yanlaoRequirements = sourceItems[yanlaoSealIndex].requirements;
        if (kuafuRequirements.Contains(Requirement.Prison) || goumangRequirements.Contains(Requirement.Prison) || yanlaoRequirements.Contains(Requirement.Prison))
        {
            return true;
        }

        // The seed is good as far as these three upgrades are concerned
        return false;
    }

    private void GenerateRandomSettings(int seed, bool logSpoiler=false)
    {
        List<RandomizerItemData> enabledRandomizerItems = new List<RandomizerItemData>();
        foreach (var item in RandomizerFlags.GetAllRandomizerItems())
        {
            if (randomizeAbilities.Value && item.type == ItemType.Ability)
            {
                enabledRandomizerItems.Add(item);
            }
            else if (randomizeKeyItems.Value && item.type == ItemType.KeyItem)
            {
                enabledRandomizerItems.Add(item);
            }
            else if (randomizeJades.Value && item.type == ItemType.Jade)
            {
                enabledRandomizerItems.Add(item);
            }
            else if (randomizeArtifacts.Value && item.type == ItemType.Artifact)
            {
                enabledRandomizerItems.Add(item);
            }
            else if (randomizePoisons.Value && item.type == ItemType.Poison)
            {
                enabledRandomizerItems.Add(item);
            }
            else if (randomizeEncyclopedia.Value && item.type == ItemType.Encyclopedia)
            {
                enabledRandomizerItems.Add(item);
            }
            else if (randomizeMapChips.Value && item.type == ItemType.MapChips)
            {
                enabledRandomizerItems.Add(item);
            }
            else if (randomizeRecyclables.Value && item.type == ItemType.Recyclables)
            {
                enabledRandomizerItems.Add(item);
            }
        }


        System.Random rng = new System.Random(seed);
        List<RandomizerItemData> shuffledRandomItems;
        int attempts = 0;
        do
        {
            shuffledRandomItems = enabledRandomizerItems.OrderBy(_ => rng.Next()).ToList();
        } while (IsInvalidArrangement(enabledRandomizerItems, shuffledRandomItems));

        ItemRemap.Clear();
        for (int i = 0; i < enabledRandomizerItems.Count; i++)
        {
            ItemRemap.Add(enabledRandomizerItems[i].finalSaveId, shuffledRandomItems[i].finalSaveId);
            if (logSpoiler)
            {
                Logger.LogInfo("Remapping " + enabledRandomizerItems[i].displayName + " to " + shuffledRandomItems[i].displayName);
            }
        }
    }


    public static bool IsRandomizedItem(GameFlagDescriptable gameFlagDescriptable)
    {
        return IsRandomizedItem(gameFlagDescriptable.FinalSaveID);
    }

    public static bool IsRandomizedItem(string finalSaveId)
    {
        if (!ItemRemap.ContainsKey(finalSaveId))
        {
            return false;
        }

        if (!flagDict.ContainsKey(ItemRemap[finalSaveId]))
        {
            Logger.LogError("Item " + finalSaveId + " should be randomized but cannot find target flag ItemRemap[gameFlagDescriptable.FinalSaveID]");
            return false;
        }

        return true;
    }

    public static GameFlagDescriptable GetMappedItem(GameFlagDescriptable gameFlagDescriptable)
    {
        // Use remapped item instead 
        return GetMappedItem(gameFlagDescriptable.FinalSaveID);
    }
    public static GameFlagDescriptable GetMappedItem(string finalSaveId)
    {
        // Use remapped item instead 
        return (IsRandomizedItem(finalSaveId) ? flagDict[ItemRemap[finalSaveId]] : flagDict[finalSaveId]) as GameFlagDescriptable;
    }

    public static void UnlockItemWithPopup(GameFlagDescriptable gameFlagDescriptable)
    {
        gameFlagDescriptable.PlayerPicked();
        SingletonBehaviour<SaveManager>.Instance.AutoSave();
        if (!gameFlagDescriptable.promptViewed.CurrentValue || gameFlagDescriptable.IsImportantObject || !(gameFlagDescriptable is ItemData))
        {
            SingletonBehaviour<UIManager>.Instance.ShowGetDescriptablePrompt(gameFlagDescriptable);
        }
        else
        {
            SingletonBehaviour<UIManager>.Instance.ShowDescriptableNitification(gameFlagDescriptable);
        }
    }

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        Seed = Config.Bind("RandomSeed", "Seed", 29932, "Seed that will be used to randomize items. Using the default value of 29932 with all settings turned on will result in a vetted seed that can be completed without glitches.");

        randomizeAbilities = Config.Bind("RandomizerSettings",
                                            "RandomizeAbilities",
                                            true,
                                            "Whether or not to randomize abilities");

        randomizeKeyItems = Config.Bind("RandomizerSettings",
                                            "RandomizeKeyItems",
                                            true,
                                            "Whether or not to randomize key items");

        randomizeJades = Config.Bind("RandomizerSettings",
                                            "RandomizeJades",
                                            true,
                                            "Whether or not to randomize jades");

        randomizeArtifacts = Config.Bind("RandomizerSettings",
                                            "RandomizeArtifacts",
                                            true,
                                            "Whether or not to randomize artifacts");

        randomizePoisons = Config.Bind("RandomizerSettings",
                                            "RandomizePoison",
                                            true,
                                            "Whether or not to randomize poisons");

        randomizeEncyclopedia = Config.Bind("RandomizerSettings",
                                            "RandomizeEncyclopedia",
                                            true,
                                            "Whether or not to randomize encyclopedia entries");

        randomizeMapChips = Config.Bind("RandomizerSettings",
                                            "RandomizeMapChips",
                                            true,
                                            "Whether or not to randomize map chips");

        randomizeRecyclables = Config.Bind("RandomizerSettings",
                                            "RandomizeRecyclables",
                                            true,
                                            "Whether or not to randomize recyclable items");


        Harmony.CreateAndPatchAll(typeof(NineSolsRandomizerPlugin));

        HelperFlags = RandomizerFlags.GetHelperFlags();
        GenerateRandomSettings(Seed.Value, true);
    }

    [HarmonyPatch(typeof(SaveManager), "Awake")]
    [HarmonyPostfix]
    static void InitializeFlagMapping(SaveManager __instance)
    {
        Logger.LogInfo("SaveManager flags count: " + __instance.allFlags.Flags.Count);

        flagDict = __instance.allFlags.FlagDict;
    }


    [HarmonyPatch(typeof(ItemData), "PlayerPicked")]
    [HarmonyPostfix]
    static void LogPlayerPicked(ItemData __instance)
    {
        Logger.LogInfo("Player Picked item: " + __instance.Title);
        //Logger.LogInfo(System.Environment.StackTrace);

        if (__instance.FinalSaveID == HelperFlags["ability_fusanghorn"])
        {
            //QoL: enable teleport ability when unlocking Fusang Horn
            var teleportAbilityFlag = flagDict[HelperFlags["ability_teleport"]] as GameFlagDescriptable;
            if (!teleportAbilityFlag.unlocked.CurrentValue)
            {
                Logger.LogInfo("Player got Fusang Horn. Unlocking Teleport");
                teleportAbilityFlag.PlayerPicked();
            }
        }
    }

    // Swap received items for cutscenes
    [HarmonyPatch(typeof(ItemGetUIShowAction), "Implement")]
    [HarmonyPrefix]
    static bool ItemGetUIShowAction_Implement_Hook(ItemGetUIShowAction __instance)
    {
        if (!IsRandomizedItem(__instance.item))
        {
            // Not a randomized item, call the base function normally
            return true;
        }

        // Replace flag with flag for mapped item
        var swappedGameFlagDescriptable = GetMappedItem(__instance.item);
        swappedGameFlagDescriptable.PlayerPicked();
        Logger.LogInfo("Swapping to randomized item: " + swappedGameFlagDescriptable.Title);

        if (__instance.showDscriptablePanelTiming == ShowDscriptablePanelTiming.NextAction)
        {
            SingletonBehaviour<UIManager>.Instance.ShowGetDescriptablePrompt(swappedGameFlagDescriptable, __instance.showNotification);
        }
        else if (__instance.showDscriptablePanelTiming == ShowDscriptablePanelTiming.NextScene)
        {
            SingletonBehaviour<PromiseManager>.Instance.MakePromise().AddCondition(() => SingletonBehaviour<GameCore>.Instance.currentCoreState == GameCore.GameCoreState.ChangingScene).OnComlete(delegate
            {
                SingletonBehaviour<UIManager>.Instance.ShowGetDescriptablePrompt(swappedGameFlagDescriptable, showNotification: false);
            });
        }

        if (__instance.ImportantItemAndSaveProgress)
        {
            SingletonBehaviour<SaveManager>.Instance.AutoSave(SaveManager.SaveSceneScheme.CurrentSceneAndPos, forceShowIcon: true);
        }
        else
        {
            SingletonBehaviour<SaveManager>.Instance.AutoSave();
        }

        // Skip calling the base function
        return false;
    }

    // Swap received items for ground pickups
    [HarmonyPatch(typeof(PickItemAction), "OnStateEnterImplement")]
    [HarmonyPrefix]
    static bool PickItemAction_OnStateEnterImplement_Hook(PickItemAction __instance)
    {

        // Use Traverse to access private field
        ItemProvider itemProvider = Traverse.Create(__instance).Field("itemProvider").GetValue() as ItemProvider;

        GameFlagDescriptable gameFlagDescriptable = ((!(itemProvider != null) || !(itemProvider.item != null)) ? __instance.pickItemData : itemProvider.item);

        Logger.LogInfo("Picked item on the ground: " + gameFlagDescriptable.Title);
        Logger.LogInfo("action name: " + __instance.name);
        Logger.LogInfo("instance id: " + __instance.GetInstanceID());


        Logger.LogInfo("GameFlagDescriptable: " + gameFlagDescriptable.FinalSaveID);

        if (__instance.scheme == PickableScheme.GetItem)
        {
            if (!IsRandomizedItem(gameFlagDescriptable))
            {
                // Not a randomized item, call the base function normally
                return true;
            }

            // Replace flag with flag for mapped item
            gameFlagDescriptable = GetMappedItem(gameFlagDescriptable);
            Logger.LogInfo("Swapping to randomized item: " + gameFlagDescriptable.Title);

            // Trigger the item unlock
            UnlockItemWithPopup(gameFlagDescriptable);

            return false; // Skip normal method execution
        }

        return true;
    }


    // Change logic for when nodes should be berserk
    [HarmonyPatch(typeof(SavePoint), "shouldEnterBerserk", MethodType.Getter)]
    [HarmonyPostfix]
    static void SavePoint_get_shouldEnterBerserk_Hook(SavePoint __instance, ref bool __result)
    {
        if (__instance.BindingTeleportPoint.FinalSaveID == HelperFlags["teleport_taichikick"])
        {
            __result = !(flagDict[HelperFlags["berserkflag_taichikick"]] as ScriptableDataBool).CurrentValue;
        }
        else if (__instance.BindingTeleportPoint.FinalSaveID == HelperFlags["teleport_chargestrike"])
        {
            __result = !(flagDict[HelperFlags["berserkflag_chargestrike"]] as ScriptableDataBool).CurrentValue;
        }
        else if (__instance.BindingTeleportPoint.FinalSaveID == HelperFlags["teleport_airdash"])
        {
            __result = !(flagDict[HelperFlags["berserkflag_airdash"]] as ScriptableDataBool).CurrentValue;
        }
        else if (__instance.BindingTeleportPoint.FinalSaveID == HelperFlags["teleport_unboundedcounter"])
        {
            __result = !(flagDict[HelperFlags["berserkflag_unboundedcounter"]] as ScriptableDataBool).CurrentValue;
        }
    }


    // Skip tutorial for berserk nodes
    [HarmonyPatch(typeof(SavePoint), "SaveSpawnPosition")]
    [HarmonyPrefix]
    static bool SavePoint_SaveSpawnPosition_Hook(SavePoint __instance)
    {
        __instance.BindSavePointEvent();
        Player.i.playerInput.VoteForState(PlayerInputStateType.Cutscene, __instance);
        if (__instance.BindingTeleportPoint == null)
        {
            Debug.LogError("No Teleport Point?", __instance);
            return false;
        }

        Logger.LogInfo("Sitting at node: " + __instance.BindingTeleportPoint.FinalSaveID + " isBerserk:" +  __instance.shouldEnterBerserk);

        __instance.BindingTeleportPoint.unlocked.CurrentValue = true;
        SingletonBehaviour<GameCore>.Instance.SetReviveSavePoint(__instance.BindingTeleportPoint);
        if (!__instance.shouldEnterBerserk)
        {
            //Not a berserk node, trigger normal logic
            return true;
        }

        Logger.LogInfo("Entering Berserk Node: " + __instance.BindingTeleportPoint.FinalSaveID);

        if (__instance.BindingTeleportPoint.FinalSaveID == HelperFlags["teleport_taichikick"])
        {
            UnlockItemWithPopup(GetMappedItem(HelperFlags["ability_taichikick"]));
            (flagDict[HelperFlags["berserkflag_taichikick"]] as ScriptableDataBool).CurrentValue = true;
        }
        else if (__instance.BindingTeleportPoint.FinalSaveID == HelperFlags["teleport_chargestrike"])
        {
            UnlockItemWithPopup(GetMappedItem(HelperFlags["ability_chargestrike"]));
            (flagDict[HelperFlags["berserkflag_chargestrike"]] as ScriptableDataBool).CurrentValue = true;
        }
        else if (__instance.BindingTeleportPoint.FinalSaveID == HelperFlags["teleport_airdash"])
        {
            UnlockItemWithPopup(GetMappedItem(HelperFlags["ability_airdash"]));
            (flagDict[HelperFlags["berserkflag_airdash"]] as ScriptableDataBool).CurrentValue = true;
        }
        else if (__instance.BindingTeleportPoint.FinalSaveID == HelperFlags["teleport_unboundedcounter"])
        {
            UnlockItemWithPopup(GetMappedItem(HelperFlags["ability_unboundedcounter"]));
            (flagDict[HelperFlags["berserkflag_unboundedcounter"]] as ScriptableDataBool).CurrentValue = true;
        }

        //Trigger normal sitting animation instead of tutorial
        __instance.myAnimator.Play("SP_opening");
        Player.i.ChangeState(PlayerStateType.EnterSavePoint);
        Traverse.Create(__instance).Field("isActived").SetValue(true);

        return false;
    }

    //Swap items in the shop
    [HarmonyPatch(typeof(ShopUIPanel), "ShowInit")]
    [HarmonyPrefix]
    static void ShopUIPanel_ShowInit_Hook(ShopUIPanel __instance)
    {
        //HACK: Only want to shuffle the items around the first time we call this hook for a shop
        //      currentIndex is -1 the first time we access it but will be set to a valid index next time we enter
        int currentIndex = Traverse.Create(__instance.allCollection).Field("_currentIndex").GetValue<int>();
        if (currentIndex == -1)
        {
            if (__instance.GetType().ToString() == "ShopUIPanel" && __instance.allCollection is MerchandiseDataCollection merchandiseCollection)
            {
                //Restore default items and replace with random targets because we don't know if this is our first time opening the menu or not
                __instance.GetComponentsInChildren(__instance.buttonViews);

                foreach (var shopItem in merchandiseCollection.gameFlagDataList)
                {
                    if (((int)shopItem.merchandiseType == 0 || (int)shopItem.merchandiseType == 2))
                    {
                        if (!(shopItem.item is null) && IsRandomizedItem(shopItem.item))
                        {
                            Logger.LogInfo("Replacing shop item " + shopItem.item.FinalSaveID + " with " + GetMappedItem(shopItem.item).FinalSaveID);
                            shopItem.item = GetMappedItem(shopItem.item);
                        }
                    }
                }
            }
        }
    }

    // Replace merchandise titles in shops
    [HarmonyPatch(typeof(MerchandiseData), "Title", MethodType.Getter)]
    [HarmonyPostfix]
    static void MerchandiseData_Title_Hook(MerchandiseData __instance, ref string __result)
    {
        if (((int)__instance.merchandiseType == 0 || (int)__instance.merchandiseType == 2))
        {
            if (!(__instance.item is null) && IsRandomizedItem(__instance.item))
            {
                // Replace with description from item as we've already randomized it
                __result = __instance.item.Title;
            }
        }
    }

    // Replace merchandise descriptions in shops
    [HarmonyPatch(typeof(MerchandiseData), "Description", MethodType.Getter)]
    [HarmonyPostfix]
    static void MerchandiseData_Description_Hook(MerchandiseData __instance, ref string __result)
    {
        if (((int)__instance.merchandiseType == 0 || (int)__instance.merchandiseType == 2))
        {
            if (!(__instance.item is null) && IsRandomizedItem(__instance.item))
            {
                // Replace with description from item as we've already randomized it
                __result = __instance.item.Description;
            }
        }
    }

    //Patch to change the result of various conditions and alter behavior of state machines
    [HarmonyPatch(typeof(GameFlagPropertyCondition), "isValid", MethodType.Getter)]
    [HarmonyPostfix]
    static void AbstractStateTransition_TransitionConditionValid_Hook(GameFlagPropertyCondition __instance, ref bool __result)
    {
        //QoL: Activate primordial root node even if the power is off in the pavillion
        if (__instance.name == "[Condition]有電") // Condition checking you've turned on the power
        {
            __result = true;
        }

        // Softlock fix: Never close door leading to mystic nymph
        if (__instance.name == "[Condition] 進過ＡＩ房") // Condition checking you've entered Ruyi's room
        {
            __result = false;
        }
    }

    // QoL: Activate primordial root node even if the power is off in the pavillion
    [HarmonyPatch(typeof(VariableBool), "FlagValue", MethodType.Getter)]
    [HarmonyPostfix]
    static void VariableBool_FlagValue_Hook(VariableBool __instance, ref bool __result)
    {
        if (__instance.name == "[Variable] 議會有電嗎")
        {
            __result = true;
            Logger.LogInfo("Overriding variable bool");
        }
    }

    // Softlock fix: Allow teleporting out of prison
    [HarmonyPatch(typeof(PlayerInPrisionCondition), "isValid", MethodType.Getter)]
    [HarmonyPostfix]
    static void PlayerInPrisionCondition_ShowInit_Hook(PlayerInPrisionCondition __instance, ref bool __result)
    {
        __result = false;
    }
}
