using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CategoryProducts.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoryProducts.Controllers;

public class ProductsController : Controller
{
    private CatProdContext db;
    public ProductsController(CatProdContext context)
    {
        db = context;
    }
    [HttpGet("/products")]
    public IActionResult Products()
    {

        List<Product> allProducts = db.Products.ToList();
        ViewBag.Products = allProducts;

        return View("Products");
    }

    [HttpPost("/products/new")]
    public IActionResult NewProduct(Product newProd)
    // inside the (), you're passing in the class and new variable
    {
        if (ModelState.IsValid)
        {
            db.Products.Add(newProd);
            // information from the form being passed in
            db.SaveChanges();

            return RedirectToAction("Products");
        }

        return View("Products");
    }

    [HttpGet("/product/{productID}")]
    public IActionResult ShowProd(int productID)
    {
        Product? oneProd = db.Products.Include(product => product.ProdAssoc)
        // include means youre going inside the table
        // theninclude will include inside the OG table(include)/opening doors/ association class
        .ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductId == productID);
        // This is getting where all the products from cats where the id is equaled to the productID

        List<Category> listCat = db.Categories.Include(c => c.CatAssoc)
        .ThenInclude(p => p.Product)
        .Where(c => c.CatAssoc.All(c => c.ProductId != productID)).ToList();

        ViewBag.listProd = listCat;
        return View("ShowProd", oneProd);


    }
    [HttpPost("/product/{ProductId}/addCatToProduct")]
    public IActionResult addCatToProduct(Product oneProd, int ProductId, int CategoryId)
    {
        Association newAssAss = new Association();
        newAssAss.CategoryId = CategoryId;
        // Line 8 in ShowProd

        newAssAss.ProductId = ProductId;

        db.Associations.Add(newAssAss);
        db.SaveChanges();

        return Redirect($"/product/{ProductId}");
    }






}



