using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SqlSever
{
    public partial class But : PhoneApplicationPage
    {
        static int i=1;
        MyDataContext MyDataContext;
        public But()
        {
            InitializeComponent();
            MyDataContext = new MyDataContext("Data Source= isostore:/MyDataContext.sdf");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            i++;
            Customer customer = new Customer { _Name = 10000 + i + "", CustomerID = "CustomerID" + i, ID = i, };
            //插入数据            
            MyDataContext.CustomerTable.InsertOnSubmit(customer);

            //改变数据库
            MyDataContext.SubmitChanges();
            MessageBox.Show("插入成功");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}