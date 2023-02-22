using System;
using System.Collections.Generic;

namespace SwimApp
{
    class Program
    {
        // Global varialbes
        static List<string> teamA = new List<string>();
        static List<string> teamB = new List<string>();
        static List<string> teamReserves = new List<string>();

        static float fastestTime = 9999f;
        static string topSwimmer = "";

        static void OneSwimmer()
        {
            Console.WriteLine("Enter the swimmers' name:");

            string swimmerName = Console.ReadLine();

            Console.WriteLine($"Swimmer name: {swimmerName}");

            int sumTotalTime = 0;

            // Loop 4 times
            for (int i = 0; i < 4; i++)
            {
                int minutes, seconds, totalTime = 0;

                // Generate a random number between 1 and 4 (incl)
                Random randomNumber = new Random();
                minutes = randomNumber.Next(1, 4);
                seconds = randomNumber.Next(0, 59);

                totalTime = (minutes * 60) + seconds;

                Console.WriteLine($"Swimmer time {i+1}: {minutes}  min {seconds}  seconds\t\tTotal time in seconds: {totalTime}s");

                sumTotalTime = sumTotalTime + totalTime;
            }
            float avgTime = (float)sumTotalTime / 4;

            if (avgTime < fastestTime)
            {
                fastestTime = avgTime;
                topSwimmer = swimmerName;
            }

            string allocatedTeam = "Reserve";

            // Assign the swimmer to a team
            if(avgTime <= 160)
            {
                teamA.Add(swimmerName);
                allocatedTeam = "A";
            }
            else if(avgTime <= 210)
            {
                teamB.Add(swimmerName);
                allocatedTeam = "B";
            }
            else
            {
                teamReserves.Add(swimmerName);
            }

            Console.WriteLine($"Avg time: {avgTime}");

            Console.WriteLine($"Team: {allocatedTeam}");
        }

        // return a string containing the team lists
        static string CreateTeamLists()
        {
            string teamLists = "The teams are:\n\nTeam A\n";

            // add team A to team lists
            foreach(string swimmer in teamA)
            {
                teamLists += swimmer + "\t";
            }
            teamLists += $"\nwith {teamB.Count} team member(s)\n\nTeam \n";
            // add team B to team lists
            foreach (string swimmer in teamB)
            {
                teamLists += swimmer + "\t";
            }
            teamLists += $"\nwith {teamB.Count} team member(s)\n\nTeam Reserves\n";
            // add team Reserves to team lists
            foreach (string swimmer in teamReserves)
            {
                teamLists += swimmer + "\t";
            }
            teamLists += $"\nwith {teamReserves.Count} team member(s)\n\n";

            return teamLists;
        }

        static void Main(string[] args)
        {
            string flag = "";
            while (!flag.Equals("Stop"))
            {
                OneSwimmer();

                Console.WriteLine("Press <Enter> to add anther swimmer or type 'Stop' to end");
                flag = Console.ReadLine();
            }

            Console.WriteLine($"The fastest swimmer was {topSwimmer} with an average time of {fastestTime} seconds\n");

            Console.WriteLine(CreateTeamLists());
        }
    }
}
