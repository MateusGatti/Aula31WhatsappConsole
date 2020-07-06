using System.Collections.Generic;

namespace Aula31WhatsappConsole
{
    public interface IAgenda
    {
         
        void Cadastrar(Contato cont);
        void Excluir(Contato cont);
        List<Contato> Listar();
        


    }
}