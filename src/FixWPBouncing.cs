/*
    Cordova Fix-WP-Bouncing Plugin
    https://github.com/vilic/cordova-plugin-fix-wp-bouncing
    
    by VILIC VANE
    https://github.com/vilic

    MIT License
*/

using LinqToVisualTree;
using Microsoft.Phone.Controls;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPCordovaClassLib;
using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;

namespace Cordova.Extension.Commands {
    class FixWPBouncing : BaseCommand {
        WebBrowser browser;

        public FixWPBouncing() {
            var frame = Application.Current.RootVisual as PhoneApplicationFrame;
            var page = frame.Content as PhoneApplicationPage;
            var grid = page.FindName("LayoutRoot") as Grid;
            var cordovaView = grid.FindName("CordovaView") as CordovaView;
            var cordovaViewGrid = cordovaView.FindName("LayoutRoot") as Grid;

            browser = cordovaViewGrid.FindName("CordovaBrowser") as WebBrowser;

            var border = browser.Descendants<Border>().Last() as Border;
            border.ManipulationDelta += border_ManipulationDelta;
        }

        void border_ManipulationDelta(object sender, ManipulationDeltaEventArgs e) {
            if (e.DeltaManipulation.Translation.Y != 0) {
                var status = browser.InvokeScript("eval", "FixWPBouncing._targetStatus") as string;
                
                if (status == "top" || status == "both") {
                    if (e.DeltaManipulation.Translation.Y > 0) {
                        e.Handled = true;
                    }
                }
                
                if (status == "bottom" || status == "both") {
                    if (e.DeltaManipulation.Translation.Y < 0) {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
