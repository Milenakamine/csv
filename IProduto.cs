using System.Collections.Generic;

namespace csv
{
    public interface IProduto
    {
        //   void Listar();

    void Cadastrar(Produto produto);
        
     void Alterar(Produto _produtoAlterado);
    List<Produto> Ler();
    void Remover(string _termo);
    
    }
}