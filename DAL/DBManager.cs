namespace DAL;

using MySql.Data.MySqlClient;
using System.Data;

public class DBManager
{
    private static MySqlConnection? con;

    private DBManager()
    {

    }

    public static MySqlConnection GetMyConnection()
    {
        if (con == null)
        {
            string conString = "server=localhost;uid=shubham;pwd=shubham;database=db2";
            con = new MySqlConnection(conString);
            return con;
        }

        return con;
    }



}