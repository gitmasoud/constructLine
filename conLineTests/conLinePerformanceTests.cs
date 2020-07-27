using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using conLine;

namespace conLineTests
{
    [TestClass]
    public class conLinePerformanceTests
    {
        private List<Shirt> shirts;
        private static readonly Random _random = new Random();

        [TestMethod]
        public void SearchPerformanceTest()
        {
            IEnumerable<Shirt> shirts = Enumerable.Range(0, 10)
            .Select(i => new Shirt(Guid.NewGuid(), $"Shirt {i}", GetRandomSize(), GetRandomColor()))
            .ToList();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // code to measure
            foreach (Shirt shirt in shirts)
            {
                if (shirt.Color.Name.Contains("Red"))
                {
                    if (shirt.Size.Name == "Small" || shirt.Size.Name == "Medium")
                    {
                        Console.WriteLine("You searched for Red and Small or Medium:" + shirt.Name + " " + shirt.Size.Name + " " + shirt.Color.Name);
                    }
                }
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Test fixture finished in {elapsedMs} milliseconds");
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
