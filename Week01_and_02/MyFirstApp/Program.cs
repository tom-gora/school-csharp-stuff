using System;
using System.Collections.Generic;

class Program {
  static void Main(string[] args) {

    Random random = new Random();

    string? name;
    var surnames = new List<String>
    {
      "Smith",
      "Jones",
      "Williams",
      "Taylor",
      "Brown",
      "Davies",
      "Evans",
      "Wilson",
      "Patel",
      "Johnson",
      "Wright",
      "Robinson",
      "Thompson",
      "White",
      "Walker",
      "Edwards",
      "Green",
      "Hall",
      "Lewis",
      "Harris"
        };

    while (true) {
      Console.Clear();
      Console.WriteLine("Enter your name: ");
      name = Console.ReadLine();
      if (string.IsNullOrEmpty(name)) {
        Console.WriteLine("A name must be provided. Press any key.");
        Console.ReadKey();
      } else if (!name.Any(c => !char.IsLetter(c))) break;
      else {
        Console.WriteLine("A name must consist of letters. Press any key.");
        Console.ReadKey();
      }
    };

    int randomNumber(List<String> list) { return random.Next(list.Count); }
    string surname = surnames[randomNumber(surnames)];

    Console.WriteLine($"Your name is {name} {surname}");
  }
}