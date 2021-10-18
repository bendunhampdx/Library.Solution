using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Library.Models;

namespace Library.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/"), AllowAnonymous]
    public ActionResult Index() 
    { 
      return View(); 
    }
  }
}