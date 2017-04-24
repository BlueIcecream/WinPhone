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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace WorkingWithAnimation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void animateButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (animatedImage.Opacity == 0)
              //动画播放
              ShowStoryboard.Begin();
            else
              HideStoryboard.Begin();
             */
            //动态添加图片到Image里面   ms-appx应用程序当前根目录中寻找
            var image = new BitmapImage(new Uri("ms-appx:///Assets/sunny.png"));
            //将路径添加到Source属性
            animatedImage.Source = image;

        }
        //ImageOpened="animatedImage_ImageOpened"的后台代码
        private void animatedImage_ImageOpened(object sender, RoutedEventArgs e)
        {
          Image img = sender as Image;

          if (img == null)
            return;

          Storyboard s = new Storyboard();

          DoubleAnimation doubleAni = new DoubleAnimation();
          doubleAni.To = 1;
          doubleAni.Duration = new Duration(TimeSpan.FromMilliseconds(2000));

          Storyboard.SetTarget(doubleAni, img);
          Storyboard.SetTargetProperty(doubleAni, "Opacity");

          s.Children.Add(doubleAni);

          s.Begin();
        }
    }
}
