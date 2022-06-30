using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiValueDictionary
{
    class Program
    {
        public static MultiValueDictionary dictionary = new MultiValueDictionary();
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();
                Console.WriteLine("You entered " + input);
                ProcessRequest(input);
            }
        }

        public static void ProcessRequest(string input)
        {
            List<string> inputWords = input.Split(" ").ToList();
            switch (inputWords.First())
            {
                case "KEYS":
                    if (inputWords.Count != 1)
                    {
                        Console.WriteLine("ERROR, Incorrect Input");
                    }
                    else
                    {
                        List<string> keys = dictionary.GetKeys();
                        if (keys == null)
                        {
                            Console.WriteLine("empty set");
                        }
                        else
                        {
                            int keyCount = 1;
                            foreach (var key in keys)
                            {
                                Console.WriteLine($"{keyCount}) {key}");
                                keyCount++;
                            }
                        }
                    }
                    break;
                case "MEMBERS":
                    if (inputWords.Count != 2)
                    {
                        Console.WriteLine("ERROR, Incorrect Input");
                    }
                    else
                    {
                        List<string> members = dictionary.GetMembers(inputWords[1]);
                        if (members == null)
                        {
                            Console.WriteLine("Error, Key does not exist.");
                        }
                        else
                        {
                            int memberCount = 1;
                            foreach (var member in members)
                            {
                                Console.WriteLine($"{memberCount}) {member}");
                                memberCount++;
                            }
                        }
                    }
                    break;
                case "ADD":
                    if (inputWords.Count != 3)
                    {
                        Console.WriteLine("ERROR, Incorrect Input");
                    }
                    else
                    {
                        bool result = dictionary.add(inputWords[1], inputWords[2]);
                        if (result)
                        {
                            Console.WriteLine("Added");
                        }
                        else
                        {
                            Console.WriteLine("ERROR, member already exists for key");
                        }
                    }
                    break;
                case "REMOVE":
                    if (inputWords.Count != 3)
                    {
                        Console.WriteLine("ERROR, Incorrect Input");
                    }
                    else
                    {
                        (bool, string) result = dictionary.Remove(inputWords[1], inputWords[2]);
                        if (result.Item1)
                        {
                            Console.WriteLine(result.Item2);
                        }
                        else
                        {
                            Console.WriteLine(result.Item2);
                        }
                    }
                    break;
                case "REMOVEALL":
                    if (inputWords.Count != 2)
                    {
                        Console.WriteLine("ERROR, Incorrect Input");
                    }
                    else
                    {
                        bool result = dictionary.RemoveAll(inputWords[1]);
                        if (result)
                        {
                            Console.WriteLine("Removed");
                        }
                        else
                        {
                            Console.WriteLine("ERROR, key does not exist");
                        }
                    }
                    break;
                case "CLEAR":
                    if (inputWords.Count != 1)
                    {
                        Console.WriteLine("ERROR, Incorrect Input");
                    }
                    else
                    {
                        dictionary.Clear();
                        Console.WriteLine("Cleared");
                    }
                    break;
                case "KEYEXISTS":
                    if (inputWords.Count != 2)
                    {
                        Console.WriteLine("ERROR, Incorrect Input");
                    }
                    else
                    {
                        Console.WriteLine(dictionary.KeyExists(inputWords[1]));
                    }
                    break;
                case "MEMBEREXISTS":
                    if (inputWords.Count != 3)
                    {
                        Console.WriteLine("ERROR, Incorrect Input");
                    }
                    else
                    {
                        Console.WriteLine(dictionary.MemberExists(inputWords[1], inputWords[2]));
                    }
                    break;
                case "ALLMEMBERS":
                    if (inputWords.Count != 1)
                    {
                        Console.WriteLine("ERROR, Incorrect Input");
                    }
                    else
                    {
                        List<string> members = dictionary.AllMembers();
                        if (members == null)
                        {
                            Console.WriteLine("empty set");
                        }
                        else
                        {
                            int keyCount = 1;
                            foreach (var member in members)
                            {
                                Console.WriteLine($"{keyCount}) {member}");
                                keyCount++;
                            }
                        }
                    }
                    break;
                case "ITEMS":
                    if (inputWords.Count != 1)
                    {
                        Console.WriteLine("ERROR, Incorrect Input");
                    }
                    else
                    {
                        var items = dictionary.GetKeys();
                        if (items == null)
                        {
                            Console.WriteLine("empty set");
                        }
                        else
                        {
                            int itemNum = 1;
                            foreach (var key in dictionary.GetKeys())
                            {
                                foreach (var member in dictionary.GetMembers(key))
                                {
                                    Console.WriteLine($"{itemNum}) {key}: {member}");
                                    itemNum++;
                                }
                            }
                        }
                    }
                    break;
                case "EXIT":
                    Environment.Exit(200);
                    break;
                default:
                    Console.WriteLine("ERROR, Invalid Command");
                    break;
            }
        }
    }
}
