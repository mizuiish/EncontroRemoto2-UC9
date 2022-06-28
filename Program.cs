using CadastroPessoa.Classes;

Console.Clear();
Console.WriteLine(@"
=============================================
|   Bem-vindo ao sistema de cadastro de     |
|      Pessoa Física e Jurídica             |
=============================================
");

BarraDeCarregamento("Inicializando", 100, 20);

//instanciado a nova lista "tipo(lista)" "nome (listaPf)" = new "tipo do objeto de novo"
List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@"
=============================================
|       Escolha uma das opões abaixo        |
|-------------------------------------------|
|           1 - Pessoa Física               |
|           2 - Pessoa Jurídica             |
|                                           |
|           0 - Sair                        |
=============================================
");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

            string? opcaoPf; //colocar ? depois de string pq a string pode ser vazia
            do
            {

                Console.Clear();
                Console.WriteLine(@"
=============================================
|       Escolha uma das opões abaixo        |
|-------------------------------------------|
|           1 - Cadastrar Pessoa Física     |
|           2 - Listar Pessoa Física        |
|                                           |
|           0 - Voltar ao menu anterior     |
=============================================
");
                opcaoPf = Console.ReadLine();
                PessoaFisica metodosPf = new PessoaFisica();

                switch (opcaoPf)
                {
                    case "1":

                        //para criar nova pessoa fisica
                        PessoaFisica novaPf = new PessoaFisica();

                        Endereco novoEndPf = new Endereco();

                        //cadastra nome
                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar: ");
                        novaPf.Nome = Console.ReadLine();

                        //do while para validar a data de nascimento

                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento EX: DD/MM/AAA ");
                            string? dataNascimento = Console.ReadLine();

                            dataValida = metodosPf.ValidarDataNasc(dataNascimento);

                            if (dataValida)
                            {
                                DateTime dataConvertida;
                                DateTime.TryParse(dataNascimento, out dataConvertida);
                                //usou o método tryparse para converter a string para o tipo date time
                                novaPf.dataNasc = dataConvertida;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data digitada inválida, por favor digite uma data válida.");
                                Console.ResetColor();
                                Thread.Sleep(3000);

                            }

                        } while (dataValida == false);

                        //cadastra cpf
                        Console.WriteLine($"Digite o cpf: ");
                        novaPf.Cpf = Console.ReadLine();

                        //usa o float parse para converter a entrada que será string para float
                        Console.WriteLine($"Digite o rendimento mensal (SOMENTE NÚMEROS)");
                        novaPf.Rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro: ");
                        novoEndPf.Logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número: ");
                        novoEndPf.Numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (aperte enter caso não haja)");
                        novoEndPf.Complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string enderecoCom = Console.ReadLine().ToUpper();
                        //ToUpper para converter para letra maiuscula caso o usuario tenha usado minuscula
                        if (enderecoCom == "S")
                        {
                            novoEndPf.endComercial = true;
                        }
                        else
                        {
                            novoEndPf.endComercial = false;
                        }

                        novaPf.Endereco = novoEndPf;

                        listaPf.Add(novaPf);
                        //cor
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Cadastro realizado com sucesso.");
                        Console.ResetColor();
                        Thread.Sleep(3000);

                        break;

                    case "2":

                        Console.Clear();

                        if (listaPf.Count > 0)
                        {
                            foreach (PessoaFisica cadaPessoa in listaPf)
                            {
                                Console.WriteLine(@$"

Nome: {cadaPessoa.Nome}
Endereço: {cadaPessoa.Endereco.Logradouro}, {cadaPessoa.Endereco.Numero}
Imposto a ser pago: {metodosPf.PagarImposto(cadaPessoa.Rendimento).ToString("C")}

");
                                Console.WriteLine($"Aperte ENTER para continuar.");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"A lista está vazia");
                            Thread.Sleep(3000);
                        }

                        break;

                    case "0":
                        break;

                    default:

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida, por favor digite uma opção válida.");
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        break;
                }

            } while (opcaoPf != "0");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Digite ENTER para  continuar.");
            Console.ResetColor();
            Console.ReadLine();
            break;

        case "2":

            string? opcaoPj;

            do
            {


                Console.WriteLine(@"
=============================================
|       Escolha uma das opões abaixo        |
|-------------------------------------------|
|           1 - Cadastrar Pessoa Jurídica   |
|           2 - Listar Pessoa Jurídica      |
|                                           |
|           0 - Voltar ao menu anterior     |
=============================================");

                opcaoPj = Console.ReadLine();
                PessoaJuridica metodosPj = new PessoaJuridica();

                switch (opcaoPj)
                {
                    case "1":

                        PessoaJuridica novaPj = new PessoaJuridica();
                        Endereco novoEndPj = new Endereco();


                        Console.WriteLine($"Digite o nome que deseja cadastrar: ");
                        novaPj.Nome = Console.ReadLine();

                        Console.WriteLine($"Digite a razão social: ");
                        novaPj.RazaoSocial = Console.ReadLine();

                        Console.WriteLine($"Digite o CNPJ: ");
                        novaPj.Cnpj = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal: ");
                        novaPj.Rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro");
                        novoEndPj.Logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número: ");
                        novoEndPj.Numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (Aperte ENTER caso não haja): ");
                        novoEndPj.Complemento = Console.ReadLine();

                        Console.WriteLine($"O endereço é comercial? S/N");
                        string enderecoCom = Console.ReadLine().ToUpper();
                        if (enderecoCom == "S")
                        {
                            novoEndPj.endComercial = true;
                        }
                        else
                        {
                            novoEndPj.endComercial = false;
                        }

                        novaPj.Endereco = novoEndPj;

                        listaPj.Add(novaPj);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Cadastro realizado com sucesso.");
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        break;

                    case "2":

                        Console.Clear();

                        if (listaPj.Count > 0)
                        {           //tipo da var - nome da var - nome onde ela está contida
                            foreach (PessoaJuridica cadaPessoa in listaPj)
                            {
                                Console.WriteLine(@$"
Nome: {cadaPessoa.Nome}
Endereço: {cadaPessoa.Endereco.Logradouro}, {cadaPessoa.Endereco.Numero}
Imposto a ser pago: {metodosPj.PagarImposto(cadaPessoa.Rendimento).ToString("C")}

                                ");

                                Console.WriteLine($"Aperte ENTER para continuar");
                                Console.ReadLine();

                            }
                        }
                        else
                        {
                            Console.WriteLine($"A lista está vazia.");
                            Thread.Sleep(3000);

                        }
                        break;

                    case "0":
                        break;

                    default:

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida, por favor digite uma opção válida.");
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        break;
                }

            } while (opcaoPj != "0");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Digite ENTER para  continuar.");
            Console.ResetColor();
            Console.ReadLine();
            break;

        case "0":
            Console.Clear();
            Console.WriteLine("Obrigado por utilizar nosso sistema.");
            Thread.Sleep(2000);
            BarraDeCarregamento("Finalizando", 300, 6);
            break;

        default:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opção inválida, por favor digite uma opção válida.");
            Console.ResetColor();
            Thread.Sleep(3000);
            break;
    }

} while (opcao != "0");

static void BarraDeCarregamento(string texto, int tempo, int quantidade)
{
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(texto);
    for (var contador = 0; contador < quantidade; contador++)
    {
        Console.Write(".");
        Thread.Sleep(tempo);
    }
    Console.ResetColor();

    Console.Clear();
}
