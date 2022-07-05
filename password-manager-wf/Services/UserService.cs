using password_manager_wf.Models.Responses;
using password_manager_wf.Models;
using password_manager_wf.Cache;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System;

namespace password_manager_wf.Controlles
{
    public class UserService
    {
        HttpClient client = new HttpClient();

        string baseURL = "http://localhost:3000/api/users";

        public async Task<bool> Login(User user)
        {
            bool success = false;

            try
            {
                string json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(baseURL + "/login", data);
                string jsonString = await response.Content.ReadAsStringAsync();
                UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(jsonString);

                if (response.IsSuccessStatusCode)
                {
                    //para indicar que todo salio bien
                    MessageBox.Show(userResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;

                    //obtener la informacion del usuario
                    UserCache.userId = userResponse.userId;
                    UserCache.username = userResponse.username;
                    UserCache.email = userResponse.email;
                    UserCache.token = userResponse.token;
                }
                else
                {
                    MessageBox.Show(userResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return success;
        }

        public async Task<bool>SignUp(User user)
        {
            bool success = false;

            try
            {
                string json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(baseURL+"/signup", data);
                string jsonString = await response.Content.ReadAsStringAsync();
                UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(jsonString);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(userResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;

                    //obtener la informacion del usuario
                    UserCache.userId = userResponse.userId;
                    UserCache.username = userResponse.username;
                    UserCache.email = userResponse.email;
                    UserCache.token = userResponse.token;
                }
                else
                {
                    MessageBox.Show(userResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return success;
        }

        public async Task<string> DeleteItem(int id)
        {
            var response = await client.DeleteAsync(baseURL+$"/{id}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
