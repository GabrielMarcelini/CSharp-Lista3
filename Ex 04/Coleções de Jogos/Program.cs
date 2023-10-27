﻿class Program
{
    struct Emprestimo
    {
        public DateTime data;
        public string nomePessoa;
        public char emprestado;
    }

    struct Jogos
    {
        public string titulo;
        public string console;
        public int ano;
        public int ranking;
        public Emprestimo emprestimo;
    }

    static void addJogos(List<Jogos> lista)
    {
        Jogos novoJogo = new Jogos();
        Console.WriteLine("Digite o Título do Jogo: ");
        novoJogo.titulo = Console.ReadLine();
        Console.WriteLine("Digite o modelo de Console: ");
        novoJogo.console = Console.ReadLine();
        Console.WriteLine("Digite o ano do Jogo: ");
        novoJogo.ano = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o ranking do Jogo: ");
        novoJogo.ranking = int.Parse(Console.ReadLine());
        Emprestimo emprestimo = new Emprestimo();
        novoJogo.emprestimo.emprestado = 'N';
        lista.Add(novoJogo);
    }

    static void listarJogos(List<Jogos> lista)
    {
        int qtd = lista.Count;
        Console.WriteLine("Lista de Jogos: ");
        for (int i = 0; i < qtd; i++)
        {
            Console.WriteLine($"Título do Jogo: {lista[i].titulo}");
            Console.WriteLine($"Modelo de Console: {lista[i].console}");
            Console.WriteLine($"Ano do Jogo: {lista[i].ano}");
            Console.WriteLine($"Ranking do Jogo: {lista[i].ranking}");
            Console.WriteLine($"Emprestado: {lista[i].emprestimo.emprestado}");
            if (lista[i].emprestimo.emprestado == 'S')
            {
                Console.WriteLine($"Data de Empréstimo: {lista[i].emprestimo.data}");
                Console.WriteLine($"Nome da Pessoa: {lista[i].emprestimo.nomePessoa}");
            }
        }
    }

    static void buscarTitulo(List<Jogos> lista, string titulo)
    {
        int qtd = lista.Count();

        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].titulo.ToUpper().Equals(titulo.ToUpper()))
            {
                Console.WriteLine($"Título do Jogo: {lista[i].titulo}");
                Console.WriteLine($"Modelo de Console: {lista[i].console}");
                Console.WriteLine($"Ano do Jogo: {lista[i].ano}");
                Console.WriteLine($"Ranking do Jogo: {lista[i].ranking}");
                Console.WriteLine($"Emprestado: {lista[i].emprestimo.emprestado}");
                if (lista[i].emprestimo.emprestado == 'S')
                {
                    Console.WriteLine($"Data de Empréstimo: {lista[i].emprestimo.data}");
                    Console.WriteLine($"Nome da Pessoa: {lista[i].emprestimo.nomePessoa}");
                }
            }
        }
    }
    static void emprestimo(List<Jogos> lista, string titulo)
    {
        int qtd = lista.Count();

        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].titulo.ToUpper().Equals(titulo.ToUpper()))
            {
                if (lista[i].emprestimo.emprestado == 'S')
                {
                    Console.WriteLine("Jogo já está emprestado!");
                }
                else
                {
                    Jogos jogoAtualizado = lista[i];
                    jogoAtualizado.emprestimo.data = DateTime.Now;
                    Console.WriteLine("Digite o nome da pessoa que está pegando o jogo:");
                    jogoAtualizado.emprestimo.nomePessoa = Console.ReadLine();
                    jogoAtualizado.emprestimo.emprestado = 'S';
                    lista[i] = jogoAtualizado;

                }
            }
        }
    }

    static void devolucao(List<Jogos> lista, string titulo)
    {
        int qtd = lista.Count();

        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].titulo.ToUpper().Equals(titulo.ToUpper()))
            {
                if (lista[i].emprestimo.emprestado == 'N')
                {
                    Console.WriteLine("Jogo não está emprestado!");
                }
                else
                {
                    Jogos jogoAtualizado = lista[i];
                    jogoAtualizado.emprestimo.data = DateTime.MinValue;
                    jogoAtualizado.emprestimo.nomePessoa = "";
                    jogoAtualizado.emprestimo.emprestado = 'N';
                    lista[i] = jogoAtualizado;
                }
            }
        }
    }

    static void listarEmprestados(List<Jogos> lista)
    {
        int qtd = lista.Count();

        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].emprestimo.emprestado == 'S')
            {
                Console.WriteLine($"Título do Jogo: {lista[i].titulo}");
                Console.WriteLine($"Modelo de Console: {lista[i].console}");
                Console.WriteLine($"Ano do Jogo: {lista[i].ano}");
                Console.WriteLine($"Ranking do Jogo: {lista[i].ranking}");
                Console.WriteLine($"Data de Empréstimo: {lista[i].emprestimo.data}");
                Console.WriteLine($"Nome da Pessoa: {lista[i].emprestimo.nomePessoa}");

            }
        }
    }
    static void salvarDados(List<Jogos> lista, string tituloArquivo)
    {

        using (StreamWriter writer = new StreamWriter(tituloArquivo))
        {
            foreach (Jogos jogo in lista)
            {
                writer.WriteLine($"{jogo.titulo},{jogo.console},{jogo.ano},{jogo.ranking},{jogo.emprestimo.data},{jogo.emprestimo.nomePessoa},{jogo.emprestimo.emprestado}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");
    }

    static int menu()
    {
        Console.WriteLine("Menu Principal");
        Console.WriteLine("1 - Adicionar Jogo: ");
        Console.WriteLine("2 - Listar Jogos: ");
        Console.WriteLine("3 - Buscar pelo Título: ");
        Console.WriteLine("4 - Realizar empréstimo de um jogo: ");
        Console.WriteLine("5 - Devolver jogo emprestado: ");
        Console.WriteLine("6 - Listar Jogos Emprestados: ");
        Console.WriteLine("0 - Sair: ");
        int op = int.Parse(Console.ReadLine());
        return op;
    }

    static void Main()
    {
        List<Jogos> listaJogos = new List<Jogos>();
        int op;

        do
        {
            op = menu();

            switch (op)
            {
                case 1:
                    addJogos(listaJogos);
                    break;
                case 2:
                    listarJogos(listaJogos);
                    break;
                case 3:
                    Console.WriteLine("Digite o Título do jogo que deseja procurar: ");
                    string tituloBusca = Console.ReadLine();
                    buscarTitulo(listaJogos, tituloBusca);
                    break;
                case 4:
                    Console.WriteLine("Digite o Título do Jogo: ");
                    string titulo = Console.ReadLine();
                    emprestimo(listaJogos, titulo);
                    break;
                case 5:
                    Console.WriteLine("Digite o Título do Jogo: ");
                    titulo = Console.ReadLine();
                    devolucao(listaJogos, titulo);
                    break;
                case 6:
                    listarEmprestados(listaJogos);
                    break;
                case 0:
                    Console.WriteLine("Saindo");
                    salvarDados(listaJogos, "dados.txt");
                    break;
                default:
                    Console.WriteLine("ERRO: Opção Inválida.");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        } while (op != 0);
    }
}