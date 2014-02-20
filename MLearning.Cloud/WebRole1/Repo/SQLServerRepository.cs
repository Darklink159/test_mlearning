using FizzWare.NBuilder;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebRole1.Api;

namespace WebRole1.Repo
{
    public class SQLServerRepository : IRepository
    {
        IDbConnectionFactory DbFactory { get; set; }

        public SQLServerRepository(IDbConnectionFactory db)
        {
            DbFactory = db;
        }
   

       
        public bool isValidId(string entityName, long id)
        {
            throw new NotImplementedException();
        }

        public long AddAnswer_Student_Question(long studentid, long questionid, long optionid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Answer_Student_Question { StudentId = studentid, QuestionId = questionid, OptionId = optionid });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Answer_Student_Question> GetStudentAnswer_Student_Questions(long studentid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Answer_Student_Question>("StudentId = {0}", studentid);
            }
        }

        public IEnumerable<Answer_Student_Question> GetQuestionAnswer_Student_Questions(long questionid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Answer_Student_Question>("QuestionId = {0}", questionid);
            }
        }

        public IEnumerable<Answer_Student_Question> GetOptionAnswer_Student_Questions(long optionid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Answer_Student_Question>("OptionId = {0}", optionid);
            }
        }

        public long AddBook(string title, long teacherid, long categoryid, DateTime uploaddate, string description, long readcount, string localimgpath, string cloudimgpath, double prize, int pagesnum)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Book { Title = title, TeacherId = teacherid, CategoryId = categoryid, UploadDate = uploaddate, Description = description, ReadCount = readcount, LocalImgPath = localimgpath, CloudImgPath = cloudimgpath, Prize = prize, PagesNum = pagesnum });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Book> GetTeacherBooks(long teacherid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Book>("TeacherId = {0}", teacherid);
            }
        }

        public IEnumerable<Book> GetCategoryBooks(long categoryid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Book>("CategoryId = {0}", categoryid);
            }
        }

        public long AddCategory(string title, string description)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Category { Title = title, Description = description });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public long AddChapter(string name, string localimgpath, string cloudimgpath, long bookid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Chapter { Name = name, LocalImgPath = localimgpath, CloudImgPath = cloudimgpath, BookId = bookid });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Chapter> GetBookChapters(long bookid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Chapter>("BookId = {0}", bookid);
            }
        }

        public long AddCourse(string name, long duration, long categoryid, long teacherid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Course { Name = name, Duration = duration, CategoryId = categoryid, TeacherId = teacherid });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Course> GetCategoryCourses(long categoryid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Course>("CategoryId = {0}", categoryid);
            }
        }

        public IEnumerable<Course> GetTeacherCourses(long teacherid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Course>("TeacherId = {0}", teacherid);
            }
        }

        public long AddEnrollment(long studentid, long courseid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Enrollment { StudentId = studentid, CourseId = courseid });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Enrollment> GetStudentEnrollments(long studentid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Enrollment>("StudentId = {0}", studentid);
            }
        }

        public IEnumerable<Enrollment> GetCourseEnrollments(long courseid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Enrollment>("CourseId = {0}", courseid);
            }
        }

        public long AddFavourite_Student_Book(long studentid, long bookid, DateTime date, int rate)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Favourite_Student_Book { StudentId = studentid, BookId = bookid, Date = date, Rate = rate });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Favourite_Student_Book> GetStudentFavourite_Student_Books(long studentid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Favourite_Student_Book>("StudentId = {0}", studentid);
            }
        }

        public IEnumerable<Favourite_Student_Book> GetBookFavourite_Student_Books(long bookid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Favourite_Student_Book>("BookId = {0}", bookid);
            }
        }

        public long AddHas_Question_Option(long questionid, long optionid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Has_Question_Option { QuestionId = questionid, OptionId = optionid });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Has_Question_Option> GetQuestionHas_Question_Options(long questionid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Has_Question_Option>("QuestionId = {0}", questionid);
            }
        }

        public IEnumerable<Has_Question_Option> GetOptionHas_Question_Options(long optionid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Has_Question_Option>("OptionId = {0}", optionid);
            }
        }

        public long AddOption(string name)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Option { Name = name });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public long AddPage(string localimgpath, string cloudimgpath, long sectionid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Page { LocalImgPath = localimgpath, CloudImgPath = cloudimgpath, SectionId = sectionid });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Page> GetSectionPages(long sectionid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Page>("SectionId = {0}", sectionid);
            }
        }

        public long AddPost(DateTime created_at, string text, long userid, long bookid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Post { created_at = created_at, Text = text, UserId = userid, BookId = bookid });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Post> GetUserPosts(long userid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Post>("UserId = {0}", userid);
            }
        }

        public IEnumerable<Post> GetBookPosts(long bookid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Post>("BookId = {0}", bookid);
            }
        }

        public long AddQuestion(string text, long optionid, long quizid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Question { Text = text, OptionId = optionid, QuizId = quizid });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Question> GetOptionQuestions(long optionid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Question>("OptionId = {0}", optionid);
            }
        }

        public IEnumerable<Question> GetQuizQuestions(long quizid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Question>("QuizId = {0}", quizid);
            }
        }

        public long AddQuiz(string name, long bookid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Quiz { Name = name, BookId = bookid });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Quiz> GetBookQuizs(long bookid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Quiz>("BookId = {0}", bookid);
            }
        }

        public long AddSection(string name, long chapterid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Section { Name = name, ChapterId = chapterid });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Section> GetChapterSections(long chapterid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Section>("ChapterId = {0}", chapterid);
            }
        }

        public long AddStudent(long userid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Student { UserId = userid });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Student> GetUserStudents(long userid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Student>("UserId = {0}", userid);
            }
        }

        public long AddTakes_Student_Quiz(long studentid, long quizid, long grade, DateTime date)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Takes_Student_Quiz { StudentId = studentid, QuizId = quizid, Grade = grade, Date = date });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Takes_Student_Quiz> GetStudentTakes_Student_Quizs(long studentid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Takes_Student_Quiz>("StudentId = {0}", studentid);
            }
        }

        public IEnumerable<Takes_Student_Quiz> GetQuizTakes_Student_Quizs(long quizid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Takes_Student_Quiz>("QuizId = {0}", quizid);
            }
        }

        public long AddTeacher(long userid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Teacher { UserId = userid });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Teacher> GetUserTeachers(long userid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Teacher>("UserId = {0}", userid);
            }
        }

        public long AddUse_Course_Book(long courseid, long bookid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new Use_Course_Book { CourseId = courseid, BookId = bookid });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<Use_Course_Book> GetCourseUse_Course_Books(long courseid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Use_Course_Book>("CourseId = {0}", courseid);
            }
        }

        public IEnumerable<Use_Course_Book> GetBookUse_Course_Books(long bookid)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<Use_Course_Book>("BookId = {0}", bookid);
            }
        }

        public long AddUser(string username, string password, string name, string lastname, string localprofileimgpath, string cloudprofileimgpath)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    db.Insert(new User { Username = username, Password = password, Name = name, LastName = lastname, LocalProfileImgPath = localprofileimgpath, CloudProfileImgPath = cloudprofileimgpath });
                    return db.GetLastInsertId();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return -1;
                }
            }
        } 










        public void StoreRandomObjects<T>(int nrows) where T: new()
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                IList<T> list = Builder<T>.CreateListOfSize(nrows).Build();
                
                foreach (var obj in list)
                {

                        db.Insert(obj);
                }
            }
        }


        public T Get<T>(long entityId)
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                try
                {
                    return db.Single<T>("Id = {0}", entityId);
                }
                catch (System.ArgumentNullException)
                {
                    return Activator.CreateInstance<T>();
                }
            }
        }


        public IEnumerable<T> Get<T>()
        {
            using (IDbConnection db = DbFactory.OpenDbConnection())
            {
                return db.Select<T>();
            }
        }
    }
}