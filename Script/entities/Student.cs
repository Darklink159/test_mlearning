using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
 using System.Linq;
using System.Text;
namespace WebRole1.Api
{
  public  class Student
    {
		[AutoIncrement]
		[Alias("id")]
		 public long Id {get; set;}
		 [References(typeof(User))]
		 public long UserId {get; set;}
    }
}
