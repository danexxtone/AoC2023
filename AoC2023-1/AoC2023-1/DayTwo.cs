namespace AoC2023_1
{
    internal class DayTwo
    {
        public static void Execute()
        {
            //part 1
            var lines = File.ReadAllLines(@"c:\Users\danex\Documents\AoC2023\input2.txt");
            var sum = 0;
            var red = 12;
            var green = 13;
            var blue = 14;
            var validLine = true;
            var index = 0;
            foreach (var line in lines)
            {
                index++;
                validLine = true;
                var text = line.Substring(line.IndexOf(':') + 2);
                var counts = text.Split(';');
                foreach (var count in counts)
                {
                    var validSet = true;
                    var colors = count.Split(",");
                    foreach (var color in colors)
                    {
                        var trimColor = color.Trim();
                        var number = int.Parse(trimColor.Split(' ')[0]);
                        if (trimColor.Contains("red"))
                        {
                            if (number > red)
                            {
                                validSet = false;
                                break;
                            }
                        }
                        else if (trimColor.Contains("blue"))
                        {
                            if (number > blue)
                            {
                                validSet = false;
                                break;
                            }
                        }
                        else
                        {
                            if (number > green)
                            {
                                validSet = false;
                                break;
                            }
                        }
                    }
                    if (!validSet)
                    {
                        validLine = false;
                        break;
                    }
                }
                if (validLine)
                {
                    sum += index;
                }
            }
            Console.WriteLine(sum);
            //part 2
            lines = File.ReadAllLines(@"c:\Users\danex\Documents\AoC2023\input2.txt");
            sum = 0;
            foreach (var line in lines)
            {
                red = 0;
                blue = 0;
                green = 0;
                var text = line.Substring(line.IndexOf(':') + 2);
                var counts = text.Split(';');
                foreach (var count in counts)
                {
                    var colors = count.Split(",");
                    foreach (var color in colors)
                    {
                        var trimColor = color.Trim();
                        var number = int.Parse(trimColor.Split(' ')[0]);
                        if (trimColor.Contains("red"))
                        {
                            if (number > red)
                            {
                                red = number;
                            }
                        }
                        else if (trimColor.Contains("blue"))
                        {
                            if (number > blue)
                            {
                                blue = number;
                            }
                        }
                        else
                        {
                            if (number > green)
                            {
                                green = number;
                            }
                        }
                    }
                }
                var total = red * blue * green;
                sum += total;
            }
            Console.WriteLine(sum);
        }
    }
}
