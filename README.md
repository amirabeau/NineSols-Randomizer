# NineSols-Randomizer
This is a simple randomizer project for Nine Sols developped as part of a hack day event. This mod randomly replaces items with each other but does not include any logic for item placement. This means that item arrangements generated by this mod will often result in unwinnable game states. 

# Installation
1. Get the plugin from the latest release
2. Copy suntzu.NineSolsRandomizer.dll into BepInEx/Plugins
3. Launch the game and a config file will be created in BepInEx/config. 
4. Randomizer settings can only be configured via this file. A game restart is required for any changes to take effect
5. Randomizer changes apply to all saves so it's recommended to only use this mod with fresh saves (or speedrun start saves)

# Build Setup
1. Copy Assembly-CSharp.dll, rcg.rcgmakercore.Runtime.dll and Sirenix.OdinInspector.Attributes.dll into the lib folder from your local Nine Sols installation.
   Example path: C:\Program Files (x86)\Steam\steamapps\common\Nine Sols\NineSols_Data\Managed
2. Open NineSolsRandomizer.sln with visual studio
3. Build