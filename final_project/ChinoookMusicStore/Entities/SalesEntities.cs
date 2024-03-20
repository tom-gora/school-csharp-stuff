using System;

namespace Entities {
  public class Customer {
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public int? SupportRepId { get; set; }

    // Navigation property for the support representative
    public Employee SupportRepresentative { get; set; }
  }
  public class Invoice {
    public int InvoiceId { get; set; }
    public int CustomerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string BillingAddress { get; set; }
    public string BillingCity { get; set; }
    public string BillingState { get; set; }
    public string BillingCountry { get; set; }
    public string BillingPostalCode { get; set; }
    public decimal Total { get; set; }

    // Navigation property for the associated customer
    public Customer Customer { get; set; }
  }
  public class InvoiceItem {
    public int InvoiceLineId { get; set; }
    public int InvoiceId { get; set; }
    public int TrackId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }

    // Navigation property for the associated invoice
    public Invoice Invoice { get; set; }

    // Navigation property for the associated track
    public Track Track { get; set; }
  }
}