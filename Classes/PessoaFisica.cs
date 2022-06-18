using CadastroPessoa.Interfaces;

namespace CadastroPessoa.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? Cpf { get; set; }

        public DateTime dataNasc { get; set; }

        public override float PagarImposto(float rendimento)
        {

            if (rendimento < 1500)
            {
                return 0;

            }
            else if (rendimento > 1500 && rendimento <= 3500)
            {
                float resultado = (rendimento / 100) * 2;

                return resultado;

            }
            else if (rendimento > 350 && rendimento <= 6000)
            {
                float resultado = (rendimento / 100) * 3.5f;

                return resultado;

            }
            else
            {
                float resultado = (rendimento / 100) * 5;

                return resultado;
            }
        }

        public bool ValidarDataNasc(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 365;

            if (anos >= 18)
            {
                return true;
            }
            return false;
        }

        public bool ValidarDataNasc(string dataNasc)
        {
            //tryParse irá fazer a conversão, primeiro argumento recebe o valor a ser convertido
            //segundo argumento recebe out que será a conversão
            DateTime dataConvertida;

            if (DateTime.TryParse(dataNasc, out dataConvertida))
            {
                DateTime dataAtual = DateTime.Today;

                double anos = (dataAtual - dataConvertida).TotalDays / 365;

                if (anos >= 18)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}