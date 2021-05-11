using System;
using Microsoft.Build.Evaluation;

namespace CsprojParsingNfprojGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Make sure you have the 6.0.100-preview.3.21202.5 installed

            // Open existing project
            // Project project = new Project(@"C:\Repos\iot\src\devices\AD5328\AD5328.csproj");
            Project project = new Project(@"C:\Repos\iot\src\devices\Card\CreditCard\CreditCardProcessing.csproj");

            Console.WriteLine("Project Properties");
            Console.WriteLine("----------------------------------");

            // All available items:
            foreach (var propertyGroup in project.Items)
            {
                    Console.WriteLine($"{propertyGroup.ItemType}, {propertyGroup.EvaluatedInclude}");
            }

            // Interesting ones are Compile and ProjectReferenc and PackeReference
            // WARNING:
            // To get the full list of elements to compile, you need to check if <EnableDefaultItems>false</EnableDefaultItems> is present in the csproj
            // If not, then **all** the *.cs files present in all the subdirectory has to be added
            // If yes, then **only** the Compile items has to be added!
        }
    }
}
