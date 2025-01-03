﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NineSolsRandomizer
{
    public enum ItemType
    {
        Ability,
        KeyItem,
        Jade,
        Artifact,
        Poison,
        Encyclopedia,
        MapChips,
        Recyclables,
    }

    public enum Requirement
    {
        MysticNymph,
        TaiChiKick,
        UnboundedCounter,
        Prison
    }

    public class RandomizerItemData
    {
        public ItemType type;
        public string displayName;
        public string finalSaveId;
        public List<Requirement> requirements = new List<Requirement>();
    };

    public class RandomizerFlags
    {
        public static List<RandomizerItemData> GetAllRandomizerItems()
        {
            return new List<RandomizerItemData>
            {
                //new RandomizerItemData { type = ItemType.Ability, displayName = "Jade System", requirements = {}, finalSaveId = "5b0bac0f643f94309b894c4286db798fPlayerAbilityData" }, // This would be kind of cursed
                new RandomizerItemData { type = ItemType.Ability, displayName = "Mystic Nymph: Scout Mode", requirements = {}, finalSaveId = "be31937c6691a44d88d3d70ac2f62cc9PlayerAbilityData" },
                new RandomizerItemData { type = ItemType.Ability, displayName = "Tai-Chi Kick", requirements = {}, finalSaveId = "15371e774c66f4ce9a58dc63b1464910SkillNodeData" },
                new RandomizerItemData { type = ItemType.Ability, displayName = "Charged Strike", requirements = {Requirement.TaiChiKick}, finalSaveId = "e4c62cea0f9fb4759b69624d571a3c8dSkillNodeData" },
                new RandomizerItemData { type = ItemType.Ability, displayName = "Air Dash", requirements = {}, finalSaveId = "b6279cb10939e9d4ebda64aea801f75cSkillNodeData" },
                new RandomizerItemData { type = ItemType.Ability, displayName = "Unbounded Counter", requirements = {Requirement.Prison}, finalSaveId = "82ea1161b33ea423caa77f67fe049046SkillNodeData" },
                new RandomizerItemData { type = ItemType.Ability, displayName = "Cloud Leap", requirements = {}, finalSaveId = "827cb8277cd144d83861460103607ed7SkillNodeData" },

                new RandomizerItemData { type = ItemType.Ability, displayName = "Arrow: Cloud Piercer", requirements = {}, finalSaveId = "7837bd6bb550641d8a9f30492603c5eePlayerWeaponData" },
                new RandomizerItemData { type = ItemType.Ability, displayName = "Arrow: Thunder Buster", requirements = {}, finalSaveId = "ef8f7eb3bcd7b444f80d5da539f3b133PlayerWeaponData" },
                new RandomizerItemData { type = ItemType.Ability, displayName = "Arrow: Shadow Hunter", requirements = {}, finalSaveId = "3949bc0edba197d459f5d2d7f15c72e0PlayerWeaponData" },
                new RandomizerItemData { type = ItemType.Ability, displayName = "Transmute Unto Wealth", requirements = {}, finalSaveId = "5036f58e39fd647a19adba5bf37069a4SkillNodeData" },
                new RandomizerItemData { type = ItemType.Ability, displayName = "Transmute Unto Life", requirements = {}, finalSaveId = "d311393b203f34bf19e020312946d376SkillNodeData" },
                new RandomizerItemData { type = ItemType.Ability, displayName = "Transmute Unto Qi", requirements = {Requirement.Prison}, finalSaveId = "6c03c15409a6244ec92b22d1ed1830c7SkillNodeData" },

                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Seal of Kuafu", requirements = {}, finalSaveId = "3e29d950db438456f856b339b02af177ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Seal of Goumang", requirements = {}, finalSaveId = "687e430938a164d249d0b3befeb786a3ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Seal of Yanlao", requirements = {}, finalSaveId = "9391d80ddafa5d74eb3aca1449ed63ecItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Seal of Jiequan", requirements = {Requirement.UnboundedCounter}, finalSaveId = "3596ea85d82e7d9419ee710c50c19655ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Seal of Lady Ethereal", requirements = {Requirement.TaiChiKick}, finalSaveId = "7d7086dda1d540f4ab32c919d59ea036ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Seal of Ji", requirements = {Requirement.TaiChiKick}, finalSaveId = "0218216d41d6441d69da23ea385d9452ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Seal of Fuxi", requirements = {Requirement.TaiChiKick}, finalSaveId = "3f04475e7c59f458a850f1725cf8f197ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Seal of Nuwa", requirements = {Requirement.TaiChiKick}, finalSaveId = "cea7218ddb8b449008101c3ccdc8b50bItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Bloody Crimson Hibiscus", requirements = {}, finalSaveId = "ebc522544cda748f4b2e121041f34752ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Ancient Penglai Ballad", requirements = {Requirement.MysticNymph}, finalSaveId = "012ed640ec72c5e409d85c7e8a6b4436ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Poem Hidden in the Immortal’s Portrait", requirements = {Requirement.TaiChiKick}, finalSaveId = "baaef97de0f4c294080224ebb9b1108eItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Thunderburst Bomb", requirements = {}, finalSaveId = "8722c67effb3dc844b48c5082ef55b70ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Gene Eradicator", requirements = {Requirement.UnboundedCounter}, finalSaveId = "c4a79371b6ba3ce47bbdda684236f7b5ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Homing Darts", requirements = {Requirement.UnboundedCounter}, finalSaveId = "3f24b97a10eaa914fbca5cf866b6dcb8ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Soul-Severing Blade", requirements = {}, finalSaveId = "b6b928329a5ae114ca7ab0935bb6427cItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Firestorm Ring", requirements = {}, finalSaveId = "a3dd1abd74d68304687da6ad5ff3fe56ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Yellow Dragonsnake Venom Sac", requirements = {Requirement.Prison}, finalSaveId = "54fa2de19e7780448b773554d0229750ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Yellow Dragonsnake Medicinal Brew", requirements = {Requirement.TaiChiKick}, finalSaveId = "80dca009f7f94024b9567c9acc857fd6ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Ji’s Hair", requirements = {Requirement.TaiChiKick}, finalSaveId = "ac3f2ead21bde4ef886068840a25a9e6ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Tianhuo Serum", requirements = {Requirement.TaiChiKick}, finalSaveId = "16d0ec9928dc24b4cac4830f25e986dcItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Elevator Access Token", requirements = {Requirement.TaiChiKick}, finalSaveId = "4930f5079e3fe4571aeeb640c3563c78ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Rhizomatic Bomb", requirements = {Requirement.TaiChiKick, Requirement.UnboundedCounter}, finalSaveId = "8b04356645160f24ab172496244c34c2ItemData" },
                new RandomizerItemData { type = ItemType.KeyItem, displayName = "Abandoned Mines Access Token", requirements = {Requirement.Prison}, finalSaveId = "e50d7e80053813c4cae82eae265b9326ItemData" },

                new RandomizerItemData { type = ItemType.Jade, displayName = "Immovable Jade", requirements = {Requirement.TaiChiKick}, finalSaveId = "b8fd8e42229824b788bc222b837382f2JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Harness Force Jade", requirements = {Requirement.Prison}, finalSaveId = "a0a2cb6d037ee4d80a74fd447a21682eJadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Focus Jade", requirements = {Requirement.UnboundedCounter}, finalSaveId = "36eb7e7b95e91467191b8f24dbbb5a3eJadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Swift Descent Jade", requirements = {}, finalSaveId = "1e635338961c24feb93798c36c07f128JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Medical Jade", requirements = {Requirement.MysticNymph}, finalSaveId = "8417398823dca444b924aa9e49e82385JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Quick Dose Jade", requirements = {}, finalSaveId = "316728bf6fa814c8085a4ce094c6cabbJadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Steely Jade", requirements = {}, finalSaveId = "28837290da6d24917ad6c99213d99d3dJadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Stasis Jade", requirements = {}, finalSaveId = "1e983ace0eb874a3a883c5f1f50e2926JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Mob Quell Jade - Yin", requirements = {Requirement.MysticNymph, Requirement.Prison}, finalSaveId = "45a17198c6bff4c42989f3e2d9cb583bJadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Mob Quell Jade - Yang", requirements = {Requirement.MysticNymph}, finalSaveId = "8ff52186b5d2849f6930bd5bf5d86b8aJadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Bearing Jade", requirements = {}, finalSaveId = "fce2186e0ae684bde9548905d5ed5533JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Divine Hand Jade", requirements = {Requirement.TaiChiKick}, finalSaveId = "ef792d1867d1a4a9c8ec6cd721ee5cb3JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Iron Skin Jade", requirements = {Requirement.Prison}, finalSaveId = "ff5f58b8404514c11b7ec4166b294349JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Pauper Jade", requirements = {}, finalSaveId = "562375e7a68ec42b28f3bdd5f45d7b72JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Swift Blade Jade", requirements = {}, finalSaveId = "b4c7da472cfba425ba5d0b0309dc4f17JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Last Stand Jade", requirements = {}, finalSaveId = "3411e0d523aec41f9be4e24ff81b6293JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Recovery Jade", requirements = {}, finalSaveId = "e6f162e19282346db96145ee80b5ccc1JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Breather Jade", requirements = {}, finalSaveId = "3ddbef7a7a579497b82fe3712177c089JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Hedgehog Jade", requirements = {}, finalSaveId = "3c8fd0425b80a405a8fb9623094fcafcJadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Ricochet Jade", requirements = {Requirement.MysticNymph}, finalSaveId = "dbda764ac569f4d6b871fb6c82f11adeJadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Revival Jade", requirements = {}, finalSaveId = "987349e8a21844d28a86853bb0e5de09JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Soul Reaper Jade", requirements = {Requirement.TaiChiKick, Requirement.MysticNymph}, finalSaveId = "468a3373787c2443794e57f101b5f794JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Health Thief Jade", requirements = {}, finalSaveId = "1796f5882076b4c7c859bc4b0747d8bbJadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Qi Blade Jade", requirements = {Requirement.TaiChiKick}, finalSaveId = "dfa6bbf26dfef4032a5287a7d9b27881JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Qi Swipe Jade", requirements = {}, finalSaveId = "111a1eb49b6d0476488eba696f991e19JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Reciprocation Jade", requirements = {Requirement.Prison}, finalSaveId = "589b90f2463944b95aeb6821385b3be6JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Cultivation Jade", requirements = {Requirement.TaiChiKick}, finalSaveId = "cfcd9f0d330344e628e7d8742955c172JadeData" },
                new RandomizerItemData { type = ItemType.Jade, displayName = "Avarice Jade", requirements = {Requirement.TaiChiKick}, finalSaveId = "88263fdff21bc8b4da3977c47ab02f03JadeData" },

                new RandomizerItemData { type = ItemType.Artifact, displayName = "Fusang Amulet", requirements = {}, finalSaveId = "c06500f5667730141aee0f2f2e470ad0ItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Multi-tool Kit", requirements = {}, finalSaveId = "e143133559a42004ba225b6273ccf6d9ItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Tiandao Academy Periodical", requirements = {Requirement.TaiChiKick}, finalSaveId = "8f81aaa43927b41448a502145949a2b0ItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Kunlun Immortal Portrait", requirements = {}, finalSaveId = "833cf6d005f2a4b7cab231aecb5f23aeItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Qiankun Board", requirements = {Requirement.TaiChiKick}, finalSaveId = "35dd82067571f4a4099df6a4fdbf7322ItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Ancient Sheet Music", requirements = {Requirement.TaiChiKick}, finalSaveId = "f688c32090bd9a447b2caa202e5d2537ItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Unknown Seed", requirements = {Requirement.TaiChiKick}, finalSaveId = "8d0f6ac6661d7ca4ab6c9a38b59e8044ItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Virtual Reality Device", requirements = {}, finalSaveId = "0a5ecab971d381a4dad39e8bf488874dItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Antique Vinyl Record", requirements = {}, finalSaveId = "b9574a152b739c147a0ecc84a26bbb51ItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Ready-to-Eat Rations", requirements = {Requirement.TaiChiKick}, finalSaveId = "cd77f022f99dce04ebc1af78be7b9b50ItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Sword of Jie", requirements = {Requirement.UnboundedCounter}, finalSaveId = "e481e2d53769c64469b962d736eea9c3ItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Red Guifang Clay", requirements = {Requirement.TaiChiKick}, finalSaveId = "f64e42e463e6c47da8eefe978273b154ItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "The Four Treasures of the Study", requirements = {Requirement.TaiChiKick}, finalSaveId = "281fc49002e760e47af668e87f3cbf82ItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Penglai Recipe Collection", requirements = {Requirement.TaiChiKick}, finalSaveId = "f9035fc8724f2224f9b4e1949459eda4ItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Damaged Fusang Amulet", requirements = {Requirement.TaiChiKick, Requirement.UnboundedCounter, Requirement.MysticNymph, Requirement.Prison}, finalSaveId = "b76de9e39b92a3642aaea5ef8280265fItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "The Legend of the Porky Heroes", requirements = {Requirement.MysticNymph}, finalSaveId = "0c76757489a7fa542b4351efc4731a49ItemData" },
                new RandomizerItemData { type = ItemType.Artifact, displayName = "Portrait of Yi", requirements = {Requirement.MysticNymph}, finalSaveId = "c50645a6658fe4b429ea575c35c28ba3ItemData" },

                new RandomizerItemData { type = ItemType.Poison, displayName = "Medicinal Citrine", requirements = {}, finalSaveId = "c753eb7cbd4ae7048a0dcc715b23e6f0ItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Golden Yinglong Egg", requirements = {Requirement.TaiChiKick}, finalSaveId = "c40e455c58fa8e444aa5c8657de9143eItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Molted Tianma Hide", requirements = {}, finalSaveId = "96d11b4a9a625ab488ca42e489787eeaItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Residual Hair", requirements = {Requirement.UnboundedCounter}, finalSaveId = "e0c92cd8e9370e74c97d5ae797cabce6ItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Oriander", requirements = {Requirement.TaiChiKick}, finalSaveId = "66a914e6e380d464e94f6c56734179c4ItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Turtle Scorpion", requirements = {Requirement.TaiChiKick}, finalSaveId = "2d7ce5740746b504d8ad8caebc1e4686ItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Plantago Frog", requirements = {Requirement.TaiChiKick}, finalSaveId = "ed5ec481e3a08344fa779713d791e8b7ItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Porcine Gem", requirements = {Requirement.Prison}, finalSaveId = "2a761d75584603d418c3a63762ce215cItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Ball of Flavor", requirements = {}, finalSaveId = "4db95fe8859303b498f08e2290f5b6b9ItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Dragon's Whip", requirements = {}, finalSaveId = "cef71c68e23677d4aae949c4999dae2bItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Necroceps", requirements = {}, finalSaveId = "3623910f44ed1d04fab5face0b376359ItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Guiseng", requirements = {}, finalSaveId = "3cb140e76363b774292297d90bc76d0eItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Thunder Centipede", requirements = {Requirement.Prison}, finalSaveId = "4bb79b0a891845542848960ddfd0a03cItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Wall-climbing Gecko", requirements = {Requirement.Prison}, finalSaveId = "00b0232c825990a45a3aad8212dff74eItemData" },
                new RandomizerItemData { type = ItemType.Poison, displayName = "Gutwrench Fruit", requirements = {Requirement.Prison}, finalSaveId = "2203778119e9b0540a493e3d4981d5e2ItemData" },

                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Dead Person's Note", requirements = {}, finalSaveId = "cca1601f63325463ca56b28fba2ac3bbEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Camp Scroll", requirements = {}, finalSaveId = "aef5b069abec5437e92be1d08e63855eEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Apemen Surveillance Footage", requirements = {}, finalSaveId = "6f09dd55228d01f4797a1d3d8a5e0e61EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Council Digital Signage", requirements = {}, finalSaveId = "b5ca02d4c727444f0ab3da1b7fdfe198EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "New Kunlun Launch Memorial", requirements = {}, finalSaveId = "e2a7fbf9aeafc48328541c6abc72a464EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Anomalous Root Node", requirements = {}, finalSaveId = "c8087170a9ebe2440b88559f0a676921EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Rhizomatic Energy Meter", requirements = {}, finalSaveId = "d6a96d9595386364abf56c85bfa2a32eEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Dusk Guardian Recording Device 1", requirements = {}, finalSaveId = "e0c18d6fbe20fde449d1ae43ade87870EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Radiant Pagoda Control Panel", requirements = {}, finalSaveId = "074b013e9264d486da7de635c2d3864dEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Lake Yaochi Stele", requirements = {Requirement.TaiChiKick}, finalSaveId = "093afc7ff350d47dba3217da80b09eedEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Ancient Cave Painting", requirements = {Requirement.TaiChiKick}, finalSaveId = "8bd01994a26d46343a21e8a6f7080634EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Coffin Inscription", requirements = {Requirement.TaiChiKick}, finalSaveId = "1b2ed9110ab548e42931345bfd984fedEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Yellow Water Report", requirements = {Requirement.TaiChiKick}, finalSaveId = "e3fd6e22b80be47ee97d69adbebe8baeEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Mutated Crops", requirements = {Requirement.TaiChiKick}, finalSaveId = "88121ba0c1030408a974cf1d99140fd9EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Water Synthesis Pipeline Panel", requirements = {Requirement.TaiChiKick}, finalSaveId = "17858803e17337c4ba1cf7cd1c84836dEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Dusk Guardian Recording Device 2", requirements = {Requirement.TaiChiKick}, finalSaveId = "1e6bf4d86baa5f44b8a44a04ec64815aEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Farmland Markings", requirements = {Requirement.TaiChiKick}, finalSaveId = "196708902c61b4f0abc1e343c650c2e5EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Council Tenets", requirements = {}, finalSaveId = "fe09efd3264ed492d9d97c69bcb68631EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Transmutation Furnace Monitor", requirements = {}, finalSaveId = "101f4db545b3dc149bd83c575225fbc7EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Evacuation Notice for Miners", requirements = {}, finalSaveId = "1eb714c43cdb548b3b18fab21847f561EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Warehouse Database", requirements = {}, finalSaveId = "b7df8be887589d844b9e648acadbe1e2EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Dusk Guardian Recording Device 3", requirements = {}, finalSaveId = "409c0d8a55857f84b8d18218559f4869EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Ancient Weapon Console", requirements = {}, finalSaveId = "fb3c0ab8f201840ef9126e088046f3fdEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Hexachrem Vault Scroll", requirements = {}, finalSaveId = "a18f20b13ed394fb7bd7d50f0470a5f6EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Prisoner's Bamboo Scroll (I)", requirements = {Requirement.Prison}, finalSaveId = "64ae4af6ad3ef8d48b38d38581fbeab5EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Prisoner's Bamboo Scroll (II)", requirements = {Requirement.Prison}, finalSaveId = "cff374c3e4499d74483e75665fb87d96EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Jie Clan Family Precept", requirements = {Requirement.UnboundedCounter}, finalSaveId = "044cbc32e4bad49bcadec39def818dd5EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Guard Production Station", requirements = {Requirement.UnboundedCounter}, finalSaveId = "e12e50bede6add0498844441ca76d3aeEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Dusk Guardian Recording Device 4", requirements = {}, finalSaveId = "cdd0012ad4db39141a0af084460f4e2cEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Pharmacy Panel", requirements = {Requirement.UnboundedCounter}, finalSaveId = "608c6830970fe4385aeac10ad290428cEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Haotian Sphere Model", requirements = {Requirement.UnboundedCounter}, finalSaveId = "7478f506316dd4eeb9dc2ef7d4dbb122EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Cave Stone Inscription", requirements = {}, finalSaveId = "cead86cbe2ec8a744b6c83d8d8e0a5e8EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Galactic Dock Sign", requirements = {}, finalSaveId = "80b4d0ed2190ed84da86efd425256c6cEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Stone Carvings", requirements = {Requirement.TaiChiKick}, finalSaveId = "ce171afc4c3b69e439444abad643eae4EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Secret Mural I", requirements = {Requirement.TaiChiKick}, finalSaveId = "b2d9abd742ccba747846527fb995ecddEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Secret Mural II", requirements = {Requirement.TaiChiKick}, finalSaveId = "1a37c30f26f84074b90ec92bdf1197b2EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Secret Mural III", requirements = {Requirement.TaiChiKick}, finalSaveId = "cff31b90ae300f549bf00535703ced17EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Stowaway's Corpse", requirements = {Requirement.TaiChiKick}, finalSaveId = "aaddc36fd468ac946919ea84f4623d75EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Underground Water Tower", requirements = {Requirement.TaiChiKick}, finalSaveId = "9f75430aa354b7946a7f65fc849684b4EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Empyrean Bulletin Board", requirements = {Requirement.TaiChiKick}, finalSaveId = "dd131993d18510b478a6f466ba366ffbEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Dusk Guardian Recording Device 5", requirements = {Requirement.TaiChiKick}, finalSaveId = "c28736cb52917b549a11d6f63f6523e0EncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Vital Sanctum Tower Monitoring Panel", requirements = {Requirement.TaiChiKick}, finalSaveId = "9b4658617a3e45a46baa1eb8d25fde8eEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Dusk Guardian Recording Device 6", requirements = {Requirement.TaiChiKick}, finalSaveId = "0a4b2b7fdfba0af4f82355e086d312caEncyclopediaItem" },
                new RandomizerItemData { type = ItemType.Encyclopedia, displayName = "Dusk Guardian Headquarters Screen", requirements = {Requirement.TaiChiKick}, finalSaveId = "4e7c90d21f20f814aaacdbfb1d0cc857EncyclopediaItem" },

                new RandomizerItemData{ type = ItemType.MapChips, displayName = "Abandoned Mines Chip", requirements = {Requirement.MysticNymph}, finalSaveId = "44eb40430cc294dcba56f740fc539336ItemData" },
                new RandomizerItemData{ type = ItemType.MapChips, displayName = "Power Reservoir Chip", requirements = {Requirement.MysticNymph}, finalSaveId = "ea9a496b025d3495c9dc2ef974fdc092ItemData" },
                new RandomizerItemData{ type = ItemType.MapChips, displayName = "Agricultural Zone Chip", requirements = {Requirement.MysticNymph, Requirement.TaiChiKick}, finalSaveId = "dbde23882967941729f72898668d888eItemData" },
                new RandomizerItemData{ type = ItemType.MapChips, displayName = "Warehouse Zone Chip", requirements = {Requirement.MysticNymph}, finalSaveId = "1f04b20cba6dd44edb862ed7cac7c8c3ItemData" },
                new RandomizerItemData{ type = ItemType.MapChips, displayName = "Transmutation Zone Chip", requirements = {Requirement.MysticNymph, Requirement.UnboundedCounter}, finalSaveId = "62c8e43f21bdb4629816759f012f2dc4ItemData" },
                new RandomizerItemData{ type = ItemType.MapChips, displayName = "Central Core Chip", requirements = {}, finalSaveId = "cc2161127ffac40f3900b2338732539cItemData" },
                new RandomizerItemData{ type = ItemType.MapChips, displayName = "Empyrean District Chip", requirements = {Requirement.MysticNymph, Requirement.TaiChiKick}, finalSaveId = "81fd8581688cd4b16947568280181a3eItemData" },
                new RandomizerItemData{ type = ItemType.MapChips, displayName = "Grotto of Scriptures Chip", requirements = {Requirement.MysticNymph, Requirement.TaiChiKick}, finalSaveId = "15afe59971f8d4ba2ba254aa63fbcccdItemData" },
                new RandomizerItemData{ type = ItemType.MapChips, displayName = "Research Institute Chip", requirements = {Requirement.TaiChiKick}, finalSaveId = "8cadca0dd118b433996ceff3b40c65f1ItemData" },

                new RandomizerItemData{ type = ItemType.Recyclables, displayName = "Noble Ring", requirements = {Requirement.Prison}, finalSaveId = "6be26d51d342d73418ba832be13bc58eItemData" },
                new RandomizerItemData{ type = ItemType.Recyclables, displayName = "Shuanshuan Coin", requirements = {Requirement.MysticNymph}, finalSaveId = "26ee16f6dab31d544aa70ab3ccd74c27ItemData" },
                new RandomizerItemData{ type = ItemType.Recyclables, displayName = "Jin Medallion", requirements = {Requirement.MysticNymph}, finalSaveId = "984057d55ad9a114b8f70d789f51a94aItemData" },
                new RandomizerItemData{ type = ItemType.Recyclables, displayName = "Passenger Token: A-Shou", requirements = {Requirement.TaiChiKick}, finalSaveId = "7f39eb3683ab07642b07a29c92f2b2eeItemData" },
                new RandomizerItemData{ type = ItemType.Recyclables, displayName = "Passenger Token: Zouyan", requirements = {Requirement.TaiChiKick}, finalSaveId = "795a70bd2b1f7314ab17f5a5cf5266acItemData" },
                new RandomizerItemData{ type = ItemType.Recyclables, displayName = "Passenger Token: Xipu", requirements = {Requirement.TaiChiKick}, finalSaveId = "9e4262f433d0f71488554605fd049696ItemData" },
                new RandomizerItemData{ type = ItemType.Recyclables, displayName = "Passenger Token: Jihai", requirements = {Requirement.TaiChiKick}, finalSaveId = "fe61f446873eb224bbf1f579e422bd7aItemData" },
                new RandomizerItemData{ type = ItemType.Recyclables, displayName = "Passenger Token: Yangfan", requirements = {Requirement.TaiChiKick}, finalSaveId = "8f37452c73abd62439d7b19bb04704ceItemData" },
                new RandomizerItemData{ type = ItemType.Recyclables, displayName = "Passenger Token: Aimu", requirements = {Requirement.TaiChiKick}, finalSaveId = "1b325062bb8a12f4d9f011b2ae560718ItemData" },
                new RandomizerItemData{ type = ItemType.Recyclables, displayName = "Passenger Token: Shiyangyue", requirements = {Requirement.TaiChiKick}, finalSaveId = "e235b00504a9145ed81edf6c2a2e0091ItemData" },
            };
        }


        public static Dictionary<string, string> GetHelperFlags()
        {
            return new Dictionary<string, string>
            {
                {"teleport_taichikick", "e5246ef15ff2a41ae884071b014351f4TeleportPointData"},
                {"ability_taichikick", "15371e774c66f4ce9a58dc63b1464910SkillNodeData"},
                {"berserkflag_taichikick", "d7a7775c-dd94-40af-9a65-bcbc73bcef43_9e73acaa5eb0f4a65bd599ed193c852cScriptableDataBool"},

                {"teleport_chargestrike", "126a7caa6701e4f0a9059b603a309c3fTeleportPointData"},
                {"ability_chargestrike", "e4c62cea0f9fb4759b69624d571a3c8dSkillNodeData"},
                {"berserkflag_chargestrike", "a791e2f5-4cfb-4be0-a8aa-cb4344ce5784_ee992f5c8f50b4b0caa5ef6c27d19d4dScriptableDataBool"},

                {"teleport_airdash", "f1e11be280022400caf9c8593ead7d43TeleportPointData"},
                {"ability_airdash", "b6279cb10939e9d4ebda64aea801f75cSkillNodeData"},
                {"berserkflag_airdash", "fcdd31e0-0772-4907-91e9-e27eac5446fe_6c434469f3b6049638220e464708ceafScriptableDataBool"},

                {"teleport_unboundedcounter", "4970d157835c54adbb55bb4f8e245fdfTeleportPointData"},
                {"ability_unboundedcounter", "82ea1161b33ea423caa77f67fe049046SkillNodeData"},
                {"berserkflag_unboundedcounter", "8e8f9d2c-8420-4056-8bef-256d981ca747_d9471a64dd55c486bbe604ae326ac961ScriptableDataBool"},

                {"ability_mysticnymph", "be31937c6691a44d88d3d70ac2f62cc9PlayerAbilityData"},
                {"ability_fusanghorn", "f6ddb914baaea4c11a4b995145dbbaadItemData"},
                {"ability_teleport", "950f8f3273611424d9b42ab209e8cac8PlayerAbilityData"},
                {"ability_cloudleap", "827cb8277cd144d83861460103607ed7SkillNodeData"},

                {"seal_kuafu", "3e29d950db438456f856b339b02af177ItemData"},
                {"seal_goumang", "687e430938a164d249d0b3befeb786a3ItemData"},
                {"seal_yanlao", "9391d80ddafa5d74eb3aca1449ed63ecItemData"},
            };
        }
    }
}
