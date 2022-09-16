using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutosOO
{
    internal class Class
    {

        enum Menu { Listagem = 1, Adicionar, Remover, Entrada, Saida, Sair }
        enum TipoDeProduto { ProdutoFisico = 1 , Ebook, Curso}

        static List<IEstoque> produtos = new List<IEstoque>();
        static void Main(string[] args)
        {

            Carregar();
            bool escolheuSair = false;

            while (!escolheuSair)
            {
            Console.WriteLine("Bem vindo ao Sistema de Estoque\n");
            Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Registrar Entrada\n5-Registrar Saída\n6-Sair");
            int opcaoInt = int.Parse(Console.ReadLine());
            Menu opcao = (Menu)opcaoInt;

            switch (opcao)
            {
                case Menu.Listagem:
                        Listagem();
                    break;
                case Menu.Adicionar:
                        Cadastro();
                    break;
                case Menu.Remover:
                        Remover();
                    break;
                case Menu.Entrada:
                        Entrada();
                    break;
                case Menu.Saida:
                        Saida();
                    break;
                case Menu.Sair:
                    escolheuSair = true;
                    break;

            }
                Console.Clear();
            }
        }
        static void Cadastro()
        {
            Console.WriteLine("Selecione o Tipo de Produto que você queira cadastrar\n");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Curso");
            int opcaoint = int.Parse(Console.ReadLine());
            TipoDeProduto tipoDeProduto = (TipoDeProduto)opcaoint;

            switch (tipoDeProduto)
            {
                case TipoDeProduto.ProdutoFisico:
                    CadastroProdutoFIsico();
                    break;
                case TipoDeProduto.Ebook:
                    CadastroEbook();
                    break;
                case TipoDeProduto.Curso:
                    CadastroCurso();
                    break;
            }         
        }

        static void CadastroProdutoFIsico()
        {
            Console.WriteLine("Cadastrando produto Fisico\n");         
            Console.WriteLine("Informe o nome do produto que queira cadastrar");
            string nome = Console.ReadLine();           
            Console.WriteLine("Informe o preço do produto que queira cadastrar");
            float preco = float.Parse(Console.ReadLine());          
            Console.WriteLine("Informe o preço do frete do produto que queira cadastrar");
            float frete = float.Parse(Console.ReadLine());           
            ProdutoFisico produtoFisico = new ProdutoFisico(nome, preco, frete);           
            produtos.Add(produtoFisico);
            Salvar();
        }

        static void CadastroEbook()
        {
            Console.WriteLine("Cadastrando Ebook\n");           
            Console.WriteLine("Informe o nome do Ebook que queira cadastrar");
            string nome = Console.ReadLine();           
            Console.WriteLine("Informe o preço do Ebook que queira cadastrar");
            float preco = float.Parse(Console.ReadLine());          
            Console.WriteLine("Informe o autor do Ebook que queira cadastrar");
            string autor = Console.ReadLine();            
            Ebook ebook = new Ebook(nome, preco, autor);            
            produtos.Add(ebook);
            Salvar();
        }

        static void CadastroCurso()
        {
            Console.WriteLine("Cadastrando Curso\n");

            Console.WriteLine("Informe o nome do Curso que queira cadastrar");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o preço do Curso que queira cadastrar");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Informe o autor do Ebook que queira cadastrar");
            string autor = Console.ReadLine();
            Curso curso = new Curso(nome, preco, autor);
            produtos.Add(curso);
            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, produtos);

            stream.Close();
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                produtos = (List<IEstoque>)formatter.Deserialize(stream);              
                if(produtos == null)
                {
                   produtos = new List<IEstoque>();
                }
            }catch(Exception e)
            {
                produtos = new List<IEstoque>();
            }
            stream.Close();

        }
        
        static void Listagem()
        {
            int id = 0;
            Console.WriteLine("Lista dos Produtos\n");

            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine($"Id: {id}");
                produto.Exibir();
                id++;
            }
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Informe o Id do produto que queira deletar");
            int id = int.Parse(Console.ReadLine());
        
            if(id >= 0 && id <= produtos.Count)
            {
                produtos.RemoveAt(id);          
                Console.WriteLine("Produto deletado com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Produto Não encontrado");
                Console.ReadLine();
            }
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Dar entrada no sistema");
            Console.WriteLine("Informe o Id do produto que você quer dar entrada");
            int id = int.Parse(Console.ReadLine());
            
            if (id >= 0 && id <= produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
                Console.WriteLine("Entrada feita com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Produto Não encontrado");
                Console.ReadLine();
            }

        }

        static void Saida()
        {
            Listagem();
            Console.WriteLine("Dar saida no sistema");
            Console.WriteLine("Informe o Id do produto que você quer dar saida");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id <= produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
                Console.WriteLine("Saida feita com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Produto Não encontrado");
                Console.ReadLine();
            }

        }

    }
}
