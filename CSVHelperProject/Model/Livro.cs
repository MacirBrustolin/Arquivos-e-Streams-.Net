using CsvHelper.Configuration.Attributes;
namespace CSVHelperProject.Model
{
    public class Livro
    {   
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
        public DateOnly Lancamento { get; set; }
        
    }
}