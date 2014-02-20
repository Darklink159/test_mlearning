using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
 using System.Linq;
using System.Text;
namespace WebRole1.Api
{
  public  class Option
    {
		[AutoIncrement]
		[Alias("id")]
		 public long Id {get; set;}
		 public string Name {get; set;}
    }
}
