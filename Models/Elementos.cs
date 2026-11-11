

namespace tccDiarioDeMonstros.Models;

    public class Elementos
    {
        public int Id { get; set; }

        public int Numero { get; set; }
        public string Nome { get; set; }
        public int Vida { get; set; }
        public double Peso { get; set; }
        public double Velocidade { get; set; }
        public double Forca { get; set; }
        public double Poder { get; set; }


        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set;}
        public string Elemento { get; set; }
        public string Fraqueza { get; set; }
        public string LocalDeNascimento { get; set; }



        public string? Imagem { get; set; }

    }
