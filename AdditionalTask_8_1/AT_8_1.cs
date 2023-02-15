namespace AdditionalTask_8_1
{
    internal class AT_8_1
    {
        //static int MinSum(int[] massNum, int size)
        //{
        //    int quentity = size - 5, start = 0;
        //    int sum = Sum(0, 0), sumSearch;

        //    //int[] sums = new int[size - quentity];

        //    //for (int i = 0; i < sums.Length; i++)
        //    //{
        //    //    sums[i] = Sum(i,i);

        //    //    Console.WriteLine($"\nTatal result {sums[i]} index of {i}\n");
        //    //}

        //    int SearchMin(int startSearch, int numberOperation)
        //    {
        //        sumSearch = Sum(startSearch, startSearch);

        //        Console.WriteLine($"\nTatal result {sumSearch}");
        //        Console.WriteLine(new string('-', 80));

        //        if (sum > sumSearch)
        //            sum = sumSearch;

        //        if (startSearch == numberOperation)
        //            return sum;

        //        return SearchMin(startSearch + 1, numberOperation);
        //    }

        //    int Sum(int index, int repeat)
        //    {

        //        Console.WriteLine($"\nIndex {index}" +
        //            $"\nMass {massNum[index]}");

        //        if (index == 4 + repeat)
        //        {
        //            return massNum[index];
        //        }
        //        Console.WriteLine();
        //        return massNum[index] + Sum(index + 1, repeat);
        //    }

        //    return SearchMin(start, quentity);
        //}

        static int MinSum(int[] massNum, int size)
        {
            int range = 9;
            int minValue = Sum(0, 0), startIndex = 0, valueSum;

            for (int i = 0; i < size - range; i++)
            {
                valueSum = Sum(i,i);

                if(minValue > valueSum)
                {
                    minValue = valueSum;
                    startIndex = i;
                }

                Console.WriteLine($"\nTotal sum {valueSum} index of {i}");
            }

            int Sum(int index, int repeat) 
            {

                //Console.WriteLine($"Index {index}" +
                    //$"\nMass {massNum[index]}");
               
                if (index == range + repeat)
                {
                    return massNum[index];
                }

                //Console.WriteLine();
                return massNum[index] + Sum(index + 1, repeat);
            }

            return startIndex;
        }

        static void Main(string[] args)
        {
            // Напишите рекурсивную функцию, которая принимает одномерный массив из 100 целых чисел заполненных случайным образом
            // и находит позицию, с которой начинается последовательность из 10 чисел, сумма которых минимальна.

            int massivSize = 50, startSumMinIndex;
            int[] massivnumber = new int[massivSize];

            Random rnd = new Random();

            for (int i = 0; i < massivSize; i++)
            {
                massivnumber[i] = rnd.Next(-5, 5);

                if(i%10 == 0)
                    Console.WriteLine();

                Console.WriteLine(massivnumber[i]);
            }

            startSumMinIndex = MinSum(massivnumber, massivSize);

            Console.WriteLine($"\nMin index {startSumMinIndex} is number in massiv {massivnumber[startSumMinIndex]}");
        }
    }
}