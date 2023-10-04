using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;

namespace testv4.Pages.Client
{
    public class LoginModel : PageModel
    {
        public clientInfo clientInfo = new clientInfo();

        public void OnGet()
        {
            // Code for handling GET requests
        }

        public void OnPost()
        {
            String con = "Data Source=Jandell\\SQLEXPRESS;Initial Catalog=db3;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand("SELECT * FROM info WHERE email = @Email AND password = @Password", sqlCon);
            cmd.Parameters.AddWithValue("@Email", Request.Form["email"]);
            cmd.Parameters.AddWithValue("@Password", Request.Form["password"]);
        }

        
    }
}
