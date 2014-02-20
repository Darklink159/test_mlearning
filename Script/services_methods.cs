public object Get(Answer_Student_Questions request) 
				{ 
					return new Answer_Student_QuestionsResponse { Answer_Student_Questions = Repository.Get<Answer_Student_Question>()};
 				}
public object Get(GetAnswer_Student_Question request) 
				{ 
					return new GetAnswer_Student_QuestionResponse { ResultAnswer_Student_Question = Repository.Get<Answer_Student_Question>(request.Id)};
 				}
public object Post(AddAnswer_Student_Question request) 
				{
 					var id = Repository.AddAnswer_Student_Question(request.StudentId,request.QuestionId,request.OptionId); 
					return new AddAnswer_Student_QuestionResponse { Answer_Student_QuestionId = id };
 				} 
public object Get(GetStudentAnswer_Student_Questions request) 
				{ 
					return new GetStudentAnswer_Student_QuestionsResponse { Answer_Student_Questions = Repository.GetStudentAnswer_Student_Questions(request.StudentId)};
 				}
public object Get(GetQuestionAnswer_Student_Questions request) 
				{ 
					return new GetQuestionAnswer_Student_QuestionsResponse { Answer_Student_Questions = Repository.GetQuestionAnswer_Student_Questions(request.QuestionId)};
 				}
public object Get(GetOptionAnswer_Student_Questions request) 
				{ 
					return new GetOptionAnswer_Student_QuestionsResponse { Answer_Student_Questions = Repository.GetOptionAnswer_Student_Questions(request.OptionId)};
 				}
public object Get(Books request) 
				{ 
					return new BooksResponse { Books = Repository.Get<Book>()};
 				}
public object Get(GetBook request) 
				{ 
					return new GetBookResponse { ResultBook = Repository.Get<Book>(request.Id)};
 				}
public object Post(AddBook request) 
				{
 					var id = Repository.AddBook(request.Title,request.TeacherId,request.CategoryId,request.UploadDate,request.Description,request.ReadCount,request.LocalImgPath,request.CloudImgPath,request.Prize,request.PagesNum); 
					return new AddBookResponse { BookId = id };
 				} 
public object Get(GetTeacherBooks request) 
				{ 
					return new GetTeacherBooksResponse { Books = Repository.GetTeacherBooks(request.TeacherId)};
 				}
public object Get(GetCategoryBooks request) 
				{ 
					return new GetCategoryBooksResponse { Books = Repository.GetCategoryBooks(request.CategoryId)};
 				}
public object Get(Categorys request) 
				{ 
					return new CategorysResponse { Categorys = Repository.Get<Category>()};
 				}
public object Get(GetCategory request) 
				{ 
					return new GetCategoryResponse { ResultCategory = Repository.Get<Category>(request.Id)};
 				}
public object Post(AddCategory request) 
				{
 					var id = Repository.AddCategory(request.Title,request.Description); 
					return new AddCategoryResponse { CategoryId = id };
 				} 
public object Get(Chapters request) 
				{ 
					return new ChaptersResponse { Chapters = Repository.Get<Chapter>()};
 				}
public object Get(GetChapter request) 
				{ 
					return new GetChapterResponse { ResultChapter = Repository.Get<Chapter>(request.Id)};
 				}
public object Post(AddChapter request) 
				{
 					var id = Repository.AddChapter(request.Name,request.LocalImgPath,request.CloudImgPath,request.BookId); 
					return new AddChapterResponse { ChapterId = id };
 				} 
public object Get(GetBookChapters request) 
				{ 
					return new GetBookChaptersResponse { Chapters = Repository.GetBookChapters(request.BookId)};
 				}
public object Get(Courses request) 
				{ 
					return new CoursesResponse { Courses = Repository.Get<Course>()};
 				}
public object Get(GetCourse request) 
				{ 
					return new GetCourseResponse { ResultCourse = Repository.Get<Course>(request.Id)};
 				}
