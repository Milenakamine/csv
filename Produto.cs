using System;
using System.Collections.Generic;
using System.IO;

namespace csv
{
    public class Produto
    {

        public int Codigo { get; set; }
        public string Nome { get; set; }

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


            public List<Produto> Ler(){

                List<Produto> produtos = new List<Produto>();
                
                string [] linhas = File.ReadAllLines(PATH);


                foreach(string linha in linhas){

                //separamos os dados de cada linha com Split
                    string [] dado = linha.Split(";");

                //produtos que vão ser colocados na lista

                Produto p = new Produto();
                p.Codigo = Int32.Parse(Separar(dado[0]));
                p.Nome = Separar(dado[1]);
                p.Preco = float.Parse(Separar(dado[2]));
           
                produtos.Add(p);
            
                }
                return produtos;

            }
            private string Separar(string _coluna){
                
              //0        1
              //nome = Iphone

                return _coluna.Split("=")[1];
            }

        public string PreparLinha(Produto p){
            return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
        }
    }
}