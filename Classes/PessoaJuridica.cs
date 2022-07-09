using System.Text.RegularExpressions;
using CadastroPessoa.Interfaces;

namespace CadastroPessoa.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? Cnpj { get; set; }

        public string? RazaoSocial { get; set; }

        public string Caminho { get; private set; } = "Database/PessoaJuridica.csv";
        //caminho para ler o arquivo. Set com private para que esse caminho não possa ser alterado
        
        


        public override float PagarImposto(float rendimento)
        {
            if (rendimento > 3000)
            {
                return rendimento * .03f;

            }
            else if (rendimento <= 6000)
            {
                return rendimento * .05f;

            }
            else if (rendimento <= 10000)
            {
                return rendimento * .07f;

            }
            else
            {
                return rendimento * .09f;
            }
        }

        public bool ValidarCnpj(string cnpj)
        {
            //xx.xxx.xxx/0001-xx
            //xxxxxxxx0001xx
            bool retornoCnpjValido = Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)");

            // outro métodos de comparação com if que dariam o mesmo resultado        
            //if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            //if (retornoCnpjValido)

            if (retornoCnpjValido == true)
            {
                if (cnpj.Length == 18)
                {   //substring irá comparar o mil ao contrário do cnpj
                    //o primeiro argumento é a partir de que char vai começar a checar,
                    //o segundo argumento é a quantidade de chars
                    string subStringCnpj = cnpj.Substring(11, 4);
                    if (subStringCnpj == "0001")
                    {
                        return true;
                    }
                }
                else if (cnpj.Length == 14)
                {
                    string subStringCnpj = cnpj.Substring(8, 4);
                    if (subStringCnpj == "0001")
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        public void Inserir (PessoaJuridica pj){

            Utils.VerificarPastaArquivo(Caminho);

            string [] pjstrings = {$"{pj.Nome}, {pj.Cnpj}, {pj.RazaoSocial}"};

            File.AppendAllLines(Caminho, pjstrings);
        }

        public List<PessoaJuridica> LerArquivo(){
            
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();
            string [] linhas = File.ReadAllLines(Caminho);
            foreach (string cadaLinha in linhas)
            {
                string [] atributos = cadaLinha.Split(",");

                PessoaJuridica cadaPj = new PessoaJuridica();

                cadaPj.Nome = atributos [0];
                cadaPj.Cnpj = atributos [1];
                cadaPj.RazaoSocial = atributos [2];

                listaPj.Add(cadaPj);
            }

            return listaPj;

        }
    }
}