
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace ModelsLayer
{
    public class Register
    {


        public Register(){

        }
        public int Id { get; set; }
        // [JsonPropertyName("FirstName")]
        // [StringLength(10, ErrorMessage = "First name is to long or to short", MinimumLength = 3)]
        public string FName { get; set; }

        // [JsonPropertyName("LastName")]
        // [StringLength(10, ErrorMessage = "Last name is to long or to short", MinimumLength = 3)]
        public string LName { get; set; }

        // [JsonPropertyName("Username")]
        // [StringLength(12, ErrorMessage = "Username is to long or to short", MinimumLength = 8)]
        public string Username { get; set; }

        // [JsonPropertyName("Password")]
        // [StringLength(15, ErrorMessage = "Password is to long or to short", MinimumLength = 8)]

        public string Password { get; set; }

        public string Confirm { get; set; }

        public Register(string fname, string lname, string username, string password, string confirm)
        {
            FName = fname;
            LName = lname;
            Username = username;
            Password = password;
            Confirm = confirm;
        }



    }
}