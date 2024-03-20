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
  public class Auth : PageModel {

    private DateTime BirthDate { get; set; }
    public String ReturnParam = "";
    public bool RedirectRequired { get; set; }
    private List<Employee> Employees { get; set; }


    public IActionResult OnPost() {

      EmployeeDataContext employeeDbData = new EmployeeDataContext();

      string Email = Request.Form["employee-email"];
      string Password = Request.Form["password"];
      DateTime parsedDate;
      if (!DateTime.TryParseExact(Password, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate)) {
        ReturnParam = "notadate";
      } else {
        Employees = employeeDbData.Employees.ToList();
        foreach (Employee employee in Employees) {
          if (employee.Email == Email && employee.BirthDate == parsedDate) {
            int EmployeeId = employee.EmployeeId;
            byte[] employeeIdBytes = BitConverter.GetBytes(EmployeeId);
            HttpContext.Session.Set("EmployeeId", employeeIdBytes);
            RedirectRequired = false;
            return RedirectToPage("../Panel");
          } else {
            ReturnParam = "invalidpass";
            RedirectRequired = true;
          }
        }
      }
      RedirectRequired = true;
      return Page();
    }


  }
}