namespace BLL;
using BOL;
using DAL;

public class ProductManager
{
    public static ProductIOManager mgr = new ProductIOManager();
    public static List<Product> GetAllProducts()
    {
        return mgr.GetAllProducts();
    }

    public static Product GetById(int id)
    {
        return mgr.GetProductById(id);
    }

    public static bool InsertProduct(Product prod)
    {
        return mgr.InsertProduct(prod);
    }

    public static bool UpdateMyProduct(Product prod)
    {
        Console.WriteLine(prod.Pid + "  ,, " + prod.Pid);
        return mgr.UpdateProduct(prod);
    }

    public static bool DeleteProduct(int id)
    {
        return mgr.DeleteProduct(id);
    }
}
