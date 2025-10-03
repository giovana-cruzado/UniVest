// Local: ~/Helpers/EnumHelpers.cs
namespace UniVest.Helpers
{
    // Defina seu enum aqui ou em um arquivo separado
    public enum EPeriodo
    {
        Manha = 1,
        Tarde = 2,
        Noite = 3,
        Integral = 4
    }

    public static class EnumHelpers
    {
        // Este é o nosso método "tradutor"
        public static string GetDisplayName(this EPeriodo periodo)
        {
            switch (periodo)
            {
                case EPeriodo.Manha:
                    return "Manhã";
                case EPeriodo.Tarde:
                    return "Tarde";
                case EPeriodo.Noite:
                    return "Noturno";
                case EPeriodo.Integral:
                    return "Integral";
                default:
                    // Caso seguro para um Id que não exista no enum
                    return "Indefinido";
            }
        }
    }
}
