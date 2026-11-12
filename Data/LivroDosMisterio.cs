
using tccDiarioDeMonstros.Models;
using tccDiarioDeMonstros.Data;

namespace tccDiarioDeMonstros.Data
{
    public class LivroDosMisterio
    {
        private readonly AppDbContext _context;

        public LivroDosMisterio(AppDbContext context)
        {
            _context = context;
        }

        public List<Elemento> PuxarLivro()
        {
            return _context.Elementos.ToList();
        }

        public void Adicionar(Elemento elemento)
        {
            _context.Elementos.Add(elemento);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var elemento = _context.Elementos.Find(id);
            if (elemento != null)
            {
                _context.Elementos.Remove(elemento);
                _context.SaveChanges();
            }
        }

        public List<Elemento> Buscar(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
            {
                return new List<Elemento>();
            }

            termo = termo.Trim();

            return _context.Elementos
                .Where(e => (e.Nome != null && e.Nome.Contains(termo)) ||
                            (e.Categoria != null && e.Categoria.Contains(termo)) ||
                            (e.ElementoPoder != null && e.ElementoPoder.Contains(termo)) ||
                            (e.Tipo != null && e.Tipo.Contains(termo)) ||
                            (e.Fraqueza != null && e.Fraqueza.Contains(termo)) ||
                            (e.LocalDeNascimento != null && e.LocalDeNascimento.Contains(termo)) ||
                            (e.Descricao != null && e.Descricao.Contains(termo)))
                .ToList();
        }
    }
}


