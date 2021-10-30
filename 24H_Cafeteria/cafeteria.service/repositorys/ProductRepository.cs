using cafeteria.service.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cafeteria.service.repositorys
{
    public class ProductRepository
    {
        readonly string fileName;

        public ProductRepository(string fileName = "products.csv")
        {
            this.fileName = fileName;
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                products.Add(new Product(sr.ReadLine()));
            }
            sr.Close();
            return products;
        }

        public Product Create(Product product)
        {
            var allItems = GetAll();
            int maxId = 0;
            if (allItems.Count() > 0)
            {
                maxId = allItems.Max(e => e.Id);
            }
            product.Id = maxId + 1;
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(product);
                sw.Close();
            }
            return product;
        }
    }
}
