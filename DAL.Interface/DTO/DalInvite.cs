namespace DAL.Interface.DTO
{
    public class DalInvite : IEntity
    {
        public int Id { get; set; }
        public int ProfileFrom { get; set; }
        public int ProfileTo { get; set; }
        public string Response { get; set; }
    }
}
