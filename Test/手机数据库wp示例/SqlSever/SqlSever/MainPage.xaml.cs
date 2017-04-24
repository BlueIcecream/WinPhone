using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SqlSever.Resources;

namespace SqlSever
{
    public partial class MainPage : PhoneApplicationPage
    {
        int i = 0;
        MyDataContext MyDataContext;
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            MyDataContext = new MyDataContext("Data Source= isostore:/MyDataContext.sdf");
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }
        //插入
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
             i++;
             Customer customer = new Customer{ _Name =  10000+i+"",CustomerID = "CustomerID" + i,ID = i,};
             //插入数据            
             MyDataContext.CustomerTable.InsertOnSubmit(customer);

             //改变数据库
             MyDataContext.SubmitChanges();
             MessageBox.Show("插入成功");
        }
        //查询
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //查询
            var list = (from order in MyDataContext.CustomerTable select order).ToList();
            //展示
            listbox.ItemsSource = list;
         }
        //删除
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //查询
            var list = (from order in MyDataContext.CustomerTable select order).ToList();
            if (list.Count > 0)
            {
                //删除第一个
                MyDataContext.CustomerTable.DeleteOnSubmit(list[0]);
                //改变数据库
                MyDataContext.SubmitChanges();
                MessageBox.Show("删除成功");
             }
         }
        ////修改
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/But.xaml", UriKind.Relative));
            //查询
            //var list = (from order in MyDataContext.CustomerTable select order).ToList();
            //if(list.Count>0){
            //    Customer order = list[0];
            //    order._Name = "444";
            //    MyDataContext.SubmitChanges();
            //  MessageBox.Show("修改成功");
            // }
        }        
    }
}