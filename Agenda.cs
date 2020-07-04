using System.Collections.Generic;
using System.IO;

namespace Aula31WhatsappConsole
{
    public class Agenda : IAgenda
    {
        
        List<Contato> contatos = new List<Contato>();

        private const string PATH = "Database/Agenda.csv";

        public Agenda(){

            if(!(Directory.Exists(PATH))){
                Directory.CreateDirectory("Database");
            }
            if(!(File.Exists(PATH))){
                File.Create(PATH).Close();
            }
        }
        /// <summary>
        /// Adiciona um contato ao CSV
        /// </summary>
        /// <param name="_adicionarContato">contato a ser adicionado</param>
        public void Cadastrar(Contato _adicionarContato)
        {
            var linha = new string[] { PrepararCSV(_adicionarContato) };
            File.AppendAllLines(PATH, linha);
        }


        /// <summary>
        /// Exclui um ou mais contatos do csv
        /// </summary>
        /// <param name="_contato">contato a ser removido</param>
        public void Excluir(string _excluirContato)
        {
            List<string> linhas = new List<string>();

            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            linhas.RemoveAll(x => x.Contains(_excluirContato));

            ReescreverCSV(linhas);
        }


        /// <summary>
        /// Lista todos os itens do CSV
        /// </summary>      
        public void Listar()
        {
            List<string> linhas = new List<string>();
            using(StreamReader leitor = new StreamReader(PATH)){

                string linha;

                while((linha = leitor.ReadLine()) != null){

                    System.Console.WriteLine($" Nome: {linha.Split(";")[0].Split("=")[1]} - Telefone: {linha.Split(";")[1].Split("=")[1]}");

                }
            }
    
        }


        /// <summary>
        /// Prepara o "layout" do CSV
        /// </summary>
        /// <param name="adicionarContato">contato a ser adicionado</param>
        /// <returns>linha pronta para ser adicionada no csv</returns>
        private string PrepararCSV(Contato adicionarContato){

            return $"nome={adicionarContato.Nome};telefone={adicionarContato.Telefone}";

        }


        /// <summary>
        /// Separa os argumentos do CSV
        /// </summary>
        /// <param name="_coluna">separador</param>
        /// <returns>linha separada</returns>
        private string Separar(string _coluna){

            return _coluna.Split("=")[0];

        }

        /// <summary>
        /// Reescreve o csv
        /// </summary>
        /// <param name="lines"></param>
        private void ReescreverCSV(List<string> lines){
            // Reescrevemos nosso csv do zero
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in lines)
                {
                    output.Write(ln + "\n");
                }
            }   
        }
    }
}
