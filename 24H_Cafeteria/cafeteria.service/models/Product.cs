using cafeteria.data;

namespace cafeteria.service.models
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Product()
        { }

        public Product(string row)
        {
            var data = row.Split(";");
            Id = int.Parse(data[0]);
            Name = data[1];
            Price = int.Parse(data[2]);
            IsDeleted = data[3] == "True";
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3}", Id, Name, Price, IsDeleted);
        }
    }
}
