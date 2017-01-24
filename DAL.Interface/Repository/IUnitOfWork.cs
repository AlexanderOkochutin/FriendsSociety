namespace DAL.Interface.Repository
{
    interface IUnitOfWork
    {
        IUserRepository Users { get; set; }
        IProfileRepository Profiles { get; set; }
        IFileRepository Photos { get; set; }
        IMessageRepository Messages { get; set; }
        IInviteRepository Invites { get; set; }
        void Commit();
    }
}
