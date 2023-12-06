namespace AoC2023_1
{
    internal class DayFive
    {
        public static void Execute()
        {
            var lines = File.ReadAllLines(@"c:\Users\danex\Documents\AoC2023\input5test.txt");
            //part 1
            var text = lines[0];
            text = text.Substring(7);
            var seedsTemp = new List<long>();
            var numbers = text.Split(' ');
            foreach(var number in numbers )
            {
                if (string.IsNullOrWhiteSpace(number)) continue;
                seedsTemp.Add(long.Parse(number));
            }
            var first = true;
            var seeds = seedsTemp.ToArray();
            var temp = new long[seeds.Length];
            seeds.CopyTo(temp, 0);
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                if (first) { first = false; continue; }
                if (line.Length == 0)
                {
                    temp.CopyTo(seeds, 0);
                    continue;
                }
                if (line.EndsWith(':')) continue;
                numbers = line.Split(' ');
                var destination = long.Parse(numbers[0]);
                var origin = long.Parse(numbers[1]);
                var range = long.Parse(numbers[2]);
                var i = 0;
               
                foreach(var seed in seeds)
                {
                    if (seed >= origin && seed <= origin + range - 1)
                    {
                        temp[i] = seed - origin + destination;
                    }
                    Console.WriteLine(i + " : " + temp[i]);
                    i++;
                }
                
            }
            Console.WriteLine(temp.Min());

            //part 2
            var seedRanges = new List<SeedRange>();
            int x = 0;
            while(x < numbers.Length)
            {
                seedRanges.Add(new SeedRange { start = long.Parse(numbers[x]), range = long.Parse(numbers[x + 1]) });
                x += 2;
            }
            first = true;
            var rangeTemp = new List<SeedRange>(seedRanges);
            /*
             * Load all mappings per group
             * process all mappings first
             * find mapping leading to lowest
             * 
             * go through input ranges
             * apply lowest mapping
             * compare to unmapped values
             * 
             * find lowest value
             */



            foreach (var line in lines)
            {
                Console.WriteLine(line);
                if (first) { first = false; continue; }
                if (line.Length == 0)
                {
                    seedRanges = new List<SeedRange>(rangeTemp);
                    continue;
                }
                if (line.EndsWith(':')) continue;
                numbers = line.Split(' ');
                var destination = long.Parse(numbers[0]);
                var origin = long.Parse(numbers[1]);
                var range = long.Parse(numbers[2]);
                var i = 0;
                foreach (var seedRange in seedRanges)
                {
                    //if (seed >= origin && seed <= origin + range - 1)
                    //{
                    //    temp[i] = seed - origin + destination;
                    //}
                    Console.WriteLine(i + " : " + temp[i]);
                    i++;
                }

            }
            Console.WriteLine(temp.Min());

        }
    }

    internal class SeedRange
    {
        public long start;
        public long range;
    }

    internal class Mapper
    {
        public long origin;
        public long range;
        public long destination;
    }
}
