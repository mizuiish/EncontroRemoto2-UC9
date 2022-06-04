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


novaPf.Endereco = novoEndPf;

Console.WriteLine(@$"

Nome: {novaPf.Nome}
Endereço: {novaPf.Endereco.Logradouro}, {novaPf.Endereco.Numero}
Maior de idade: {metodosPf.ValidarDataNasc(novaPf.dataNasc)}

");


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

");
