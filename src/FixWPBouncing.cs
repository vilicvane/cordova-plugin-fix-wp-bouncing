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
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPCordovaClassLib;
using WPCordovaClassLib.Cordova.Commands;

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
            border.ManipulationCompleted += border_ManipulationCompleted;
        }

        void border_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e) {
            browser.InvokeScript("eval", "FixWPBouncing.onmanipulationcompleted()");
        }

        void border_ManipulationDelta(object sender, ManipulationDeltaEventArgs e) {
            if (e.DeltaManipulation.Translation.Y != 0) {
                var status = browser.InvokeScript("eval", "FixWPBouncing.onmanipulationdelta()") as string;
                
                if (e.DeltaManipulation.Translation.Y > 0) {
                    if (status == "top" || status == "both") {
                        e.Handled = true;
                    }
                } else {
                    if (status == "bottom" || status == "both") {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}