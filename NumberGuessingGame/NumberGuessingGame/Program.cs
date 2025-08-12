using System;

class Program
{
  static void Main()
  {
    bool cont = true;

    while (cont == true)
    {

      Random random = new();

      int secretNumber = random.Next(1, 101);

      Console.WriteLine(secretNumber);

      Console.WriteLine("Do you wish to continue? (y/n)");
      string? input = Console.ReadLine();

      if (input == null)
      {
        Console.WriteLine("Please enter a valid answer");
        continue;
      }

      input = input.Trim().ToLower();

      if (input == "y" || input == "yes")
      {
        cont = true;
      }
      else if (input == "n" || input == "no")
      {
        cont = false;
      }
      else
      {
        Console.WriteLine("Please enter a valid answer");
        continue;
      }
    }
  }
}

