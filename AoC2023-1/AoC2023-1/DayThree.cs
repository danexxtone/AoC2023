namespace AoC2023_1
{
    internal class DayThree
    {
        public static void Execute()
        {
            var lines = File.ReadAllLines(@"c:\Users\danex\Documents\AoC2023\input3.txt");
            //part 1
            var sum = 0;
            var x = 0;
            var values = new List<ValueLoc>();
            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                while (x < line.Length)
                {
                    if (line[x] >= '0' && line[x] <= '9')
                    {
                        var length = 1;
                        var partValue = int.Parse(line[x].ToString());
                        while (x + length < line.Length && line[x + length] >= '0' && line[x + length] <= '9')
                        {
                            partValue = partValue * 10 + int.Parse(line[x + length].ToString());
                            length++;
                        }
                        values.Add(new ValueLoc { x = x, y = y, value = partValue, length = length });
                        var isPart = false;
                        for (int i = x - 1; i <= x + length; i++)
                        {
                            if (i > -1 && i < line.Length)
                            {
                                if (y > 0)
                                {
                                    if (lines[y - 1][i] != '.' && (lines[y - 1][i] < '0' || lines[y - 1][i] > '9'))
                                    {
                                        isPart = true;
                                        break;
                                    }
                                }
                                if (y < line.Length - 1)
                                {
                                    if (lines[y + 1][i] != '.' && (lines[y + 1][i] < '0' || lines[y + 1][i] > '9'))
                                    {
                                        isPart = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (!isPart)
                        {
                            if (x > 0)
                            {
                                if (line[x - 1] != '.' && (line[x - 1] < '0' || line[x - 1] > '9'))
                                {
                                    isPart = true;
                                }
                            }
                        }
                        if (!isPart)
                        {
                            if (x + length < line.Length - 1)
                            {
                                if (line[x + length] != '.' && (line[x + length] < '0' || line[x + length] > '9'))
                                {
                                    isPart = true;
                                }
                            }
                        }
                        if (isPart)
                        {
                            sum += partValue;
                        }
                        x += length;
                    }
                    x++;
                }
                x = 0;
            }
            Console.WriteLine(sum);

            //part 2
            sum = 0;
            x = 0;
            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                while (x < line.Length)
                {
                    if (line[x] == '*')
                    {
                        var potential = values.Where(i => i.y >= y - 1 && i.y <= y + 1 && i.x <= x + 1 && i.x + i.length >= x ).ToList();
                        if (potential.Count == 2)
                        {
                            sum += potential[0].value * potential[1].value;
                        }
                    }
                    x++;
                }
                x = 0;
            }
            Console.WriteLine(sum);
        }
    }

    internal class ValueLoc
    {
        public int x;
        public int y;
        public int value;
        public int length;
    }
}
