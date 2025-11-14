using System.Collections.Generic;


namespace UniVest.ViewModels
{
    public class FavoritoVM
    {
        public List<CursoFavoritadoViewModel> CursosFavoritados { get; set; }

        public FavoritoVM()
        {
            CursosFavoritados = new List<CursoFavoritadoViewModel>();
        }
    }
    public class CursoFavoritadoViewModel
    {
        public int CampusCursoId { get; set; }
        public int CursoId { get; set; }
        public string NomeCurso { get; set; }
        public string NomeUniversidade { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Modalidade { get; set; }
    }
}
