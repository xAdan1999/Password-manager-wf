using password_manager_wf.Models.Responses;
using password_manager_wf.Models;
using password_manager_wf.Cache;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace password_manager_wf.Controlles
{
    public class WebsiteService
    {
        HttpClient client = new HttpClient();

        string baseURL = "http://localhost:3000/api/websites";

        public async Task<List<Website>> GetWebsites()
        {
            //lista a llenar con los websites
            List<Website> websites = null;

            //hacer la peticion y almacenar la respuesta que devolvio
            client.DefaultRequestHeaders.Add("x-access-token", UserCache.token);
            var response = await client.GetAsync(baseURL);
            string jsonString = await response.Content.ReadAsStringAsync();

            //si la respuesta tuvo un status code exitoso
            if (response.IsSuccessStatusCode)
            {
                websites = JsonConvert.DeserializeObject<List<Website>>(jsonString);
            }
            else
            {
                //de lo contrario deserializar la respuesta en su debido modelo y mostrarla
                Response websiteResponse = JsonConvert.DeserializeObject<Response>(jsonString);
                MessageBox.Show(websiteResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //desechar la respuesta despues de haber hecho las acciones necesarias
            response.Dispose();

            //retorna la lista
            return websites;
        }

        public async Task<List<Website>> GetWebsite(string websiteName)
        {
            //lista a llenar con los websites
            List<Website> websites = null;

            //hacer la peticion y almacenar la respuesta que devolvio
            var response = await client.GetAsync(baseURL + "/" + websiteName);
            string jsonString = await response.Content.ReadAsStringAsync();
            websites = JsonConvert.DeserializeObject<List<Website>>(jsonString);

            //desechar la respuesta despues de haber hecho las acciones necesarias
            response.Dispose();

            //retorna la lista
            return websites;
        }

        public async Task<bool> InsertWebsite(Website website)
        {
            //para manejar la respuesta
            bool success;

            //serializar el website recibido
            string json = JsonConvert.SerializeObject(website);

            //configurar el json
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //hacer la peticion y almacenar la respuesta que devolvio
            var response = await client.PostAsync(baseURL, data);
            string jsonString = await response.Content.ReadAsStringAsync();

            //deserializar la respuesta en el modelo correspondiente
            Response websiteResponse = JsonConvert.DeserializeObject<Response>(jsonString);

            //si la respuesta fue exitosa
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(websiteResponse.message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                success =  true;
            }
            else
            {
                //de lo contrario mostrar cualquier error que se genero
                MessageBox.Show(websiteResponse.message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
            }
            return success;
        }

        public async Task<bool> UpdateWebsite(Website website)
        {
            //para manejar la respuesta
            bool success;

            //serializar el website recibido
            string json = JsonConvert.SerializeObject(website);

            //configurar el json
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //hacer la peticion y almacenar la respuesta que devolvio
            var response = await client.PutAsync(baseURL + $"/{website.id}", data);
            string jsonString = await response.Content.ReadAsStringAsync();

            //deserializar la respuesta en el modelo correspondiente
            Response websiteResponse = JsonConvert.DeserializeObject<Response>(jsonString);

            //si la respuesta fue exitosa
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(websiteResponse.message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = true;
            }
            else
            {
                //de lo contrario mostrar cualquier error que se genero
                MessageBox.Show(websiteResponse.message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
            }
            return success;
        }

        public async Task<bool> DeleteWebsite(int id)
        {
            //para manejar la respuesta
            bool success;

            //hacer la peticion y almacenar la respuesta que devolvio (enviar el id)
            var response = await client.DeleteAsync(baseURL + $"/{id}");
            string jsonString = await response.Content.ReadAsStringAsync();

            //deserializar la respuesta en el modelo correspondiente
            Response websiteResponse = JsonConvert.DeserializeObject<Response>(jsonString);

            //si la respuesta fue exitosa
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(websiteResponse.message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = true;
            }
            else
            {
                //de lo contrario mostrar cualquier error que se genero
                MessageBox.Show(websiteResponse.message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
            }
            return success;
        }
    }
}
