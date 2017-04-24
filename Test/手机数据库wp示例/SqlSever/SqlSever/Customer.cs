using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSever
{
    [Table(Name="Customer")]
    //INotifyPropertyChanged，INotifyPropertyChanging属性改变通知接口
    public class Customer : INotifyPropertyChanged, INotifyPropertyChanging
    {   //Column列  //IsPrimaryKey主键
        [Column(IsPrimaryKey=true)]
        public string CustomerID { get; set; }
        //数据库里不会存ID属性
        public int ID { get; set; }
        public String _Name { get; set; }
        //[Column(IsPrimaryKey = true)]
        //public String Name
        //{
        //    get
        //    {
        //        return _Name;
        //    }
        //    set
        //    {
        //        if (_Name != value)
        //        {
        //            NotifyPropertyChanging("Name");
        //            _Name = value;
        //            NotifyPropertyChanged("Name");
        //        }
        //    }
        //}      

        ////属性变化处理的方法
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        ////Used to notify通知 that a property性质 changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion

        #region INotifyPropertyChanging Members
        public event PropertyChangingEventHandler PropertyChanging;
        ////Used tonotify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }
        #endregion
    }
}
