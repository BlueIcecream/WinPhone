using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ThreadTest.Resources;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ThreadTest
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            Continu();
            //Task task = new Task(() => 
            //{
            //    Doing();
            //});
            //task.Start();
        }
        //取消任务
        private void CancelTast()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            var token = cts.Token; 
            Task task1= Task.Factory.StartNew(()=>
                {
                    while (true){
                        Thread.Sleep(1000);
                        Debug.WriteLine("任务一");
                        if(token.IsCancellationRequested){
                            Debug.WriteLine("任务取消啦");
                            break;
                        }
                    }
                },token);
            Thread.Sleep(2000);
            cts.Cancel();
        }

        //等待，不会阻塞线程
        private async void DelayTest()
        { 
            Task delayTime = Task.Delay(1000);
            await delayTime;
        }
        //等待线程继续
        private void Continu()
        {
            Task task1 = new Task(() =>
            {
                Thread.Sleep(500);
                //获取当前线程ID
                Debug.WriteLine("1" + Thread.CurrentThread.ManagedThreadId);
            });
            //线程1完成开始线程2
            Task task2 = task1.ContinueWith((t) =>
            {
                Thread.Sleep(500);
                //获取当前线程ID
                Debug.WriteLine("2" + Thread.CurrentThread.ManagedThreadId);
            });
            Task task3 = task2.ContinueWith((t) =>
            {
                Thread.Sleep(500);
                //获取当前线程ID
                Debug.WriteLine("3" + Thread.CurrentThread.ManagedThreadId);
            });
            task1.Start();
        }
        //线程复用
        private void Doing()
        {
            Task task1 = new Task(() => 
            {               
                Thread.Sleep(500);
                //获取当前线程ID
                Debug.WriteLine("1"+Thread.CurrentThread.ManagedThreadId);
            });
            Task task2 = new Task(() =>
            {
                Thread.Sleep(500);
                Debug.WriteLine("2" + Thread.CurrentThread.ManagedThreadId);
            });
            Debug.WriteLine("0" + Thread.CurrentThread.ManagedThreadId);
            task1.Start();
            task2.Start();
            //等待所有任务的完成
            Task.WaitAll(new Task[] { task1, task2});
        }
 
    }
}