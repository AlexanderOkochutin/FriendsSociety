using System.Data.Entity;
using BLL.Interface.Services;
using BLL.Services;
using CryptoService;
using ICryptoService;
using DAL.Concrete;
using DAL.Interface.Repository;
using Log;
using Log.Interface;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    /// <summary>
    /// Service class for DI and IoC implemetnation
    /// </summary>
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

            kernel.Bind<ILogger>().To<Logger>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IProfileRepository>().To<ProfileRepository>();
            kernel.Bind<IFileRepository>().To<FileRepository>();
            kernel.Bind<IPostRepository>().To<PostRepository>();
            kernel.Bind<IMessageRepository>().To<MessageRepository>();
            kernel.Bind<ILikeRepository>().To<LikeRepository>();
            kernel.Bind<IInviteRepository>().To<InviteRepository>();

            kernel.Bind<IPasswordService>().To<PasswordService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IProfileService>().To<ProfileService>();
            kernel.Bind<IFileService>().To<FileService>();
            kernel.Bind<IInviteService>().To<InviteService>();
            kernel.Bind<ILikeService>().To<LikeService>();
            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IMessageService>().To<MessageService>();
        }
    }
}
