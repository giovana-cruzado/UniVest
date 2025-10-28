using System.Net.Mail;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniVest.Models;
using UniVest.ViewModels;
using UniVest.Data;
using UniVest.Helpers;

namespace UniVest.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly UserManager<Usuario> _userManager;
    private readonly IWebHostEnvironment _host;
    private readonly AppDbContext _db;
    public AccountController(
        ILogger<AccountController> logger,
        SignInManager<Usuario> signInManager,
        UserManager<Usuario> userManager,
        IWebHostEnvironment host,
        AppDbContext db
    )
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
        _host = host;
        _db = db;
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
    

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (ModelState.IsValid)
        {
            string userName = login.Email;
            if (IsValidEmail(login.Email))
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                if (user != null)
                    userName = user.UserName;
            }

            var result = await _signInManager.PasswordSignInAsync(
                userName, login.Senha, login.Lembrar, lockoutOnFailure: true
            );

            if (result.Succeeded)
            {
                _logger.LogInformation($"Usuário {login.Email} acessou o sistema");
                return RedirectToAction("Cursos", "Home");
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning($"Usuário {login.Email} está bloqueado");
                ModelState.AddModelError("", "Sua conta está bloqueada, aguarde alguns minutos e tente novamente.");
            }
            else
            if (result.IsNotAllowed)
            {
                _logger.LogWarning($"Usuário {login.Email} não confirmou sua conta");
                ModelState.AddModelError(string.Empty, "Sua conta não está confirmada, verifique seu email.");
            }
            else
                ModelState.AddModelError(string.Empty, "Usuário e/ou senha inválidos");
        }
        return View(login);
    }

    [HttpGet]
    public IActionResult MudarSenha()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> MudarSenha(ChangePasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {

            return RedirectToAction("Login");
        }

        var result = await _userManager.ChangePasswordAsync(user, model.SenhaAtual, model.NovaSenha);

        if (result.Succeeded)
        {
            await _signInManager.RefreshSignInAsync(user);

            TempData["SuccessMessage"] = "Sua senha foi alterada com sucesso!";
            return RedirectToAction("Perfil");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        _logger.LogInformation($"Usuário {ClaimTypes.Email} fez logoff");
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Cadastro()
    {
        return View(new CadastroVM());
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

    public IActionResult Perfil()
    {
        var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var usuario = _db.Usuario.FirstOrDefault(u => u.Id == usuarioId);

        if (usuario == null)
            return NotFound();

        return View(usuario);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cadastro(CadastroVM cadastro)
    {
        if (ModelState.IsValid)
        {
            var usuario = Activator.CreateInstance<Usuario>();
            usuario.Nome = cadastro.Nome;
            usuario.UserName = cadastro.Email;
            usuario.NormalizedUserName = cadastro.Email.ToUpper();
            usuario.Email = cadastro.Email;
            usuario.NormalizedEmail = cadastro.Email.ToUpper();
            usuario.EmailConfirmed = true;
            var result = await _userManager.CreateAsync(usuario, cadastro.Senha);

            if (result.Succeeded)
            {
                _logger.LogInformation($"Novo usuário registrado com o email {cadastro.Email}.");

                await _userManager.AddToRoleAsync(usuario, "Usuário");

                if (cadastro.Foto != null)
                {
                    string nomeArquivo = usuario.Id + Path.GetExtension(cadastro.Foto.FileName);
                    string caminho = Path.Combine(_host.WebRootPath, @"img\usuarios");
                    string novoArquivo = Path.Combine(caminho, nomeArquivo);
                    using (var stream = new FileStream(novoArquivo, FileMode.Create))
                    {
                        cadastro.Foto.CopyTo(stream);
                    }
                    usuario.Foto = @"\img\usuarios\" + nomeArquivo;
                    await _db.SaveChangesAsync();
                }

                TempData["Success"] = "Conta Criada com Sucesso!";
                return RedirectToAction(nameof(Login));
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, TranslateIdentityErrors.TranslateErrorMessage(error.Code));
        }
        return View(cadastro);
    }

    public bool IsValidEmail(string email)
    {
        try
        {
            MailAddress m = new(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
