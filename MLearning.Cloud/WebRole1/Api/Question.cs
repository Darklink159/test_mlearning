using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
 using System.Linq;
using System.Text;
namespace WebRole1.Api
{
  public  class Question
    {
		[AutoIncrement]
		[Alias("id")]
		 public long Id {get; set;}
		 public string Text {get; set;}
		 [References(typeof(Option))]
		 public long OptionId {get; set;}
		 [References(typeof(Quiz))]
		 public long QuizId {get; set;}
    }
}
