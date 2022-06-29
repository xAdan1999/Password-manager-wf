using password_manager_wf.Models.Responses;
using password_manager_wf.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace password_manager_wf.Controlles
{
    public class UserService
    {
        HttpClient client = new HttpClient();

        string baseURL = "http://localhost:3000/api/users";

        public async Task<UserResponse> Login(User user)
        {
            string json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(baseURL + "/signup", data);
            var jsonString = await response.Content.ReadAsStringAsync();
            UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(jsonString);
            return userResponse;
        }

        public async Task<UserResponse> InsertUser(User user)
        {
            string json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(baseURL + "/signup", data);
            var jsonString = await response.Content.ReadAsStringAsync();
            UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(jsonString);
            return userResponse;
        }

        public async Task<string> DeleteItem(int id)
        {
            var response = await client.DeleteAsync(baseURL+$"/{id}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
