using System;
using System.Collections.Generic;

namespace csv
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo= 1;
            p1.Nome= "Xiaomi";
            p1.Preco= 4555f;

            p1.Cadastrar(p1);

            List<Produto> lista = p1.Ler();

            foreach(Produto item in lista){

                Console.WriteLine($"{item.Nome} - R${item.Preco}.");

            }
        }
    }
}
