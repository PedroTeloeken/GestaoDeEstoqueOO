using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutosOO
{
    [System.Serializable]
    internal class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome , float preco , string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não tem como dar entrada num Ebook");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar quantidade de vendas do Ebook: {nome}");
            Console.WriteLine("Digite a quantidade de vendas dos Ebook ");
            int RegistroVendas = int.Parse(Console.ReadLine());

            vendas -= RegistroVendas;

            Console.WriteLine("Vendas Registradas");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Preco: {preco}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine("===============================================");
        }
    }
}
