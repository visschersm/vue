using System;
using System.Collections.Generic;

namespace TravelingSalesman
{
    class Program
    {
        public class Coordinate
        {
            public int x, y;
        };

        static void Main(string[] args)
        {
            int amountOfCoordinates = 10;

            Random random = new Random();

            List<Coordinate> coordinates = new List<Coordinate>();

            for (int i = 0; i < amountOfCoordinates; ++i)
            {
                coordinates.Add(new Coordinate
                {
                    x = random.Next(),
                    y = random.Next()
                });
            }
        }


    }
}
