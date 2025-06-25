using BepInEx.Logging;
using MelonLoader;
using UnityEngine;

namespace CapuchinTemplate
{
    public class Plugin : MonoBehaviour
    {
        public static Plugin instance;

        void Start()
        {
            instance = this;

            // Add your startup code here, initialize assets, check configurations, etc.
            WriteLine("Hello world");
        }

        public void WriteLine(string text, LogLevel severity = LogLevel.Debug)
        {
            if (ModInfo.Loader == ModLoader.BepInEx)
                BepInExInit.initInstance.Log.Log(severity, text);
            else if (ModInfo.Loader == ModLoader.MelonLoader)
                MelonLogger.Msg(text);
        }
    }
}
