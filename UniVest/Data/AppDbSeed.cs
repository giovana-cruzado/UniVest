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
            new Universidade { Id = 3, Nome = "Universidade Estadual de Campinas", Sigla = "Unicamp" },
            new Universidade { Id = 4, Nome = "Universidade Federal do Paraná", Sigla = "UFPR"}
            new Universidade { Id = 5, Nome = "Universidade Estadual de Londrina", Sigla = "UEL"}
            new Universidade { Id = 6, Nome = "Universidade Estadual de Maringá", Sigla = "UEM"}
            new Universidade { Id = 7, Nome = "Universidade Estadual do Oeste do Paraná", Sigla = "UNIOESTE"}
            new Universidade { Id = 8, Nome = "Universidade Estadual de Ponta Grossa", Sigla = "UEPG"}
            new Universidade { Id = 9, Nome = "Universidade Estadual do Norte do Paraná", Sigla = "UENP"}
            new Universidade { Id = 10, Nome = "Universidade Estadual do Paraná", Sigla = "UNESPAR"}
            new Universidade { Id = 11, Nome = "Universidade Federal de Santa Catarina", Sigla = "UFSC"}
            new Universidade { Id = 12, Nome = "Universidade Federal do Rio Grande do Sul", Sigla = "UFRGS"}
            new Universidade { Id = 13, Nome = "Universidade Federal de Pelotas", Sigla = "UFPEL"}
            new Universidade { Id = 14, Nome = "Universidade Federal de Santa Maria", Sigla = "UFSM"}
            new Universidade { Id = 15, Nome = "Universidade do Estado do Amazonas ", Sigla = "UEA"}
            new Universidade { Id = 16, Nome = "Universidade Federal de Roraima", Sigla = "UFRR"}
            new Universidade { Id = 17, Nome = "Universidade Estadual de Roraima", Sigla = "UERR"}
            new Universidade { Id = 18, Nome = "Universidade Federal do Tocantins", Sigla = "UFT"}
            new Universidade { Id = 19, Nome = "Universidade Estadual do Tocantins", Sigla = "UNITINS"}
            new Universidade { Id = 20, Nome = "Universidade do Estado da Bahia", Sigla = "UNEB"}
            new Universidade { Id = 21, Nome = "Universidade Estadual do Sudoeste da Bahia", Sigla = "UESB"}
            new Universidade { Id = 22, Nome = "Universidade de Pernambuco", Sigla = "UPE"}
            new Universidade { Id = 23, Nome = "Universidade Católica de Pernambuco", Sigla = "UNICAP"}
            new Universidade { Id = 24, Nome = "Universidade Federal de Pernambuco", Sigla = "UFPE"}
            new Universidade { Id = 25, Nome = "Universidade Estadual da Paraíba", Sigla = "UEPB"}
            new Universidade { Id = 26, Nome = "Universidade Estadual de Ciências da Saúde de Alagoas", Sigla = "UNCISAL"}
            new Universidade { Id = 27, Nome = "Universidade Estadual do Maranhão", Sigla = "UEMA"}
            new Universidade { Id = 28, Nome = "Universidade Estadual do Ceará", Sigla = "UECE"}
            new Universidade { Id = 29, Nome = "Universidade Regional do Cariri", Sigla = "URCA"}
            new Universidade { Id = 30, Nome = "Universidade Estadual do Vale do Acaraú", Sigla = "UVA"}
            new Universidade { Id = 31, Nome = "Faculdade de Tecnologia do Estado de São Paulo", Sigla = "FATEC"}
            new Universidade { Id = 32, Nome = "Instituto Tecnológico de Aeronáutica", Sigla = "ITA"}
            new Universidade { Id = 33, Nome = "Universidade Federal de São Paulo", Sigla = "UNIFESP"}
            new Universidade { Id = 34, Nome = "Universidade do Estado do Rio de Janeiro", Sigla = "UERJ"}
            new Universidade { Id = 35, Nome = "Instituto Militar de Engenharia", Sigla = "IME"}
            new Universidade { Id = 36, Nome = "Universidade Federal de Minas Gerais", Sigla = "UFMG"}
            new Universidade { Id = 37, Nome = "Universidade Federal de Uberlândia", Sigla = "UFU"}
            new Universidade { Id = 38, Nome = "Universidade Federal de Juíz de Fora", Sigla = "UFJF"}
            new Universidade { Id = 39, Nome = "Universidade Estadual de Minas Gerais", Sigla = "UEMG"}
            new Universidade { Id = 40, Nome = "Universidade de Brasília", Sigla = "UNB"}
            new Universidade { Id = 41, Nome = "Universidade Federal de Rondonópolis", Sigla = "UFR"}
            new Universidade { Id = 42, Nome = "Universidade Federal da Grande Dourados", Sigla = "UFGD"}
            new Universidade { Id = 43, Nome = "Universidade Federal de Mato Grosso do Sul", Sigla = "UFMS"}
        };
        builder.Entity<Universidade>().HasData(universidades);

        List<Vestibular> vestibulares = new()
{
    new Vestibular
    {
        Id = 1,
        Nome = "USP",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 1
    },
    new Vestibular
    {
        Id = 2,
        Nome = "Unesp",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 2
    },
    new Vestibular
    {
        Id = 3,
        Nome = "Unicamp",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 3
    },
    new Vestibular
    {
        Id = 4,
        Nome = "UFPR",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 4
    },
    new Vestibular
    {
        Id = 5,
        Nome = "UEL",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 5
    },
    new Vestibular
    {
        Id = 6,
        Nome = "UEM",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 6
    },
    new Vestibular
    {
        Id = 7,
        Nome = "UNIOESTE",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 7
    },
    new Vestibular
    {
        Id = 8,
        Nome = "UEPG",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 8
    },
    new Vestibular
    {
        Id = 9,
        Nome = "UENP",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 9
    },
    new Vestibular
    {
        Id = 10,
        Nome = "UNESPAR",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 10
    },
    new Vestibular
    {
        Id = 11,
        Nome = "UFSC",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 11
    },
    new Vestibular
    {
        Id = 12,
        Nome = "UFRGS",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 12
    },
    new Vestibular
    {
        Id = 13,
        Nome = "UFPEL",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 13
    },
    new Vestibular
    {
        Id = 14,
        Nome = "UFSM",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 14
    },
    new Vestibular
    {
        Id = 15,
        Nome = "UEA",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 15
    },
    new Vestibular
    {
        Id = 16,
        Nome = "UFRR",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 16
    },
    new Vestibular
    {
        Id = 17,
        Nome = "UERR",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 17
    },
    new Vestibular
    {
        Id = 18,
        Nome = "UFT",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 18
    },
    new Vestibular
    {
        Id = 19,
        Nome = "UNITINS",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 19
    },
    new Vestibular
    {
        Id = 20,
        Nome = "UNEB",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 20
    },
    new Vestibular
    {
        Id = 21,
        Nome = "UESB",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 21
    },
    new Vestibular
    {
        Id = 22,
        Nome = "UPE",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 22
    },
    new Vestibular
    {
        Id = 23,
        Nome = "UNICAP",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 23
    },
    new Vestibular
    {
        Id = 24,
        Nome = "UFPE",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 24
    },
    new Vestibular
    {
        Id = 25,
        Nome = "UEPB",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 25
    },
    new Vestibular
    {
        Id = 26,
        Nome = "UNCISAL",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 26
    },
    new Vestibular
    {
        Id = 27,
        Nome = "UEMA",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 27
    },
    new Vestibular
    {
        Id = 28,
        Nome = "UECE",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 28
    },
    new Vestibular
    {
        Id = 29,
        Nome = "URCA",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 29
    },
    new Vestibular
    {
        Id = 30,
        Nome = "UVA",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 30
    },
    new Vestibular
    {
        Id = 31,
        Nome = "FATEC",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 31
    },
    new Vestibular
    {
        Id = 32,
        Nome = "ITA",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 32
    },
    new Vestibular
    {
        Id = 33,
        Nome = "UNIFESP",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 33
    },
    new Vestibular
    {
        Id = 34,
        Nome = "UERJ",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 34
    },
    new Vestibular
    {
        Id = 35,
        Nome = "IME",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 35
    },
    new Vestibular
    {
        Id = 36,
        Nome = "UFMG",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 36
    },
    new Vestibular
    {
        Id = 37,
        Nome = "UFU",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 37
    },
    new Vestibular
    {
        Id = 38,
        Nome = "UFJF",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 38
    },
    new Vestibular
    {
        Id = 39,
        Nome = "UEMG",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 39
    },
    new Vestibular
    {
        Id = 40,
        Nome = "UNB",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 40
    },
    new Vestibular
    {
        Id = 41,
        Nome = "UFR",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 41
    },
    new Vestibular
    {
        Id = 42,
        Nome = "UFGD",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 42
    },
    new Vestibular
    {
        Id = 43,
        Nome = "UFMS",
        DataPrevista1 = DateTime.Parse("23/11/2025"),
        DataPrevista2 = DateTime.Parse("14/12/2025"),
        DataPrevista3 = DateTime.Parse("15/12/2025"),
        DataPrevista4 = DateTime.Parse("09/12/2025"),
        EditalUni = "https://www.fuvest.br/vestibular-da-usp/",
        EditalProvao = "blob:https://www.doe.sp.gov.br/38ebf651-5a98-4e78-8024-f9b8fc4c86d8",
        PrecoInscricao = 211.00m,
        UniversidadeId = 43
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
            new Curso {
                Id = 4,
                Nome = "Medicina",
            }
            new Curso {
                Id = 5,
                Nome = "Engenharia Civil",
            }
            new Curso {
                Id = 6,
                Nome = "Fisioterapia",
            }
            new Curso {
                Id = 7,
                Nome = "Psicologia",
            }
            new Curso {
                Id = 8,
                Nome = "Ciência da Computação",
            }
            new Curso {
                Id = 9,
                Nome = "Design",
            }
            new Curso {
                Id = 10,
                Nome = "Biomedicina",
            }
            new Curso {
                Id = 11,
                Nome = "Pedagogia",
            }
            new Curso {
                Id = 12,
                Nome = "Química",
            }
            new Curso {
                Id = 13,
                Nome = "Medicina Veterinária",
            }
        };
        builder.Entity<Curso>().HasData(cursos);

        List<Campus> campus = new() {
            new Campus {
                Id = 1,
                Estado = "São Paulo",
                Nome = "Campinas",
                Cidade = "",
                UniversidadeId = 3,
            },
            new Campus {
                Id = 2,
                Estado = "São Paulo",
                Nome = "São Paulo",
                Cidade = "",
                UniversidadeId = 1,
            },
            new Campus {
                Id = 3,
                Estado = "São Paulo",
                Nome = "Bauru",
                Cidade = "",
                UniversidadeId = 2,
            }
            new Campus {
                Id = 3,
                Estado = "São Paulo",
                Nome = "Bauru",
                Cidade = "",
                UniversidadeId = 2,
            }
        };
        builder.Entity<Campus>().HasData(campus);

        // 1- USP  2- UNESP  3- UNICAMP
        // 1- Administração  2- Matemática 3- Arquitetura e Urbanismo
        // 1- Campinas  2- São Paulo  3- Bauru
        // 1- Bacharelado  2- Licenciatura  3- Tecnólogo

        List<CampusCurso> campuscurso = new() {
            new CampusCurso {
            // Bacharelado em administração na UNICAMP em Campinas
                Id = 1,
                CampusId = 1,
                CursoId = 1,
                Periodo = Periodo.Noturno,
                ModalidadeId = 1,
                Duracao = 8 //semestres
            },
            // Licenciatura em matemática na UNESP em Bauru
            new CampusCurso {
                Id = 2,
                CampusId = 3,
                CursoId = 2,
                Periodo = Periodo.Diurno,
                ModalidadeId = 2,
                Duracao = 8
            },
            // Licenciatura em matemática na USP em SP
            new CampusCurso {
                Id = 3,
                CampusId = 2,
                CursoId = 2,
                Periodo = Periodo.Diurno,
                ModalidadeId = 2,
                Duracao = 8
            },
            // Bacharelado em Arq e Urb na USP em SP
            new CampusCurso {
                Id = 4,
                CampusId = 2,
                CursoId = 3,
                Periodo = Periodo.Diurno,
                ModalidadeId = 1,
                Duracao = 10
            },
            new CampusCurso {
                Id = 5,
                CampusId = 1,
                CursoId = 4,
                Periodo = Periodo.Integral,
                ModalidadeId = 1,
                Duracao = 12
            },
            new CampusCurso {
                Id = 6,
                CampusId = 2,
                CursoId = 3,
                Periodo = Periodo.Diurno,
                ModalidadeId = 1,
                Duracao = 10
            },
            new CampusCurso {
                Id = 7,
                CampusId = 2,
                CursoId = 3,
                Periodo = Periodo.Diurno,
                ModalidadeId = 1,
                Duracao = 10
            },
            new CampusCurso {
                Id = 8,
                CampusId = 2,
                CursoId = 3,
                Periodo = Periodo.Diurno,
                ModalidadeId = 1,
                Duracao = 10
            },
            new CampusCurso {
                Id = 9,
                CampusId = 2,
                CursoId = 3,
                Periodo = Periodo.Diurno,
                ModalidadeId = 1,
                Duracao = 10
            },
            new CampusCurso {
                Id = 10,
                CampusId = 2,
                CursoId = 3,
                Periodo = Periodo.Diurno,
                ModalidadeId = 1,
                Duracao = 10
            },
            new CampusCurso {
                Id = 11,
                CampusId = 2,
                CursoId = 3,
                Periodo = Periodo.Diurno,
                ModalidadeId = 1,
                Duracao = 10
            },
            new CampusCurso {
                Id = 12,
                CampusId = 2,
                CursoId = 3,
                Periodo = Periodo.Diurno,
                ModalidadeId = 1,
                Duracao = 10
            },
            new CampusCurso {
                Id = 13,
                CampusId = 2,
                CursoId = 3,
                Periodo = Periodo.Diurno,
                ModalidadeId = 1,
                Duracao = 10
            },
            new CampusCurso {
                Id = 14,
                CampusId = 2,
                CursoId = 3,
                Periodo = Periodo.Diurno,
                ModalidadeId = 1,
                Duracao = 10
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
            user.PasswordHash = pass.HashPassword(user, "123456");
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
