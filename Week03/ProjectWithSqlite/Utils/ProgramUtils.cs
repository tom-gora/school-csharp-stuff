using System;

namespace ProgramUtils {
  public enum OperationList {
    ListDetails,
    Modify,
    Delete
  }

  public class FormatUtils {
    public static void AnyKeyPressPlease() {
      Console.WriteLine("\nPress any key to continue...");
      Console.ReadKey();
    }
  }

  public class InputValidators {
    public static string TakeAndValidateInputString(string message) {
      Console.Clear();
      Console.WriteLine(message);
      string? input = Console.ReadLine();
      while (string.IsNullOrWhiteSpace(input)) {
        Console.Clear();
        Console.WriteLine("The input cannot be empty. Please try again.\n");
        Console.WriteLine(message);
        input = Console.ReadLine();
      }
      return input.ToString().Trim();
    }

    public static int TakeAndValidateInputInt(string message) {
      Console.Clear();
      Console.WriteLine(message);
      string? input = Console.ReadLine();
      while (!int.TryParse(input, out int number) || number < 0) {
        Console.Clear();
        Console.WriteLine("The input must be a positive number. Please try again.\n");
        Console.WriteLine(message);
        input = Console.ReadLine();
      }
      return int.Parse(input);
    }

    public static float TakeAndValidateInputFloat(string message) {
      Console.Clear();
      Console.WriteLine(message);
      string? input = Console.ReadLine();
      while (!float.TryParse(input, out float number) || number < 0) {
        Console.Clear();
        Console.WriteLine("The input must be a positive numeric value. Please try again.\n");
        Console.WriteLine(message);
        input = Console.ReadLine();
      }
      return float.Parse(input);
    }


    public static bool TakeAndValidateInputBool(string message) {
      Console.Clear();
      Console.WriteLine(message);
      string? input = Console.ReadLine();
      while (input != "n" && input != "y" && input != "yes" && input != "no") {
        Console.Clear();
        Console.WriteLine("The input must be either 'y' / 'n' or 'yes' / 'no'. Please try again.\n");
        Console.WriteLine(message);
        input = Console.ReadLine();
      }
      if (input == "y" || input == "yes") return true;
      else return false;
    }
  }
}