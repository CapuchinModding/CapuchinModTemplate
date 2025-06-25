using BepInEx;
using HarmonyLib;
using System.Reflection;
using BepInEx.Unity.IL2CPP;

namespace CapuchinTemplate.Patches
{
    public class HarmonyPatcher
    {
        public static HarmonyLib.Harmony Patch(string UUID)
        {
            HarmonyLib.Harmony thisHarmony = new HarmonyLib.Harmony(UUID);
            thisHarmony.PatchAll(Assembly.GetCallingAssembly());

            return thisHarmony;
        }

        public static HarmonyLib.Harmony PatchAssembly(string UUID, Assembly assemblyToPatch)
        {
            HarmonyLib.Harmony thisHarmony = new HarmonyLib.Harmony(UUID);
            thisHarmony.PatchAll(assemblyToPatch);

            return thisHarmony;
        }

        public static void Unpatch(HarmonyLib.Harmony instance) =>
            instance.UnpatchSelf();
    }
}
