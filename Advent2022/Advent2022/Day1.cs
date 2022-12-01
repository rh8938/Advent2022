namespace Advent2022
{
    public static class Day1
    {
        public static void Run()
        {
            List<int> totals = new List<int>();

            int runningTotal = 0;

            foreach (var line in File.ReadAllLines("Day1Input.txt"))
            {
                if (string.IsNullOrEmpty(line))
                {
                    totals.Add(runningTotal);
                    runningTotal = 0;
                    continue;
                }
                runningTotal += int.Parse(line);
            }

            Console.WriteLine("Part 1");
            var max = totals.Max();
            var elf = totals.IndexOf(max);
            Console.WriteLine($"Elf {elf} is carrying {max}");

            Console.WriteLine("Part 2");
            totals = totals.OrderByDescending(x => x).ToList();
            var total = totals[0] + totals[1] + totals[2];
            Console.WriteLine($"Top 3 elves are carrying {total}");

        }
    }
}
