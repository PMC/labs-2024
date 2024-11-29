using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    internal class Category
    {
        private string name = "";

        public string Name { get => name; set => name = value; }

        public Category(string categoryName) 
        { 
            Name = categoryName;
        }
    }
}
