namespace DAL;
using BOL;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

public class LoginIOManager 
{
    MySqlConnection con = DBManager.GetMyConnection();

    public User AuthenticateUser(string uname, string password)
    {
        string query = "SELECT * FROM login WHERE uname='"+uname+"' AND password='"+password+"'";
        MySqlCommand cmd = new MySqlCommand(query,con);
        con.Open();
        MySqlDataReader reader = cmd.ExecuteReader();
        User? user=null;
        while(reader.Read())
        {
            string username = reader.GetString("uname");
            string pass = reader.GetString("password");
            string role = reader.GetString("role");
            user=new User{Uname=username,Password=pass,Role=role};
        }

        con.Close();
        return user;
    }

    public bool RegisterNewUser(NewUser user)
    {
        bool status = false;
        string query = "INSERT INTO newuser values('"+user.FullName+"','"+user.Uname+"','"+user.Password+"','"+user.Password+"')";
        MySqlCommand cmd = new MySqlCommand(query,con);
        con.Open();
        cmd.ExecuteNonQuery();
        status = true;
        con.Close();
        return status;
    }
    
}