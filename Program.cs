using System;
using System.Collections.Generic;

namespace Aula31WhatsappConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Contato c = new Contato();
            Agenda a = new Agenda();
            c.Nome = "João";
            c.Telefone = "845612584";
            
            a.Cadastrar(c);
            a.Excluir("João");

            a.Listar();

            
            
        }
    }
}
