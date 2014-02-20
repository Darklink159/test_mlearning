using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
 using System.Linq;
using System.Text;
namespace WebRole1.Api
{
  public  class Has_Question_Option
    {
		[AutoIncrement]
		[Alias("id")]
		 public long Id {get; set;}
		 [References(typeof(Question))]
		 public long QuestionId {get; set;}
		 [References(typeof(Option))]
		 public long OptionId {get; set;}
    }
}
