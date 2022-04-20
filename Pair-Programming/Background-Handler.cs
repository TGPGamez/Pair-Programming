using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pair_Programming
{
    public enum UAction
    {
        /// <summary>
        /// Set the desktop background image
        /// </summary>
        SPI_SETDESKWALLPAPER = 0x0014,
        /// <summary>
        /// Get the desktop background image
        /// </summary>
        SPI_GETDESKWALLPAPER = 0x0073,
    }

    /// <summary>
    /// Used to set background with DllImport
    /// </summary>
    public static class Background_Handler
    {
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(UAction uAction, int uParam, StringBuilder lpvParam, int fuWinIni);

        public static void SetBackground(string filePath)
        {
            const int SET_DESKTOP_BACKGROUND = 20;

            const int UPDATE_INI_FILE = 1;

            const int SEND_WINDOWS_INI_CHANGE = 2;

            win32.SystemParametersInfo(SET_DESKTOP_BACKGROUND, 0, filePath, UPDATE_INI_FILE | SEND_WINDOWS_INI_CHANGE);
        }
    }

    /// <summary>
    /// Additional required data to set background
    /// </summary>
    internal sealed class win32
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        internal static extern int SystemParametersInfo(

            int uAction,

            int uParam,

            String lpvParam,

            int fuWinIni);
    }
}
