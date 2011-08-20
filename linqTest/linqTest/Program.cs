﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace linqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] myStrings = 
            {
                "house",
                "car",
                "dog",
                "cat",
                "couch",
                "crazy",
                "crazyLongWord",
                "cc",
                "c",
                "castle"
            };

            var query = from str in myStrings
                        let length = str.Length
                        where str.StartsWith("c") &&
                        length >= 2
                        orderby length //descending
                        select new {Word = str, Length = length };
            foreach (var word in query)
            {
                Console.WriteLine("Word = {0}: Length is: {1}", word.Word, word.Length);
            }

            object[] myObjects = 
            {
                "house",
                "car",
                8,
                "cat",
                7,
                "crazy"
            };

            Console.WriteLine();
            Console.WriteLine("Object Array");
            IEnumerable<int> ints = myObjects.OfType<int>();
            Console.WriteLine("Total is : " + ints.Sum());
            foreach (int num in ints)
            {
                Console.WriteLine(num);
            }

            var doc = XDocument.Load("doc.xml");
            var sum = (from node in doc.Descendants("Sales")
                       select Convert.ToInt32(node.Value)).Sum();

            Console.WriteLine("Sum in xdoc is " + sum);
            Console.Read();
            // added a test comment first!

        }

    }
}
