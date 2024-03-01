using System;

namespace Utils {
  public enum OperationList {
    ListDetails,
    Modify,
    Delete
  }

  public class MetaUtils {
    public static void AnyKeyPressPlease() {
      Console.WriteLine("\nPress any key to continue...");
      Console.ReadKey();
    }
  }
}