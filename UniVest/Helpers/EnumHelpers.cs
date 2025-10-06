
using UniVest.Models;

namespace UniVest.Helpers
{
    public static class EnumHelpers
    {
        public static string GetDisplayName(this Periodo periodoEnum)
        {
            switch (periodoEnum)
            {
                case Periodo.Matutino:
                    return "Matutino";
                case Periodo.Vespertino:
                    return "Vespertino";
                case Periodo.Noturno:
                    return "Noturno";
                case Periodo.Integral:
                    return "Integral";
                case Periodo.Diurno:
                    return "Diurno";
                default:
                    return "Indefinido";
            }
        }
    }
}
