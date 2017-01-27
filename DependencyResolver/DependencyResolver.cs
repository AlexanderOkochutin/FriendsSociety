using System.Data.Entity;
using BLL.Interface.Services;
using BLL.Services;
using CryptoService;
using ICryptoService;
using DAL;
using DAL.Concrete;
using DAL.Interface.Repository;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    public static class DependencyResolver
    {
        /// <summary>
        /// The method for Kernel configuration
        /// </summary>
        /// <param name="kernel">this IKernel parameter</param>
        public static void ConfigurateResolver(this IKernel kernel)
        {
            Configure(kernel);
        }

        public static void Configure(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<SocialNetworkContext>().InRequestScope();
            kernel.Bind<IPasswordService>().To<PasswordService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IProfileRepository>().To<ProfileRepository>();
            kernel.Bind<IFileRepository>().To<FileRepository>();
            kernel.Bind<IPostRepository>().To<PostRepository>();
            kernel.Bind<IMessageRepository>().To<MessageRepository>();
            kernel.Bind<ILikeRepository>().To<LikeRepository>();
            kernel.Bind<IInviteRepository>().To<InviteRepository>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IProfileService>().To<ProfileService>();
            kernel.Bind<IFileService>().To<FileService>();
        }
    }
}
