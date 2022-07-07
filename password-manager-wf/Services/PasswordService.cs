using password_manager_wf.Models.Responses;
using password_manager_wf.Models;
using password_manager_wf.Cache;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System;

namespace password_manager_wf.Controlles
{
    public class PasswordService
    {
        HttpClient client = new HttpClient();

        string baseURL = "http://localhost:3000/api/passwords";

        //metodo para traer las contraseñas
        public async Task<List<PasswordResponse>> GetPasswords()
        {
            //Lista a llenar 
            List<PasswordResponse> passwords = null;

            try
            {
                //enviar el token para poder autorizar la obtencion de las contraseñas
                //client.DefaultRequestHeaders.Add("Authorization", UserCache.token);

                //hacer la solicitud y capturar la respuesta
                var response = await client.GetAsync(baseURL + $"/{UserCache.userId}");

                //convertir el json que responde el servidor en string para poder deserializarlo
                string jsonString = await response.Content.ReadAsStringAsync();

                //verificar si todo fue correcto
                if (response.IsSuccessStatusCode)
                {
                    //si es asi desearializar los objetos
                    passwords = JsonConvert.DeserializeObject<List<PasswordResponse>>(jsonString);
                }
                else
                {
                    //de lo contrario deserializar la respuesta en su modelo
                    Response passwordResponse = JsonConvert.DeserializeObject<Response>(jsonString);
                    MessageBox.Show(passwordResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //desechar la respuesta una vez utilizada
                response.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //retornar las contraseñas
            return passwords;
        }

        public async Task<List<PasswordResponse>> SearchPassword(Search search)
        {
            //Lista a llenar 
            List<PasswordResponse> passwords = null;

            try
            {
                //serializar el objeto recibido
                string json = JsonConvert.SerializeObject(search);

                //configurar la solicitud
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //enviar el token para autorizar la insercion
                //client.DefaultRequestHeaders.Add("Authorization", UserCache.token);

                //hacer la solicitud y capturar la respuesta                params                   body
                var response = await client.PostAsync(baseURL + $"/{UserCache.userId}", data);

                //convertir el json que responde el servidor en string para poder deserializarlo
                string jsonString = await response.Content.ReadAsStringAsync();

                //deserializarla en el modelo correspondiente
                passwords = JsonConvert.DeserializeObject<List<PasswordResponse>>(jsonString);

                //desechar la respuesta una vez utilizada
                response.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //retornar las contraseñas
            return passwords;
        }

        public async Task<bool> InsertPassword(Password password)
        {
            //para manejar el resultado
            bool success = false;

            try
            {
                //serializar el objeto recibido
                string json = JsonConvert.SerializeObject(password);

                //configurar la solicitud
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //enviar el token para autorizar la insercion
                //client.DefaultRequestHeaders.Add("Authorization", UserCache.token);

                //hacer la solicitud y capturar la respuesta
                var response = await client.PostAsync(baseURL, data);

                //convertir el json que responde el servidor en string para poder deserializarlo
                string jsonString = await response.Content.ReadAsStringAsync();

                //deserializarla en el modelo correspondiente
                Response passwordResponse = JsonConvert.DeserializeObject<Response>(jsonString);

                //hay 2 manera de verificar si todo fue correcto, por el success que responde el servidor o por el status code
                if (response.IsSuccessStatusCode)
                {
                    //para indicar que todo salio bien
                    MessageBox.Show(passwordResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;
                }
                else
                {
                    //si algo sale mal mostrar el error que se capturo
                    MessageBox.Show(passwordResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //desechar la respuesta una vez utilizada
                response.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //retornar un resultado
            return success;
        }

        public async Task<bool> UpdatePassword(Password password)
        {
            //para manejar el resultado
            bool success = false;

            try
            {
                //serializar el objeto recibido
                string json = JsonConvert.SerializeObject(password);

                //configurar la solicitud
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //enviar el token para autorizar la actualizacion
                //client.DefaultRequestHeaders.Add("Authorization", UserCache.token);

                //hacer la solicitud y capturar la respuesta
                var response = await client.PutAsync(baseURL + $"/{password.id}", data);

                //convertir el json que responde el servidor en string para poder deserializarlo
                string jsonString = await response.Content.ReadAsStringAsync();

                //deserializarla en el modelo correspondiente
                Response passwordResponse = JsonConvert.DeserializeObject<Response>(jsonString);

                //hay 2 manera de verificar si todo fue correcto, por el success que responde el servidor o por el status code
                if (response.IsSuccessStatusCode)
                {
                    //para indicar que todo salio bien
                    MessageBox.Show(passwordResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;
                }
                else
                {
                    //si algo sale mal mostrar el error que se capturo
                    MessageBox.Show(passwordResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //desechar la respuesta una vez utilizada
                response.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //retornar un resultado
            return success;
        }

        public async Task<bool> DeletePassword(int id)
        {
            //para manejar el resultado
            bool success = false;

            try
            {
                //enviar el token para autorizar la actualizacion
                //client.DefaultRequestHeaders.Add("Authorization", UserCache.token);

                //hacer la solicitud y capturar la respuesta
                var response = await client.DeleteAsync(baseURL + $"/{id}");

                //convertir el json que responde el servidor en string para poder deserializarlo
                string jsonString = await response.Content.ReadAsStringAsync();

                //deserializarla en el modelo correspondiente
                Response passwordResponse = JsonConvert.DeserializeObject<Response>(jsonString);

                //hay 2 manera de verificar si todo fue correcto, por el success que responde el servidor o por el status code
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
                }

                //desechar la respuesta una vez utilizada
                response.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //retornar un resultado
            return success;
        }
    }
}
