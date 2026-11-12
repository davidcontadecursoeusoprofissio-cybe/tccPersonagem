using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tccDiarioDeMonstros.Data;
using tccDiarioDeMonstros.Models;

namespace tccDiarioDeMonstros.Pages
{
    

public class IndexModel : PageModel
{
    private readonly LivroDosMisterio _repositorio;

    public List<Elemento> Elementos { get; set;} = new();

    public IndexModel(LivroDosMisterio repositorio)
        {
            _repositorio = repositorio;
        }
        public void OnGet()
        {
            Elementos = _repositorio.PuxarLivro();
        }

        public IActionResult OnPost(int id)
        {
         _repositorio.Deletar(id) ;  
         return RedirectToPage("/Index");
        }
    }
}
