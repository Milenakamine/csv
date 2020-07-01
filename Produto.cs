using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace csv {
    public class Produto {
        //variavel

        public int Codigo { get; set; }
        public string Nome { get; set; }

        public float Preco { get; set; }

        private const string PATH = "Database/produto.csv";
        //se não existir a pasta, ela é criada a partir desse processo com o !
        public Produto () {
            string pasta = PATH.Split ('/') [0];
            if (!Directory.Exists (pasta)) {
                Directory.CreateDirectory (pasta);
            }
            //PATH - arquivo, caso ele tambem não exista, ele é criado da mesma forma q a pasta, com o ! 
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
        }
        //cadastrando o produto e arrumado pelo prepararlinha 
        public void Cadastrar (Produto prod) {
            var linha = new string[] { PreparLinha (prod) };
            File.AppendAllLines (PATH, linha);
        }

        public List<Produto> Ler () {
            //lista de produtos
            List<Produto> produtos = new List<Produto> ();

            string[] linhas = File.ReadAllLines (PATH);

            foreach (string linha in linhas) {

                //separamos os dados de cada linha com Split
                string[] dado = linha.Split (";");

                //produtos que vão ser colocados na lista

                Produto p = new Produto ();
                p.Codigo = Int32.Parse (Separar (dado[0]));
                p.Nome = Separar (dado[1]);
                p.Preco = float.Parse (Separar (dado[2]));
                //adicionando os produtos 
                produtos.Add (p);

            }
            produtos = produtos.OrderBy (y => y.Nome).ToList ();
            return produtos;

        }
        //para remover uma linha da lista criada
        public void Remover (string _termo) {
            //criação de lista 
            List<string> linhas = new List<string> ();
            using (StreamReader arquivo = new StreamReader (PATH)) {
                string linha;
                while ((linha = arquivo.ReadLine ()) != null) {
                    linhas.Add (linha);
                }
            }
            linhas.RemoveAll (l => l.Contains (_termo));
            //reescreve o csv de novo 
            using (StreamWriter output = new StreamWriter (PATH)) {

               output.Write(String.Join(Environment.NewLine, linhas.ToArray()));
            }
        }

            public List<Produto> Filtrar (string _nome) {
            return Ler ().FindAll (x => x.Nome == _nome);
            }


            private string Separar (string _coluna) {

                //0        1
                //nome = Iphone

                return _coluna.Split ("=") [1];
            }

            public string PreparLinha (Produto p) {
                return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
            }
        }
    }