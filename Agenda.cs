using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aula31WhatsappConsole
{
    public class Agenda : IAgenda
    {

        private const string PATH = "Database/agenda.csv";
        List<Contato> contatos = new List<Contato>();

        /// <summary>
        /// Método para criar a pasta e o CSV
        /// </summary>
        public Agenda()
        {
            string pasta = PATH.Split('/')[0];

            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }

            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        /// <summary>
        /// Adiciona os contatos ao csv
        /// </summary>
        /// <param name="cont">contato a ser adicionado</param>
        public void Cadastrar(Contato cont)
        {
            var linha = new string[] { PrepararLinhaCSV (cont) };
            File.AppendAllLines (PATH, linha);
        }

        /// <summary>
        /// Prepara a linha para ser colocada no csv
        /// </summary>
        /// <param name="c">Contato a ser colocado na linha preparada</param>
        /// <returns>Linha preparada</returns>
        public string PrepararLinhaCSV(Contato c){

            return $"nome={c.Nome};telefone={c.Telefone}";

        }

        /// <summary>
        /// Exclui 1 ou mais termos selecionados no csv
        /// </summary>
        /// <param name="cont">contato a ser excluido</param>
        public void Excluir(Contato cont)
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
            
            linhas.RemoveAll(x => x.Contains(cont.Nome));
            ReescreverCSV(linhas);

        }

        /// <summary>
        /// Lista todos os contatos do csv
        /// </summary>
        /// <returns>Lista com contatos</returns>
        public List<Contato> Listar()
        {
            string[] linhas = File.ReadAllLines(PATH);

            foreach(string linha in linhas){

                string[] dado = linha.Split(";");
                Contato c = new Contato(dado[0], dado[1]);
                contatos.Add(c);
            }

            contatos = contatos.OrderBy(y => y.Nome).ToList();
            
            return contatos;
        }

        /// <summary>
        /// Reescreve o csv
        /// </summary>
        /// <param name="lines">linhas a serem reescritas</param>
        private void ReescreverCSV(List<string> lines){

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
