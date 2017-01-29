using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    /// <summary>
    /// Expand of IRepository interface for  operations with DalUsers
    /// </summary>
    public interface IUserRepository:IRepository<DalUser>
    {
        /// <summary>
        /// Method for geting DalUser by contact Email
        /// </summary>
        /// <param name="email">contact email of DalUser</param>
        DalUser GetByEmail(string email);
    }
}
