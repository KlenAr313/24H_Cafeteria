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

        public ProductRepository()
        { }

        public Product GetById(int id)
        {
            var allProduct = GetAll().ToList();
            return allProduct.FirstOrDefault(i => i.Id == id);
        }

        public Product Create(Product product)
        {
            var allProducts = GetAll();
            int maxId = 0;
            if (allProducts.Count() > 0)
            {
                maxId = allProducts.Max(e => e.Id);
            }
            product.Id = maxId + 1;
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(product);
                sw.Close();
            }
            return product;
        }

        public Product Update(Product product)
        {
            var allProducts = GetAll().ToList();
            RemoveItemFromList(product, allProducts);
            allProducts.Add(product);
            WriteItemsToList(allProducts);
            return product;
        }

        public void Delete(Product product)
        {
            product.IsDeleted = true;
            Update(product);
        }


        private void RemoveItemFromList(Product product, List<Product> allProducts)
        {
            var foundProduct = allProducts.FirstOrDefault(e => e.Id == product.Id);
            if (foundProduct == null)
            {
                throw new KeyNotFoundException($"Id {product.Id} not found");
            }
            allProducts.Remove(foundProduct);
        }

        private void WriteItemsToList(List<Product> products)
        {
            using(StreamWriter sw = new StreamWriter(fileName, false))
            {
                products.ForEach(e => sw.WriteLine(e));
                sw.Close();
            }
        }
    }
}
