using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
 using System.Linq;
using System.Text;
namespace WebRole1.Api
{
  public  class Category
    {
		[AutoIncrement]
		[Alias("id")]
		 public long Id {get; set;}
		 public string Title {get; set;}
		 public string Description {get; set;}
    }
}
