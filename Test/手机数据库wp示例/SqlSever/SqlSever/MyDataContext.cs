using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSever
{
    //数据上下文定义
    [Database(Name="MyDataContext" )]
    //继承基类
    public class MyDataContext:DataContext

    {
        //connectionSting 链接数据库的字符串
        public MyDataContext(string connectionSting): base(connectionSting){}
        //表的定义
        public Table<Customer> CustomerTable;
    }
}
