using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContext;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SitesApp.Pages {
  public class ViewPages : PageModel {
    public String Heading { get; set; }
    public String BannerID { get; set; }
    public List<Site> Sites { get; set; }

    public void OnGet() {
      Heading = "Tomasz Gora";
      BannerID = "B01665261";

      SiteDataContext db = new SiteDataContext();
      Sites = db.Sites.OrderBy(s => s.SiteName).ToList();
    }
  }
}