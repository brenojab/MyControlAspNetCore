using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyControlAspNetCore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using MyControlAspNetCore.Models;

namespace MyControlAspNetCore.Controllers
{
  public class AccountController : Controller
  {
    private SignInManager<Usuario> _signManager;
    private UserManager<Usuario> _userManager;

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Registro()
    {
      return View();
    }


    [HttpPost]
    public async Task<IActionResult> RegistrarUsuario(UsuarioViewModel model)
    {
      if (ModelState.IsValid)
      {
        var user = new Usuario { UserName = model.Username };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
          //await _signManager.SignInAsync(user, false);
          return RedirectToAction("Index", "Home");
        }
        else
        {
          foreach (var error in result.Errors)
          {
            ModelState.AddModelError("", error.Description);
          }
        }
      }
      return View();
    }

    public AccountController(UserManager<Usuario> userManager, SignInManager<Usuario> signManager)
    {
      _userManager = userManager;
      _signManager = signManager;
    }


    [HttpPost]
    public async Task<IActionResult> Logout()
    {
      await _signManager.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }

  }
}