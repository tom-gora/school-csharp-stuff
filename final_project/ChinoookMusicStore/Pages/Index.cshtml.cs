using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinookMusicStore.Pages {
  public class IndexModel : PageModel {


    // strings
    public String BannerID { get; set; }
    public String StudentName { get; set; }


    public void OnGet() {
      StudentName = "Tomasz Gora";
      BannerID = "B01665261";
    }


    public IActionResult OnPost() {
      string email = Request.Form["employee-email"];
      string password = Request.Form["password"];
      return Page();
    }
  }
}