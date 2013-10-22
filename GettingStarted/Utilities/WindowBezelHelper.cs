using System;
using System.Windows;
using System.Windows.Input;

namespace Przewodnik.Utilities
{
    public class WindowBezelHelper : DependencyObject
    {
        public static void UpdateBezel(Window window, bool showBezel)
        {
            if (window == null)
            {
                throw new ArgumentNullException("window");
            }

            if (showBezel)
            {
                window.WindowStyle = WindowStyle.SingleBorderWindow;
                window.Cursor = Cursors.Arrow;
            }
            else
            {
                window.WindowStyle = WindowStyle.None;

                // If the window is already full-screen, we must set it again else the window will appear under the Windows taskbar.
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                    window.WindowState = WindowState.Maximized;
                }

                window.Cursor = Cursors.None;
            }
        }
    }
}