
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
  public class DbDelete : PageModel {

    public List<AlbumWithArtistName> AlbumsJoined { get; set; }

    public IActionResult OnPostDeletealbum() {
      if (!Request.Query.TryGetValue("id", out var id)) return RedirectToPage("../Panel", new { res = "noalbumiderror" });
      int idToDelete = int.Parse(id[0]);
      AlbumsJoinedContext albumsJoinedDbData = new AlbumsJoinedContext();
      var remainingAlbumsForArtist = albumsJoinedDbData.GetAlbumsWithArtistNames().Where(a => a.AlbumId != idToDelete).Any();
      int artistIdForThisAlbum = 0;

      using (var albumsContext = new AlbumsDataContext()) {
        var albumToDelete = albumsContext.Albums.Find(idToDelete);
        if (albumToDelete != null && HttpContext.Session.GetString("EmployeeId") != null) {
          artistIdForThisAlbum = albumToDelete.ArtistId;
          Console.WriteLine($"Artis of deleted album is {artistIdForThisAlbum}");
          albumsContext.Albums.Remove(albumToDelete);
          albumsContext.SaveChanges();
          remainingAlbumsForArtist = albumsContext.Albums.Where(a => a.ArtistId == artistIdForThisAlbum).Any();
        }
      }
      using (var artistsContext = new ArtistsDataContext()) {
        if (remainingAlbumsForArtist) {
          Console.WriteLine("There are still albums for this artist");
          return Page();
        }
        Console.WriteLine("There are no more albums for this artist");
        // Step 4: Delete Artist (Optional)
        Artist artistToDelete = artistsContext.Artists.Find(artistIdForThisAlbum);
        if (artistToDelete != null) {
          artistsContext.Artists.Remove(artistToDelete);
          artistsContext.SaveChanges();
        }
      }
      AlbumsJoined = albumsJoinedDbData.GetAlbumsWithArtistNames();
      return Page();
    }
  }
}