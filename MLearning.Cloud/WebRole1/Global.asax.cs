using ServiceStack.Redis;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebRole1.Api;
using System.Configuration;
using WebRole1.Repo;
using System.Data;

namespace WebRole1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            new MLearningAppHost().Init();
        }
    }


    public class MLearningAppHost : AppHostBase
    {

        public MLearningAppHost() : base("MLearning Web Service", typeof(BookService).Assembly) { }
        public override void Configure(Funq.Container container)
        {
            SetConfig(new EndpointHostConfig { ServiceStackHandlerFactoryPath = "api" });

            string remoteHostIP = "localhost";
            string connectionStringName = "ServiceStackServer";



            container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString, SqlServerDialect.Provider));
            container.Register<IRedisClientsManager>(c => new PooledRedisClientManager(remoteHostIP));
           // container.Register<IRepository>(c => new Repository(c.Resolve<IRedisClientsManager>()));

            IDbConnectionFactory factory = container.Resolve<IDbConnectionFactory>();
            container.Register<IRepository>(c => new SQLServerRepository(factory));

          //  dropTables(factory); NOT WORKING
            createTables(factory);
            IRepository repo = container.Resolve<IRepository>();
            populateDB(repo);
          
        }


        public void dropTables(IDbConnectionFactory factory)
        {
            using (IDbConnection db = factory.OpenDbConnection())
            {
                
                db.DropTable<User>();
                db.DropTable<Teacher>();
                db.DropTable<Student>();
                db.DropTable<Category>();
                db.DropTable<Book>();
                db.DropTable<Quiz>();
                db.DropTable<Option>();
                db.DropTable<Question>();

                db.DropTable<Has_Question_Option>();
                db.DropTable<Answer_Student_Question>();
                db.DropTable<Course>();
                db.DropTable<Chapter>();
                db.DropTable<Enrollment>();
                db.DropTable<Favourite_Student_Book>();

                db.DropTable<Section>();
                db.DropTable<Page>();
                db.DropTable<Post>();




                db.DropTable<Takes_Student_Quiz>();

                db.DropTable<Use_Course_Book>();
            }

        }
        public void createTables(IDbConnectionFactory factory)
        {
            using (IDbConnection db = factory.OpenDbConnection())
            {
                db.CreateTable<User>();
                db.CreateTable<Teacher>();
                db.CreateTable<Student>();
                db.CreateTable<Category>();
                db.CreateTable<Book>();
                db.CreateTable<Quiz>();
                db.CreateTable<Option>();
                db.CreateTable<Question>();

                db.CreateTable<Has_Question_Option>();
                db.CreateTable<Answer_Student_Question>();
                db.CreateTable<Course>();
                db.CreateTable<Chapter>();
                db.CreateTable<Enrollment>();
                db.CreateTable<Favourite_Student_Book>();

                db.CreateTable<Section>();
                db.CreateTable<Page>();
                db.CreateTable<Post>();




                db.CreateTable<Takes_Student_Quiz>();

                db.CreateTable<Use_Course_Book>();

            }
        }

        public void populateDB(IRepository repo)
        {
             int nrows = 50;
             repo.StoreRandomObjects<User>(nrows);
             repo.StoreRandomObjects<Teacher>(nrows);
             repo.StoreRandomObjects<Category>(nrows);
             repo.StoreRandomObjects<Student>(nrows);
             repo.StoreRandomObjects<Book>(nrows);             
             repo.StoreRandomObjects<Chapter>(nrows);
             repo.StoreRandomObjects<Course>(nrows);
             repo.StoreRandomObjects<Enrollment>(nrows);
             repo.StoreRandomObjects<Favourite_Student_Book>(nrows);
             repo.StoreRandomObjects<Section>(nrows);
             repo.StoreRandomObjects<Page>(nrows);
             repo.StoreRandomObjects<Post>(nrows);
             repo.StoreRandomObjects<Quiz>(nrows);
             repo.StoreRandomObjects<Option>(nrows);  
             repo.StoreRandomObjects<Question>(nrows);                             
             repo.StoreRandomObjects<Has_Question_Option>(nrows);
             repo.StoreRandomObjects<Takes_Student_Quiz>(nrows);
             repo.StoreRandomObjects<Answer_Student_Question>(nrows);
             repo.StoreRandomObjects<Use_Course_Book>(nrows);
             
        }
    }
}
