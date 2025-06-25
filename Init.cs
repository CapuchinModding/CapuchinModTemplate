using BepInEx;
using BepInEx.Unity.IL2CPP;

using CapuchinTemplate;
using CapuchinTemplate.Patches;

using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(MelonLoaderInit), ModInfo.Name, ModInfo.Version, ModInfo.Author)]
[assembly: MelonGame("Duttbust", "Capuchin")]

namespace CapuchinTemplate
{
    public class ModInfo
    {
        public const string UUID = "yourname.yourmod";
        public const string Name = "Mod";
        public const string Author = "Your Name";
        public const string Version = "1.0.0";

        public static ModLoader Loader = ModLoader.None;
    }

    public enum ModLoader { BepInEx, MelonLoader, None }

    [BepInPlugin(ModInfo.UUID, ModInfo.Name, ModInfo.Version)]
    public class BepInExInit : BasePlugin
    {
        public HarmonyLib.Harmony harmonyInstance;
        public Plugin pluginInstance;
        public static BepInExInit initInstance;

        public override void Load()
        {
            ModInfo.Loader = ModLoader.BepInEx;

            harmonyInstance = HarmonyPatcher.Patch("yourname.modname");
            initInstance = this;

            pluginInstance = new GameObject().AddComponent<Plugin>();
        }

        public override bool Unload()
        {
            if (harmonyInstance != null)
                HarmonyPatcher.Unpatch(harmonyInstance);

            return true;
        }
    }

    public class MelonLoaderInit : MelonMod
    {
        public Plugin pluginInstance;
        public static MelonLoaderInit initInstance;

        public override void OnInitializeMelon()
        {
            ModInfo.Loader = ModLoader.MelonLoader;
            initInstance = this;

            pluginInstance = new GameObject().AddComponent<Plugin>();
        }
    }
}
