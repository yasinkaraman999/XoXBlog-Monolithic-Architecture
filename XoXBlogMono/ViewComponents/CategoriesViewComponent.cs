using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XoXBlogMono.DBModels;

namespace XoXBlogMono.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly YasinkaNarchContext _context;

        public CategoriesViewComponent(YasinkaNarchContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories
                .Where(x => x.Status == 1)
                .OrderBy(x => x.Order)
                .ToListAsync();
            return View(categories);
        }
    }
} 