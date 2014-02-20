using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole1.Api
{
    public class BookService : Service
    {

        public IRepository Repository { get; set; }
        public object Get(Answer_Student_Questions request)
        {
            return new Answer_Student_QuestionsResponse { Answer_Student_Questions = Repository.Get<Answer_Student_Question>() };
        }
        public object Get(GetAnswer_Student_Question request)
        {
            return new GetAnswer_Student_QuestionResponse { ResultAnswer_Student_Question = Repository.Get<Answer_Student_Question>(request.Id) };
        }
        public object Post(AddAnswer_Student_Question request)
        {
            var id = Repository.AddAnswer_Student_Question(request.StudentId, request.QuestionId, request.OptionId);
            return new AddAnswer_Student_QuestionResponse { Answer_Student_QuestionId = id };
        }
        public object Get(GetStudentAnswer_Student_Questions request)
        {
            return new GetStudentAnswer_Student_QuestionsResponse { Answer_Student_Questions = Repository.GetStudentAnswer_Student_Questions(request.StudentId) };
        }
        public object Get(GetQuestionAnswer_Student_Questions request)
        {
            return new GetQuestionAnswer_Student_QuestionsResponse { Answer_Student_Questions = Repository.GetQuestionAnswer_Student_Questions(request.QuestionId) };
        }
        public object Get(GetOptionAnswer_Student_Questions request)
        {
            return new GetOptionAnswer_Student_QuestionsResponse { Answer_Student_Questions = Repository.GetOptionAnswer_Student_Questions(request.OptionId) };
        }
        public object Get(Books request)
        {
            return new BooksResponse { Books = Repository.Get<Book>() };
        }
        public object Get(GetBook request)
        {
            return new GetBookResponse { ResultBook = Repository.Get<Book>(request.Id) };
        }
        public object Post(AddBook request)
        {
            var id = Repository.AddBook(request.Title, request.TeacherId, request.CategoryId, request.UploadDate, request.Description, request.ReadCount, request.LocalImgPath, request.CloudImgPath, request.Prize, request.PagesNum);
            return new AddBookResponse { BookId = id };
        }
        public object Get(GetTeacherBooks request)
        {
            return new GetTeacherBooksResponse { Books = Repository.GetTeacherBooks(request.TeacherId) };
        }
        public object Get(GetCategoryBooks request)
        {
            return new GetCategoryBooksResponse { Books = Repository.GetCategoryBooks(request.CategoryId) };
        }
        public object Get(Categorys request)
        {
            return new CategorysResponse { Categorys = Repository.Get<Category>() };
        }
        public object Get(GetCategory request)
        {
            return new GetCategoryResponse { ResultCategory = Repository.Get<Category>(request.Id) };
        }
        public object Post(AddCategory request)
        {
            var id = Repository.AddCategory(request.Title, request.Description);
            return new AddCategoryResponse { CategoryId = id };
        }
        public object Get(Chapters request)
        {
            return new ChaptersResponse { Chapters = Repository.Get<Chapter>() };
        }
        public object Get(GetChapter request)
        {
            return new GetChapterResponse { ResultChapter = Repository.Get<Chapter>(request.Id) };
        }
        public object Post(AddChapter request)
        {
            var id = Repository.AddChapter(request.Name, request.LocalImgPath, request.CloudImgPath, request.BookId);
            return new AddChapterResponse { ChapterId = id };
        }
        public object Get(GetBookChapters request)
        {
            return new GetBookChaptersResponse { Chapters = Repository.GetBookChapters(request.BookId) };
        }
        public object Get(Courses request)
        {
            return new CoursesResponse { Courses = Repository.Get<Course>() };
        }
        public object Get(GetCourse request)
        {
            return new GetCourseResponse { ResultCourse = Repository.Get<Course>(request.Id) };
        }
        public object Post(AddCourse request)
        {
            var id = Repository.AddCourse(request.Name, request.Duration, request.CategoryId, request.TeacherId);
            return new AddCourseResponse { CourseId = id };
        }
        public object Get(GetCategoryCourses request)
        {
            return new GetCategoryCoursesResponse { Courses = Repository.GetCategoryCourses(request.CategoryId) };
        }
        public object Get(GetTeacherCourses request)
        {
            return new GetTeacherCoursesResponse { Courses = Repository.GetTeacherCourses(request.TeacherId) };
        }
        public object Get(Enrollments request)
        {
            return new EnrollmentsResponse { Enrollments = Repository.Get<Enrollment>() };
        }
        public object Get(GetEnrollment request)
        {
            return new GetEnrollmentResponse { ResultEnrollment = Repository.Get<Enrollment>(request.Id) };
        }
        public object Post(AddEnrollment request)
        {
            var id = Repository.AddEnrollment(request.StudentId, request.CourseId);
            return new AddEnrollmentResponse { EnrollmentId = id };
        }
        public object Get(GetStudentEnrollments request)
        {
            return new GetStudentEnrollmentsResponse { Enrollments = Repository.GetStudentEnrollments(request.StudentId) };
        }
        public object Get(GetCourseEnrollments request)
        {
            return new GetCourseEnrollmentsResponse { Enrollments = Repository.GetCourseEnrollments(request.CourseId) };
        }
        public object Get(Favourite_Student_Books request)
        {
            return new Favourite_Student_BooksResponse { Favourite_Student_Books = Repository.Get<Favourite_Student_Book>() };
        }
        public object Get(GetFavourite_Student_Book request)
        {
            return new GetFavourite_Student_BookResponse { ResultFavourite_Student_Book = Repository.Get<Favourite_Student_Book>(request.Id) };
        }
        public object Post(AddFavourite_Student_Book request)
        {
            var id = Repository.AddFavourite_Student_Book(request.StudentId, request.BookId, request.Date, request.Rate);
            return new AddFavourite_Student_BookResponse { Favourite_Student_BookId = id };
        }
        public object Get(GetStudentFavourite_Student_Books request)
        {
            return new GetStudentFavourite_Student_BooksResponse { Favourite_Student_Books = Repository.GetStudentFavourite_Student_Books(request.StudentId) };
        }
        public object Get(GetBookFavourite_Student_Books request)
        {
            return new GetBookFavourite_Student_BooksResponse { Favourite_Student_Books = Repository.GetBookFavourite_Student_Books(request.BookId) };
        }
        public object Get(Has_Question_Options request)
        {
            return new Has_Question_OptionsResponse { Has_Question_Options = Repository.Get<Has_Question_Option>() };
        }
        public object Get(GetHas_Question_Option request)
        {
            return new GetHas_Question_OptionResponse { ResultHas_Question_Option = Repository.Get<Has_Question_Option>(request.Id) };
        }
        public object Post(AddHas_Question_Option request)
        {
            var id = Repository.AddHas_Question_Option(request.QuestionId, request.OptionId);
            return new AddHas_Question_OptionResponse { Has_Question_OptionId = id };
        }
        public object Get(GetQuestionHas_Question_Options request)
        {
            return new GetQuestionHas_Question_OptionsResponse { Has_Question_Options = Repository.GetQuestionHas_Question_Options(request.QuestionId) };
        }
        public object Get(GetOptionHas_Question_Options request)
        {
            return new GetOptionHas_Question_OptionsResponse { Has_Question_Options = Repository.GetOptionHas_Question_Options(request.OptionId) };
        }
        public object Get(Options request)
        {
            return new OptionsResponse { Options = Repository.Get<Option>() };
        }
        public object Get(GetOption request)
        {
            return new GetOptionResponse { ResultOption = Repository.Get<Option>(request.Id) };
        }
        public object Post(AddOption request)
        {
            var id = Repository.AddOption(request.Name);
            return new AddOptionResponse { OptionId = id };
        }
        public object Get(Pages request)
        {
            return new PagesResponse { Pages = Repository.Get<Page>() };
        }
        public object Get(GetPage request)
        {
            return new GetPageResponse { ResultPage = Repository.Get<Page>(request.Id) };
        }
        public object Post(AddPage request)
        {
            var id = Repository.AddPage(request.LocalImgPath, request.CloudImgPath, request.SectionId);
            return new AddPageResponse { PageId = id };
        }
        public object Get(GetSectionPages request)
        {
            return new GetSectionPagesResponse { Pages = Repository.GetSectionPages(request.SectionId) };
        }
        public object Get(Posts request)
        {
            return new PostsResponse { Posts = Repository.Get<Post>() };
        }
        public object Get(GetPost request)
        {
            return new GetPostResponse { ResultPost = Repository.Get<Post>(request.Id) };
        }
        public object Post(AddPost request)
        {
            var id = Repository.AddPost(request.created_at, request.Text, request.UserId, request.BookId);
            return new AddPostResponse { PostId = id };
        }
        public object Get(GetUserPosts request)
        {
            return new GetUserPostsResponse { Posts = Repository.GetUserPosts(request.UserId) };
        }
        public object Get(GetBookPosts request)
        {
            return new GetBookPostsResponse { Posts = Repository.GetBookPosts(request.BookId) };
        }
        public object Get(Questions request)
        {
            return new QuestionsResponse { Questions = Repository.Get<Question>() };
        }
        public object Get(GetQuestion request)
        {
            return new GetQuestionResponse { ResultQuestion = Repository.Get<Question>(request.Id) };
        }
        public object Post(AddQuestion request)
        {
            var id = Repository.AddQuestion(request.Text, request.OptionId, request.QuizId);
            return new AddQuestionResponse { QuestionId = id };
        }
        public object Get(GetOptionQuestions request)
        {
            return new GetOptionQuestionsResponse { Questions = Repository.GetOptionQuestions(request.OptionId) };
        }
        public object Get(GetQuizQuestions request)
        {
            return new GetQuizQuestionsResponse { Questions = Repository.GetQuizQuestions(request.QuizId) };
        }
        public object Get(Quizs request)
        {
            return new QuizsResponse { Quizs = Repository.Get<Quiz>() };
        }
        public object Get(GetQuiz request)
        {
            return new GetQuizResponse { ResultQuiz = Repository.Get<Quiz>(request.Id) };
        }
        public object Post(AddQuiz request)
        {
            var id = Repository.AddQuiz(request.Name, request.BookId);
            return new AddQuizResponse { QuizId = id };
        }
        public object Get(GetBookQuizs request)
        {
            return new GetBookQuizsResponse { Quizs = Repository.GetBookQuizs(request.BookId) };
        }
        public object Get(Sections request)
        {
            return new SectionsResponse { Sections = Repository.Get<Section>() };
        }
        public object Get(GetSection request)
        {
            return new GetSectionResponse { ResultSection = Repository.Get<Section>(request.Id) };
        }
        public object Post(AddSection request)
        {
            var id = Repository.AddSection(request.Name, request.ChapterId);
            return new AddSectionResponse { SectionId = id };
        }
        public object Get(GetChapterSections request)
        {
            return new GetChapterSectionsResponse { Sections = Repository.GetChapterSections(request.ChapterId) };
        }
        public object Get(Students request)
        {
            return new StudentsResponse { Students = Repository.Get<Student>() };
        }
        public object Get(GetStudent request)
        {
            return new GetStudentResponse { ResultStudent = Repository.Get<Student>(request.Id) };
        }
        public object Post(AddStudent request)
        {
            var id = Repository.AddStudent(request.UserId);
            return new AddStudentResponse { StudentId = id };
        }
        public object Get(GetUserStudents request)
        {
            return new GetUserStudentsResponse { Students = Repository.GetUserStudents(request.UserId) };
        }
        public object Get(Takes_Student_Quizs request)
        {
            return new Takes_Student_QuizsResponse { Takes_Student_Quizs = Repository.Get<Takes_Student_Quiz>() };
        }
        public object Get(GetTakes_Student_Quiz request)
        {
            return new GetTakes_Student_QuizResponse { ResultTakes_Student_Quiz = Repository.Get<Takes_Student_Quiz>(request.Id) };
        }
        public object Post(AddTakes_Student_Quiz request)
        {
            var id = Repository.AddTakes_Student_Quiz(request.StudentId, request.QuizId, request.Grade, request.Date);
            return new AddTakes_Student_QuizResponse { Takes_Student_QuizId = id };
        }
        public object Get(GetStudentTakes_Student_Quizs request)
        {
            return new GetStudentTakes_Student_QuizsResponse { Takes_Student_Quizs = Repository.GetStudentTakes_Student_Quizs(request.StudentId) };
        }
        public object Get(GetQuizTakes_Student_Quizs request)
        {
            return new GetQuizTakes_Student_QuizsResponse { Takes_Student_Quizs = Repository.GetQuizTakes_Student_Quizs(request.QuizId) };
        }
        public object Get(Teachers request)
        {
            return new TeachersResponse { Teachers = Repository.Get<Teacher>() };
        }
        public object Get(GetTeacher request)
        {
            return new GetTeacherResponse { ResultTeacher = Repository.Get<Teacher>(request.Id) };
        }
        public object Post(AddTeacher request)
        {
            var id = Repository.AddTeacher(request.UserId);
            return new AddTeacherResponse { TeacherId = id };
        }
        public object Get(GetUserTeachers request)
        {
            return new GetUserTeachersResponse { Teachers = Repository.GetUserTeachers(request.UserId) };
        }
        public object Get(Use_Course_Books request)
        {
            return new Use_Course_BooksResponse { Use_Course_Books = Repository.Get<Use_Course_Book>() };
        }
        public object Get(GetUse_Course_Book request)
        {
            return new GetUse_Course_BookResponse { ResultUse_Course_Book = Repository.Get<Use_Course_Book>(request.Id) };
        }
        public object Post(AddUse_Course_Book request)
        {
            var id = Repository.AddUse_Course_Book(request.CourseId, request.BookId);
            return new AddUse_Course_BookResponse { Use_Course_BookId = id };
        }
        public object Get(GetCourseUse_Course_Books request)
        {
            return new GetCourseUse_Course_BooksResponse { Use_Course_Books = Repository.GetCourseUse_Course_Books(request.CourseId) };
        }
        public object Get(GetBookUse_Course_Books request)
        {
            return new GetBookUse_Course_BooksResponse { Use_Course_Books = Repository.GetBookUse_Course_Books(request.BookId) };
        }
        public object Get(Users request)
        {
            return new UsersResponse { Users = Repository.Get<User>() };
        }
        public object Get(GetUser request)
        {
            return new GetUserResponse { ResultUser = Repository.Get<User>(request.Id) };
        }
        public object Post(AddUser request)
        {
            var id = Repository.AddUser(request.Username, request.Password, request.Name, request.LastName, request.LocalProfileImgPath, request.CloudProfileImgPath);
            return new AddUserResponse { UserId = id };
        } 




    }


    [Route("/answer_student_questions", "POST")]
    public class AddAnswer_Student_Question
    {
        public long StudentId { get; set; }
        public long QuestionId { get; set; }
        public long OptionId { get; set; }

    }
    public class AddAnswer_Student_QuestionResponse
    {
        public long Answer_Student_QuestionId { get; set; }
    }
    [Route("/answer_student_questions", "GET")]
    public class Answer_Student_Questions
    {
    }
    public class Answer_Student_QuestionsResponse
    {
        public IEnumerable<Answer_Student_Question> Answer_Student_Questions { get; set; }
    }
    [Route("/answer_student_questions/{Id}", "GET")]
    public class GetAnswer_Student_Question
    {
        public long Id { get; set; }
    }
    public class GetAnswer_Student_QuestionResponse
    {
        public Answer_Student_Question ResultAnswer_Student_Question { get; set; }
    }
    [Route("/student_answer_student_questions/{StudentId}", "GET")]
    public class GetStudentAnswer_Student_Questions
    {
        public long StudentId { get; set; }

    }
    public class GetStudentAnswer_Student_QuestionsResponse
    {
        public IEnumerable<Answer_Student_Question> Answer_Student_Questions { get; set; }
    }
    [Route("/question_answer_student_questions/{QuestionId}", "GET")]
    public class GetQuestionAnswer_Student_Questions
    {
        public long QuestionId { get; set; }

    }
    public class GetQuestionAnswer_Student_QuestionsResponse
    {
        public IEnumerable<Answer_Student_Question> Answer_Student_Questions { get; set; }
    }
    [Route("/option_answer_student_questions/{OptionId}", "GET")]
    public class GetOptionAnswer_Student_Questions
    {
        public long OptionId { get; set; }

    }
    public class GetOptionAnswer_Student_QuestionsResponse
    {
        public IEnumerable<Answer_Student_Question> Answer_Student_Questions { get; set; }
    }
    [Route("/books", "POST")]
    public class AddBook
    {
        public string Title { get; set; }
        public long TeacherId { get; set; }
        public long CategoryId { get; set; }
        public DateTime UploadDate { get; set; }
        public string Description { get; set; }
        public long ReadCount { get; set; }
        public string LocalImgPath { get; set; }
        public string CloudImgPath { get; set; }
        public double Prize { get; set; }
        public int PagesNum { get; set; }

    }
    public class AddBookResponse
    {
        public long BookId { get; set; }
    }
    [Route("/books", "GET")]
    public class Books
    {
    }
    public class BooksResponse
    {
        public IEnumerable<Book> Books { get; set; }
    }
    [Route("/books/{Id}", "GET")]
    public class GetBook
    {
        public long Id { get; set; }
    }
    public class GetBookResponse
    {
        public Book ResultBook { get; set; }
    }
    [Route("/teacher_books/{TeacherId}", "GET")]
    public class GetTeacherBooks
    {
        public long TeacherId { get; set; }

    }
    public class GetTeacherBooksResponse
    {
        public IEnumerable<Book> Books { get; set; }
    }
    [Route("/category_books/{CategoryId}", "GET")]
    public class GetCategoryBooks
    {
        public long CategoryId { get; set; }

    }
    public class GetCategoryBooksResponse
    {
        public IEnumerable<Book> Books { get; set; }
    }
    [Route("/categorys", "POST")]
    public class AddCategory
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }
    public class AddCategoryResponse
    {
        public long CategoryId { get; set; }
    }
    [Route("/categorys", "GET")]
    public class Categorys
    {
    }
    public class CategorysResponse
    {
        public IEnumerable<Category> Categorys { get; set; }
    }
    [Route("/categorys/{Id}", "GET")]
    public class GetCategory
    {
        public long Id { get; set; }
    }
    public class GetCategoryResponse
    {
        public Category ResultCategory { get; set; }
    }
    [Route("/chapters", "POST")]
    public class AddChapter
    {
        public string Name { get; set; }
        public string LocalImgPath { get; set; }
        public string CloudImgPath { get; set; }
        public long BookId { get; set; }

    }
    public class AddChapterResponse
    {
        public long ChapterId { get; set; }
    }
    [Route("/chapters", "GET")]
    public class Chapters
    {
    }
    public class ChaptersResponse
    {
        public IEnumerable<Chapter> Chapters { get; set; }
    }
    [Route("/chapters/{Id}", "GET")]
    public class GetChapter
    {
        public long Id { get; set; }
    }
    public class GetChapterResponse
    {
        public Chapter ResultChapter { get; set; }
    }
    [Route("/book_chapters/{BookId}", "GET")]
    public class GetBookChapters
    {
        public long BookId { get; set; }

    }
    public class GetBookChaptersResponse
    {
        public IEnumerable<Chapter> Chapters { get; set; }
    }
    [Route("/courses", "POST")]
    public class AddCourse
    {
        public string Name { get; set; }
        public long Duration { get; set; }
        public long CategoryId { get; set; }
        public long TeacherId { get; set; }

    }
    public class AddCourseResponse
    {
        public long CourseId { get; set; }
    }
    [Route("/courses", "GET")]
    public class Courses
    {
    }
    public class CoursesResponse
    {
        public IEnumerable<Course> Courses { get; set; }
    }
    [Route("/courses/{Id}", "GET")]
    public class GetCourse
    {
        public long Id { get; set; }
    }
    public class GetCourseResponse
    {
        public Course ResultCourse { get; set; }
    }
    [Route("/category_courses/{CategoryId}", "GET")]
    public class GetCategoryCourses
    {
        public long CategoryId { get; set; }

    }
    public class GetCategoryCoursesResponse
    {
        public IEnumerable<Course> Courses { get; set; }
    }
    [Route("/teacher_courses/{TeacherId}", "GET")]
    public class GetTeacherCourses
    {
        public long TeacherId { get; set; }

    }
    public class GetTeacherCoursesResponse
    {
        public IEnumerable<Course> Courses { get; set; }
    }
    [Route("/enrollments", "POST")]
    public class AddEnrollment
    {
        public long StudentId { get; set; }
        public long CourseId { get; set; }

    }
    public class AddEnrollmentResponse
    {
        public long EnrollmentId { get; set; }
    }
    [Route("/enrollments", "GET")]
    public class Enrollments
    {
    }
    public class EnrollmentsResponse
    {
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
    [Route("/enrollments/{Id}", "GET")]
    public class GetEnrollment
    {
        public long Id { get; set; }
    }
    public class GetEnrollmentResponse
    {
        public Enrollment ResultEnrollment { get; set; }
    }
    [Route("/student_enrollments/{StudentId}", "GET")]
    public class GetStudentEnrollments
    {
        public long StudentId { get; set; }

    }
    public class GetStudentEnrollmentsResponse
    {
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
    [Route("/course_enrollments/{CourseId}", "GET")]
    public class GetCourseEnrollments
    {
        public long CourseId { get; set; }

    }
    public class GetCourseEnrollmentsResponse
    {
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
    [Route("/favourite_student_books", "POST")]
    public class AddFavourite_Student_Book
    {
        public long StudentId { get; set; }
        public long BookId { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }

    }
    public class AddFavourite_Student_BookResponse
    {
        public long Favourite_Student_BookId { get; set; }
    }
    [Route("/favourite_student_books", "GET")]
    public class Favourite_Student_Books
    {
    }
    public class Favourite_Student_BooksResponse
    {
        public IEnumerable<Favourite_Student_Book> Favourite_Student_Books { get; set; }
    }
    [Route("/favourite_student_books/{Id}", "GET")]
    public class GetFavourite_Student_Book
    {
        public long Id { get; set; }
    }
    public class GetFavourite_Student_BookResponse
    {
        public Favourite_Student_Book ResultFavourite_Student_Book { get; set; }
    }
    [Route("/student_favourite_student_books/{StudentId}", "GET")]
    public class GetStudentFavourite_Student_Books
    {
        public long StudentId { get; set; }

    }
    public class GetStudentFavourite_Student_BooksResponse
    {
        public IEnumerable<Favourite_Student_Book> Favourite_Student_Books { get; set; }
    }
    [Route("/book_favourite_student_books/{BookId}", "GET")]
    public class GetBookFavourite_Student_Books
    {
        public long BookId { get; set; }

    }
    public class GetBookFavourite_Student_BooksResponse
    {
        public IEnumerable<Favourite_Student_Book> Favourite_Student_Books { get; set; }
    }
    [Route("/has_question_options", "POST")]
    public class AddHas_Question_Option
    {
        public long QuestionId { get; set; }
        public long OptionId { get; set; }

    }
    public class AddHas_Question_OptionResponse
    {
        public long Has_Question_OptionId { get; set; }
    }
    [Route("/has_question_options", "GET")]
    public class Has_Question_Options
    {
    }
    public class Has_Question_OptionsResponse
    {
        public IEnumerable<Has_Question_Option> Has_Question_Options { get; set; }
    }
    [Route("/has_question_options/{Id}", "GET")]
    public class GetHas_Question_Option
    {
        public long Id { get; set; }
    }
    public class GetHas_Question_OptionResponse
    {
        public Has_Question_Option ResultHas_Question_Option { get; set; }
    }
    [Route("/question_has_question_options/{QuestionId}", "GET")]
    public class GetQuestionHas_Question_Options
    {
        public long QuestionId { get; set; }

    }
    public class GetQuestionHas_Question_OptionsResponse
    {
        public IEnumerable<Has_Question_Option> Has_Question_Options { get; set; }
    }
    [Route("/option_has_question_options/{OptionId}", "GET")]
    public class GetOptionHas_Question_Options
    {
        public long OptionId { get; set; }

    }
    public class GetOptionHas_Question_OptionsResponse
    {
        public IEnumerable<Has_Question_Option> Has_Question_Options { get; set; }
    }
    [Route("/options", "POST")]
    public class AddOption
    {
        public string Name { get; set; }

    }
    public class AddOptionResponse
    {
        public long OptionId { get; set; }
    }
    [Route("/options", "GET")]
    public class Options
    {
    }
    public class OptionsResponse
    {
        public IEnumerable<Option> Options { get; set; }
    }
    [Route("/options/{Id}", "GET")]
    public class GetOption
    {
        public long Id { get; set; }
    }
    public class GetOptionResponse
    {
        public Option ResultOption { get; set; }
    }
    [Route("/pages", "POST")]
    public class AddPage
    {
        public string LocalImgPath { get; set; }
        public string CloudImgPath { get; set; }
        public long SectionId { get; set; }

    }
    public class AddPageResponse
    {
        public long PageId { get; set; }
    }
    [Route("/pages", "GET")]
    public class Pages
    {
    }
    public class PagesResponse
    {
        public IEnumerable<Page> Pages { get; set; }
    }
    [Route("/pages/{Id}", "GET")]
    public class GetPage
    {
        public long Id { get; set; }
    }
    public class GetPageResponse
    {
        public Page ResultPage { get; set; }
    }
    [Route("/section_pages/{SectionId}", "GET")]
    public class GetSectionPages
    {
        public long SectionId { get; set; }

    }
    public class GetSectionPagesResponse
    {
        public IEnumerable<Page> Pages { get; set; }
    }
    [Route("/posts", "POST")]
    public class AddPost
    {
        public DateTime created_at { get; set; }
        public string Text { get; set; }
        public long UserId { get; set; }
        public long BookId { get; set; }

    }
    public class AddPostResponse
    {
        public long PostId { get; set; }
    }
    [Route("/posts", "GET")]
    public class Posts
    {
    }
    public class PostsResponse
    {
        public IEnumerable<Post> Posts { get; set; }
    }
    [Route("/posts/{Id}", "GET")]
    public class GetPost
    {
        public long Id { get; set; }
    }
    public class GetPostResponse
    {
        public Post ResultPost { get; set; }
    }
    [Route("/user_posts/{UserId}", "GET")]
    public class GetUserPosts
    {
        public long UserId { get; set; }

    }
    public class GetUserPostsResponse
    {
        public IEnumerable<Post> Posts { get; set; }
    }
    [Route("/book_posts/{BookId}", "GET")]
    public class GetBookPosts
    {
        public long BookId { get; set; }

    }
    public class GetBookPostsResponse
    {
        public IEnumerable<Post> Posts { get; set; }
    }
    [Route("/questions", "POST")]
    public class AddQuestion
    {
        public string Text { get; set; }
        public long OptionId { get; set; }
        public long QuizId { get; set; }

    }
    public class AddQuestionResponse
    {
        public long QuestionId { get; set; }
    }
    [Route("/questions", "GET")]
    public class Questions
    {
    }
    public class QuestionsResponse
    {
        public IEnumerable<Question> Questions { get; set; }
    }
    [Route("/questions/{Id}", "GET")]
    public class GetQuestion
    {
        public long Id { get; set; }
    }
    public class GetQuestionResponse
    {
        public Question ResultQuestion { get; set; }
    }
    [Route("/option_questions/{OptionId}", "GET")]
    public class GetOptionQuestions
    {
        public long OptionId { get; set; }

    }
    public class GetOptionQuestionsResponse
    {
        public IEnumerable<Question> Questions { get; set; }
    }
    [Route("/quiz_questions/{QuizId}", "GET")]
    public class GetQuizQuestions
    {
        public long QuizId { get; set; }

    }
    public class GetQuizQuestionsResponse
    {
        public IEnumerable<Question> Questions { get; set; }
    }
    [Route("/quizs", "POST")]
    public class AddQuiz
    {
        public string Name { get; set; }
        public long BookId { get; set; }

    }
    public class AddQuizResponse
    {
        public long QuizId { get; set; }
    }
    [Route("/quizs", "GET")]
    public class Quizs
    {
    }
    public class QuizsResponse
    {
        public IEnumerable<Quiz> Quizs { get; set; }
    }
    [Route("/quizs/{Id}", "GET")]
    public class GetQuiz
    {
        public long Id { get; set; }
    }
    public class GetQuizResponse
    {
        public Quiz ResultQuiz { get; set; }
    }
    [Route("/book_quizs/{BookId}", "GET")]
    public class GetBookQuizs
    {
        public long BookId { get; set; }

    }
    public class GetBookQuizsResponse
    {
        public IEnumerable<Quiz> Quizs { get; set; }
    }
    [Route("/sections", "POST")]
    public class AddSection
    {
        public string Name { get; set; }
        public long ChapterId { get; set; }

    }
    public class AddSectionResponse
    {
        public long SectionId { get; set; }
    }
    [Route("/sections", "GET")]
    public class Sections
    {
    }
    public class SectionsResponse
    {
        public IEnumerable<Section> Sections { get; set; }
    }
    [Route("/sections/{Id}", "GET")]
    public class GetSection
    {
        public long Id { get; set; }
    }
    public class GetSectionResponse
    {
        public Section ResultSection { get; set; }
    }
    [Route("/chapter_sections/{ChapterId}", "GET")]
    public class GetChapterSections
    {
        public long ChapterId { get; set; }

    }
    public class GetChapterSectionsResponse
    {
        public IEnumerable<Section> Sections { get; set; }
    }
    [Route("/students", "POST")]
    public class AddStudent
    {
        public long UserId { get; set; }

    }
    public class AddStudentResponse
    {
        public long StudentId { get; set; }
    }
    [Route("/students", "GET")]
    public class Students
    {
    }
    public class StudentsResponse
    {
        public IEnumerable<Student> Students { get; set; }
    }
    [Route("/students/{Id}", "GET")]
    public class GetStudent
    {
        public long Id { get; set; }
    }
    public class GetStudentResponse
    {
        public Student ResultStudent { get; set; }
    }
    [Route("/user_students/{UserId}", "GET")]
    public class GetUserStudents
    {
        public long UserId { get; set; }

    }
    public class GetUserStudentsResponse
    {
        public IEnumerable<Student> Students { get; set; }
    }
    [Route("/takes_student_quizs", "POST")]
    public class AddTakes_Student_Quiz
    {
        public long StudentId { get; set; }
        public long QuizId { get; set; }
        public long Grade { get; set; }
        public DateTime Date { get; set; }

    }
    public class AddTakes_Student_QuizResponse
    {
        public long Takes_Student_QuizId { get; set; }
    }
    [Route("/takes_student_quizs", "GET")]
    public class Takes_Student_Quizs
    {
    }
    public class Takes_Student_QuizsResponse
    {
        public IEnumerable<Takes_Student_Quiz> Takes_Student_Quizs { get; set; }
    }
    [Route("/takes_student_quizs/{Id}", "GET")]
    public class GetTakes_Student_Quiz
    {
        public long Id { get; set; }
    }
    public class GetTakes_Student_QuizResponse
    {
        public Takes_Student_Quiz ResultTakes_Student_Quiz { get; set; }
    }
    [Route("/student_takes_student_quizs/{StudentId}", "GET")]
    public class GetStudentTakes_Student_Quizs
    {
        public long StudentId { get; set; }

    }
    public class GetStudentTakes_Student_QuizsResponse
    {
        public IEnumerable<Takes_Student_Quiz> Takes_Student_Quizs { get; set; }
    }
    [Route("/quiz_takes_student_quizs/{QuizId}", "GET")]
    public class GetQuizTakes_Student_Quizs
    {
        public long QuizId { get; set; }

    }
    public class GetQuizTakes_Student_QuizsResponse
    {
        public IEnumerable<Takes_Student_Quiz> Takes_Student_Quizs { get; set; }
    }
    [Route("/teachers", "POST")]
    public class AddTeacher
    {
        public long UserId { get; set; }

    }
    public class AddTeacherResponse
    {
        public long TeacherId { get; set; }
    }
    [Route("/teachers", "GET")]
    public class Teachers
    {
    }
    public class TeachersResponse
    {
        public IEnumerable<Teacher> Teachers { get; set; }
    }
    [Route("/teachers/{Id}", "GET")]
    public class GetTeacher
    {
        public long Id { get; set; }
    }
    public class GetTeacherResponse
    {
        public Teacher ResultTeacher { get; set; }
    }
    [Route("/user_teachers/{UserId}", "GET")]
    public class GetUserTeachers
    {
        public long UserId { get; set; }

    }
    public class GetUserTeachersResponse
    {
        public IEnumerable<Teacher> Teachers { get; set; }
    }
    [Route("/use_course_books", "POST")]
    public class AddUse_Course_Book
    {
        public long CourseId { get; set; }
        public long BookId { get; set; }

    }
    public class AddUse_Course_BookResponse
    {
        public long Use_Course_BookId { get; set; }
    }
    [Route("/use_course_books", "GET")]
    public class Use_Course_Books
    {
    }
    public class Use_Course_BooksResponse
    {
        public IEnumerable<Use_Course_Book> Use_Course_Books { get; set; }
    }
    [Route("/use_course_books/{Id}", "GET")]
    public class GetUse_Course_Book
    {
        public long Id { get; set; }
    }
    public class GetUse_Course_BookResponse
    {
        public Use_Course_Book ResultUse_Course_Book { get; set; }
    }
    [Route("/course_use_course_books/{CourseId}", "GET")]
    public class GetCourseUse_Course_Books
    {
        public long CourseId { get; set; }

    }
    public class GetCourseUse_Course_BooksResponse
    {
        public IEnumerable<Use_Course_Book> Use_Course_Books { get; set; }
    }
    [Route("/book_use_course_books/{BookId}", "GET")]
    public class GetBookUse_Course_Books
    {
        public long BookId { get; set; }

    }
    public class GetBookUse_Course_BooksResponse
    {
        public IEnumerable<Use_Course_Book> Use_Course_Books { get; set; }
    }
    [Route("/users", "POST")]
    public class AddUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LocalProfileImgPath { get; set; }
        public string CloudProfileImgPath { get; set; }

    }
    public class AddUserResponse
    {
        public long UserId { get; set; }
    }
    [Route("/users", "GET")]
    public class Users
    {
    }
    public class UsersResponse
    {
        public IEnumerable<User> Users { get; set; }
    }
    [Route("/users/{Id}", "GET")]
    public class GetUser
    {
        public long Id { get; set; }
    }
    public class GetUserResponse
    {
        public User ResultUser { get; set; }
    } 




   


}