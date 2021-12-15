/*[10/11/2021] CN E.Patot*/

namespace BackEnd.Models
{
    public class UserModel
    { 
        public string username { get; set; } // local user
        public string email { get; set; }
        public string password { get; set; }
        public int isGmail { get; set; } //determine if data passed is through google auth  or not
    }
}