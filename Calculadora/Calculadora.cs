using System;


namespace ProgramaCalculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            //mostra titulo como um programa c# de calculadora.
            Console.WriteLine("Calculadora de console em C#\r");
            Console.WriteLine("-----------------------\n");

            Calculadora calculadora = new Calculadora();

            while (!endApp)
            {    //declara as variáveis e colaca elas com valor 0.
                string numInput1 = "";
                string numInput2 = "";
                double resultado = 0;

                //pergunta ao usuário para inserir o primeiro número
                Console.WriteLine("Insira um número, depois pressione Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.WriteLine("Este não é um valor válido. Por favor coloque um número inteiro: ");
                    numInput1 = Console.ReadLine();
                }

                //pergunta ao usuário para inserir o segundo número
                Console.Write("Insira um outro número, depois pressione Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.WriteLine("Este não é um valor válido. Por favor coloque um número inteiro: ");
                    numInput2 = Console.ReadLine();
                }

                //pergunte ao usuário qual operação realizar.
                Console.WriteLine("Escolha uma opção da lista abaixo:");
                Console.WriteLine("\ta - Adição");
                Console.WriteLine("\ts - Subtração");
                Console.WriteLine("\tm - Multiplicação");
                Console.WriteLine("\td - Divisão");
                Console.WriteLine("Qual opção? ");

                string op = Console.ReadLine();

                try
                {

                    resultado = calculadora.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(resultado))
                    {
                        Console.WriteLine("Esse operador resultará em um erro matemático \n");
                    }
                    else Console.WriteLine("Seu resultado: {0:0.##}\n", resultado);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Aconteceu um erro! Uma exceção foi encontrada tentando realizar o calculo.\n - Detalhes: " + e.Message);
                }

                Console.WriteLine("---------------------\n");

                //aguarda o usuário responder antes de fechar.
                Console.WriteLine("Pressione 'n' e Enter para fechar o aplicativo, ou pressiona qualquer tecla e Enter para continuar: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); //pula linha.
            }

            // Adiciona uma chamada para fechar o JSON antes do retorno
            calculadora.Finish();
            return;
        }

    }
}



