using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=391641 上有介绍

namespace Fuction327
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static int i = 0;   
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            
            this.DataContext = new MainViewModel();         
        }

        private void CommodityNavigation_Click(object sender, RoutedEventArgs e)
        {
            Shop s = new Shop("asd", "asdasda");
            i = i + 2;
        }

        private void CommodityNavigation_Click1(object sender, RoutedEventArgs e)
        {
           
            for( int b = 0;b<i;b++)
            {
                MainViewModel.Set(Shop.Get(b), Shop.Get(b+1));
                b ++;
            }           
        }
    }  
}
