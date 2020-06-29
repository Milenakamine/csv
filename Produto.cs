using System.IO;

namespace csv
{
    public class Produto
    {
        public string Nome { get; set; }

        public int Codigo { get; set; }

        public float Preco { get; set; }

        private const string PATH = "Database/produto.csv" ;

        public Produto(){
         string pasta = PATH.Split('/')[0];
         if(!Directory.Exists(pasta)){
             Directory.CreateDirectory(pasta);
         }




            if(!File.Exists(PATH)){
              File.Create(PATH).Close();
            }
        }

        public void Cadastrar (Produto prod){
            var linha = new string[]{PreparLinha(prod)};
            File.AppendAllLines(PATH, linha);
        }

        public string PreparLinha(Produto p){
            return $"nome={p.Nome}; codigo={p.Codigo}; preco={p.Preco}";
        }
    }
}