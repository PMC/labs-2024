using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    internal class Product
    {
        private string name= "";
        private decimal price = 0;
        private List<Category> category = new List<Category>();

        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        internal List<Category> Category { get => category; set => category = value; }
    }
}
