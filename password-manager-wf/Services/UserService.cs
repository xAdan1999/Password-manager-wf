using password_manager_wf.Models.Responses;
using password_manager_wf.Models;
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
        //obtener la url base
        readonly string baseURL = Properties.Settings.Default.usersURL;

        //recuperar el token almacenado para dar autorizaciones
        readonly string token = Properties.Settings.Default.token;

        public async Task<bool> Login(User user)
        {
            return await Request(user, "login");
        }

        public async Task<bool> SignUp(User user)
        {
            return await Request(user, "signup");
        }

        /*Lo siguiente es el mismo codigo para login y signup, por eso se encapuslo en un metodo, 
        solo cambia la ruta*/

        private async Task<bool> Request(User user, string route)
        {
            //para manejar la respuesta
            bool success = false;

            try
            {
                //para hacer peticiones
                HttpClient client = new HttpClient();

                //serializar el objeto recibido
                string json = JsonConvert.SerializeObject(user);

                //configurar la solicitud
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //hacer la solicitud y capturar la respuesta
                var response = await client.PostAsync(baseURL + $"/{route}", data);

                //convertir el json que responde el servidor en string para poder deserializarlo
                string jsonString = await response.Content.ReadAsStringAsync();

                //deserializarla en el modelo correspondiente
                UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(jsonString);

                //hay 2 manera de verificar si todo fue correcto, por el success que responde el servidor o por el status code
                if (response.IsSuccessStatusCode)
                {
                    //para indicar que todo salio bien
                    MessageBox.Show(userResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;

                    //guardar la sesion
                    SaveSession(userResponse);
                }
                else
                {
                    //si algo sale mal mostrar el error que se capturo
                    MessageBox.Show(userResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //desechar la respuesta una vez utilizada
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

        public async Task<bool> UpdateUsername(User user)
        {
            //para manejar el resultado
            bool success = false;

            try
            {
                //para hacer peticiones
                HttpClient client = new HttpClient();

                //enviar el token para poder autorizar la obtencion de las contraseñas
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("authorization", token);

                //serializar el objeto recibido
                string json = JsonConvert.SerializeObject(user);

                //configurar la solicitud
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //hacer la solicitud y capturar la respuesta
                var response = await client.PutAsync(baseURL + $"/{user.id}", data);

                //convertir el json que responde el servidor en string para poder deserializarlo
                string jsonString = await response.Content.ReadAsStringAsync();

                //deserializarla en el modelo correspondiente
                Response userResponse = JsonConvert.DeserializeObject<Response>(jsonString);

                //hay 2 manera de verificar si todo fue correcto, por el success que responde el servidor o por el status code
                if (response.IsSuccessStatusCode)
                {
                    //para indicar que todo salio bien
                    MessageBox.Show(userResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;
                }
                else
                {
                    //si algo sale mal mostrar el error que se capturo
                    MessageBox.Show(userResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //desechar la respuesta una vez utilizada
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

        public async Task<bool> DeleteUser(int id)
        {
            //para manejar el resultado
            bool success = false;

            try
            {
                //para hacer peticiones
                HttpClient client = new HttpClient();

                //enviar el token para poder autorizar la obtencion de las contraseñas
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("authorization", token);

                //hacer la solicitud y capturar la respuesta
                var response = await client.DeleteAsync(baseURL + $"/{id}");

                //convertir el json que responde el servidor en string para poder deserializarlo
                string jsonString = await response.Content.ReadAsStringAsync();

                //deserializarla en el modelo correspondiente
                Response userResponse = JsonConvert.DeserializeObject<Response>(jsonString);

                //hay 2 manera de verificar si todo fue correcto, por el success que responde el servidor o por el status code
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(userResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;
                }
                else
                {
                    MessageBox.Show(userResponse.message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //desechar la respuesta una vez utilizada
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

        //metodo que guarda la sesion con la informacion que response el servidor
        private void SaveSession(UserResponse userResponse)
        {
            try
            {
                Properties.Settings.Default.loggedIn = userResponse.logged_in;
                Properties.Settings.Default.userId = userResponse.user_id;
                Properties.Settings.Default.username = userResponse.username;
                Properties.Settings.Default.token = userResponse.token;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
