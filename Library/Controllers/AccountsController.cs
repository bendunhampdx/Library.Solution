using Library.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Library.Controllers
{
  [AllowAnonymous]
  public class AccountsController :  Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountsController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, LibraryContext db) 
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db= db;
    }

    public ActionResult Index()
    {
      return View();
    }
    [AllowAnonymous]
    public IActionResult Register()
    {
      return View();
    }

    [HttpPost, AllowAnonymous]
    public async Task<ActionResult> Register (RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
          return RedirectToAction("Index");
      }
      else
      {
        ViewBag.ErrorMessage = "Registration Failed.";
        return View();
      }
    }
    [AllowAnonymous]
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost, AllowAnonymous]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
       Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        ViewBag.ErrorMessage = "Unable to Login.";
        return View();
      }
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }
  }
}