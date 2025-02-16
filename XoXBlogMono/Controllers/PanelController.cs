using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XoXBlogMono.DBModels;
using XoXBlogMono.Attributes;
using XoXBlogMono.Models;
using XoXBlogMono.Models.DTOs;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace XoXBlogMono.Controllers;

[CustomAuthorize]
public class PanelController : Controller
{
    private readonly YasinkaNarchContext _context;
    private readonly ILogger<PanelController> _logger;
    public PanelController(YasinkaNarchContext context, ILogger<PanelController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    #region Categories
    public async Task<IActionResult> Categories()
    {
        var dto = new PanelDto
        {
            Categories = await _context.Categories.OrderBy(x => x.Order).ToListAsync()
        };
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> CategoryAdd([FromBody] Category category)
    {
        if (ModelState.IsValid)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
        return Json(new { success = false });
    }

    [HttpPost]
    public async Task<IActionResult> CategoryUpdate([FromBody] Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
        return Json(new { success = false });
    }

    [HttpPost]
    public async Task<IActionResult> CategoryDelete(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
        return Json(new { success = false });
    }

    [HttpGet]
    public async Task<IActionResult> GetCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            return Json(category);
        }
        return NotFound();
    }
    #endregion

    #region Posts
    public async Task<IActionResult> Posts()
    {
        var dto = new PanelDto
        {
            Posts = await _context.Posts
                .OrderBy(x => x.Order)
                .Include(x => x.Category)
                .Include(x => x.Owner)
                .ToListAsync(),
            Categories = await _context.Categories
                .Where(x => x.Status == 1)
                .OrderBy(x => x.Order)
                .ToListAsync()
        };
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> PostAdd(Post post, IFormFile bannerImage)
    {
        try 
        {
            if (bannerImage != null)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "upload");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(bannerImage.FileName)}";
                var path = Path.Combine(uploadPath, fileName);
                
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await bannerImage.CopyToAsync(stream);
                }
                
                post.BannerImage = $"/images/upload/{fileName}";
            }
            
            post.CreatedAt = DateTime.Now;
            post.UpdatedAt = DateTime.Now;
            post.OwnerId = HttpContext.Session.GetInt32("UserId") ?? 1; 

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostUpdate([FromForm] Post post, IFormFile bannerImage)
    {
        try
        {
            var existingPost = await _context.Posts.FindAsync(post.Id);
            if (existingPost == null) return NotFound();

            if (bannerImage != null)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "upload");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                if (!string.IsNullOrEmpty(existingPost.BannerImage))
                {
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingPost.BannerImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(bannerImage.FileName)}";
                var path = Path.Combine(uploadPath, fileName);
                
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await bannerImage.CopyToAsync(stream);
                }
                
                existingPost.BannerImage = $"/images/upload/{fileName}";
            }

            existingPost.Title = post.Title;
            existingPost.CategoryId = post.CategoryId;
            existingPost.Text = post.Text;
            existingPost.Keywords = post.Keywords;
            existingPost.Order = post.Order;
            existingPost.Status = post.Status;
            existingPost.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostDelete(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post != null)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
        return Json(new { success = false });
    }

    [HttpGet]
    public async Task<IActionResult> GetPost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post != null)
        {
            return Json(post);
        }
        return NotFound();
    }
    #endregion
}