using System;
using System.Collections.Generic;
using System.Linq;
using DataContext;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using UI;

namespace ConsoleApp_b01665261 {
  class Program {
    static void Main(string[] args) {
      Console.Clear();
      String topMsg = "Welcome to my CLI App written in C#";
      String bottomMsg = "Tomasz Gora B01665261";
      int boxLenght = Math.Max(topMsg.Length, bottomMsg.Length);
      Console.WriteLine($"{UiBlocks.startCharTop}{UiBlocks.topBar(boxLenght + 2)}{UiBlocks.endCharTop}");
      Console.WriteLine($"{UiBlocks.sideChar}{topMsg.PadRight(boxLenght + 2, ' ')}{UiBlocks.sideChar} ");
      Console.WriteLine($"{UiBlocks.sideChar}{bottomMsg.PadRight(boxLenght + 2, ' ')}{UiBlocks.sideChar} ");
      Console.WriteLine($"{UiBlocks.startCharBottom}{UiBlocks.topBar(boxLenght + 2)}{UiBlocks.endCharBottom}");
      Behaviours.AnyKeyPressPlease();

      String msg = "Please enter the site name:\n";
      String siteString = InputValidators.TakeAndValidateInputString(msg);

      List<Site> sitesAvailable = GetSitesList();
      Site siteFound = null;
      foreach (Site site in sitesAvailable) {
        if (site.SiteName.ToLower().Contains(siteString.ToLower()) || site.URL.ToLower().Contains(siteString.ToLower())) siteFound = site;
      }

      if (siteFound != null) {
        topMsg = "Site found";
        bottomMsg = siteFound.URL;
        boxLenght = Math.Max(topMsg.Length, bottomMsg.Length);
        Console.Clear();
        Console.WriteLine($"{UiBlocks.startCharTop}{UiBlocks.topBar(boxLenght + 2)}{UiBlocks.endCharTop}");
        Console.WriteLine($"{UiBlocks.sideChar}{topMsg.PadRight(boxLenght + 2, ' ')}{UiBlocks.sideChar} ");
        Console.WriteLine($"{UiBlocks.sideChar}{bottomMsg.PadRight(boxLenght + 2, ' ')}{UiBlocks.sideChar} ");
        Console.WriteLine($"{UiBlocks.startCharBottom}{UiBlocks.topBar(boxLenght + 2)}{UiBlocks.endCharBottom}");
        Behaviours.AnyKeyPressToExit();
      } else {
        topMsg = "Site not found!";
        bottomMsg = "Unknown URL error";
        boxLenght = Math.Max(topMsg.Length, bottomMsg.Length);
        Console.Clear();
        Console.WriteLine($"{UiBlocks.startCharTop}{UiBlocks.topBar(boxLenght + 2)}{UiBlocks.endCharTop}");
        Console.WriteLine($"{UiBlocks.sideChar}{topMsg.PadRight(boxLenght + 2, ' ')}{UiBlocks.sideChar} ");
        Console.WriteLine($"{UiBlocks.sideChar}{bottomMsg.PadRight(boxLenght + 2, ' ')}{UiBlocks.sideChar} ");
        Console.WriteLine($"{UiBlocks.startCharBottom}{UiBlocks.topBar(boxLenght + 2)}{UiBlocks.endCharBottom}");
        Behaviours.AnyKeyPressToExit();
      }
    }
    public static List<Site> GetSitesList() {
      SiteDataContext db = new SiteDataContext();
      List<Site>? list = db.Sites!.ToList();
      return list;
    }
  }
}