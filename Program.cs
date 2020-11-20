using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");
            List<TeamMember> heistTeam = AssembleTeam();
            int numTries = GetNumTrials();
            Console.WriteLine($"Your heist team contains {heistTeam.Count} member(s)");
            Trials(numTries, heistTeam);
        }
        static void Trials(int attempts, List<TeamMember> team)
        {
            for (int i = 0; i < attempts; i++)
            {
                int luckValue = new Random().Next(-10, 10);
                Bank bank = new Bank(100 + luckValue);
                int totalSkill = team.Sum(member => member.SkillLevel);
                Console.WriteLine(@$"Team's combined skill level: {totalSkill}
Bank's difficulty level: {bank.DifficultyLevel}");
                if (totalSkill >= bank.DifficultyLevel)
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Heist failed");
                }
            }
        }
        static int GetNumTrials()
        {
            while (true)
            {
                Console.Write("How many trial runs should the program perform? ");
                try
                {
                    int tries = int.Parse(Console.ReadLine());
                    if (tries > 0)
                    {
                        return tries;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a positive integer");
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a positive integer");
                }
            }
        }
        static List<TeamMember> AssembleTeam()
        {
            List<TeamMember> heistTeam = new List<TeamMember>();
            while (true)
            {
                TeamMember heistMember = new TeamMember();
                Console.Write("Enter a team member's name: ");
                string stopLoop = Console.ReadLine();
                if (stopLoop == "")
                {
                    break;
                }
                heistMember.Name = stopLoop;
                while (true)
                {
                    Console.Write("Enter their skill level: ");
                    try
                    {
                        int skill = int.Parse(Console.ReadLine());
                        if (skill > 0)
                        {
                            heistMember.SkillLevel = skill;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a positive integer");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a positive integer");
                    }
                }
                while (true)
                {
                    Console.Write("Enter their courage factor (0.0 - 2.0): ");
                    try
                    {
                        double courage = double.Parse(Console.ReadLine());
                        if (courage >= 0 && courage <= 2)
                        {
                            heistMember.CourageFactor = courage;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number between 0.0 and 2.0");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number between 0.0 and 2.0");
                    }
                }
                heistTeam.Add(heistMember);
            }
            return heistTeam;
        }
    }
}