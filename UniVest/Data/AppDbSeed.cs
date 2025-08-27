using Microsoft.EntityFrameworkCore;
using UniVest.Models;
using Microsoft.AspNetCore.Identity;

namespace UniVest.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        List<Modalidade> modalidades = new() {
            new Modalidade { Id = 1, Nome = "Bacharelado" },
            new Modalidade { Id = 2, Nome = "Licenciatura" },
            new Modalidade { Id = 3, Nome = "Tecnólogo" }
        };
        builder.Entity<Modalidade>().HasData(modalidades);

        List<Universidade> universidades = new() {
            new Universidade { Id = 1, Nome = "Universidade de São Paulo", Sigla = "USP", },
            new Universidade { Id = 2, Nome = "Universidade Estadual Paulista", Sigla = "Unesp" },
            new Universidade { Id = 3, Nome = "Universidade Estadual de Campinas", Sigla = "Unicamp" }
        };
        builder.Entity<Universidade>().HasData(universidades);

        List<Vestibular> vestibulares = new() {
            new Vestibular {
                Id = 1,
                Nome = "Fuvest",
                DataPrevista1 = DateTime.Parse("23/11/2025"),
                DataPrevista2 = DateTime.Parse("14/12/2025"),
                DataPrevista3 = DateTime.Parse("15/12/2025"),
                DataPrevista4 = DateTime.Parse("09/12/2025"),
                Edital = null,
                PrecoInscricao = 211.00m,
                UniversidadeId = 1
            },
            new Vestibular {
                Id = 2,
                Nome = "Unesp",
                DataPrevista1 = DateTime.Parse("02/11/2025"),
                DataPrevista2 = DateTime.Parse("07/12/2025"),
                DataPrevista3 = DateTime.Parse("08/12/2025"),
                DataPrevista4 = null,
                Edital = "https://vestibular.unesp.br/Home/guiadeprofissoes51/guia-unesp-de-profissoes-2025-1.pdf",
                PrecoInscricao = 210.00m,
                UniversidadeId = 2
            },
            new Vestibular {
                Id = 3,
                Nome = "Comvest",
                DataPrevista1 = DateTime.Parse("26/10/2025"),
                DataPrevista2 = DateTime.Parse("30/11/2025"),
                DataPrevista3 = DateTime.Parse("01/12/2025"),
                DataPrevista4 = DateTime.Parse("03/12/2025"),
                Edital = null,
                PrecoInscricao = 210.00m,
                UniversidadeId = 3
            }
        };
        builder.Entity<Vestibular>().HasData(vestibulares);

        List<Curso> cursos = new() {
            new Curso {
                Id = 1,
                Nome = "Administração",
            },
            new Curso {
                Id = 2,
                Nome = "Matemática",
            },
            new Curso {
                Id = 3,
                Nome = "Arquitetura e Urbanismo",
            }
        };
        builder.Entity<Curso>().HasData(cursos);

        List<Campus> campus = new() {
            new Campus {
                Id = 1,
                Nome = "Campinas",
                Endereco = "",
                UniversidadeId = 3,
            },
            new Campus {
                Id = 2,
                Nome = "São Paulo",
                Endereco = "",
                UniversidadeId = 1,
            },
            new Campus {
                Id = 3,
                Nome = "Bauru",
                Endereco = "",
                UniversidadeId = 2,
            }
        };
        builder.Entity<Campus>().HasData(campus);

        // 1- USP  2- UNESP  3- UNICAMP
        // 1- Campinas  2- São Paulo  3- Bauru
        // 1- Administração  2- Matemática 3- Arquitetura e Urbanismo
        // 1- Bacharelado  2- Licenciatura  3- Tecnólogo

        List<CampusCurso> campuscurso = new() {
            new CampusCurso {
            // Bacharelado em administração em Campinas
                Id = 1,
                CampusId = 1,
                CursoId = 1,
                Periodo = Periodo.Noturno,
                ModalidadeId = 1
            },
            // Licenciatura em matemática em Bauru
            new CampusCurso {
                Id = 2,
                CampusId = 3,
                CursoId = 2,
                Periodo = Periodo.Diurno,
                ModalidadeId = 2
            },
            // Licenciatura em matemática em SP
            new CampusCurso {
                Id = 3,
                CampusId = 2,
                CursoId = 2,
                Periodo = Periodo.Diurno,
                ModalidadeId = 2
            },
            // Bacharelado em Arq e Urb 
            new CampusCurso {
                Id = 4,
                CampusId = 2,
                CursoId = 3,
                Periodo = Periodo.Diurno,
                ModalidadeId = 1
            },
        };
        builder.Entity<CampusCurso>().HasData(campuscurso);

        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole() {
            Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
            Name = "Administrador",
            NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
            Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
            Name = "Usuário",
            NormalizedName = "USUÁRIO"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = new()
        {
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "giovanascruzado@gmail.com",
                NormalizedEmail = "GIOVANASCRUZADO@GMAIL.COM",
                UserName = "Giovana",
                NormalizedUserName = "GIOVANA",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Giovana Souza Cruzado",
                Foto = "/img/usuarios/ddf093a6-6cb5-4ff7-9a64-83da34aee005.png"
            }
        };
        foreach (var user in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            user.PasswordHash = pass.HashPassword(user, "Admin@123");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}
