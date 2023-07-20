using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingPortal.Models;
using BOL;
using BLL;

namespace OnlineShoppingPortal.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Product> plist = ProductManager.GetAllProducts();
        this.ViewData["plist"] = plist;
        return View();
    }

    public IActionResult Insert()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Insert(int pid, string pname, int qty, int price)
    {
        bool status = ProductManager.InsertProduct(new Product { Pid = pid, Pname = pname, Qty = qty, Price = price });

        return RedirectToAction("Index");

    }

    public IActionResult Update(int id)
    {
        Product prod = ProductManager.GetById(id);
        this.ViewData["prod"] = prod;
        return View();
    }

    [HttpPost]
    public IActionResult Update(int pid, string pname, int qty, int price)
    {
        Console.WriteLine(pid + "  ," + pname);
        bool status = ProductManager.UpdateMyProduct(new Product { Pid = pid, Pname = pname, Qty = qty, Price = price });

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        bool status = ProductManager.DeleteProduct(id);
        return RedirectToAction("Index");
    }
}