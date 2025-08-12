using System;
using System.ComponentModel.DataAnnotations;

class Program
{
  static void Main()
  {
    bool cont = true;

    while (cont == true)
    {

      int maxNumber;

      while (true)
      {
        Console.Write("Choose the highest number thats greater than 1: ");
        string? maxNumberInput = Console.ReadLine();

        if (maxNumberInput == null)
        {
          Console.WriteLine("Please enter a number");
          continue;
        }

        if (int.TryParse(maxNumberInput, out maxNumber) && maxNumber > 1)
          break;

        Console.WriteLine("Please enter a valid number greater than 1");
      }


      Random random = new();

      int secretNumber = random.Next(1, maxNumber + 1);

      int guess = 0;
      int attempts = 0;

      Console.WriteLine($"I'm thinking of a number between 1 and {maxNumber}");

      while (guess != secretNumber)
      {
        Console.Write("Enter your guess: ");
        string? guessInput = Console.ReadLine();

        if (guessInput == null)
        {
          Console.WriteLine("Please enter a number");
          continue;
        }

        if (!int.TryParse(guessInput, out guess))
        {
          Console.WriteLine("Please enter a valid number");
          continue;
        }

        attempts++;

        if (guess < secretNumber)
        {
          Console.WriteLine("Too low...");
        }
        else if (guess > secretNumber)
        {
          Console.WriteLine("Too high!");
        }
        else
        {
          Console.WriteLine($"Correct! You guessed it in {attempts} attempts");
        }
      }

      Console.WriteLine("Do you wish to continue? (y/n)");
      string? contInput = Console.ReadLine();

      if (contInput == null)
      {
        Console.WriteLine("Please enter a valid answer");
        continue;
      }

      contInput = contInput.Trim().ToLower();

      if (contInput == "y" || contInput == "yes")
      {
        cont = true;
      }
      else if (contInput == "n" || contInput == "no")
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

