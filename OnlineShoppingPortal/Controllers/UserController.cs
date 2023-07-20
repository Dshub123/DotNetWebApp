using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingPortal.Models;
using BOL;
using BLL;

namespace OnlineShoppingPortal.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string uname, string pwd)
    {
        User user = UserManager.AuthenticateUser(uname,pwd);
        
        if(user.Role == "admin")
        {
            return RedirectToAction("Index","Product");
        }
        return RedirectToAction("Index");  
    
    }

    public IActionResult RegisterUser()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegisterUser(string fullname, string uname, string pwd, string repwd, string mobile)
    {
        if(pwd.Equals(repwd))
        {
            bool status = UserManager.RegisterNewUser(new NewUser(){FullName=fullname, Uname=uname, Password=pwd, Mobile=mobile});
            return RedirectToAction("Index");
        }
        else
        {
            return RedirectToAction("RegisterUser");
        }
        return View();
    }
}