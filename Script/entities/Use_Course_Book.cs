using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
 using System.Linq;
using System.Text;
namespace WebRole1.Api
{
  public  class Use_Course_Book
    {
		[AutoIncrement]
		[Alias("id")]
		 public long Id {get; set;}
		 [References(typeof(Course))]
		 public long CourseId {get; set;}
		 [References(typeof(Book))]
		 public long BookId {get; set;}
    }
}
