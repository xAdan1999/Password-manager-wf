using password_manager_wf.Models.Responses;
using password_manager_wf.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace password_manager_wf.Controlles
{
    public class PasswordService
    {
        HttpClient client = new HttpClient();

        string baseURL = "http://localhost:3000/api/passwords";

        public async Task<List<Password>> GetPasswords()
        {
            List<Password> passwords = null;
            var response = await client.GetAsync(baseURL);
            string jsonString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                passwords = JsonConvert.DeserializeObject<List<Password>>(jsonString);
            }
            else
            {
                Response passwordResponse = JsonConvert.DeserializeObject<Response>(jsonString);
                MessageBox.Show(passwordResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            response.Dispose();
            return passwords;
        }

        public async Task<List<Password>> GetPassword(string search)
        {
            List<Password> passwords = null;
            var response = await client.GetAsync(baseURL + "/" + search);
            string jsonString = await response.Content.ReadAsStringAsync();
            passwords = JsonConvert.DeserializeObject<List<Password>>(jsonString);
            response.Dispose();
            return passwords;
        }

        public async Task<bool> InsertPassword(Password password)
        {
            bool success;
            string json = JsonConvert.SerializeObject(password);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(baseURL, data);
            string jsonString = await response.Content.ReadAsStringAsync();
            Response passwordResponse = JsonConvert.DeserializeObject<Response>(jsonString);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(passwordResponse.message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = true;
            }
            else
            {
                MessageBox.Show(passwordResponse.message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
            }
            return success;
        }

        public async Task<bool> UpdatePassword(Password password)
        {
            bool success;
            string json = JsonConvert.SerializeObject(password);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(baseURL + $"/{password.id}", data);
            string jsonString = await response.Content.ReadAsStringAsync();
            Response passwordResponse = JsonConvert.DeserializeObject<Response>(jsonString);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(passwordResponse.message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = true;
            }
            else
            {
                MessageBox.Show(passwordResponse.message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
            }
            return success;
        }

        public async Task<bool> DeletePassword(int id)
        {
            bool success;
            var response = await client.DeleteAsync(baseURL + $"/{id}");
            string jsonString = await response.Content.ReadAsStringAsync();
            Response passwordResponse = JsonConvert.DeserializeObject<Response>(jsonString);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(passwordResponse.message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = true;
            }
            else
            {
                MessageBox.Show(passwordResponse.message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
            }
            return success;
        }
    }
}
