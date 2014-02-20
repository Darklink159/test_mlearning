public long AddAnswer_Student_Question(long studentid, long questionid, long optionid ) 
 { 
 	 if (isValidId("student",studentid) && isValidId("question",questionid) && isValidId("option",optionid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisAnswer_Student_Questions= redisClient.As<Answer_Student_Question>(); 
 				var entidad = new Answer_Student_Question{ StudentId = studentid, QuestionId = questionid, OptionId = optionid, Id = redisAnswer_Student_Questions.GetNextSequence()}; 
                 redisAnswer_Student_Questions.Store(entidad);
				 redisClient.AddItemToSet(StudentAnswer_Student_QuestionIndex.Answer_Student_Questions(studentid), entidad.Id.ToString());
				 redisClient.AddItemToSet(QuestionAnswer_Student_QuestionIndex.Answer_Student_Questions(questionid), entidad.Id.ToString());
				 redisClient.AddItemToSet(OptionAnswer_Student_QuestionIndex.Answer_Student_Questions(optionid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Answer_Student_Question> GetStudentAnswer_Student_Questions(long studentid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsAnswer_Student_Questions= redisClient.GetAllItemsFromSet(StudentAnswer_Student_QuestionIndex.Answer_Student_Questions(studentid)); 
               return redisClient.As<Answer_Student_Question>().GetByIds(idsAnswer_Student_Questions); 
             } 
         } 
 
public IEnumerable<Answer_Student_Question> GetQuestionAnswer_Student_Questions(long questionid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsAnswer_Student_Questions= redisClient.GetAllItemsFromSet(QuestionAnswer_Student_QuestionIndex.Answer_Student_Questions(questionid)); 
               return redisClient.As<Answer_Student_Question>().GetByIds(idsAnswer_Student_Questions); 
             } 
         } 
 
public IEnumerable<Answer_Student_Question> GetOptionAnswer_Student_Questions(long optionid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsAnswer_Student_Questions= redisClient.GetAllItemsFromSet(OptionAnswer_Student_QuestionIndex.Answer_Student_Questions(optionid)); 
               return redisClient.As<Answer_Student_Question>().GetByIds(idsAnswer_Student_Questions); 
             } 
         } 
 
public long AddBook(string title, long teacherid, long categoryid, DateTime uploaddate, string description, long readcount, string localimgpath, string cloudimgpath, double prize, int pagesnum ) 
 { 
 	 if (isValidId("teacher",teacherid) && isValidId("category",categoryid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisBooks= redisClient.As<Book>(); 
 				var entidad = new Book{ Title = title, TeacherId = teacherid, CategoryId = categoryid, UploadDate = uploaddate, Description = description, ReadCount = readcount, LocalImgPath = localimgpath, CloudImgPath = cloudimgpath, Prize = prize, PagesNum = pagesnum, Id = redisBooks.GetNextSequence()}; 
                 redisBooks.Store(entidad);
				 redisClient.AddItemToSet(TeacherBookIndex.Books(teacherid), entidad.Id.ToString());
				 redisClient.AddItemToSet(CategoryBookIndex.Books(categoryid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Book> GetTeacherBooks(long teacherid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsBooks= redisClient.GetAllItemsFromSet(TeacherBookIndex.Books(teacherid)); 
               return redisClient.As<Book>().GetByIds(idsBooks); 
             } 
         } 
 
public IEnumerable<Book> GetCategoryBooks(long categoryid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsBooks= redisClient.GetAllItemsFromSet(CategoryBookIndex.Books(categoryid)); 
               return redisClient.As<Book>().GetByIds(idsBooks); 
             } 
         } 
 
public long AddCategory(string title, string description ) 
 { 
 			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisCategorys= redisClient.As<Category>(); 
 				var entidad = new Category{ Title = title, Description = description, Id = redisCategorys.GetNextSequence()}; 
                 redisCategorys.Store(entidad);
				 return entidad.Id; 
 			} 
} 
public long AddChapter(string name, string localimgpath, string cloudimgpath, long bookid ) 
 { 
 	 if (isValidId("book",bookid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisChapters= redisClient.As<Chapter>(); 
 				var entidad = new Chapter{ Name = name, LocalImgPath = localimgpath, CloudImgPath = cloudimgpath, BookId = bookid, Id = redisChapters.GetNextSequence()}; 
                 redisChapters.Store(entidad);
				 redisClient.AddItemToSet(BookChapterIndex.Chapters(bookid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Chapter> GetBookChapters(long bookid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsChapters= redisClient.GetAllItemsFromSet(BookChapterIndex.Chapters(bookid)); 
               return redisClient.As<Chapter>().GetByIds(idsChapters); 
             } 
         } 
 
public long AddCourse(string name, long duration, long categoryid, long teacherid ) 
 { 
 	 if (isValidId("category",categoryid) && isValidId("teacher",teacherid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisCourses= redisClient.As<Course>(); 
 				var entidad = new Course{ Name = name, Duration = duration, CategoryId = categoryid, TeacherId = teacherid, Id = redisCourses.GetNextSequence()}; 
                 redisCourses.Store(entidad);
				 redisClient.AddItemToSet(CategoryCourseIndex.Courses(categoryid), entidad.Id.ToString());
				 redisClient.AddItemToSet(TeacherCourseIndex.Courses(teacherid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Course> GetCategoryCourses(long categoryid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsCourses= redisClient.GetAllItemsFromSet(CategoryCourseIndex.Courses(categoryid)); 
               return redisClient.As<Course>().GetByIds(idsCourses); 
             } 
         } 
 
public IEnumerable<Course> GetTeacherCourses(long teacherid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsCourses= redisClient.GetAllItemsFromSet(TeacherCourseIndex.Courses(teacherid)); 
               return redisClient.As<Course>().GetByIds(idsCourses); 
             } 
         } 
 
public long AddEnrollment(long studentid, long courseid ) 
 { 
 	 if (isValidId("student",studentid) && isValidId("course",courseid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisEnrollments= redisClient.As<Enrollment>(); 
 				var entidad = new Enrollment{ StudentId = studentid, CourseId = courseid, Id = redisEnrollments.GetNextSequence()}; 
                 redisEnrollments.Store(entidad);
				 redisClient.AddItemToSet(StudentEnrollmentIndex.Enrollments(studentid), entidad.Id.ToString());
				 redisClient.AddItemToSet(CourseEnrollmentIndex.Enrollments(courseid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Enrollment> GetStudentEnrollments(long studentid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsEnrollments= redisClient.GetAllItemsFromSet(StudentEnrollmentIndex.Enrollments(studentid)); 
               return redisClient.As<Enrollment>().GetByIds(idsEnrollments); 
             } 
         } 
 
public IEnumerable<Enrollment> GetCourseEnrollments(long courseid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsEnrollments= redisClient.GetAllItemsFromSet(CourseEnrollmentIndex.Enrollments(courseid)); 
               return redisClient.As<Enrollment>().GetByIds(idsEnrollments); 
             } 
         } 
 
public long AddFavourite_Student_Book(long studentid, long bookid, DateTime date, int rate ) 
 { 
 	 if (isValidId("student",studentid) && isValidId("book",bookid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisFavourite_Student_Books= redisClient.As<Favourite_Student_Book>(); 
 				var entidad = new Favourite_Student_Book{ StudentId = studentid, BookId = bookid, Date = date, Rate = rate, Id = redisFavourite_Student_Books.GetNextSequence()}; 
                 redisFavourite_Student_Books.Store(entidad);
				 redisClient.AddItemToSet(StudentFavourite_Student_BookIndex.Favourite_Student_Books(studentid), entidad.Id.ToString());
				 redisClient.AddItemToSet(BookFavourite_Student_BookIndex.Favourite_Student_Books(bookid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Favourite_Student_Book> GetStudentFavourite_Student_Books(long studentid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsFavourite_Student_Books= redisClient.GetAllItemsFromSet(StudentFavourite_Student_BookIndex.Favourite_Student_Books(studentid)); 
               return redisClient.As<Favourite_Student_Book>().GetByIds(idsFavourite_Student_Books); 
             } 
         } 
 
public IEnumerable<Favourite_Student_Book> GetBookFavourite_Student_Books(long bookid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsFavourite_Student_Books= redisClient.GetAllItemsFromSet(BookFavourite_Student_BookIndex.Favourite_Student_Books(bookid)); 
               return redisClient.As<Favourite_Student_Book>().GetByIds(idsFavourite_Student_Books); 
             } 
         } 
 
public long AddHas_Question_Option(long questionid, long optionid ) 
 { 
 	 if (isValidId("question",questionid) && isValidId("option",optionid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisHas_Question_Options= redisClient.As<Has_Question_Option>(); 
 				var entidad = new Has_Question_Option{ QuestionId = questionid, OptionId = optionid, Id = redisHas_Question_Options.GetNextSequence()}; 
                 redisHas_Question_Options.Store(entidad);
				 redisClient.AddItemToSet(QuestionHas_Question_OptionIndex.Has_Question_Options(questionid), entidad.Id.ToString());
				 redisClient.AddItemToSet(OptionHas_Question_OptionIndex.Has_Question_Options(optionid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Has_Question_Option> GetQuestionHas_Question_Options(long questionid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsHas_Question_Options= redisClient.GetAllItemsFromSet(QuestionHas_Question_OptionIndex.Has_Question_Options(questionid)); 
               return redisClient.As<Has_Question_Option>().GetByIds(idsHas_Question_Options); 
             } 
         } 
 
public IEnumerable<Has_Question_Option> GetOptionHas_Question_Options(long optionid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsHas_Question_Options= redisClient.GetAllItemsFromSet(OptionHas_Question_OptionIndex.Has_Question_Options(optionid)); 
               return redisClient.As<Has_Question_Option>().GetByIds(idsHas_Question_Options); 
             } 
         } 
 
public long AddOption(string name ) 
 { 
 			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisOptions= redisClient.As<Option>(); 
 				var entidad = new Option{ Name = name, Id = redisOptions.GetNextSequence()}; 
                 redisOptions.Store(entidad);
				 return entidad.Id; 
 			} 
} 
public long AddPage(string localimgpath, string cloudimgpath, long sectionid ) 
 { 
 	 if (isValidId("section",sectionid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisPages= redisClient.As<Page>(); 
 				var entidad = new Page{ LocalImgPath = localimgpath, CloudImgPath = cloudimgpath, SectionId = sectionid, Id = redisPages.GetNextSequence()}; 
                 redisPages.Store(entidad);
				 redisClient.AddItemToSet(SectionPageIndex.Pages(sectionid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Page> GetSectionPages(long sectionid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsPages= redisClient.GetAllItemsFromSet(SectionPageIndex.Pages(sectionid)); 
               return redisClient.As<Page>().GetByIds(idsPages); 
             } 
         } 
 
public long AddPost(DateTime created_at, string text, long userid, long bookid ) 
 { 
 	 if (isValidId("user",userid) && isValidId("book",bookid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisPosts= redisClient.As<Post>(); 
 				var entidad = new Post{ created_at = created_at, Text = text, UserId = userid, BookId = bookid, Id = redisPosts.GetNextSequence()}; 
                 redisPosts.Store(entidad);
				 redisClient.AddItemToSet(UserPostIndex.Posts(userid), entidad.Id.ToString());
				 redisClient.AddItemToSet(BookPostIndex.Posts(bookid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Post> GetUserPosts(long userid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsPosts= redisClient.GetAllItemsFromSet(UserPostIndex.Posts(userid)); 
               return redisClient.As<Post>().GetByIds(idsPosts); 
             } 
         } 
 
public IEnumerable<Post> GetBookPosts(long bookid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsPosts= redisClient.GetAllItemsFromSet(BookPostIndex.Posts(bookid)); 
               return redisClient.As<Post>().GetByIds(idsPosts); 
             } 
         } 
 
public long AddQuestion(string text, long optionid, long quizid ) 
 { 
 	 if (isValidId("option",optionid) && isValidId("quiz",quizid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisQuestions= redisClient.As<Question>(); 
 				var entidad = new Question{ Text = text, OptionId = optionid, QuizId = quizid, Id = redisQuestions.GetNextSequence()}; 
                 redisQuestions.Store(entidad);
				 redisClient.AddItemToSet(OptionQuestionIndex.Questions(optionid), entidad.Id.ToString());
				 redisClient.AddItemToSet(QuizQuestionIndex.Questions(quizid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Question> GetOptionQuestions(long optionid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsQuestions= redisClient.GetAllItemsFromSet(OptionQuestionIndex.Questions(optionid)); 
               return redisClient.As<Question>().GetByIds(idsQuestions); 
             } 
         } 
 
public IEnumerable<Question> GetQuizQuestions(long quizid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsQuestions= redisClient.GetAllItemsFromSet(QuizQuestionIndex.Questions(quizid)); 
               return redisClient.As<Question>().GetByIds(idsQuestions); 
             } 
         } 
 
public long AddQuiz(string name, long bookid ) 
 { 
 	 if (isValidId("book",bookid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisQuizs= redisClient.As<Quiz>(); 
 				var entidad = new Quiz{ Name = name, BookId = bookid, Id = redisQuizs.GetNextSequence()}; 
                 redisQuizs.Store(entidad);
				 redisClient.AddItemToSet(BookQuizIndex.Quizs(bookid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Quiz> GetBookQuizs(long bookid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsQuizs= redisClient.GetAllItemsFromSet(BookQuizIndex.Quizs(bookid)); 
               return redisClient.As<Quiz>().GetByIds(idsQuizs); 
             } 
         } 
 
public long AddSection(string name, long chapterid ) 
 { 
 	 if (isValidId("chapter",chapterid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisSections= redisClient.As<Section>(); 
 				var entidad = new Section{ Name = name, ChapterId = chapterid, Id = redisSections.GetNextSequence()}; 
                 redisSections.Store(entidad);
				 redisClient.AddItemToSet(ChapterSectionIndex.Sections(chapterid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Section> GetChapterSections(long chapterid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsSections= redisClient.GetAllItemsFromSet(ChapterSectionIndex.Sections(chapterid)); 
               return redisClient.As<Section>().GetByIds(idsSections); 
             } 
         } 
 
public long AddStudent(long userid ) 
 { 
 	 if (isValidId("user",userid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisStudents= redisClient.As<Student>(); 
 				var entidad = new Student{ UserId = userid, Id = redisStudents.GetNextSequence()}; 
                 redisStudents.Store(entidad);
				 redisClient.AddItemToSet(UserStudentIndex.Students(userid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Student> GetUserStudents(long userid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsStudents= redisClient.GetAllItemsFromSet(UserStudentIndex.Students(userid)); 
               return redisClient.As<Student>().GetByIds(idsStudents); 
             } 
         } 
 
public long AddTakes_Student_Quiz(long studentid, long quizid, long grade, DateTime date ) 
 { 
 	 if (isValidId("student",studentid) && isValidId("quiz",quizid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisTakes_Student_Quizs= redisClient.As<Takes_Student_Quiz>(); 
 				var entidad = new Takes_Student_Quiz{ StudentId = studentid, QuizId = quizid, Grade = grade, Date = date, Id = redisTakes_Student_Quizs.GetNextSequence()}; 
                 redisTakes_Student_Quizs.Store(entidad);
				 redisClient.AddItemToSet(StudentTakes_Student_QuizIndex.Takes_Student_Quizs(studentid), entidad.Id.ToString());
				 redisClient.AddItemToSet(QuizTakes_Student_QuizIndex.Takes_Student_Quizs(quizid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Takes_Student_Quiz> GetStudentTakes_Student_Quizs(long studentid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsTakes_Student_Quizs= redisClient.GetAllItemsFromSet(StudentTakes_Student_QuizIndex.Takes_Student_Quizs(studentid)); 
               return redisClient.As<Takes_Student_Quiz>().GetByIds(idsTakes_Student_Quizs); 
             } 
         } 
 
public IEnumerable<Takes_Student_Quiz> GetQuizTakes_Student_Quizs(long quizid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsTakes_Student_Quizs= redisClient.GetAllItemsFromSet(QuizTakes_Student_QuizIndex.Takes_Student_Quizs(quizid)); 
               return redisClient.As<Takes_Student_Quiz>().GetByIds(idsTakes_Student_Quizs); 
             } 
         } 
 
public long AddTeacher(long userid ) 
 { 
 	 if (isValidId("user",userid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisTeachers= redisClient.As<Teacher>(); 
 				var entidad = new Teacher{ UserId = userid, Id = redisTeachers.GetNextSequence()}; 
                 redisTeachers.Store(entidad);
				 redisClient.AddItemToSet(UserTeacherIndex.Teachers(userid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Teacher> GetUserTeachers(long userid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsTeachers= redisClient.GetAllItemsFromSet(UserTeacherIndex.Teachers(userid)); 
               return redisClient.As<Teacher>().GetByIds(idsTeachers); 
             } 
         } 
 
public long AddUse_Course_Book(long courseid, long bookid ) 
 { 
 	 if (isValidId("course",courseid) && isValidId("book",bookid)) 
 	 { 
			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisUse_Course_Books= redisClient.As<Use_Course_Book>(); 
 				var entidad = new Use_Course_Book{ CourseId = courseid, BookId = bookid, Id = redisUse_Course_Books.GetNextSequence()}; 
                 redisUse_Course_Books.Store(entidad);
				 redisClient.AddItemToSet(CourseUse_Course_BookIndex.Use_Course_Books(courseid), entidad.Id.ToString());
				 redisClient.AddItemToSet(BookUse_Course_BookIndex.Use_Course_Books(bookid), entidad.Id.ToString());
				 return entidad.Id; 
 			} 
	 } 
 			else 
 			{ 
 						return -1; 
			} 
} 
public IEnumerable<Use_Course_Book> GetCourseUse_Course_Books(long courseid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsUse_Course_Books= redisClient.GetAllItemsFromSet(CourseUse_Course_BookIndex.Use_Course_Books(courseid)); 
               return redisClient.As<Use_Course_Book>().GetByIds(idsUse_Course_Books); 
             } 
         } 
 
public IEnumerable<Use_Course_Book> GetBookUse_Course_Books(long bookid) 
         { 
             using (var redisClient = RedisManager.GetClient()) 
             { 
                 var idsUse_Course_Books= redisClient.GetAllItemsFromSet(BookUse_Course_BookIndex.Use_Course_Books(bookid)); 
               return redisClient.As<Use_Course_Book>().GetByIds(idsUse_Course_Books); 
             } 
         } 
 
public long AddUser(string username, string password, string name, string lastname, string localprofileimgpath, string cloudprofileimgpath ) 
 { 
 			 using (var redisClient = RedisManager.GetClient()) 
            { 
                 var redisUsers= redisClient.As<User>(); 
 				var entidad = new User{ Username = username, Password = password, Name = name, LastName = lastname, LocalProfileImgPath = localprofileimgpath, CloudProfileImgPath = cloudprofileimgpath, Id = redisUsers.GetNextSequence()}; 
                 redisUsers.Store(entidad);
				 return entidad.Id; 
 			} 
} 
