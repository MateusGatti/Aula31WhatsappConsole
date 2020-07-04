namespace Aula31WhatsappConsole
{
    public class Mensagem
    {
        
        public string Texto { get; set; }
        public string Destinatario { get; set; }

        public string Enviar(string _contato){

            return "Mensagem enviada.";

        }

    }
}