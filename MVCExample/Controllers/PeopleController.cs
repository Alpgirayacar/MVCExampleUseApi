using Microsoft.AspNetCore.Mvc;
using MVCExample.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;


namespace MVCExample.Controllers
{
    public class PeopleController : Controller
    {
        public async Task<IActionResult> Index()
        {
           List<Person> PersonList = new List<Person>();

            using(var httpClient = new HttpClient())
            {   
                
                using(var response = await httpClient.GetAsync("https://localhost:7299/Home"))
                {
                    var gelenString = await response.Content.ReadAsStringAsync();
                    PersonList = JsonConvert.DeserializeObject<List<Person>>(gelenString);

                }
            }
            
            return View(PersonList);
        }

       


   


        

        


    }
}

