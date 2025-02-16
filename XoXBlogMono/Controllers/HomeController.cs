using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using XoXBlogMono.Models;
using XoXBlogMono.DBModels;
using Microsoft.EntityFrameworkCore;


namespace XoXBlogMono.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly YasinkaNarchContext _context;
    public HomeController(ILogger<HomeController> logger, YasinkaNarchContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        GeneralModel generalModel = new GeneralModel();
        generalModel.Categories = _context.Categories.ToList();
        generalModel.Posts = _context.Posts.Include(p => p.Category).Include(p => p.Owner).OrderByDescending(p => p.CreatedAt).ToList();

        return View(generalModel);
    }

    [Route("category/{categoryName}-{categoryId}")]
    public IActionResult Category(string categoryName, int categoryId)
    {

        GeneralModel generalModel = new GeneralModel();
        generalModel.Category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);

        if (generalModel.Category == null)
            return RedirectToAction("Index", "Home");

        generalModel.Categories = _context.Categories.ToList();
        generalModel.Posts = _context.Posts.Include(p => p.Owner).Where(p => p.CategoryId == categoryId).ToList();
        return View(generalModel);
    }
    [Route("category/{categoryName}/{blogTitle}-{blogId}")]
    public IActionResult Blog(string categoryName, string blogTitle, int blogId)
    {

        GeneralModel generalModel = new GeneralModel();
        generalModel.Categories = _context.Categories.ToList();
        generalModel.Post = _context.Posts.Include(p => p.Category).Include(p => p.Owner).FirstOrDefault(p => p.Id == blogId);
        if (generalModel.Post == null)
         return RedirectToAction("Index", "Home");
         
        return View(generalModel);

    }

}
