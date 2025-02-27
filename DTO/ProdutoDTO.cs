using ProjetoAPI.Model;

namespace ProjetoAPI.DTO
{
    public class ProdutoDTO
    {
        
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
       
    }
}
