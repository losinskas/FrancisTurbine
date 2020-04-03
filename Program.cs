/** 
 * Álgorimimo para a construção de uma turbina 
 * 
 * Paramêtros de entrada:
 *      Q (m/s³)    = Vazão de entrada 
 *      H (m)       = Altura de queda 
 *      n (rpm)     = Velocidade de rotação do rotor da turbina 
 */


using System;
using ConsoleApp3.Classe;
using ConsoleApp3.Classe.Tabelas;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            InputParms input = new InputParms(21.7,450,3.8,0.96);
            Console.WriteLine(input.report);



        }
    }
}

