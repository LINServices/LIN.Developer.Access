global using Newtonsoft.Json;
global using System;
global using System.Net.Http;
global using System.Text;
global using System.Threading.Tasks;
global using LIN.Developer.Types.Enumerations;
global using LIN.Shared.Tools;

namespace LIN.Access.Developer
{

    public sealed class Sesion
    {


        public string Token { get; set; }


        /// <summary>
        /// Informacion del usuario
        /// </summary>
        public ProfileDataModel Informacion { get; private set; }



        /// <summary>
        /// Si la sesion es activa
        /// </summary>
        public static bool IsOpen { get; set; } = false;




        /// <summary>
        /// Recarga o inicia una sesion
        /// </summary>
        public static async Task<(Sesion? Sesion, Responses Response)> LoginWith(int id)
        {

            // Cierra la sesion Actual
            CloseSesion();
            // Obtiene la IP publica actual del dispositivo
            // Validacion de user
            var response = await Controllers.Profile.ReadOneAsync(id);

            if (response.Response != Responses.Success)
                return (null, response.Response);


            // Datos de la instancia
            Instance.Informacion = response.Model;

            IsOpen = true;

            Instance.Token = response.Token;

            return (Instance, Responses.Success);

        }




        /// <summary>
        /// Cierra la sesion
        /// </summary>
        public static void CloseSesion()
        {
            IsOpen = false;
            Instance.Informacion = new();
        }






        //==================== Singletong ====================//


        private readonly static Sesion _instance = new();

        private Sesion()
        {
            Informacion = new();
        }


        public static Sesion Instance => _instance;
    }
}
