using BepInEx;
using HarmonyLib;

namespace GodNoLava
{
    [BepInPlugin("org.ssmvc.valheim.godnolava", "God No Lava", "1.0.0.0")]
    [BepInProcess("valheim.exe")]
    public class GodNoLava : BaseUnityPlugin
    {
        private static Harmony harmony;

        private void Awake()
        {
            Logger.LogInfo($"Plugin org.ssmvc.valheim.godnolava is loaded!");
            harmony = new Harmony("org.ssmvc.valheim.godnolava");
            harmony.PatchAll();
        }

        private void OnDestroy()
        {
            GodNoLava.harmony.UnpatchSelf();
        }

        [HarmonyPatch(typeof(Player), "SetGodMode")]
        private static class GodNoLavaMode
        {
            public static void Prefix(Player __instance, bool godMode)
            {
                __instance.m_tolerateFire = godMode;

            }
        }
    }
}
