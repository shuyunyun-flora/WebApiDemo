using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class PersonsController : ApiController
    {
        private People[] humanbeings = new People[]
        {
            new People { Name = "Apollo", Gender = "Male" },
            new People { Name = "Aphrodite", Gender = "Female" }
        };

        // GET: api/Persons
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Persons/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Persons
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Persons/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Persons/5
        public void Delete(int id)
        {
        }

        public IEnumerable<People> GetAllPeople()
        {
            return humanbeings;
        }

        public People GetPeopleByName(string id)
        {
            for (int i = 0; i < humanbeings.Length; i++)
            {
                if (String.Compare(id, humanbeings[i].Name, true) == 0)
                {
                    return humanbeings[i];
                }
            }

            //AthenaDatabase.DatabaseProvider dbp = new AthenaDatabase.DatabaseProvider();
            //dbp.ReportDatabaseConnectState();

            return new People() { Name = "NULL", Gender = "FM" };
        }

        [HttpGet]

        public People GetPeopleByName([FromUri]string para1, [FromUri]string para2)
        {
            if (para1 == "Apollo")
            {
                return humanbeings[0];
            }
            else
            {
                return humanbeings[1];
            }
        }

        public People GetPeopleByName(string id, string sex, string xx)
        {
            for ( int i = 0; i < humanbeings.Length; i++)
            {
                if (String.Compare(id, humanbeings[i].Name, true) == 0)
                {
                    return humanbeings[i];
                }
            }

            return new People() { Name = "NULL", Gender = "FM"};
        }

        [HttpPost]
        public int CalculateItemsCount([FromUri]int bananas, int apples, int cherries)
        {
            int nTotal = 0;
            nTotal = bananas + apples + cherries;

            return nTotal + 2;
        }

        [HttpPost]
        public JObject Calc(JObject fruit)
        {
            JObject x = new JObject(fruit);
            x["Total"] = fruit["bananas"].Value<int>() + fruit["apples"].Value<int>() + fruit["cherries"].Value<int>() + 3;
            return x;
        }

        [HttpPost]
        public CalcResult CalcFruits(CalculateFruitsCount item)
        {
            CalcResult cr = new CalcResult();

            cr.Total = item.Apples + item.Bananas + item.Cherries + 4;

            return cr;
        }

        [HttpGet]

        [Route ("api/Persons/CalcFruits/{bananas}/{apples}/{cherries}")]
        public int CalcFruits(int bananas, int apples, int cherries)
        {
            return (bananas + apples + cherries + 1);
        }

        [HttpPost]
        public string CalcFruitsByPeople(string name, CalculateFruitsCount item)
        {
            string result = String.Empty;
            int nTotal = item.Bananas + item.Apples + item.Cherries;
            result = name + ": " + nTotal.ToString();

            return result;
        }
    }
}
