using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
 using System.Linq;
using System.Text;
namespace WebRole1.Api
{
  public  class Takes_Student_Quiz
    {
		[AutoIncrement]
		[Alias("id")]
		 public long Id {get; set;}
		 [References(typeof(Student))]
		 public long StudentId {get; set;}
		 [References(typeof(Quiz))]
		 public long QuizId {get; set;}
		 public long Grade {get; set;}
		 public DateTime Date {get; set;}
    }
}