public object Post(AddCourse request) 
				{
 					var id = Repository.AddCourse(request.Name,request.Duration,request.CategoryId,request.TeacherId); 
					return new AddCourseResponse { CourseId = id };
 				} 
public object Get(GetCategoryCourses request) 
				{ 
					return new GetCategoryCoursesResponse { Courses = Repository.GetCategoryCourses(request.CategoryId)};
 				}
public object Get(GetTeacherCourses request) 
				{ 
					return new GetTeacherCoursesResponse { Courses = Repository.GetTeacherCourses(request.TeacherId)};
 				}
public object Get(Enrollments request) 
				{ 
					return new EnrollmentsResponse { Enrollments = Repository.Get<Enrollment>()};
 				}
public object Get(GetEnrollment request) 
				{ 
					return new GetEnrollmentResponse { ResultEnrollment = Repository.Get<Enrollment>(request.Id)};
 				}
public object Post(AddEnrollment request) 
				{
 					var id = Repository.AddEnrollment(request.StudentId,request.CourseId); 
					return new AddEnrollmentResponse { EnrollmentId = id };
 				} 
public object Get(GetStudentEnrollments request) 
				{ 
					return new GetStudentEnrollmentsResponse { Enrollments = Repository.GetStudentEnrollments(request.StudentId)};
 				}
public object Get(GetCourseEnrollments request) 
				{ 
					return new GetCourseEnrollmentsResponse { Enrollments = Repository.GetCourseEnrollments(request.CourseId)};
 				}
public object Get(Favourite_Student_Books request) 
				{ 
					return new Favourite_Student_BooksResponse { Favourite_Student_Books = Repository.Get<Favourite_Student_Book>()};
 				}
public object Get(GetFavourite_Student_Book request) 
				{ 
					return new GetFavourite_Student_BookResponse { ResultFavourite_Student_Book = Repository.Get<Favourite_Student_Book>(request.Id)};
 				}
public object Post(AddFavourite_Student_Book request) 
				{
 					var id = Repository.AddFavourite_Student_Book(request.StudentId,request.BookId,request.Date,request.Rate); 
					return new AddFavourite_Student_BookResponse { Favourite_Student_BookId = id };
 				} 
public object Get(GetStudentFavourite_Student_Books request) 
				{ 
					return new GetStudentFavourite_Student_BooksResponse { Favourite_Student_Books = Repository.GetStudentFavourite_Student_Books(request.StudentId)};
 				}
public object Get(GetBookFavourite_Student_Books request) 
				{ 
					return new GetBookFavourite_Student_BooksResponse { Favourite_Student_Books = Repository.GetBookFavourite_Student_Books(request.BookId)};
 				}
public object Get(Has_Question_Options request) 
				{ 
					return new Has_Question_OptionsResponse { Has_Question_Options = Repository.Get<Has_Question_Option>()};
 				}
public object Get(GetHas_Question_Option request) 
				{ 
					return new GetHas_Question_OptionResponse { ResultHas_Question_Option = Repository.Get<Has_Question_Option>(request.Id)};
 				}
public object Post(AddHas_Question_Option request) 
				{
 					var id = Repository.AddHas_Question_Option(request.QuestionId,request.OptionId); 
					return new AddHas_Question_OptionResponse { Has_Question_OptionId = id };
 				} 
public object Get(GetQuestionHas_Question_Options request) 
				{ 
					return new GetQuestionHas_Question_OptionsResponse { Has_Question_Options = Repository.GetQuestionHas_Question_Options(request.QuestionId)};
 				}
public object Get(GetOptionHas_Question_Options request) 
				{ 
					return new GetOptionHas_Question_OptionsResponse { Has_Question_Options = Repository.GetOptionHas_Question_Options(request.OptionId)};
 				}
public object Get(Options request) 
				{ 
					return new OptionsResponse { Options = Repository.Get<Option>()};
 				}
