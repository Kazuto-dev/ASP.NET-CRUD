using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security;
namespace testv4.Pages.Client
{
    public class RegistrationModel : PageModel
    {
        public clientInfo clientInfo = new clientInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {

        }

        public void OnPost()
        {
            clientInfo.email = Request.Form["email"];
            clientInfo.password = Request.Form["password"];


            if (clientInfo.email.Length == 0 || clientInfo.password.Length == 0)
            {
                errorMessage = "All fields are required";
                return;
            }


            try
            {
                String con = "Data Source=Jandell\\SQLEXPRESS;Initial Catalog=db3;Integrated Security=True";
                using(SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();

                    String injectData = "INSERT INTO info " + "(email, password) VALUES " + "(@email, @password);";


                    using (SqlCommand command = new SqlCommand(injectData, connection))
                    {
                        command.Parameters.AddWithValue("@email", clientInfo.email);
                        command.Parameters.AddWithValue("@password", clientInfo.password);
                            

                        command.ExecuteNonQuery();
                    }
                }



            }catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            clientInfo.email = "";
            clientInfo.password = "";
            successMessage = "New User Added!";

            Response.Redirect("/Client/Index");
        }
    }
}
