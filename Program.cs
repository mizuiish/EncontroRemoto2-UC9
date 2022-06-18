using CadastroPessoa.Classes;

Console.Clear();
Console.WriteLine(@"
=============================================
|   Bem-vindo ao sistema de cadastro de     |
|      Pessoa Física e Jurídica             |
=============================================
");

BarraDeCarregamento("Inicializando", 100, 20);

string? opcao;
do
{
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

            PessoaFisica novaPf = new PessoaFisica();
            PessoaFisica metodosPf = new PessoaFisica();
            Endereco novoEndPf = new Endereco();

            novaPf.Nome = "Nicolle";
            novaPf.dataNasc = new DateTime(2000, 01, 01);

            novaPf.Cpf = "1234567890";
            novaPf.Rendimento = 3500.5f;

            novoEndPf.Logradouro = "Alameda Barão de Limeira";
            novoEndPf.Numero = 539;
            novoEndPf.Complemento = "SENAI Informática";
            novoEndPf.endComercial = true;

            novaPf.Endereco = novoEndPf;

            Console.WriteLine(@$"

Nome: {novaPf.Nome}
Endereço: {novaPf.Endereco.Logradouro}, {novaPf.Endereco.Numero}
Maior de idade: {(metodosPf.ValidarDataNasc(novaPf.dataNasc) ? "Sim" : "Não")}
Imposto a ser pago: {metodosPf.PagarImposto(novaPf.Rendimento).ToString("C")}

");

// condição ? "Sim" : "Não"
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Digite ENTER para  continuar.");
            Console.ResetColor();
            Console.ReadLine();
            break;

        case "2":

            PessoaJuridica novaPj = new PessoaJuridica();
            PessoaJuridica metodosPj = new PessoaJuridica();
            Endereco novoEndPj = new Endereco();

            novaPj.Nome = "Nome Pj";
            novaPj.RazaoSocial = "Razão Social Pj";
            novaPj.Cnpj = "00.663.965/0001-64";
            novaPj.Rendimento = 10000.5f; //usar f no final pra forçar o valor ser tipo float

            novoEndPj.Logradouro = "Alameda Barão de Limeira";
            novoEndPj.Numero = 539;
            novoEndPj.Complemento = "Senai Informática";
            novoEndPj.endComercial = true;

            novaPj.Endereco = novoEndPj;

            Console.WriteLine(@$"

Nome: {novaPj.Nome}
Razão Social: {novaPj.RazaoSocial}
CNPJ: {novaPj.Cnpj}, Válido: {metodosPj.ValidarCnpj(novaPj.Cnpj)}
Endereço: {novaPj.Endereco.Logradouro}, {novaPj.Endereco.Numero}
Complemento: {novaPj.Endereco.Complemento}
Imposto a ser pago: {metodosPj.PagarImposto(novaPj.Rendimento).ToString("C")}

");
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
