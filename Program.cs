using System;
using System.Collections.Generic;

namespace csv {
    class Program {
        static void Main (string[] args) {
            Produto p2 = new Produto ();
            p2.Codigo = 2;
            p2.Nome = "Xiaomi";
            p2.Preco = 4555f;

            p2.Cadastrar (p2);

            Produto alterado = new Produto ();
            alterado.Codigo = 3;
            alterado.Nome = "Nokia";
            alterado.Preco = 326f;

            p2.Alterar (alterado);

            p2.Remover ("Motorola");



            // List<Produto> lista = p2.Ler ();

            List<Produto> lista = p2.Filtrar("Iphone");

            foreach (Produto item in lista) {

                Console.WriteLine ($"{item.Nome} - R${item.Preco}.");

            }
        }
    }
}
