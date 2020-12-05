using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            while (true)
            {
                Console.WriteLine("Enter X coord");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Y coord");
                int y = int.Parse(Console.ReadLine());
                coord grid = new coord(x, y); 
                long tote = gridTraveler(grid, new Dictionary<coord, long>());
                Console.WriteLine("The results are : " + tote);

                string exit = Console.ReadLine();
                if (exit.ToLower() == "x") break;
            }

        }

        struct coord
        {
            public int x;
            public int y;

            public coord(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }

        static long gridTraveler(coord grid, Dictionary<coord, long> memo)
        {
            if (memo.ContainsKey(grid))
            {
                return memo[grid];
            }
            if (grid.x == 1 & grid.y == 1) return 1;
            if (grid.x == 0 || grid.y == 0) return 0;
            memo[grid] = gridTraveler(new coord(grid.x - 1, grid.y), memo) + gridTraveler(new coord(grid.x, grid.y - 1), memo);
            return memo[grid];
        }
    }
}
