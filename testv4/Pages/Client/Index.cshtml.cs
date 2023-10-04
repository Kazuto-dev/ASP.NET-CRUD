using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace testv4.Pages.Client
{
    public class IndexModel : PageModel
    {
        public List<clientInfo> client = new List<clientInfo>();

        public void OnGet()
        {
            try
            {
                String con = "Data Source=Jandell\\SQLEXPRESS;Initial Catalog=db3;Integrated Security=True";
                using (SqlConnection sqlCon = new SqlConnection(con))
                {
                    sqlCon.Open();
                    String sql = "SELECT * FROM info";
                    using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientInfo clients = new clientInfo();
                                clients.id = "" + reader.GetInt32(0);
                                clients.email = reader.GetString(1);
                                clients.password = reader.GetString(2);

                                client.Add(clients);
                            }
                        }
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
    }

    public class clientInfo
    {
        public String id;
        public String email;
        public String password;
        
    }
}
