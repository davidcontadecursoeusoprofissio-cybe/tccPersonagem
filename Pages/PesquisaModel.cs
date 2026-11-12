using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tccDiarioDeMonstros.Data;
using tccDiarioDeMonstros.Models;

namespace tccDiarioDeMonstros.Pages
{
    public class PesquisaModel : PageModel
    {
        private readonly LivroDosMisterio _repositorio;

        public PesquisaModel(LivroDosMisterio repositorio)
        {
            _repositorio = repositorio;
        }

        [BindProperty(SupportsGet = true)]
        public string Termo { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public List<Elemento> Resultados { get; set; } = new();

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(Termo))
            {
                Resultados = _repositorio.Buscar(Termo);
            }
        }
    }
}