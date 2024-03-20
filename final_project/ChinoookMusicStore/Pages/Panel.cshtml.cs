using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinookMusicStore.Pages {
  public class PanelModel : PageModel {

    public IActionResult OnGet() {
      // check if logged in to prevent accessing with typing into url bar
      if (HttpContext.Session.GetString("EmployeeId") == null) {
        Console.WriteLine("Session doesn't exist");
        return RedirectToPage("Index", new { res = "notloggedin" });
      }

      // if session exists and id set
      return Page();
    }
    public IActionResult OnPost() {
      Console.WriteLine("Logged out");
      HttpContext.Session.Clear();
      return RedirectToPage("Index", new { res = "loggedout" });
    }
  }
}