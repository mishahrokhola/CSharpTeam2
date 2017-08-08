﻿using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using ProductDatabase.BL.CustomExceptions;

namespace ProductDatabase
{
    class CategoryMenu
    {
        public static void Show()
        {
            Title = "\tМеню роботи з базою \"Категорії\"";
            Clear();
            WriteLine("\tРедагування бази \"Категорії\"");
            WriteLine("\n1. Додати нової категорії");
            WriteLine("2. Редагувати існуючої категорії");
            WriteLine("3. Видалити існуючої категорії");
            WriteLine("\n9. Повернутися до головного меню");
            WriteLine("\n0. Повернутися до попереднього меню");
            Write("\nВиберіть дію яку ви хочете виконати: ");
            Choose();
        }

        public static void Choose()
        {
            string choice = (ReadLine());
            Clear();
            switch (choice)
            {
                case "0":
                    DataBaseEditMenu.Show();
                    break;
                case "1":
                    AddCategory();
                    break;
                case "2":
                    EditCategory();
                    break;
                case "3":
                    DeleteCategory();
                    break;
                case "9":
                    MainMenu.Show();
                    break;
                default:
                    Show();
                    break;
            }
        }

        public static void AddCategory()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            bool check = false;
            WriteLine("Список існуючих категорій\n");
            var category = display.CategoryListToText();
            foreach (var cat in category)
            {
                Console.WriteLine(cat);
            }
            string newCategoryName = null;
            do
            {
                Write("\nВведіть назву категорії : ");
                try
                {
                    newCategoryName = (ReadLine());

                    Validation.CategoryName(newCategoryName);

                    CategoryEditor.Add(newCategoryName);
                    Clear();
                    WriteLine("Назва категорії : {0}", newCategoryName);
                    WriteLine("\nКатегорія введена успішно!");
                    WriteLine("Натисніть будь яку клавішу для повернення до попереднього меню.");
                    ReadLine();
                    Show();
                    check = true;
                }
                catch (CustomeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (!check);
        }

        private static void EditCategory()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих категорій\n");
            var category = display.CategoryListToText();
            foreach (var cat in category)
            {
                Console.WriteLine(cat);
            }
            Write("\nВведіть ID категорії : ");
            int CategoryID = Convert.ToInt32(Console.ReadLine());
            string CategoryName = display.CategoryToText(CategoryID);
            Clear();
            WriteLine("Категорія : {0}", CategoryName);
            WriteLine("\nВведіть нову назву категорії : ");
            CategoryName = (ReadLine());
            CategoryEditor.Edit(CategoryID, CategoryName);
            WriteLine("\nНазву категорії змінено : {0}", CategoryName);
            WriteLine("Натисніть будь яку клавішу для повернення до попереднього меню.");
            ReadLine();
            Show();
        }

        private static void DeleteCategory()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих категорій\n");
            var category = display.CategoryListToText();
            foreach (var cat in category)
            {
                Console.WriteLine(cat);
            }
            Write("\nВведіть ID категорії : ");
            int CategoryID = Convert.ToInt32(Console.ReadLine());
            CategoryEditor.Delete(CategoryID);
            string CategoryName = display.CategoryToText(CategoryID);
            Clear();
            WriteLine("Категорію {0} видалено успішно!", CategoryName);
            WriteLine("Натисніть будь яку клавішу для повернення до попереднього меню.");
            ReadLine();
            Show();
        }
    }
}
