using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CategoryProducts.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoryProducts.Controllers;

public class CategoriesController : Controller
{
    private CatProdContext db;
    public CategoriesController(CatProdContext context)
    {
        db = context;
    }

    [HttpGet("/categories")]
    public IActionResult Categories()
    {

        List<Category> allCategories = db.Categories.ToList();
        ViewBag.Categories = allCategories;

        return View("Categories");
    }

    [HttpPost("/categories/new")]
    public IActionResult NewCategories(Category newCat)
    // inside the (), you're passing in the class and new variable
    {
        if (ModelState.IsValid)
        {
            db.Categories.Add(newCat);
            // information from the form being passed in
            db.SaveChanges();

            return RedirectToAction("Categories");
        }

        return View("Categories");
    }

    [HttpGet("/category/{categoryID}")]
    public IActionResult ShowCat(int CategoryID)
    {
        Category? oneCat = db.Categories.Include(Category => Category.CatAssoc)
        // include means youre going inside the table
        // theninclude will include inside the OG table(include)/opening doors/ association class
        .ThenInclude(a => a.Product).FirstOrDefault(p => p.CategoryId == CategoryID);
        // This is getting where all the Categorys from cats where the id is equaled to the CategoryID

        List<Product> listProd = db.Products.Include(c => c.ProdAssoc)
        .ThenInclude(p => p.Category)
        .Where(c => c.ProdAssoc.All(c => c.CategoryId != CategoryID)).ToList();

        ViewBag.listCat = listProd;
        return View("ShowCat", oneCat);


    }
    [HttpPost("/Category/{CategoryId}/addProdToCategory")]
    public IActionResult addProdToCategory(Category oneCat, int CategoryId, int ProductId)
    {
        Association newCatCat = new Association();
        newCatCat.ProductId = ProductId;
        // Line 8 in ShowProd

        newCatCat.CategoryId = CategoryId;

        db.Associations.Add(newCatCat);
        db.SaveChanges();

        return Redirect($"/category/{CategoryId}");
    }


}