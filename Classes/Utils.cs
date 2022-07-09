namespace CadastroPessoa.Classes
{
    public class Utils
    {
        public static void VerificarPastaArquivo(string caminho){

            string pasta = caminho.Split("/")[0];
            
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            if (!File.Exists(caminho)){
                using(File.Create(caminho)){}
            }
        }
    }
}