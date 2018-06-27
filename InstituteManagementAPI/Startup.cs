using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Ninject;
using System.Reflection;
using InstMgmtClassLibrary.Interfaces;
using InstMgmtClassLibrary.Repository;
using System.Web.Http;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

[assembly: OwinStartup(typeof(InstituteManagementAPI.Startup))]

namespace InstituteManagementAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureAuth(app);
            WebApiConfig.Register(config);
            app.UseNinjectMiddleware(CreateKernel);
            app.UseNinjectWebApi(config);
        }


        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(Assembly.GetExecutingAssembly());

            // Repository bindings here
            kernel.Bind<ITeacherRepository>().To<TeacherRepository>();
            kernel.Bind<IStudentRepository>().To<StudentRepository>();
            kernel.Bind<IDepartmentRepository>().To<DepartmentRepository>();
            kernel.Bind<ICourseRepository>().To<CourseRepository>();
            kernel.Bind<ILoginRepository>().To<LoginRepository>();
            return kernel;
        }
    }
}
