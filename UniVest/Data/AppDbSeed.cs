using Microsoft.EntityFrameworkCore;
using UniVest.Models;
using UniVest.Data;

namespace UniVest.Data
{
    public static class AppDbSeed
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.Migrate(); 
                
                if (!context.Modalidades.Any())
                {
                    context.Modalidades.AddRange(
                        new Modalidade { Nome = "Bacharelado" },
                        new Modalidade { Nome = "Licenciatura" },
                        new Modalidade { Nome = "Tecnólogo" }
                    );
                    context.SaveChanges();
                }

                if (!context.Universidades.Any())
                {
                    var usp = new Universidade { Nome = "USP", Sigla = "USP" };
                    var unesp = new Universidade { Nome = "Unesp", Sigla = "UNESP" };

                    context.Universidades.AddRange(usp, unesp);
                    context.SaveChanges();

                    var vestibularUsp = new Vestibular
                    {
                        UniversidadeId = usp.Id,
                        Edital = "https://www.fuvest.br/edital2025"
                    };

                    var vestibularUnesp = new Vestibular
                    {
                        UniversidadeId = unesp.Id,
                        Edital = "https://www.vunesp.com.br/edital2025"
                    };

                    context.Vestibulares.AddRange(vestibularUsp, vestibularUnesp);
                    context.SaveChanges();

                    var modalidades = context.Modalidades.ToList();

                    context.Cursos.AddRange(
                        new Curso { Nome = "Engenharia", UniversidadeId = usp.Id, ModalidadeId = modalidades.First(m => m.Nome == "Bacharelado").Id },
                        new Curso { Nome = "Pedagogia", UniversidadeId = unesp.Id, ModalidadeId = modalidades.First(m => m.Nome == "Licenciatura").Id }
                    );

                    var modalidadeTecnologo = modalidades.FirstOrDefault(m => m.Nome == "Tecnólogo");
                    if (modalidadeTecnologo != null)
                    {
                        context.Cursos.Add(
                            new Curso { Nome = "Gestão Comercial", UniversidadeId = usp.Id, ModalidadeId = modalidadeTecnologo.Id }
                        );
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
