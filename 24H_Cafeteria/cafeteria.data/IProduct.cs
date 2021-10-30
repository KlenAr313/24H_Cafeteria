namespace cafeteria.data
{
    public interface IProduct : IIdentity
    {
        string Name { get; set; }
        int Price { get; set; }
        bool IsDeleted { get; set; }
    }
}