public object Get(GetOption request) 
				{ 
					return new GetOptionResponse { ResultOption = Repository.Get<Option>(request.Id)};
 				}
public object Post(AddOption request) 
				{
 					var id = Repository.AddOption(request.Name); 
					return new AddOptionResponse { OptionId = id };
 				} 
public object Get(Pages request) 
				{ 
					return new PagesResponse { Pages = Repository.Get<Page>()};
 				}
public object Get(GetPage request) 
				{ 
					return new GetPageResponse { ResultPage = Repository.Get<Page>(request.Id)};
 				}
public object Post(AddPage request) 
				{
 					var id = Repository.AddPage(request.LocalImgPath,request.CloudImgPath,request.SectionId); 
					return new AddPageResponse { PageId = id };
 				} 
public object Get(GetSectionPages request) 
				{ 
					return new GetSectionPagesResponse { Pages = Repository.GetSectionPages(request.SectionId)};
 				}
public object Get(Posts request) 
				{ 
					return new PostsResponse { Posts = Repository.Get<Post>()};
 				}
public object Get(GetPost request) 
				{ 
					return new GetPostResponse { ResultPost = Repository.Get<Post>(request.Id)};
 				}
public object Post(AddPost request) 
				{
 					var id = Repository.AddPost(request.created_at,request.Text,request.UserId,request.BookId); 
					return new AddPostResponse { PostId = id };
 				} 
public object Get(GetUserPosts request) 
				{ 
					return new GetUserPostsResponse { Posts = Repository.GetUserPosts(request.UserId)};
 				}
public object Get(GetBookPosts request) 
				{ 
					return new GetBookPostsResponse { Posts = Repository.GetBookPosts(request.BookId)};
 				}
public object Get(Questions request) 
				{ 
					return new QuestionsResponse { Questions = Repository.Get<Question>()};
 				}
public object Get(GetQuestion request) 
				{ 
					return new GetQuestionResponse { ResultQuestion = Repository.Get<Question>(request.Id)};
 				}
public object Post(AddQuestion request) 
				{
 					var id = Repository.AddQuestion(request.Text,request.OptionId,request.QuizId); 
					return new AddQuestionResponse { QuestionId = id };
 				} 
public object Get(GetOptionQuestions request) 
				{ 
					return new GetOptionQuestionsResponse { Questions = Repository.GetOptionQuestions(request.OptionId)};
 				}
public object Get(GetQuizQuestions request) 
				{ 
					return new GetQuizQuestionsResponse { Questions = Repository.GetQuizQuestions(request.QuizId)};
 				}
public object Get(Quizs request) 
				{ 
					return new QuizsResponse { Quizs = Repository.Get<Quiz>()};
 				}
public object Get(GetQuiz request) 
				{ 
					return new GetQuizResponse { ResultQuiz = Repository.Get<Quiz>(request.Id)};
 				}
public object Post(AddQuiz request) 
				{
 					var id = Repository.AddQuiz(request.Name,request.BookId); 
					return new AddQuizResponse { QuizId = id };
 				} 
public object Get(GetBookQuizs request) 
				{ 
					return new GetBookQuizsResponse { Quizs = Repository.GetBookQuizs(request.BookId)};
 				}
public object Get(Sections request) 
				{ 
					return new SectionsResponse { Sections = Repository.Get<Section>()};
 				}
public object Get(GetSection request) 
				{ 
					return new GetSectionResponse { ResultSection = Repository.Get<Section>(request.Id)};
 				}
public object Post(AddSection request) 
				{
 					var id = Repository.AddSection(request.Name,request.ChapterId); 
					return new AddSectionResponse { SectionId = id };
 				} 
public object Get(GetChapterSections request) 
				{ 
					return new GetChapterSectionsResponse { Sections = Repository.GetChapterSections(request.ChapterId)};
 				}
public object Get(Students request) 
				{ 
					return new StudentsResponse { Students = Repository.Get<Student>()};
 				}
