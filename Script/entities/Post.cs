using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
 using System.Linq;
using System.Text;
namespace WebRole1.Api
{
  public  class Post
    {
		[AutoIncrement]
		[Alias("id")]
		 public long Id {get; set;}
		 public DateTime created_at {get; set;}
		 public string Text {get; set;}
		 [References(typeof(User))]
		 public long UserId {get; set;}
		 [References(typeof(Book))]
		 public long BookId {get; set;}
    }
}
