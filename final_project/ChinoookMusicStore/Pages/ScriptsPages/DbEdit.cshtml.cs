
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataContext;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Scripts {
  public class DbEdit : PageModel {

    private List<AlbumWithArtistName> AlbumsJoined { get; set; }

    private AlbumsJoinedContext albumsJoinedDbData = new AlbumsJoinedContext();
    public AlbumWithArtistName EditedAlbum;

    private AlbumWithArtistName changesStore = new AlbumWithArtistName();
    public bool isForm = false;
    public int idEdited;

    // check if session is set and user is logged in
    public IActionResult OnGet() {
      if (HttpContext.Session == null || HttpContext.Session.GetString("EmployeeId") == null) {
        Console.WriteLine("Session doesn't exist");
        return RedirectToPage("../Index", new { res = "notloggedin" });
      } else return RedirectToPage("../Panel");
    }

    public IActionResult OnPostEditalbum() {
      isForm = true;
      if (!Request.Query.TryGetValue("id", out var id)) return RedirectToPage("../Panel", new { res = "noalbumiderror" });
      idEdited = int.Parse(id[0]);

      AlbumsJoined = albumsJoinedDbData.GetAlbumsWithArtistNames();
      EditedAlbum = AlbumsJoined.Find(a => a.AlbumId == idEdited);

      changesStore.AlbumId = EditedAlbum.AlbumId;
      changesStore.Title = Request.Form["newAlbumTitle"];
      changesStore.ArtistId = EditedAlbum.ArtistId;
      changesStore.ArtistName = Request.Form["newArtistName"];
      Console.WriteLine($"Album id: {idEdited}");
      return Page();
    }

    public IActionResult OnPostApplychanges() {
      isForm = false;
      string newArtistName = Request.Form["newArtistName"];
      string newAlbumTitle = Request.Form["newAlbumTitle"];
      AlbumsJoined = albumsJoinedDbData.GetAlbumsWithArtistNames();
      EditedAlbum = AlbumsJoined.Find(a => a.AlbumId == Int32.Parse(Request.Form["albumId"]));
      if (newArtistName == EditedAlbum.ArtistName && newAlbumTitle == EditedAlbum.Title) {
        return RedirectToPage("../Panel", new { res = "nochanges" });
      } else {
        //grab artist and album context and inject new values into the database
        using (var albumsContext = new AlbumsDataContext()) {
          var albumToUpdate = albumsContext.Albums.Find(Int32.Parse(Request.Form["albumId"]));
          albumToUpdate.Title = newAlbumTitle;
          albumToUpdate.ArtistId = EditedAlbum.ArtistId;
          albumsContext.SaveChanges();
        }
        using (var artistsContext = new ArtistsDataContext()) {
          var artistToUpdate = artistsContext.Artists.Find(EditedAlbum.ArtistId);
          artistToUpdate.Name = newArtistName;
          artistsContext.SaveChanges();
        }
        isForm = false;
        return Page();
      }

    }
  }
}