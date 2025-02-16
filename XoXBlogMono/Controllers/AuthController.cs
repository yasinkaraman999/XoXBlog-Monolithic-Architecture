using Microsoft.AspNetCore.Mvc;
using XoXBlogMono.DBModels;
namespace XoXBlogMono.Controllers;

public class AuthController : Controller
{
    private readonly YasinkaNarchContext _context;
    private readonly ILogger<AuthController> _logger;
    public AuthController(YasinkaNarchContext context, ILogger<AuthController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [Route("login")] 
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult LoginCheck(string username, string password)
    {   
        _logger.LogInformation("LoginCheck method called with username: {username} and password: {password}", username, password);
        if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
          return Json(new { success = false, message = "Kullanıcı adı veya şifre hatalı" });
         
        
        User user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == CryptoManager.getMD5(password));
        
        if(user == null)
        {
            ViewData["message"] = "Kullanıcı adı veya şifre hatalı";
            return Json(new { success = false, message = "Kullanıcı adı veya şifre hatalı" });
        }

        HttpContext.Session.SetString("userId", user.Id.ToString());

        return Json(new { success = true, message = "Giriş başarılı" });
    }
}
