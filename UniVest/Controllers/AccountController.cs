using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniVest.Models;
using UniVest.ViewModels;

namespace UniVest.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly UserManager<Usuario> _userManager;
    private readonly IWebHostEnvironment _host;
    public AccountController(
        ILogger<AccountController> logger,
        SignInManager<Usuario> signInManager,
        UserManager<Usuario> userManager,
        IWebHostEnvironment host
    )
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
        _host = host;
    }

    [HttpGet]

    public IActionResult Login(string returnUrl)
    {
        LoginVM login = new()
        {
            UrlRetorno = returnUrl ?? Url.Content("~/")
        };
        return View(login);
    }

    [HttpGet]
    public IActionResult Cadastro()
    {
        return View(new CadastroVM());
    }

    [HttpPost]
    public async Task<IActionResult> Cadastro(CadastroVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var usuario = new Usuario
        {
            Email = model.Email,
            UserName = model.Email
        };

        var resultado = await _userManager.CreateAsync(usuario, model.Senha);

        if (resultado.Succeeded)
        {
            await _signInManager.SignInAsync(usuario, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        foreach (var erro in resultado.Errors)
        {
            ModelState.AddModelError(string.Empty, erro.Description);
        }

        return View(model);
    }

}
