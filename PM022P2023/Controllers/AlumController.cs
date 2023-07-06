using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using PM022P2023.Config;

namespace PM022P2023.Controllers
{
    public class AlumController
    {
        // Creacion de los metodos crud 
        public async static Task<Models.Msg> CreateAlum(Models.Alumnos alum)
        {
            Models.Msg msg = new Models.Msg();

            String jsonObject = JsonConvert.SerializeObject(alum);
            System.Net.Http.StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            using(HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage response = null;
                response = await client.PostAsync(ConfigProcess.ApiPOST, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    msg = JsonConvert.DeserializeObject<Models.Msg>(result);
                }
            }

            return msg;
        }


        // Microservicio - Read

        public async static Task<List<Models.Alumnos>> GetAlumnos()
        {
            List<Models.Alumnos> alums = new List<Models.Alumnos>();

            using (HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage response = null;
                response = await client.GetAsync(ConfigProcess.ApiGET);
                
                if (response.IsSuccessStatusCode) 
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    alums = JsonConvert.DeserializeObject<List<Models.Alumnos>>(result);
                }
                
                return alums;
            }
        }
    }
}
