﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    internal class ProductList
    {
        List<Product> products = new List<Product>();
        // List<Category> categories = new List<Category>();

        internal void AddProduct(string category, string productName, decimal price)
        {
            Product prd = new Product();
            prd.Name = productName;
            prd.Price = price;
            prd.Category.Add(new Category(category));
            products.Add(prd);
        }

        //Return number of products in the list
        internal int GetProductCount()
        {
            return products.Count;
        }

        internal void Print(string searchText)
        {
            ConsoleColor color = Console.ForegroundColor;
            ConsoleColor defaultColor = Console.ForegroundColor;
            if (!string.IsNullOrEmpty(searchText))
            {
                CS.Print(ConsoleColor.Green, "Searching for: ");
                CS.PrintLn(searchText);
            }
            Console.WriteLine("------------------------------------------------------------");
            CS.PrintLn(ConsoleColor.Green, $"{"Category",-20}{"Product",-20}{"Price",-20}");

            //sort by price
            IEnumerable<Product> myProducts = products.OrderBy(x => x.Price);
            foreach (var item in myProducts)
            {
                string category = item.Category[0].Name;
                if (!string.IsNullOrEmpty(searchText) && (item.Name.Contains(searchText,StringComparison.OrdinalIgnoreCase) 
                    || item.Category[0].Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)))
                {
                    color = ConsoleColor.Magenta;
                } 
                else
                {
                    color = defaultColor;
                }

                CS.PrintLn(color,$"{category,-20}{item.Name,-20}{item.Price,-20}");
            }
            Console.WriteLine();
            decimal amount = products.Sum(x => x.Price);
            Console.WriteLine($"{" ",-20}{"Total amount:",-20}{amount,-20}");

        }
    }
}
