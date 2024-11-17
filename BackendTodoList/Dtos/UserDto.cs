using System.Collections.Generic;

namespace BackendTodoList.Dtos
{
    public class UserDto
    {
        public int id { get; set; }
        public string username { get; set; } = string.Empty;
        public string email_address { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
    }
}