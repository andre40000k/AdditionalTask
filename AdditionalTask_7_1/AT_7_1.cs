namespace AdditionalTask_7_1
{
    internal class AT_7_1
    {
        static void ArrayFilling(int[,] massNum)
        {
            int startNumber = 0;

            try
            {
                Console.Write("Entered initial number: ");
                startNumber = int.Parse(Console.ReadLine());                
            }
            catch (Exception)
            {
                Console.WriteLine("\nErrors!\nIncorrd data entry!\nRepeat data entry!\n");
                ArrayFilling(massNum);
            }

            for (int i = 0; i < massNum.GetLength(0); i++)
            {
                for (int j = 0; j < massNum.GetLength(1); j++)
                {
                    massNum[i, j] = startNumber++;
                }
            }
        }

        static void Main(string[] args)
        {
            // Напишите программу, которая создает двухмерный массив и заполняет его по следующему принципу:
            // пользователь вводит число (например, 3) первый элемент массива принимает значение этого числа,
            // последующий элемент массива принимает значение этого числа + 1 (т.е. 4 для нашего примера),
            // третий элемент массива предыдущий элемент + 1 (т.е. 5 для нашего примера).
            // Созданный массив вывести на экран.

            Random rnd = new Random();

            int[,] massivNumbers = new int[rnd.Next(1,10), rnd.Next(1, 10)];

            ArrayFilling( massivNumbers);

            Console.WriteLine();

            for (int i = 0; i < massivNumbers.GetLength(0); i++)
            {
                for (int j = 0; j < massivNumbers.GetLength(1); j++)
                {
                    Console.Write($"{massivNumbers[i, j]}\t"); 
                }
                Console.WriteLine();
            }

        }
    }
}