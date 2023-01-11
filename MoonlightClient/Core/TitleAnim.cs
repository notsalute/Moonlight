using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Moonlight_Client.Core
{
    internal class TitleAnim
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowText")]
        public static extern bool SetWindowText(System.IntPtr hwnd, System.String lpString);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern System.IntPtr FindWindow(System.String className, System.String windowName);

        static IntPtr VRChat = IntPtr.Zero;

        public static IEnumerator ChangeTitle()
        {
            VRChat = FindWindow(null, "VRChat");
            MelonLoader.MelonLogger.Msg("Process: " + VRChat);
            while (true)
            {
                SetWindowText(VRChat, "M");
                yield return new WaitForSecondsRealtime(1);
                SetWindowText(VRChat, "MO");
                yield return new WaitForSecondsRealtime(1);
                SetWindowText(VRChat, "MOO");
                yield return new WaitForSecondsRealtime(1);
                SetWindowText(VRChat, "MOON");
                yield return new WaitForSecondsRealtime(1);
                SetWindowText(VRChat, "MOONL");
                yield return new WaitForSecondsRealtime(1);
                SetWindowText(VRChat, "MOONLI");
                yield return new WaitForSecondsRealtime(1);
                SetWindowText(VRChat, "MOONLIG");
                yield return new WaitForSecondsRealtime(1);
                SetWindowText(VRChat, "MOONLIGH");
                yield return new WaitForSecondsRealtime(1);
                SetWindowText(VRChat, "MOONLIGHT");
                yield return new WaitForSecondsRealtime(1);
            }
        }
    }
}
