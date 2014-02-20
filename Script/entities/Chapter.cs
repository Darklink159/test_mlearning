using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
 using System.Linq;
using System.Text;
namespace WebRole1.Api
{
  public  class Chapter
    {
		[AutoIncrement]
		[Alias("id")]
		 public long Id {get; set;}
		 public string Name {get; set;}
		 public string LocalImgPath {get; set;}
		 public string CloudImgPath {get; set;}
		 [References(typeof(Book))]
		 public long BookId {get; set;}
    }
}
