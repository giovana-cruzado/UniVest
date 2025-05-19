using Microsoft.EntityFrameworkCore;
using UniVest.Models;
using UniVest.Data;

namespace UniVest.Data
{
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
                    Nome = "Unesp",
                    DataPrevista1 = DateTime.Parse("02/11/2025"),
                    DataPrevista2 = DateTime.Parse("07/12/2025"),
                    DataPrevista3 = DateTime.Parse("08/12/2025"),
                    DataPrevista4 = DateTime.Parse(""),
                    Edital = "https://vestibular.unesp.br/Home/guiadeprofissoes51/guia-unesp-de-profissoes-2025-1.pdf",
                    PrecoInscricao = 210.00m,
                    UniversidadeId = 2
                },
                new Vestibular {
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
                    ModalidadeId = 1,
                },
                new Curso {
                    Id = 2,
                    Nome = "Agronomia",
                    ModalidadeId = 1,
                },
                new Curso {
                    Id = 3,
                    Nome = "Arquitetura e Urbanismo",
                    ModalidadeId = 1,
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
                    Nome = "Botucatu",
                    Endereco = "",
                    UniversidadeId = 2,
                }
            };
            builder.Entity<Campus>().HasData(campus);
        }
    }
}
