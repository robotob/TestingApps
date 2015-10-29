using ConsoleApplication1.Bll;
using ConsoleApplication1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestBll bll = new TestBll(ConfigurationManager.ConnectionStrings["mysqlConnection"].ConnectionString);

            IEnumerable<Table1Model> aa = bll.Table1GetAll(1,10);
        }
    }
}
