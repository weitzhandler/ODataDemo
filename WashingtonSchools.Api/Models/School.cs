using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashingtonSchools.Api.Models
{
  public class School
  {
    public Guid SchoolId { get; set; }
    public string Name { get; set; }
    public string State { get; set; }
    public string City { get; set; }

    public ICollection<Student> Students { get; set; }

    public static School CreateSample() =>
        new School
        {
          Name = "MySchool",
          City = "New York City",
          State = "NY",
          SchoolId = Guid.Parse("6cef9446-b814-45ef-bb2a-3a3519f7e998")
        };
  }
}