public object Get(GetStudent request) 
				{ 
					return new GetStudentResponse { ResultStudent = Repository.Get<Student>(request.Id)};
 				}
public object Post(AddStudent request) 
				{
 					var id = Repository.AddStudent(request.UserId); 
					return new AddStudentResponse { StudentId = id };
 				} 
public object Get(GetUserStudents request) 
				{ 
					return new GetUserStudentsResponse { Students = Repository.GetUserStudents(request.UserId)};
 				}
public object Get(Takes_Student_Quizs request) 
				{ 
					return new Takes_Student_QuizsResponse { Takes_Student_Quizs = Repository.Get<Takes_Student_Quiz>()};
 				}
public object Get(GetTakes_Student_Quiz request) 
				{ 
					return new GetTakes_Student_QuizResponse { ResultTakes_Student_Quiz = Repository.Get<Takes_Student_Quiz>(request.Id)};
 				}
public object Post(AddTakes_Student_Quiz request) 
				{
 					var id = Repository.AddTakes_Student_Quiz(request.StudentId,request.QuizId,request.Grade,request.Date); 
					return new AddTakes_Student_QuizResponse { Takes_Student_QuizId = id };
 				} 
public object Get(GetStudentTakes_Student_Quizs request) 
				{ 
					return new GetStudentTakes_Student_QuizsResponse { Takes_Student_Quizs = Repository.GetStudentTakes_Student_Quizs(request.StudentId)};
 				}
public object Get(GetQuizTakes_Student_Quizs request) 
				{ 
					return new GetQuizTakes_Student_QuizsResponse { Takes_Student_Quizs = Repository.GetQuizTakes_Student_Quizs(request.QuizId)};
 				}
public object Get(Teachers request) 
				{ 
					return new TeachersResponse { Teachers = Repository.Get<Teacher>()};
 				}
public object Get(GetTeacher request) 
				{ 
					return new GetTeacherResponse { ResultTeacher = Repository.Get<Teacher>(request.Id)};
 				}
public object Post(AddTeacher request) 
				{
 					var id = Repository.AddTeacher(request.UserId); 
					return new AddTeacherResponse { TeacherId = id };
 				} 
public object Get(GetUserTeachers request) 
				{ 
					return new GetUserTeachersResponse { Teachers = Repository.GetUserTeachers(request.UserId)};
 				}
public object Get(Use_Course_Books request) 
				{ 
					return new Use_Course_BooksResponse { Use_Course_Books = Repository.Get<Use_Course_Book>()};
 				}
public object Get(GetUse_Course_Book request) 
				{ 
					return new GetUse_Course_BookResponse { ResultUse_Course_Book = Repository.Get<Use_Course_Book>(request.Id)};
 				}
public object Post(AddUse_Course_Book request) 
				{
 					var id = Repository.AddUse_Course_Book(request.CourseId,request.BookId); 
					return new AddUse_Course_BookResponse { Use_Course_BookId = id };
 				} 
public object Get(GetCourseUse_Course_Books request) 
				{ 
					return new GetCourseUse_Course_BooksResponse { Use_Course_Books = Repository.GetCourseUse_Course_Books(request.CourseId)};
 				}
public object Get(GetBookUse_Course_Books request) 
				{ 
					return new GetBookUse_Course_BooksResponse { Use_Course_Books = Repository.GetBookUse_Course_Books(request.BookId)};
 				}
public object Get(Users request) 
				{ 
					return new UsersResponse { Users = Repository.Get<User>()};
 				}
public object Get(GetUser request) 
				{ 
					return new GetUserResponse { ResultUser = Repository.Get<User>(request.Id)};
 				}
public object Post(AddUser request) 
				{
 					var id = Repository.AddUser(request.Username,request.Password,request.Name,request.LastName,request.LocalProfileImgPath,request.CloudProfileImgPath); 
					return new AddUserResponse { UserId = id };
 				} 
