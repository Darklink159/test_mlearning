using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole1.Api
{

    public interface  IRepository
    { 
    
       

        bool isValidId(string entityName, long id);
        void StoreRandomObjects<T>(int nrows) where T:new();

        T Get<T>(long entityId);
        IEnumerable<T> Get<T>();

        //Auto generated
        long AddAnswer_Student_Question(long studentid, long questionid, long optionid);
        IEnumerable<Answer_Student_Question> GetStudentAnswer_Student_Questions(long studentid);
        IEnumerable<Answer_Student_Question> GetQuestionAnswer_Student_Questions(long questionid);
        IEnumerable<Answer_Student_Question> GetOptionAnswer_Student_Questions(long optionid);
        long AddBook(string title, long teacherid, long categoryid, DateTime uploaddate, string description, long readcount, string localimgpath, string cloudimgpath, double prize, int pagesnum);
        IEnumerable<Book> GetTeacherBooks(long teacherid);
        IEnumerable<Book> GetCategoryBooks(long categoryid);
        long AddCategory(string title, string description);
        long AddChapter(string name, string localimgpath, string cloudimgpath, long bookid);
        IEnumerable<Chapter> GetBookChapters(long bookid);
        long AddCourse(string name, long duration, long categoryid, long teacherid);
        IEnumerable<Course> GetCategoryCourses(long categoryid);
        IEnumerable<Course> GetTeacherCourses(long teacherid);
        long AddEnrollment(long studentid, long courseid);
        IEnumerable<Enrollment> GetStudentEnrollments(long studentid);
        IEnumerable<Enrollment> GetCourseEnrollments(long courseid);
        long AddFavourite_Student_Book(long studentid, long bookid, DateTime date, int rate);
        IEnumerable<Favourite_Student_Book> GetStudentFavourite_Student_Books(long studentid);
        IEnumerable<Favourite_Student_Book> GetBookFavourite_Student_Books(long bookid);
        long AddHas_Question_Option(long questionid, long optionid);
        IEnumerable<Has_Question_Option> GetQuestionHas_Question_Options(long questionid);
        IEnumerable<Has_Question_Option> GetOptionHas_Question_Options(long optionid);
        long AddOption(string name);
        long AddPage(string localimgpath, string cloudimgpath, long sectionid);
        IEnumerable<Page> GetSectionPages(long sectionid);
        long AddPost(DateTime created_at, string text, long userid, long bookid);
        IEnumerable<Post> GetUserPosts(long userid);
        IEnumerable<Post> GetBookPosts(long bookid);
        long AddQuestion(string text, long optionid, long quizid);
        IEnumerable<Question> GetOptionQuestions(long optionid);
        IEnumerable<Question> GetQuizQuestions(long quizid);
        long AddQuiz(string name, long bookid);
        IEnumerable<Quiz> GetBookQuizs(long bookid);
        long AddSection(string name, long chapterid);
        IEnumerable<Section> GetChapterSections(long chapterid);
        long AddStudent(long userid);
        IEnumerable<Student> GetUserStudents(long userid);
        long AddTakes_Student_Quiz(long studentid, long quizid, long grade, DateTime date);
        IEnumerable<Takes_Student_Quiz> GetStudentTakes_Student_Quizs(long studentid);
        IEnumerable<Takes_Student_Quiz> GetQuizTakes_Student_Quizs(long quizid);
        long AddTeacher(long userid);
        IEnumerable<Teacher> GetUserTeachers(long userid);
        long AddUse_Course_Book(long courseid, long bookid);
        IEnumerable<Use_Course_Book> GetCourseUse_Course_Books(long courseid);
        IEnumerable<Use_Course_Book> GetBookUse_Course_Books(long bookid);
        long AddUser(string username, string password, string name, string lastname, string localprofileimgpath, string cloudprofileimgpath);



    }
 
    

}