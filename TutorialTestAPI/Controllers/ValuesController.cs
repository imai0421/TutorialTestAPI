using TutorialTestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace TutorialTestAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private Hero[] heroes = new Hero[]
            {
                new Hero { id = 11, name = "Dr Nice@server" },
                new Hero { id = 12, name = "Narco@server" },
                new Hero { id = 13, name = "Bombasto@server" },
                new Hero { id= 14, name = "Celeritas@server" },
                new Hero { id= 15, name = "Magneta@server" },
                new Hero { id= 16, name = "RubberMan@server" },
                new Hero { id= 17, name = "Dynama@server" },
                new Hero { id= 18, name = "Dr IQ@server" },
                new Hero { id= 19, name = "Magma@server" },
                new Hero { id= 20, name = "Tornado@server" }
            };


        // GET api/values
        public IEnumerable<Hero> Get()
        {
            string[] value = GetQueryString("name");

            string name = value == null ?
                string.Empty : string.Join(",", value);

            if (string.IsNullOrWhiteSpace(name))
            {
                return heroes;
            }

            return heroes.Where(x => x.name.Contains(name));
        }

        // GET api/values/5
        public Hero Get(int id)
        {
            return heroes.Where(x => x.id==id).First();
        }

        // POST api/values
        public Hero Post([FromBody] Hero value)
        {
            return value;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Hero value)
        {
     
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }


        /// <summary>
        /// 指定したキーのクエリ文字列の値を取得します
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string[] GetQueryString(string key)
        {
            return Request.GetQueryNameValuePairs()
                .Where(e => e.Key == key)
                .Select(e => e.Value)
                .ToArray();
        }

    }
}
