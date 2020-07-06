using System;
using System.Collections.Generic;

namespace Aula31WhatsappConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Agenda a = new Agenda();

            Contato c1 = new Contato("Mateus", "12312-1234");
            Contato c2 = new Contato("Mello", "12312-1234");
            Contato c3 = new Contato("Gatti", "12312-1234");

            a.Cadastrar(c1);
            a.Cadastrar(c2);
            a.Cadastrar(c3);

            a.Excluir(c1);

            foreach(Contato c in a.Listar()){
                System.Console.WriteLine($"Nome: {c.Nome} - Telefone: {c.Telefone}");
            }

            Mensagem msg = new Mensagem();
            msg.Destinatario = c1;
            msg.Texto = $"Olá {msg.Destinatario.Nome} como vai?";
            msg.Enviar();

        }
    }
}
