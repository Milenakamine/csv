using System;

namespace csv
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Nome= "Iphone";
            p1.Codigo= 1;
            p1.Preco= 4545454f;

            p1.Cadastrar(p1);
        }
    }
}
