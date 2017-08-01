﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using ProductDatabase.BL.Main_Classes;
using ProductDatabase.BL.Repos;


namespace ProductDatabase
{
    class Program
    {
       
        static void Main(string [] args)
        {
            //Вхідна точка програми
            Console.OutputEncoding = Encoding.UTF8;
            //MainMenu.Show();
            try
            {
                ProductRepository productRepo = new ProductRepository();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               
            }
            


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
