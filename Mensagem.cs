namespace Aula31WhatsappConsole
{
    public class Mensagem
    {
        
        public string Texto { get; set; }
        public Contato Destinatario { get; set; }

        public string Enviar(){

            return $"Para: {Destinatario.Nome} \nMensagem: {Texto}";

        }

    }
}