using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorialTestAPI.Models;

namespace TutorialTestAPI.DAL
{
    /// <summary>
    /// ORACLEのカスタムイニシャライザ
    /// 毎回データベースを初期化します
    /// </summary>
    public class OracleInitializer : System.Data.Entity.DropCreateDatabaseAlways<OracleContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(OracleContext context)
        {
            // 初期データ投入
            var heroes = new List<Hero>
            {
                new Hero { Id = 11, Name = "Dr Nice" },
                new Hero { Id = 12, Name = "Narco" },
                new Hero { Id = 13, Name = "Bombasto" },
                new Hero { Id = 14, Name = "Celeritas" },
                new Hero { Id = 15, Name = "Magneta" },
                new Hero { Id = 16, Name = "RubberMan" },
                new Hero { Id = 17, Name = "Dynama" },
                new Hero { Id = 18, Name = "Dr IQ" },
                new Hero { Id = 19, Name = "Magma" },
                new Hero { Id = 20, Name = "Tornado" }
            };
            heroes.ForEach(s => context.Heroes.Add(s));
            context.SaveChanges();
        }
    }
}