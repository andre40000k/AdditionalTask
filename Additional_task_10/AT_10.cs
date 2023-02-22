using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace Additional_task_10
{
    internal class AT_10
    {
        public static int indexOfDead = 0;

        enum Words
        {
            bloated,
            believable,
            friendless,
            expectorant,
            burgundy,
            adaptable,
            build,
            ducky,
            backach
        }
        enum RangeWords
        {
            a,
            z
        }

        public static void ChoiceOfGuessingWord(out string wordSearch, out string wordHidden)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, 8);

            wordSearch = Convert.ToString((Words)randomIndex);

            int lenghtWordHidden = wordSearch.Length;
            wordHidden = new string('-', lenghtWordHidden);

            //Console.ReadKey();
        }

        static char CheckCharacter() 
        {
            char firstCharacter = Convert.ToChar(RangeWords.a.ToString()),
                lastCharacter = Convert.ToChar(RangeWords.z.ToString()),
                yourCharacter = '\0';

            try
            {
                yourCharacter = Convert.ToChar(Console.ReadLine());

                if (yourCharacter < firstCharacter || yourCharacter > lastCharacter)
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                Console.WriteLine("\nErrors!\nIncorrd data entry!\nRepeat data entry!\n");
                MinGame();
            }

            return yourCharacter;
        }

        static bool InputCharacter(string wordSearch, ref string wordHidden)
        {
            Console.WriteLine($"\nEntered your character (range from \"{RangeWords.a}\" to \"{RangeWords.z}\")");
            
            StringBuilder sbWordHidden = new StringBuilder(wordHidden);

            char character = CheckCharacter();
            int lenghtWord = wordSearch.Length;
            bool checkAvailability = false;

            for (int i = 0; i < lenghtWord; i++)
            {
                if(character == wordSearch[i])
                {
                    sbWordHidden[i] = character;
                    checkAvailability = true;
                }
            }

            wordHidden = sbWordHidden.ToString();

            return checkAvailability;
        }

        static bool CheckEmptyCharacter(string wordHidden)
        {            
            for (int i = 0; i < wordHidden.Length; i++)
            {
                if (wordHidden[i] == '-')
                {
                    return true;
                }
            }

            return false;
        }

        static bool MinGame()
        {           

            string searchWord, hiddenWord;
            int numberOfAttempts = 6;

            ChoiceOfGuessingWord(out searchWord, out hiddenWord);

            for (int i = 0; i < numberOfAttempts; i++)
            {
                if(InputCharacter(searchWord, ref hiddenWord))
                {
                    Console.WriteLine($"\n{hiddenWord}");
                    if (CheckEmptyCharacter(hiddenWord))
                    {
                        i--;
                    }

                    else
                    {
                        return true;
                    }                    
                }

                else
                {                    
                    switch (indexOfDead)
                    {
                        case 0:
                            Console.WriteLine("\nDrawing a head");
                            break;
                        case 1:
                            Console.WriteLine("\nDrawing a head, torso");
                            break;
                        case 2:
                            Console.WriteLine("\nDrawing a head, torso, right hand");
                            break;
                        case 3:
                            Console.WriteLine("\nDrawing a head, torso, right hand, left hand");
                            break;
                        case 4:
                            Console.WriteLine("\nDrawing a head, torso, right hand, left hand, right leg");
                            break;  
                        default:
                            Console.WriteLine("\nDrawing a head, torso, right hand, left hand, right leg, left leg");
                            return false;
                    }

                    indexOfDead++;
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello in game \"Veselnitza\"!");

            Console.WriteLine($"{(MinGame() == true ? "\nYou are win this game!" : "\nYou lose this game!")}");

        }
    }
}