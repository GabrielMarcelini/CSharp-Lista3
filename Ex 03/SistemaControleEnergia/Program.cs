using System;
class program
{   
    struct Eletro
    {
        public string nome;
        public double potencia;
        public double tempoMedioUso;
    }// fim struct
    
    static void addEletro(List<Eletro> lista)
    {
        Eletro novoEletro = new Eletro(); // declarando uma variavel do TipoBanda
        Console.Write("Nome:");
        novoEletro.nome = (Console.ReadLine());
        Console.Write("Consumo:");
        novoEletro.potencia = Convert.ToDouble(Console.ReadLine());
        Console.Write("tempoMedioUso:");
        novoEletro.tempoMedioUso = Convert.ToDouble(Console.ReadLine());
        lista.Add(novoEletro);
    } // fim funcao
    static void listarEletros(List<Eletro> lista)
    {
        int qtd = lista.Count(); // Função "Count" ou Contar
        for (int i = 0; i < qtd; i++)
        {
            Console.WriteLine("\t*** Lista de Eletrodomésticos ***");
            Console.WriteLine("Nome:" + lista[i].nome);
            Console.WriteLine("consumo kw:" + lista[i].potencia);
            Console.WriteLine("Tempo Médio de Uso horas:" + lista[i].tempoMedioUso);
        } // fim for
    } // fim lista
    static void calcularCustoEletro(List<Eletro> vetorEletros, string nomeEletro)
    {
        double consumoDia , valorGastoDia , valorKw;
        Console.Write("Valor do Kw em R$:");
        valorKw = Convert.ToDouble(Console.ReadLine());
        foreach (Eletro eletro in vetorEletros)
        {
            if (eletro.nome.ToUpper().Equals((nomeEletro.ToUpper()))){
                consumoDia = eletro.potencia * eletro.tempoMedioUso;
                valorGastoDia = consumoDia * valorKw;
                Console.WriteLine($"Consumo em KW por dia:{Math.Round(consumoDia,2)}, por mês:{Math.Round(consumoDia * 30, 2)}");
                Console.WriteLine($"Valor gasto por dia:{Math.Round(valorGastoDia, 2)}," + $"por mês{Math.Round(valorGastoDia * 30, 2)}");
            }
        }

    }
    static void calcularCustoTotal(List<Eletro> vetorEletros)
    {
        double consumoDia = 0, valorGastoDia = 0, valorKw;
        Console.Write("Valor do Kw em R$:");
        valorKw = Convert.ToDouble(Console.ReadLine());
        foreach (Eletro eletro in vetorEletros)
        {
            consumoDia += eletro.potencia * eletro.tempoMedioUso;
            valorGastoDia = consumoDia * valorKw;
        }
        Console.WriteLine($"Consumo em KW por dia:{Math.Round(consumoDia, 2)}, por mês:{Math.Round(consumoDia * 30, 2)}");
        Console.WriteLine($"Valor gasto por dia:{Math.Round(valorGastoDia, 2)}," + $"por mês{Math.Round(valorGastoDia * 30, 2)}");
    }
            static void salvarDados(List<Eletro> eletrodomesticos, string nomeEletro)
    {
        using (StreamWriter writer = new StreamWriter(nomeEletro))
        {
            foreach (Eletro eletrodomestico in eletrodomesticos)
            {
                writer.WriteLine($"{eletrodomestico.nome},{eletrodomestico.potencia},{eletrodomestico.tempoMedioUso}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");
    }
    static void carregarDados(List<Eletro> lista, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                Eletro eletro = new Eletro
                {
                    nome = campos[0],
                    potencia = double.Parse(campos[1]),
                    tempoMedioUso = double.Parse(campos[2])
                };
                lista.Add(eletro);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    static int menu()
    {
        int op;
        Console.WriteLine("1-Cadastrar");
        Console.WriteLine("2-Listar");
        Console.WriteLine("3-Calcular consumo por eletro");
        Console.WriteLine("4-Calcular consumo total");
        Console.WriteLine("0-Sair");
        Console.Write("Escolha uma opção:");
        op = Convert.ToInt32(Console.ReadLine());
        return op;

    }//fim funcao menu
    static void Main()
    {
        List<Eletro> vetorEletros = new List<Eletro>();
        carregarDados(vetorEletros, "dadosEletro.txt");
        int op = 0;
        Console.WriteLine("*** Sistema de Controle de Energia C# ***");
        do
        {
            op = menu();
            switch(op)
            {
                case 1:addEletro(vetorEletros);
                    Console.WriteLine("Cadastrar");
                    break;
                case 2:listarEletros(vetorEletros);
                    Console.WriteLine("listar");
                    break;
                case 3:Console.Write("eletro para calculo: ");
                    string eletroBusca = Console.ReadLine();
                    calcularCustoEletro(vetorEletros, eletroBusca);
                    break;
                case 0:Console.WriteLine("Saindo");
                    salvarDados(vetorEletros, "dadosEletro.txt");
                    break;
            }//fim switch
          Console.ReadKey();//pausa
          Console.Clear();

        } while (op != 0);
       
    }
     

}