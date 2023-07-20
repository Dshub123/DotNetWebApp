namespace DAL;
using BOL;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


public class ProductIOManager
{

    MySqlConnection con = DBManager.GetMyConnection();

    public List<Product> GetAllProducts()
    {
        string query = "select * from product";
        MySqlCommand cmd = new MySqlCommand(query, con);
        con.Open();
        MySqlDataReader reader = cmd.ExecuteReader();
        List<Product> plist = new List<Product>();
        while (reader.Read())
        {
            int id = Convert.ToInt32(reader.GetInt32("pid"));
            string name = reader.GetString("pname");
            int qty = Convert.ToInt32(reader.GetInt32("qty"));
            double price = Convert.ToDouble(reader.GetDouble("price"));
            plist.Add(new Product { Pid = id, Pname = name, Qty = qty, Price = price });
        }
        con.Close();
        return plist;
    }

    public Product GetProductById(int id)
    {
        string query = "select * from product where pid=" + id;
        MySqlCommand cmd = new MySqlCommand(query, con);
        con.Open();
        MySqlDataReader reader = cmd.ExecuteReader();
        Product? prod = null;
        while (reader.Read())
        {
            int pid = Convert.ToInt32(reader.GetInt32("pid"));
            string pname = reader.GetString("pname");
            int qty = Convert.ToInt32(reader.GetInt32("qty"));
            double price = Convert.ToDouble(reader.GetDouble("price"));
            prod = new Product { Pid = pid, Pname = pname, Qty = qty, Price = price };
        }
        con.Close();
        return prod;
    }

    public bool InsertProduct(Product prod)
    {
        bool status = false;
        string query = "INSERT INTO product values("+prod.Pid+",'"+prod.Pname+"',"+prod.Qty+","+prod.Price+")";
        MySqlCommand cmd = new MySqlCommand(query,con);
        con.Open();
        cmd.ExecuteNonQuery();
        status = true;
        con.Close();
        return status;
    }

    public bool UpdateProduct(Product prod)
    {
        Console.WriteLine(prod.Pid+"  ,, "+prod.Pid);
        bool status = false;
        string query = "UPDATE product SET pname='"+prod.Pname+"',qty="+prod.Qty+",price="+prod.Price+" WHERE pid="+prod.Pid;
        MySqlCommand cmd = new MySqlCommand(query,con);
        con.Open();
        cmd.ExecuteNonQuery();
        status = true;
        con.Close();
        return status;
    }

    public bool DeleteProduct(int pid)
    {
        bool status = false;
        string query = "DELETE FROM product where pid="+pid;
        MySqlCommand cmd = new MySqlCommand(query,con);
        con.Open();
        cmd.ExecuteNonQuery();
        status = true;
        con.Close();
        return status;
    }



}
