using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutosOO
{
    [System.Serializable]
    internal class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome , float preco , string autor)
        {
            this.nome = nome;   
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas ao curso {nome}");
            Console.WriteLine("Digite a quantidade de vagas que você quer dar entrada no curso");
            int quantidade = int.Parse(Console.ReadLine());

            vagas += quantidade;

            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();

        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar quantidade de vagas preenchidas do curso: {nome}");
            Console.WriteLine("Digite a quantidade de vagas preenchidas do curso ");
            int vendas = int.Parse(Console.ReadLine());

            if(vendas > vagas)
            {
                Console.WriteLine("Não há mais vagas para preencher");
            }
            
            vagas -= vendas;

            Console.WriteLine("Vendas Registradas");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Preco: {preco}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"vagas: {vagas}");
            Console.WriteLine("===============================================");
        }
    }
}
