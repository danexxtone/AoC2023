namespace AoC2023_1
{
    internal class DayFour
    {
        public static void Execute()
        {
            var lines = File.ReadAllLines(@"c:\Users\danex\Documents\AoC2023\input4.txt");
            //part 1
            var sum = 0;
            foreach (var line in lines)
            {
                var text = line.Substring(9);
                var numbers = text.Split('|');
                var winning = new List<int>();
                var winningNumbers = numbers[0].Split(' ');
                foreach (var number in winningNumbers) 
                {
                    if(string.IsNullOrWhiteSpace(number)) continue;
                    winning.Add(int.Parse(number));
                }
                winning.Sort();
                var card = new List<int>();
                var cardNumbers = numbers[1].Split(" ");
                foreach(var number in cardNumbers)
                {
                    if(string.IsNullOrWhiteSpace(number)) continue;
                    card.Add(int.Parse(number));
                }
                card.Sort();
                var points = 0;
                foreach(var win in winning)
                {
                    if (card.Contains(win))
                    {
                        if (points == 0)
                        {
                            points = 1;
                        }else
                        {
                            points *= 2;
                        }
                    }
                }
                sum+=points;
            }
            Console.WriteLine(sum);

            //part 2
            var cards = new int[lines.Length+1];
            var index = 1;
            foreach (var line in lines)
            {
                var text = line.Substring(9);
                var numbers = text.Split('|');
                var winning = new List<int>();
                var winningNumbers = numbers[0].Split(' ');
                foreach (var number in winningNumbers)
                {
                    if (string.IsNullOrWhiteSpace(number)) continue;
                    winning.Add(int.Parse(number));
                }
                winning.Sort();
                var card = new List<int>();
                var cardNumbers = numbers[1].Split(" ");
                foreach (var number in cardNumbers)
                {
                    if (string.IsNullOrWhiteSpace(number)) continue;
                    card.Add(int.Parse(number));
                }
                card.Sort();
                var points = 0;
                cards[index]++;
                var times = cards[index];
                foreach (var win in winning)
                {
                    if (card.Contains(win))
                    {
                        points++;
                        cards[index + points] += times;
                    }
                }
                index++;
            }
            sum = 0;
            foreach(var numberOfCard in cards)
            {
                sum += numberOfCard;
            }
            Console.WriteLine(sum);
        }
    }
}
