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
            InputParms input = new InputParms(60,360,15,0.96, 0.99,0.91);
            Console.WriteLine(input.report);

            Excel excel = new Excel(input);


        }
    }
}

