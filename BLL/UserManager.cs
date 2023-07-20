namespace BLL;
using BOL;
using DAL;

public class UserManager
{
    public static LoginIOManager loginmgr = new LoginIOManager();
  
  
    public static User AuthenticateUser(string uname, string password)
    {
        return loginmgr.AuthenticateUser(uname,password);
    }
    
    public static bool RegisterNewUser(NewUser user)
    {
        return loginmgr.RegisterNewUser(user);
    }

}