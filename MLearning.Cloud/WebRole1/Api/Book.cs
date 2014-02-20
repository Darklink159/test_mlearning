using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
 using System.Linq;
using System.Text;
namespace WebRole1.Api
{
  public  class Book
    {
		[AutoIncrement]
		[Alias("id")]
		 public long Id {get; set;}
		 public string Title {get; set;}
		 [References(typeof(Teacher))]
		 public long TeacherId {get; set;}
		 [References(typeof(Category))]
		 public long CategoryId {get; set;}
		 public DateTime UploadDate {get; set;}
		 public string Description {get; set;}
		 public long ReadCount {get; set;}
		 public string LocalImgPath {get; set;}
		 public string CloudImgPath {get; set;}
		 public double Prize {get; set;}
		 public int PagesNum {get; set;}
    }
}
