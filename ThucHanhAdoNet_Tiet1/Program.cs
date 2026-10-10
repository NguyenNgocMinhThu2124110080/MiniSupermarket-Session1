using System;
using Microsoft.Data.SqlClient;
using System.Text;

namespace ThucHanhAdoNet_Tiet1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Bai1.Run();
            Console.WriteLine("\n--------------------------------------------------\n");
            
            Bai2.Run();
            Console.WriteLine("\n--------------------------------------------------\n");
            
            Bai3.Run();
            
            Console.WriteLine("\n-> Hoàn thành Tiết 1. Nhấn Enter để kết thúc...");
            Console.ReadLine();
        }
    }
}

