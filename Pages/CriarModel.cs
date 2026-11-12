using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tccDiarioDeMonstros.Data;
using tccDiarioDeMonstros.Models;

 namespace tccDiarioDeMonstros.Pages;

    public class CriarModel(LivroDosMisterio repositorio, IWebHostEnvironment environment) : PageModel   
    {
       [BindProperty] 
       public Elemento Elemento { get; set;} = new();

       [BindProperty]
       public IFormFile? ArquivoImagem {get; set;}

       public void OnGet()
    {
    }

      public async Task<IActionResult> OnPostAsync()
    {
        if (ArquivoImagem != null && ArquivoImagem.Length > 0)
        {
            string pastaImagem = Path.Combine(environment.WebRootPath, "imagens");

            if(!Directory.Exists(pastaImagem))
            {
                Directory.CreateDirectory(pastaImagem);
            }
            string nomeUnicoArquivo = Guid.NewGuid().ToString() + Path.GetExtension(ArquivoImagem.FileName);
            string caminhoCompleto = Path.Combine(pastaImagem,nomeUnicoArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await ArquivoImagem.CopyToAsync(stream);
            }
            Elemento.Imagem = "/imagens/" + nomeUnicoArquivo;
            {
                repositorio.Adicionar(Elemento);
                return RedirectToPage("/Index");
            }
        }
    }
    }
