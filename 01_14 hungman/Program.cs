using System;
using System.Linq;

namespace _01_14_hungman
{
    class Program
    {
        //<summary>
        //word to be guessed
        //</summary>
        static String word;

        //<summary>
        //letters to guess the word
        //</summary>
        static char[] guess;


        //<summary>
        //lives 
        //</summary>
        static int lives;

        static string[] status = new string[] {

     "  _______\n"+
     " |/      |\n"+
     " |      (_)\n"+
     " |      \\|/\n"+
     " |       |\n"+
     " |      / \\\n"+
     " |        \n"+
    "_|___",

     "  _______\n"+
     " |/      |\n"+
     " |      (_)\n"+
     " |      \\|/\n"+
     " |       |\n"+
     " |        \n"+      
     " |       \n"+
    "_|___",

     " _______\n"+
     " |/    |\n"+
     " |    (_)\n"+
     " |    \\|/\n"+
     " |         \n"+
     " |         \n"+     
     " |         \n"+
    "_|___",

     " _______\n"+
     " |/    |\n"+
     " |    (_)\n"+
     " |         \n"+
     " |         \n"+
     " |         \n"+
     " |         \n"+
    "_|___      ",

     " _______\n"+
     " |/    |\n"+
     " |         \n"+
     " |         \n"+
     " |         \n"+
     " |         \n"+
     " |         \n"+
    "_|___     ",

     " _______\n"+
     " |/      \n"+
     " |         \n"+
     " |          \n"+
     " |          \n"+
     " |          \n"+
     " |         \n"+
    "_|___      ",

    " \n"+
    " |      \n"+
    " |         \n"+
    " |          \n"+
    " |          \n"+
    " |          \n"+
    " |         \n"+
   "_|___ "
        };



        static void Main(string[] args)
        {
            Update();

            Console.ReadKey();
        }

        static void Start()
        {
            Console.Clear();

            word = PickWord();

            BlankLetter();
            lives = 5;
        }

        static void Update()
        {
            Start();

            while (lives > 0)
            {
                PrintWord();
                PromptPlayer();
                string input = GetInput();
                CheckInput(input);
                CheckGameOver();
            }
           
        }

        static string PickWord()
        {
            string[] words = new string[]
            {
                "Cow",
                "Dog",
                "Cat",
                "Hen",
                "Die",
                "Inn",
                "Clear",
                "Orange",
                "Grey",
                "Game",
                "Play",
                "Change"
            };

            Random rnd = new Random();
           int index= rnd.Next(0, words.Length);

            return words[index].ToUpper();

        }

        static void BlankLetter()
        {
            guess = new char[word.Length];
            for(int i =0; i<guess.Length; i++)
            {
                guess[i] = '_';
            }
        }

        //<summary>
        //    Prints the word that we wants to guess
        //    </summary>
        
        static void PrintWord()
        {
            Console.WriteLine("Guess the word");

            for(int i =0; i<guess.Length; i++)
            {
                Console.Write(guess[i] + " ");
            }
            Console.WriteLine();
        }
        static void PromptPlayer()
        {
            Console.WriteLine("Enter a letter");
             if (lives < 5)
            {
                Console.WriteLine(status[lives]);

            }

           
        }

        static string GetInput()
        {
           string input = Console.ReadLine();

            input = input.ToUpper();

            return input;
        }

        static void CheckInput(string input)
        {
            bool correct = false;

            for(int i=0; i<word.Length; i++)
            {
                if (word[i] == input[0])
                {
                    guess[i] = input[0];
                    correct = true;
                }
            }

            if (!correct)
            {
                lives--;
            }
            Console.Clear();
        }

        static void CheckGameOver()
        {
            if (lives == 0)
            {
                Console.WriteLine("GAME OVER! \n");

                ShowEndScreen();
            }
            else if(!guess.Contains('_'))
            {
                Console.WriteLine("YOU WIN \n");

                ShowEndScreen();
            }
        }

        static void ShowEndScreen()
        {
            Console.WriteLine("The word was " +word);

            if (lives < 5)
            {
                Console.WriteLine(status[lives]);
            }

            Console.WriteLine("Press R to Restart and any Key to Quit");
            ConsoleKeyInfo r = Console.ReadKey();

            if(r.Key == ConsoleKey.R)
            {
                Start();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
