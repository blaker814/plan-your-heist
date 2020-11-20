using System;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");
            TeamMember heistMember = new TeamMember();
            Console.Write("Enter a team member's name: ");
            heistMember.Name = Console.ReadLine();
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
            Console.WriteLine(@$"Name: {heistMember.Name}
Skill level: {heistMember.SkillLevel}
Courage factor: {heistMember.CourageFactor}");
        }
    }
}
