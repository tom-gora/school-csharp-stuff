

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
  public class DbAdd : PageModel {

    private List<AlbumWithArtistName> AlbumsJoined { get; set; }

    private AlbumsJoinedContext albumsJoinedDbData = new AlbumsJoinedContext();
    public AlbumWithArtistName EditedAlbum;

    private AlbumWithArtistName changesStore = new AlbumWithArtistName();
    public bool isForm = false;

    // check if session is set and user is logged in
    public IActionResult OnGet() {
      if (HttpContext.Session == null || HttpContext.Session.GetString("EmployeeId") == null) {
        Console.WriteLine("Session doesn't exist");
        return RedirectToPage("../Index", new { res = "notloggedin" });
      } else return RedirectToPage("../Panel");
    }

    public IActionResult OnPostAddalbum() {
      isForm = true;
      return Page();
    }

    public IActionResult OnPostApplychanges() {
      isForm = false;
      string newArtistName = Request.Form["newArtistName"];
      string newAlbumTitle = Request.Form["newAlbumTitle"];
      AlbumsJoined = albumsJoinedDbData.GetAlbumsWithArtistNames();
      Console.WriteLine($"Artist name: {newArtistName}");
      Console.WriteLine($"Album title: {newAlbumTitle}");
      bool foundAlbum = false;
      bool foundArtist = false;
      int foundArtistId = 0;

      AlbumsDataContext albumsContext = new AlbumsDataContext();
      ArtistsDataContext artistsContext = new ArtistsDataContext();

      foreach (var artist in artistsContext.Artists) {
        if (artist.Name == newArtistName) {
          foundArtist = true;
          foundArtistId = artist.ArtistId;
          break;
        }
      }
      foreach (var album in albumsContext.Albums) {
        if (album.Title == newAlbumTitle) {
          foundAlbum = true;
          break;
        }
      }

      if (foundArtist && foundAlbum) {
        Console.WriteLine("Found album!");
        // message back to handle in ui and tell user that's a duplicate
        return RedirectToPage("../Panel", new { res = "alreadyexists" });
      } else if (foundArtist && !foundAlbum) {
        // skip artist to not do duplicates and only add album
        Album newAlbum = new Album();
        newAlbum.Title = newAlbumTitle;
        newAlbum.ArtistId = foundArtistId;
        albumsContext.Albums.Add(newAlbum);
        albumsContext.SaveChanges();
        isForm = false;
        return Page();
      } else {
        // If found album but not artist might be same name album by different artists
        // also if nothing found then add new artist and album
        Artist newArtist = new Artist();
        newArtist.Name = newArtistName;
        artistsContext.Artists.Add(newArtist);
        artistsContext.SaveChanges();

        Album newAlbum = new Album();
        newAlbum.Title = newAlbumTitle;
        newAlbum.ArtistId = newArtist.ArtistId;
        albumsContext.Albums.Add(newAlbum);
        albumsContext.SaveChanges();
        isForm = false;
        return Page();
      }
    }
  }
}