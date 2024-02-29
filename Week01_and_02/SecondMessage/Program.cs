using System;

namespace SecondMessage {

  class Program {
    static void Main(string[] args) {
      // basic vars
      String msg = "Hi. This is my second message.";
      var age = 0;
      age = 30;
      var name = "John";
      // string interpolation
      Console.WriteLine($"{msg} My name is {name} and my age is {age}.");
      //date
      var time = DateTime.Now.ToString("HH:mm");
      var weekday = DateTime.Now.ToString("dddd").ToUpper();
      var declaredDate = new DateTime(2021, 12, 24);
      Console.WriteLine($"The time at the moment is {time}.");
      Console.WriteLine($"Today is {weekday}.");
      Console.WriteLine($"The date is {declaredDate.ToShortDateString()}.");
    }
  }
}