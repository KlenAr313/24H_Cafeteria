namespace cafeteria.data
{
    public interface IProduct : IIdentity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
