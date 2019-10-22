using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");
            // Create a new instance of your TacoParser class
            var parser = new TacoParser();
            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops
            // DON'T FORGET TO LOG YOUR STEPS
            // Grab the path from the name of your file
            if (lines.Length == 0)
            {
                logger.LogError("Error: 0 lines accepted");
            }
            if (lines.Length == 1)
            {
                logger.LogWarning("Only 1 line Accepted");
            }

            var cordA = new GeoCoordinate();
            var cordB = new GeoCoordinate();

            double maxTrav = int.MinValue;
            double actualD;

            ITrackable locationOne = null;
            ITrackable locationTwo = null;

            for (int i = 0; i < locations.Length; i++)
            {
                cordA.Latitude = locations[i].Location.Latitude;
                cordA.Longitude = locations[i].Location.Longitude;
                for (int j = 0; j < locations.Length; j++)
                {
                    cordB.Latitude = locations[j].Location.Latitude;
                    cordB.Longitude = locations[j].Location.Longitude;
                    actualD = cordA.GetDistanceTo(cordB);

                    if (maxTrav < actualD)
                    {
                        maxTrav = actualD;
                        locationOne = locations[i];
                        locationTwo = locations[j];
                    }
                }
                
            }
            /*Console.WriteLine("________________________________________________");
            Console.WriteLine("These two Taco Bell's are the farthest apart.");
            Console.WriteLine("************************************************");
            Console.WriteLine(locationOne.Name + " " + locationTwo.Name);
            Console.WriteLine("________________________________________________");
            Console.ReadLine();*/
        }
    }
}