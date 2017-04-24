using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;

namespace Fuction327
{
    internal class MainViewModel// : INotifyPropertyChanged
    {                     
        public static ObservableCollection<Data> ListDatas { get; set; }
        public MainViewModel(/*string Nam,string Pric*/)
        {
            ListDatas = new ObservableCollection<Data>();
            //ListDatas.Add(new Data { DataTestString = "aaaa" });
           //ListDatas.Add(new Data { Name = Nam, Price= Pric});
        }
        public static void  Set(string Nam, string Pric)
        {
            ListDatas.Add(new Data { Name = Nam, Price = Pric });
        }
        public class Data
        { 
            public string Name { get; set; }
            public string Price { get; set; }
        }
    }
}