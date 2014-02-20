using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
 using System.Linq;
using System.Text;
namespace WebRole1.Api
{
  public  class User
    {
		[AutoIncrement]
		[Alias("id")]
		 public long Id {get; set;}
		 public string Username {get; set;}
		 public string Password {get; set;}
		 public string Name {get; set;}
		 public string LastName {get; set;}
		 public string LocalProfileImgPath {get; set;}
		 public string CloudProfileImgPath {get; set;}
    }
}
