using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
 using System.Linq;
using System.Text;
namespace WebRole1.Api
{
  public  class Course
    {
		[AutoIncrement]
		[Alias("id")]
		 public long Id {get; set;}
		 public string Name {get; set;}
		 public long Duration {get; set;}
		 [References(typeof(Category))]
		 public long CategoryId {get; set;}
		 [References(typeof(Teacher))]
		 public long TeacherId {get; set;}
    }
}
