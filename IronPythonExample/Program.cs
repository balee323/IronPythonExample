using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronPythonExample
{
    class Program
    {
        static void Main(string[] args)
        {

            var game = new CreateGameInstance();
            game.SpinUpGameInstance();

            bool keepPlaying = true;

            while (keepPlaying)
            {

                Console.WriteLine("Please make a guess");
                var guess = int.Parse(Console.ReadLine());
                game.MakeAGuess(guess);


                Console.WriteLine("Do you want to guess again? Y/N");
                var decision = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                
                if(decision.KeyChar == 'Y' || decision.KeyChar == 'y')
                {
                    keepPlaying = true;
                }
                else
                {
                    keepPlaying = false;
                }
            }

        }
    }
}
