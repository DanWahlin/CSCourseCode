using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text;

namespace ADO.NET.MARS
{
    class MARSDemo
    {
        public static void Main()
        {
            //MARSAsync mars = new MARSAsync();
            //mars.GetDataAsync();

            MARSSync mars = new MARSSync();
            mars.GetData();
            Console.ReadLine();
        }

     }
}
