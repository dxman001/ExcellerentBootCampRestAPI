
namespace RestAPICompleted.Models
{
    public class Member: UserCredential
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Grade { get; set; }
        public string Email { get; set; }
    }
}
