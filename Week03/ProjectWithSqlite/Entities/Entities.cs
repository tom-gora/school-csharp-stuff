using System;

namespace Entities {
  public class Product {
    public int id { get; set; }
    public string? name { get; set; }
    public int price_in_gbp { get; set; }
    public string? description { get; set; }
    public bool availability { get; set; }
    public int stock_level { get; set; }
    public bool on_promo { get; set; }
    public int promo_rate_as_percentage { get; set; }
  }
}

