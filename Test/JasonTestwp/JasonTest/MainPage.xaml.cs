using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=391641 上有介绍

namespace JasonTest
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private ApplicationDataContainer _appSettings;
        //private const string UserDataKey = "UserDataKey";
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            //_appSettings = ApplicationData.Current.LocalSettings;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HtttpPost();
        }
        private void HtttpPost()
        {
            try
            {
                var request = HttpWebRequest.Create("http://139.217.14.24/SmartShopping/API/SelectCommodity.php?code=6920698432409");
                request.Method = "POST";
                request.BeginGetRequestStream(ResponseStreamCallbackPost, request);
                //request.BeginGetResponse(ResponseCallbackPost, request);
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.SendFailure)
                {

                }
            }
        }
        private void ResponseStreamCallbackPost(IAsyncResult result)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)result.AsyncState;
                Stream stream = httpWebRequest.EndGetRequestStream(result);
                string postString = "qqqqqqqqq";
                byte[] data = Encoding.UTF8.GetBytes(postString);
                stream.Write(data, 0, data.Length);
                stream.Dispose();
                httpWebRequest.BeginGetResponse(ResponseCallbackPost, httpWebRequest);
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.SendFailure)
                {
                }
            }
        }
        private async void ResponseCallbackPost(IAsyncResult result)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)result.AsyncState;
                WebResponse webResponse = httpWebRequest.EndGetResponse(result);
                using (Stream stream = webResponse.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    
                    await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    { 
                       info.Text = content;
                    });
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.SendFailure)
                {

                }
            }
        }//Post
        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //_appSettings.Values[UserDataKey] = info.Text;
            // string json = _appSettings.Values[UserDataKey].ToString();
            string json = info.Text;
            User u = new User(json);
            await new MessageDialog(u.name +":"+ u.price + ":" + u.produced_date+":"+ u.expiration_date).ShowAsync();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        // private void Button_Click_3(object sender, RoutedEventArgs e)        
        //{
        //    User u = new User
        //    {
        //        id = "123",
        //        name = "json",
        //        price = "10"
        //    };
        //    string json = u.Stringify();
        //    //await new MessageDialog(json).ShowAsync();
        //    _appSettings.Values[UserDataKey] = json;
        //}
    }
}
