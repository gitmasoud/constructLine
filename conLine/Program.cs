using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace conLine
{
    class Program
    {
        private readonly List<Array> _shirts;
        private static readonly Random _random = new Random();
        private int _numberOfShirts;

        static void Main(string[] args)
        {
            Console.WriteLine("Search engine starting...");
            //in this example we pass all options and exclude later on based on user input
            //in the search method. We can if we wanted add a loop to hold selected items
            Search("Small,Medium,Large", "Red,Blue,Yellow,White,Black");
        }

        //for small, medium and red the search engine 
        //should return shirts that are either small or medium in size and are red in color.
        //In this case, the SearchOptions should look like:
        //return small red
        public static void Search(string sizes, string colors)
        {
         
            //create shirts based of the helpers
            IEnumerable<Shirt> shirts = Enumerable.Range(0, 10)
            .Select(i => new Shirt(Guid.NewGuid(), $"Shirt {i}", GetRandomSize(), GetRandomColor()))
            .ToList();

            //loop through and choose what you need
            //in a real example this would come from user input
            //we hard code color choice since other wise return is random and we cant be sure we
            //receive our colour
            //1. show whole items in stock
            Console.WriteLine("Whole selection produced first");
            foreach (Shirt shirt in shirts)
            {
                Console.WriteLine(shirt.Name + " " + shirt.Size.Name + " " + shirt.Color.Name);
            }

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++");
            //2. for each shirt in list let user specify color and sizes
            int counter = 0;
            foreach (Shirt shirt in shirts)
            {
                
                var colorlist = colors.Split(",");
                var sizelist = sizes.Split(",");
                if (shirt.Color.Name.Contains("Red")) {
                    if (shirt.Size.Name == sizelist[0] || shirt.Size.Name == sizelist[1])
                    {
                        Console.WriteLine("You searched for Red and Small or Medium:" + shirt.Name + " " + shirt.Size.Name + " " + shirt.Color.Name);
                        counter++;
                    }
                } 
            }
            Console.WriteLine("The total amount of shirts are: " + counter);
        }
        public static bool IsAny<T>(IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
        private static Size GetRandomSize()
        {

            var sizes = Size.All;
            var index = _random.Next(0, sizes.Count);
            return sizes.ElementAt(index);
        }

        private static Color GetRandomColor()
        {
            var colors = Color.All;
            var index = _random.Next(0, colors.Count);
            return colors.ElementAt(index);
        }
    }
}