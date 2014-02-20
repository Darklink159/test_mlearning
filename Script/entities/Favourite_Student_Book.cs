using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
 using System.Linq;
using System.Text;
namespace WebRole1.Api
{
  public  class Favourite_Student_Book
    {
		[AutoIncrement]
		[Alias("id")]
		 public long Id {get; set;}
		 [References(typeof(Student))]
		 public long StudentId {get; set;}
		 [References(typeof(Book))]
		 public long BookId {get; set;}
		 public DateTime Date {get; set;}
		 public int Rate {get; set;}
    }
}
