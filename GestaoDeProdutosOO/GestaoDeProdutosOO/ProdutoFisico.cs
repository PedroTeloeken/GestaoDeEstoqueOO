using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutosOO
{
    [System.Serializable]
    internal class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
           
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar produtos no estoque de {nome}");
            Console.WriteLine("Digite a quantidade de produtos que você quer dar entrada no estoque");
            int quantidade = int.Parse(Console.ReadLine());

            estoque += quantidade;

            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar quantidade de vendas do {nome}");
            Console.WriteLine("Digite a quantidade de vendas do produto");
            int RegistroVendas = int.Parse(Console.ReadLine());

            estoque -= RegistroVendas;

            Console.WriteLine("Vendas Registradas");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Preco: {preco}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("===============================================");
        }
    }
}
