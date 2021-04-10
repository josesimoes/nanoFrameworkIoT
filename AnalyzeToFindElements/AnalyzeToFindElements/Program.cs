using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AnalyzeToFindElements
{
    class Program
    {
        private static int _totalFilesAnalyzed = 0;
        private static int _totalFilesWithPotentialIssues = 0;
        private static int _totalFilesToBeTRansformed = 0;
        private static int _totalBindings = 0;
        private static int _totalBindingsWithPotentialIssues = 0;
        private static int _totalTransformationNeeded = 0;
        private static int _totalNumberUnitsNet = 0;
        private static List<string> _units = new List<string>();
        private static List<string> _unitsUsed = new List<string>();

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello .NET IoT Analyzer!");

            string pathToSearch = string.Empty;
            string pathToUnitsNet = string.Empty;
            if (args?.Length > 0)
            {
                pathToSearch = args[0];
                if (args.Length > 1)
                {
                    pathToUnitsNet = args[1];
                }
            }

            pathToSearch = string.IsNullOrEmpty(pathToSearch) ? @"C:\Repos\iot\src\devices" : pathToSearch;
            pathToUnitsNet = string.IsNullOrEmpty(pathToUnitsNet) ? @"C:\Repos\UnitsNet\UnitsNet\GeneratedCode\Quantities" : pathToUnitsNet;

            LoadAllUnits(pathToUnitsNet);

            ProcessAllFiles(pathToSearch, true);

            Console.WriteLine($"Total number of root folders (bindings): {_totalBindings}");
            Console.WriteLine($"Total potential bindings which will need transformations: {_totalTransformationNeeded}");
            Console.WriteLine($"Total potential bindings with potential issues (async, Linq and other simple Span<byte> transformation): {_totalBindingsWithPotentialIssues}");
            Console.WriteLine($"Total number of files containing UnitsNet: {_totalNumberUnitsNet}");
            _unitsUsed = _unitsUsed.Distinct().ToList();
            foreach (var unit in _unitsUsed)
            {
                Console.WriteLine($"  {unit}");
            }

            Console.WriteLine($"Total files analyzed: {_totalFilesAnalyzed}");
            Console.WriteLine($"Total files with potential issues: {_totalFilesWithPotentialIssues}");
        }

        private static void LoadAllUnits(string pathToUnitsNet)
        {
            foreach (var file in Directory.GetFiles(pathToUnitsNet, "*.g.cs"))
            {
                string nameOnly = file.Substring(file.LastIndexOf("\\") + 1);
                nameOnly = nameOnly.Substring(0, nameOnly.Length - 5);
                _units.Add(nameOnly);
            }
        }

        private static (bool issue, bool transofmration) ProcessAllFiles(string directory, bool isRoot = false)
        {
            bool issuesInDirectory = false;
            bool transformationNeeded = false;

            foreach (var file in Directory.GetFiles(directory, "*.cs"))
            {
                using (var reader = new StreamReader(file))
                {
                    bool somethingFound = false;
                    var textFile = reader.ReadToEnd();

                    var result = SearchForSpanListT(textFile);

                    if (result.Count > 0)
                    {
                        Console.WriteLine($"{file}");
                        var distincts = result.Select(m => m.Groups[0].Value).Distinct();
                        foreach (var res in distincts)
                        {
                            if (res.Contains("Span<byte>"))
                            {
                                transformationNeeded = true;
                            }
                            else
                            {
                                somethingFound = true;
                            }

                            Console.WriteLine($"  {res} - count: {result.Count(m => m.Value == res)}");
                        }
                    }

                    var isAsync = IsAsyncSomewhere(textFile);

                    if (isAsync)
                    {
                        if (!somethingFound)
                        {
                            Console.WriteLine($"{file}");
                        }

                        somethingFound = true;
                        Console.WriteLine("  Contains some async potentially");
                    }

                    var isLinq = IsLinq(textFile);

                    if (isLinq)
                    {
                        if (!somethingFound)
                        {
                            Console.WriteLine($"{file}");
                        }

                        somethingFound = true;
                        Console.WriteLine("  Linq found");
                    }

                    var isUnitsNet = IsUnitsNet(textFile);

                    if (isUnitsNet)
                    {
                        if (!somethingFound)
                        {
                            Console.WriteLine($"{file}");
                        }

                        _totalNumberUnitsNet++;
                        somethingFound = true;
                        Console.WriteLine("  Contains UnitsNet:");

                        var units = FindUntis(textFile);
                        foreach (var unit in units)
                        {
                            Console.WriteLine($"    {unit}");
                        }

                        _unitsUsed.AddRange(units);
                    }

                    if (somethingFound)
                    {
                        _totalFilesWithPotentialIssues++;
                    }

                    _totalFilesAnalyzed++;
                    issuesInDirectory |= somethingFound;
                }

            }

            foreach (var dir in Directory.GetDirectories(directory))
            {
                if ((dir.EndsWith("samples")) || dir.EndsWith("tests"))
                {
                    continue;
                }

                var (potentialIssue, transfo) = ProcessAllFiles(dir, false);
                issuesInDirectory |= potentialIssue;
                transformationNeeded |= transfo;

                if (isRoot)
                {
                    _totalBindings++;

                    if (potentialIssue)
                    {
                        _totalBindingsWithPotentialIssues++;
                    }
                    else if (transformationNeeded)
                    {
                        _totalTransformationNeeded++;
                    }
                }
            }

            return (issuesInDirectory, transformationNeeded);
        }

        private static MatchCollection SearchForSpanListT(string textFile)
        {

            string pattern = @"\w+<\w*>";
            var result = Regex.Matches(textFile, pattern);
            return result;

        }

        private static bool IsAsyncSomewhere(string textFile)
        {
            bool contains = textFile.Contains(" async ");
            contains |= textFile.Contains("await ");
            return contains;
        }

        private static bool IsLinq(string textfile)
        {
            return textfile.Contains("using System.Linq;");
        }

        private static bool IsUnitsNet(string textfile)
        {
            return textfile.Contains("using UnitsNet;");
        }

        private static List<string> FindUntis(string textfile)
        {
            List<string> units = new List<string>();
            // We need to find patterns where there are possibly one of the Unit.
            // They are either in a property, either in a function
            // There muyst be a private or public or internal or protected in front in the same line and spaces before and after
            // Typical example:
            // public virtual RelativeHumidity Humidity
            // And we have to do it for all units
            foreach (var unit in _units)
            {
                string pattern = $"\\s((public)|(protected)|(internal)|(private))\\w*( {unit} )";
                var result = Regex.Matches(textfile, pattern);
                if (result.Count > 0)
                {
                    units.Add(unit);
                }
            }
            return units.Distinct().ToList();
        }
    }
}
