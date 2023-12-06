namespace AoC2023_1
{
    internal class DaySix
    {
        public static void Execute()
        {
            var lines = File.ReadAllLines(@"c:\Users\danex\Documents\AoC2023\input6.txt");
            //part 1
            Console.WriteLine(lines[0]);
            var text = lines[0].Substring(10);
            var numbers = text.Split(' ');
            var time = new List<int>();
            foreach (var number in numbers)
            {
                if (string.IsNullOrWhiteSpace(number)) continue;
                time.Add(int.Parse(number));
            }
            Console.WriteLine(lines[1]);
            text = lines[1].Substring(10);
            numbers = text.Split(' ');
            var distance = new List<int>();
            foreach (var number in numbers)
            {
                if (string.IsNullOrWhiteSpace(number)) continue;
                distance.Add(int.Parse(number));
            }
            var index = 0;
            var results = new List<int>();
            while(index < time.Count)
            {
                var bigTime = time[index];
                results.Add(0);
                for(int i =0; i < bigTime; i++)
                {
                    var moved = (bigTime - i) * i;
                    if (moved > distance[index])
                    {
                        results[index]++;
                    }
                }
                index++;
            }
            var total = 1;
            foreach(var result in results)
            {
                total *= result;
            }
            Console.WriteLine(total);

            //part2
            text = lines[0].Substring(10);
            numbers = text.Split(' ');
            var temptime = "";
            foreach (var number in numbers)
            {
                if (string.IsNullOrWhiteSpace(number)) continue;
                temptime += number;
            }
            Console.WriteLine(lines[1]);
            text = lines[1].Substring(10);
            numbers = text.Split(' ');
            var tempdistance = "";
            foreach (var number in numbers)
            {
                if (string.IsNullOrWhiteSpace(number)) continue;
                tempdistance += number;
            }
            var singleresult = 0;
            var maxTime = long.Parse(temptime);
            var maxDistance = long.Parse(tempdistance);
            for (int i = 0; i < maxTime; i++)
            {
                var moved = (maxTime - i) * i;
                if (moved > maxDistance)
                {
                    singleresult++;
                }
            }
            Console.WriteLine(singleresult);
        }
    }
}
