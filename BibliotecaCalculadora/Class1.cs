using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;


namespace ProgramaCalculadora
{
    public class Calculadora
    {

        JsonWriter writer;
        public Calculadora()
        {
            StreamWriter logFile = File.CreateText("calculatorLog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operações");
            writer.WriteStartArray();

        }
        public  double DoOperation(double num1, double num2, string op)
        {

            double resultado = double.NaN; // valor padrão é um "não-numero" se uma operação, como divisão, poderá resultar em um erro.
            writer.WriteStartObject();
            writer.WritePropertyName("Operador1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operador1");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operação");
            //usar um switch case para fazer o cálculo matemático

            switch (op)
            {
                case "a":
                    resultado = num1 + num2;
                    writer.WriteValue("Adição");
                    break;
                case "s":
                    resultado = num1 - num2;
                    writer.WriteValue("Adição");
                    break;
                case "m":
                    resultado = num1 * num2;
                    writer.WriteValue("Multiplicação");
                    break;
                case "d":
                    //peça ao usuário para colocar um numero não divisor por 0.
                    if (num2 != 0)
                    {
                        resultado = num1 / num2;
                        writer.WriteValue("Divisão");
                    }
                    break;
                // retorne texto para uma entrada incorreta.
                default:
                    break;
            }

            writer.WritePropertyName("Resultado");
            writer.WriteValue(resultado);
            writer.WriteEndObject();
            return resultado;
        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();

        }
        
    }
}
