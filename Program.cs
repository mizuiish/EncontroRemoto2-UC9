using CadastroPessoa.Classes;

PessoaFisica novaPf = new PessoaFisica();
PessoaFisica metodosPf = new PessoaFisica();
Endereco novoEndPf = new Endereco();

novaPf.Nome = "Nicolle";
novaPf.dataNasc = new DateTime (2000,01,01);

novaPf.Cpf = "1234567890";
novaPf.Rendimento = 3500.5f;

novoEndPf.Logradouro = "Alameda Barão de Limeira";
novoEndPf.Numero = 539;
novoEndPf.Complemento = "SENAI Informática";
novoEndPf.endComercial = true;


//Console.WriteLine(metodosPf.ValidarDataNasc("01/01/2000"));

novaPf.Endereco = novoEndPf;

Console.WriteLine(@$"

Nome: {novaPf.Nome}
Endereço: {novaPf.Endereco.Logradouro}, {novaPf.Endereco.Numero}
Maior de idade: {metodosPf.ValidarDataNasc(novaPf.dataNasc)}

");




