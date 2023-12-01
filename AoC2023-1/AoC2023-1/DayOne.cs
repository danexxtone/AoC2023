namespace AoC2023_1
{
    internal class DayOne
    {        public static void Execute()
        {
            var lines = File.ReadAllLines(@"c:\Users\danex\Documents\AoC2023\input1.txt");
            var sum = 0;
            foreach (var line in lines)
            {
                var first = false;
                var temp = 0;
                var last = 0;
                for (int index = 0; index < line.Length; index++)
                {
                    //Part one of Day one
                    if (line[index] >= '0' && line[index] <= '9')
                    {
                        if (!first)
                        {
                            temp = ((int)line[index] - 48) * 10;
                            first = true;
                        }
                        last = (int)line[index] - 48;
                    }
                    //Adding part two of Day One
                    else
                    {
                        var word = line.Substring(index);
                        var number = 0;
                        if (word.StartsWith("one"))
                        {
                            number = 1;
                        }
                        else if (word.StartsWith("two"))
                        {
                            number= 2;
                        }
                        else if (word.StartsWith("three"))
                        {
                            number= 3;
                        }
                        else if (word.StartsWith("four"))
                        {
                            number = 4;
                        }
                        else if (word.StartsWith("five"))
                        {
                            number = 5;
                        }
                        else if (word.StartsWith("six"))
                        {
                            number = 6;
                        }
                        else if (word.StartsWith("seven"))
                        {
                            number = 7;
                        }
                        else if (word.StartsWith("eight"))
                        {
                            number = 8;
                        }
                        else if (word.StartsWith("nine"))
                        {
                            number = 9;
                        }
                        if (number > 0)
                        {
                            if (!first)
                            {
                                temp = number * 10;
                                first = true;
                            }
                            else
                            {
                                last = number;
                            }
                        }
                    }
                }
                Console.WriteLine(temp + last);
                sum += temp + last;
            }
            Console.WriteLine(sum);
        }
    }
}
