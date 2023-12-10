using System.Security;
using System.Security.Cryptography.X509Certificates;

public class Day2
{
     public static void Day2Fix(FileStream fileStream)
    {
        using (var streamReader = new StreamReader(fileStream))
        {
            string line = "";
            List<int> numbers = new List<int>();
            List<int> part2Num = new List<int>();
            // one, two, three, four, five, six, seven, eight, and nine
            while ((line = streamReader.ReadLine()) != null)
            {
               // part1(line, numbers, part2Num);
               part2(line,part2Num);
            }
               
            // System.Console.WriteLine(string.Join(",",numbers));
            // System.Console.WriteLine(numbers.Sum());
            System.Console.WriteLine(part2Num.Sum());

        }
  
    }

    private static void part1(string line, List<int> numbers, List<int> part2Num)
    {
        Dictionary<string, int> config = new Dictionary<string, int>
                 {
                    {"red" , 12} ,
                    {"green" , 13},
                    {"blue",  14}
                    };

        var messageLine = line.Split(":");
        string gameId = string.Join("", messageLine[0].Where(x => char.IsDigit(x)).ToArray());

        bool success = true;

        Dictionary<string, int> minValues = new Dictionary<string, int>
                    {
                    {"red" , 0} ,
                    {"green" , 0},
                    {"blue",  0}
                    };
        foreach (var bag in messageLine[1].Split(";"))
        {

            foreach (var set in bag.Trim().Split(","))
            {
                var cub = set.Trim().Split(" ");
                if (minValues[cub[1]] < int.Parse(cub[0]))
                    minValues[cub[1]] = int.Parse(cub[0]);

                if (config[cub[1].ToString()] < int.Parse(cub[0].ToString()))
                {
                    success = false;
                    break;
                }
            }
            if (success == false)
                break;

        }

        if (success)
        {
            numbers.Add(int.Parse(gameId));
            part2Num.Add(minValues["red"] * minValues["blue"] * minValues["green"]);

        }

    }

      private static void part2(string line,  List<int> part2Num)
    {    

        var messageLine = line.Split(":");
        string gameId = string.Join("", messageLine[0].Where(x => char.IsDigit(x)).ToArray());

        bool success = true;

        Dictionary<string, int> minValues = new Dictionary<string, int>
                    {
                    {"red" , 1} ,
                    {"green" , 1},
                    {"blue",  1}
                    };
        foreach (var bag in messageLine[1].Split(";"))
        {

            foreach (var set in bag.Trim().Split(","))
            {
                var cub = set.Trim().Split(" ");
                if (minValues[cub[1]] < int.Parse(cub[0]))
                    minValues[cub[1]] = int.Parse(cub[0]);
                
            }
          
        }

        if (success)
        {
            part2Num.Add(minValues["red"] * minValues["blue"] * minValues["green"]);

        }

    }

}