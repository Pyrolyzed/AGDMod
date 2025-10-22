using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Core;
using DisputeLib;
using Harmony;
using HarmonyLib;
using MelonLoader;
using Menus.Lobby;
using Menus.Settings;

namespace AGDMod
{
    public class SettingsPostfix : MelonMod
    {
        public override void OnInitializeMelon()
        {
            HarmonyLib.Harmony harmony = this.HarmonyInstance;
            harmony.PatchAll(MelonAssembly.Assembly);
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(GameConfigManager), "GetAdvancedSettings")]
    public static class SettingsPatch
    {
        static void Postfix(ref Task<Dictionary<SettingsKey, SettingsManager.Setting>> __result)
        {
            ((SettingsManager.SliderSetting)__result.Result[SettingsKey.PerkStrength]).Max = 10000;
        }
    }
}