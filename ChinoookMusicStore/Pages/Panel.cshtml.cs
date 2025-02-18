using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContext;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace ChinookMusicStore.Pages {
  public class PanelModel : PageModel {
    public string LoggedInEmployee { get; set; }
    public List<AlbumWithArtistName> AlbumsJoined { get; set; }
    public int AlbumCount { get; set; }
    public int ArtistCount { get; set; }
    public int PlaylistsCount { get; set; }
    public int TracksCount { get; set; }
    public int CustomersCount { get; set; }

    public IActionResult OnGet() {
      // check if logged in to prevent accessing with typing into url bar
      if (HttpContext.Session.GetString("EmployeeId") == null) {
        Console.WriteLine("Session doesn't exist");
        return RedirectToPage("Index", new { res = "notloggedin" });
      }

      // get my contexts
      EmployeeDataContext employeeDbData = new EmployeeDataContext();
      AlbumsJoinedContext albumsJoinedDbData = new AlbumsJoinedContext();
      ArtistsDataContext artistsDbData = new ArtistsDataContext();
      PlaylistsContext playlistsDbData = new PlaylistsContext();
      TracksContext tracksDbData = new TracksContext();
      CustomersContext customersDbData = new CustomersContext();


      // get id from session and match against employee data
      int EmployeeId = BitConverter.ToInt32(HttpContext.Session.Get("EmployeeId"), 0);
      Employee employee = employeeDbData.Employees.Where(e => e.EmployeeId == EmployeeId).FirstOrDefault();

      // aaaand start setting my public variables
      LoggedInEmployee = $"{employee.FirstName} {employee.LastName}";
      AlbumsJoined = albumsJoinedDbData.GetAlbumsWithArtistNames();
      AlbumCount = AlbumsJoined.Count;
      ArtistCount = artistsDbData.Artists.Count();
      PlaylistsCount = playlistsDbData.PlaylistCount;
      TracksCount = tracksDbData.TrackCount;
      CustomersCount = customersDbData.CustomerCount;

      // if session exists and id set
      return Page();
    }

    public Task<IActionResult> OnPostLogout() {
      Console.WriteLine("Logged out");
      HttpContext.Session.Clear();
      return Task.FromResult<IActionResult>(RedirectToPage("Index", new { res = "loggedout" }));
    }



  }
}