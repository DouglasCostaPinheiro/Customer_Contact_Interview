namespace Entities
{
    public class UserSys
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public byte[] EncPwd { get; set; }
        public UserRole Role { get; set; }
    }
}
