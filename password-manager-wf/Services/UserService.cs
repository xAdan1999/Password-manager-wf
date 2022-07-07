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
            return await Request(user, "login");
        }

        public async Task<bool>SignUp(User user)
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

                    //obtener la informacion del usuario
                    UserCache.userId = userResponse.userId;
                    UserCache.username = userResponse.username;
                    UserCache.email = userResponse.email;
                    UserCache.token = userResponse.token;
                }
                else
                {
                    //si algo sale mal mostrar el error que se capturo
                    MessageBox.Show(userResponse.message, "Information",
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
