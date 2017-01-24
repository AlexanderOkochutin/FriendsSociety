namespace DAL.Interface.DTO
{
    public class DalLike:IEntity
    {
        public int Id { get; set; }
        public int ProfileFromId { get; set; }
        public int PostId { get; set; }
    }
}
