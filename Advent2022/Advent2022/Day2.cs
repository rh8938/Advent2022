using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2022
{

    public static class Day2
    {
        public enum RPS
        {
            Rock,
            Paper,
            Scissors,
            None
        }


        public static void Run()
        {
            Console.WriteLine("Part 1");
            int score = 0;



            foreach (var line in File.ReadAllLines("Day2Input.txt"))
            {
                var plan = line.Split(" ");
                var p1Choice = RPS.None;
                var p2Choice = RPS.None;
                p1Choice = plan[0] == "A" ? RPS.Rock : plan[0] == "B" ? RPS.Paper : RPS.Scissors;
                p2Choice = plan[1] == "X" ? RPS.Rock : plan[1] == "Y" ? RPS.Paper : RPS.Scissors;
                score += GetP2Score(p1Choice, p2Choice);

            }
            Console.WriteLine(score);


            Console.WriteLine("Part 2");
            int scoreP2 = 0;

            foreach (var line in File.ReadAllLines("Day2Input.txt"))
            {
                var plan = line.Split(" ");
                var p1Choice = RPS.None;
                var p2Choice = RPS.None;
                p1Choice = plan[0] == "A" ? RPS.Rock : plan[0] == "B" ? RPS.Paper : RPS.Scissors;
                if (plan[1] == "Y")
                {
                    p2Choice = p1Choice;
                }
                else if (plan[1] == "Z")
                {
                    switch (p1Choice)
                    {
                        case RPS.Rock:
                            p2Choice = RPS.Paper;
                            break;
                        case RPS.Paper:
                            p2Choice = RPS.Scissors;
                            break;
                        case RPS.Scissors:
                            p2Choice = RPS.Rock;
                            break;
                        case RPS.None:
                            throw new Exception("FAULTED");
                        default:
                            break;
                    }
                }
                else
                {
                    switch (p1Choice)
                    {
                        case RPS.Rock:
                            p2Choice = RPS.Scissors;
                            break;
                        case RPS.Paper:
                            p2Choice = RPS.Rock;
                            break;
                        case RPS.Scissors:
                            p2Choice = RPS.Paper;
                            break;
                        case RPS.None:
                            throw new Exception("FAULTED");
                        default:
                            break;
                    }
                }
                var s = GetP2Score(p1Choice, p2Choice);
                //Console.WriteLine(line);
                //Console.WriteLine(s);
                scoreP2 += s;
            }
            Console.WriteLine(scoreP2);
        }

        public static int GetP2Score(RPS p1, RPS p2)
        {
            int score = 0;

            switch (p2)
            {
                case RPS.Rock:
                    score += 1;
                    break;
                case RPS.Paper:
                    score += 2;
                    break;
                case RPS.Scissors:
                    score += 3;
                    break;
                default:
                    break;
            }

            if (p1 == p2)
            {
                return score += 3;
            }

            if (p1 == RPS.Rock && p2 == RPS.Paper)
            {
                score += 6;
                return score;
            }
            if (p1 == RPS.Paper && p2 == RPS.Scissors)
            {
                score += 6;
                return score;
            }
            if (p1 == RPS.Scissors && p2 == RPS.Rock)
            {
                score += 6;
                return score;
            }

            return score;
        }


        public static void Run2()
        {
            Console.WriteLine("Part 1.2");

            IDictionary<string, int> scores = new Dictionary<string, int>();
            scores.Add("A X", 4);
            scores.Add("A Y", 8);
            scores.Add("A Z", 3);

            scores.Add("B X", 1);
            scores.Add("B Y", 5);
            scores.Add("B Z", 9);

            scores.Add("C X", 7);
            scores.Add("C Y", 2);
            scores.Add("C Z", 6);

            int scoreMethod2 = 0;
            foreach (var line in File.ReadAllLines("Day2Input.txt"))
            {
                scoreMethod2 += scores.First(x => x.Key == line).Value;
            }

            Console.WriteLine(scoreMethod2);

            Console.WriteLine("Part 2.2");
            scores.Clear();

            scores.Add("A X", 3);
            scores.Add("A Y", 4);
            scores.Add("A Z", 8);

            scores.Add("B X", 1);
            scores.Add("B Y", 5);
            scores.Add("B Z", 9);

            scores.Add("C X", 2);
            scores.Add("C Y", 6);
            scores.Add("C Z", 7);

            scoreMethod2 = 0;
            foreach (var line in File.ReadAllLines("Day2Input.txt"))
            {
                scoreMethod2 += scores.First(x => x.Key == line).Value;
            }

            Console.WriteLine(scoreMethod2);
        }
    }
}

