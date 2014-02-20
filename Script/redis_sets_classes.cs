  static class StudentAnswer_Student_QuestionIndex 
        { 
 			internal static string Answer_Student_Questions(long studentid)
             {
                 return "urn:student>answer_Student_Question:" + studentid;
            }
         }
  static class QuestionAnswer_Student_QuestionIndex 
        { 
 			internal static string Answer_Student_Questions(long questionid)
             {
                 return "urn:question>answer_Student_Question:" + questionid;
            }
         }
  static class OptionAnswer_Student_QuestionIndex 
        { 
 			internal static string Answer_Student_Questions(long optionid)
             {
                 return "urn:option>answer_Student_Question:" + optionid;
            }
         }
  static class TeacherBookIndex 
        { 
 			internal static string Books(long teacherid)
             {
                 return "urn:teacher>book:" + teacherid;
            }
         }
  static class CategoryBookIndex 
        { 
 			internal static string Books(long categoryid)
             {
                 return "urn:category>book:" + categoryid;
            }
         }
  static class BookChapterIndex 
        { 
 			internal static string Chapters(long bookid)
             {
                 return "urn:book>chapter:" + bookid;
            }
         }
  static class CategoryCourseIndex 
        { 
 			internal static string Courses(long categoryid)
             {
                 return "urn:category>course:" + categoryid;
            }
         }
  static class TeacherCourseIndex 
        { 
 			internal static string Courses(long teacherid)
             {
                 return "urn:teacher>course:" + teacherid;
            }
         }
  static class StudentEnrollmentIndex 
        { 
 			internal static string Enrollments(long studentid)
             {
                 return "urn:student>enrollment:" + studentid;
            }
         }
  static class CourseEnrollmentIndex 
        { 
 			internal static string Enrollments(long courseid)
             {
                 return "urn:course>enrollment:" + courseid;
            }
         }
  static class StudentFavourite_Student_BookIndex 
        { 
 			internal static string Favourite_Student_Books(long studentid)
             {
                 return "urn:student>favourite_Student_Book:" + studentid;
            }
         }
  static class BookFavourite_Student_BookIndex 
        { 
 			internal static string Favourite_Student_Books(long bookid)
             {
                 return "urn:book>favourite_Student_Book:" + bookid;
            }
         }
  static class QuestionHas_Question_OptionIndex 
        { 
 			internal static string Has_Question_Options(long questionid)
             {
                 return "urn:question>has_Question_Option:" + questionid;
            }
         }
  static class OptionHas_Question_OptionIndex 
        { 
 			internal static string Has_Question_Options(long optionid)
             {
                 return "urn:option>has_Question_Option:" + optionid;
            }
         }
  static class SectionPageIndex 
        { 
 			internal static string Pages(long sectionid)
             {
                 return "urn:section>page:" + sectionid;
            }
         }
  static class UserPostIndex 
        { 
 			internal static string Posts(long userid)
             {
                 return "urn:user>post:" + userid;
            }
         }
  static class BookPostIndex 
        { 
 			internal static string Posts(long bookid)
             {
                 return "urn:book>post:" + bookid;
            }
         }
  static class OptionQuestionIndex 
        { 
 			internal static string Questions(long optionid)
             {
                 return "urn:option>question:" + optionid;
            }
         }
  static class QuizQuestionIndex 
        { 
 			internal static string Questions(long quizid)
             {
                 return "urn:quiz>question:" + quizid;
            }
         }
  static class BookQuizIndex 
        { 
 			internal static string Quizs(long bookid)
             {
                 return "urn:book>quiz:" + bookid;
            }
         }
  static class ChapterSectionIndex 
        { 
 			internal static string Sections(long chapterid)
             {
                 return "urn:chapter>section:" + chapterid;
            }
         }
  static class UserStudentIndex 
        { 
 			internal static string Students(long userid)
             {
                 return "urn:user>student:" + userid;
            }
         }
  static class StudentTakes_Student_QuizIndex 
        { 
 			internal static string Takes_Student_Quizs(long studentid)
             {
                 return "urn:student>takes_Student_Quiz:" + studentid;
            }
         }
  static class QuizTakes_Student_QuizIndex 
        { 
 			internal static string Takes_Student_Quizs(long quizid)
             {
                 return "urn:quiz>takes_Student_Quiz:" + quizid;
            }
         }
  static class UserTeacherIndex 
        { 
 			internal static string Teachers(long userid)
             {
                 return "urn:user>teacher:" + userid;
            }
         }
  static class CourseUse_Course_BookIndex 
        { 
 			internal static string Use_Course_Books(long courseid)
             {
                 return "urn:course>use_Course_Book:" + courseid;
            }
         }
  static class BookUse_Course_BookIndex 
        { 
 			internal static string Use_Course_Books(long bookid)
             {
                 return "urn:book>use_Course_Book:" + bookid;
            }
         }
