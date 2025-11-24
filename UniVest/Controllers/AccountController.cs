using System.Net.Mail;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniVest.Models;
using UniVest.ViewModels;
using UniVest.Data;
using UniVest.Helpers;
using System.Text.RegularExpressions;

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
        var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var usuario = _db.Usuario.FirstOrDefault(u => u.Id == usuarioId);

        if (usuario == null)
            return NotFound();

        return View(usuario);
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
    // ✅ 1. MUDE O NOME DO PARÂMETRO PARA "Foto" PARA CORRESPONDER AO <input>
    public async Task<IActionResult> Perfil(string email, string nome, string Foto)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return NotFound();
        }

        // Atualiza o nome (se houver lógica para edição no futuro)
        user.Nome = nome;

        // ✅ 2. VERIFIQUE SE A STRING "Foto" (BASE64) FOI ENVIADA
    if (!string.IsNullOrEmpty(Foto))
    {
        try
        {
            // Limpa a string Base64, removendo o cabeçalho (ex: "data:image/png;base64,")
            var base64Data = Regex.Match(Foto, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            byte[] imageBytes = Convert.FromBase64String(base64Data);

            // Define um nome de arquivo único e a extensão (usaremos .jpg como padrão, mas pode ser melhorado)
            string nomeArquivo = user.Id + ".jpg"; // Usar o ID do usuário garante que a foto seja sempre substituída
            string caminhoDiretorio = Path.Combine(_host.WebRootPath, "img", "usuarios");

            // Garante que o diretório exista
            if (!Directory.Exists(caminhoDiretorio))
            {
                Directory.CreateDirectory(caminhoDiretorio);
            }

            string caminhoCompleto = Path.Combine(caminhoDiretorio, nomeArquivo);

            // Salva o arquivo no disco
            await System.IO.File.WriteAllBytesAsync(caminhoCompleto, imageBytes);

            // ✅ 3. ATUALIZE O CAMPO "Foto" DO USUÁRIO COM O CAMINHO DO ARQUIVO
            user.Foto = "/img/usuarios/" + nomeArquivo; // Use barras normais para URLs web
        }
        catch (Exception ex)
        {
            // Se algo der errado na conversão ou salvamento, registre o erro.
            _logger.LogError(ex, "Erro ao salvar a foto de perfil do usuário {UserId}", user.Id);
            // Opcional: Adicionar uma mensagem de erro para o usuário
            // ModelState.AddModelError("Foto", "Ocorreu um erro ao salvar sua imagem.");
            // return View(user); // Retorna para a view mostrando o erro
        }
    }

        // Salva as alterações no banco de dados
        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            TempData["SuccessMessage"] = "Perfil atualizado com sucesso!";
        }
        else
        {
            // Adiciona erros ao ModelState se a atualização falhar
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            // Se houver um erro, o ideal é retornar para a view para mostrá-lo
            // return View(user); 
    }

    return RedirectToAction("Perfil");
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

    public IActionResult DeletarConta()
    {
        var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var usuario = _db.Usuario.FirstOrDefault(u => u.Id == usuarioId);

        if (usuario == null)
            return NotFound();

        return View(usuario);
    }

    [HttpPost, ActionName("DeletarConta")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletarContaConfirmado()
    {
        var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var usuario = _db.Usuario.FirstOrDefault(u => u.Id == usuarioId);
        await _signInManager.SignOutAsync();
        await _userManager.DeleteAsync(usuario);
        return RedirectToAction("Index", "Home");
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