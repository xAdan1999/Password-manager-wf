using password_manager_wf.Models.Responses;
using password_manager_wf.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System;

namespace password_manager_wf.Controlles
{
    public class PasswordService
    {
        //obtener la url base
        readonly string baseURL = Properties.Settings.Default.passwordURL;

        //recuperar el token almacenado para dar autorizaciones
        readonly string token = Properties.Settings.Default.token;

        //metodo para traer las contraseñas
        public async Task<List<PasswordResponse>> GetPasswords()
        {
            //Lista a llenar 
            List<PasswordResponse> passwords = null;

            try
            {
                //para hacer peticiones
                HttpClient client = new HttpClient();

                //enviar el token para poder autorizar la obtencion de las contraseñas
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("authorization", token);

                //obtener el id del usuario para traer su informacion
                int userId = Properties.Settings.Default.userId;

                //hacer la solicitud y capturar la respuesta
                var response = await client.GetAsync(baseURL + $"/{userId}");

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

                //desechar objetos utilizados
                response.Dispose();
                client.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //retornar las contraseñas
            return passwords;
        }

        //metodo para buscar contraseñas
        public async Task<List<PasswordResponse>> SearchPassword(string search)
        {
            //Lista a llenar 
            List<PasswordResponse> passwords = null;

            try
            {
                //para hacer peticiones
                HttpClient client = new HttpClient();

                //enviar el token para poder autorizar la busqueda de contraseñas
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("authorization", token);

                //obtener el id del usuario para traer su informacion
                int userId = Properties.Settings.Default.userId;

                //hacer la solicitud y capturar la respuesta
                var response = await client.GetAsync(baseURL + $"/{userId}" + $"/search?title={search}");

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

                //desechar objetos utilizados
                response.Dispose();
                client.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //retornar las contraseñas
            return passwords;
        }

        //metodo para insertar una nueva contraseña
        public async Task<bool> InsertPassword(Password password)
        {
            //para manejar el resultado
            bool success = false;

            try
            {
                //para hacer peticiones
                HttpClient client = new HttpClient();

                //enviar el token para poder autorizar un insert
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("authorization", token);

                //serializar el objeto recibido
                string json = JsonConvert.SerializeObject(password);

                //configurar la solicitud
                var data = new StringContent(json, Encoding.UTF8, "application/json");

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

                //desechar objetos utilizados
                response.Dispose();
                client.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //retornar un resultado
            return success;
        }

        //metodo para actualizar una contraseña
        public async Task<bool> UpdatePassword(Password password)
        {
            //para manejar el resultado
            bool success = false;

            try
            {
                //para hacer peticiones
                HttpClient client = new HttpClient();

                //enviar el token para poder autorizar un update
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("authorization", token);

                //serializar el objeto recibido
                string json = JsonConvert.SerializeObject(password);

                //configurar la solicitud
                var data = new StringContent(json, Encoding.UTF8, "application/json");

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

                //desechar objetos utilizados
                response.Dispose();
                client.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //retornar un resultado
            return success;
        }

        //metodo para eliminar una contraseña
        public async Task<bool> DeletePassword(int id)
        {
            //para manejar el resultado
            bool success = false;

            try
            {
                //para hacer peticiones
                HttpClient client = new HttpClient();

                //enviar el token para poder autorizar un delete
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("authorization", token);

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

                //desechar objetos utilizados
                response.Dispose();
                client.Dispose();
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
