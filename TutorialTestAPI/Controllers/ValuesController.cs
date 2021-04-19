using TutorialTestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TutorialTestAPI.DAL;

namespace TutorialTestAPI.Controllers
{
    /// <summary>
    /// Hero操作API
    /// </summary>
    public class ValuesController : ApiController
    {
        /// <summary>
        /// ヒーローＩＤの初期値
        /// </summary>
        private int initialHeroId = 11;

        /// <summary>
        /// ヒーローを検索します
        /// </summary>
        /// <returns>ヒーロー一覧</returns>
        /// <remarks>GET api/values</remarks>
        public IEnumerable<Hero> Get()
        {
            // クエリパラメータから"name"を取得
            string[] value = GetQueryString("name");
            string name = value == null ?
                string.Empty : string.Join(",", value);

            // クエリパラメータに"name"が指定されている場合はヒーロー名に"name"を含むヒーローを検索
            // 上記以外の場合は全件検索
            using (var context = new OracleContext())
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    var query = context.Heroes
                        .Select(x => x)
                        .OrderBy(x => x.Id);
                    return query.ToArray();
                }
                else
                {
                    var query = context.Heroes
                        .Where(x => x.Name.Contains(name))
                        .Select(x => x)
                        .OrderBy(x => x.Id);
                    return query.ToArray();
                }
            }
        }

        /// <summary>
        /// 取得します
        /// </summary>
        /// <param name="id">ヒーローＩＤ</param>
        /// <returns>ヒーロー</returns>
        /// <remarks>GET api/values/5</remarks>
        public Hero Get(int id)
        {
            // 指定したヒーローＩＤのヒーローを取得し返却
            using (var context = new OracleContext())
            {
                return context.Heroes.Where(x => x.Id == id).First();
            }
        }

        /// <summary>
        /// 登録します
        /// </summary>
        /// <param name="value">ヒーロー</param>
        /// <returns>登録後ヒーロー</returns>
        /// <remarks>POST api/values</remarks>
        public Hero Post([FromBody] Hero value)
        {
            // ヒーローを登録して登録後のヒーローを返却
            using (var context = new OracleContext())
            {
                // 最大のヒーローＩＤを取得
                int? maxId = context.Heroes.Max(x => (int?)x.Id);
                var newHero = new Hero
                {
                    // ヒーローＩＤをインクリメント
                    Id = maxId == null ? initialHeroId : maxId.Value + 1,
                    Name = value.Name
                };
                context.Heroes.Add(newHero);
                context.SaveChanges();
                return newHero;
            }
        }

        /// <summary>
        /// 更新します
        /// </summary>
        /// <param name="id">ヒーローＩＤ</param>
        /// <param name="value">ヒーロー</param>
        /// <remarks>PUT api/values/5</remarks>
        public void Put(int id, [FromBody] Hero value)
        {
            // ヒーローを更新
            // 氏名が変更されていなかった場合は更新しない
            using (var context = new OracleContext())
            {
                var hero = context.Heroes.Where(x => x.Id == id).First();
                if (hero.Name.Equals(value.Name))
                {
                    return;
                }

                hero.Name = value.Name;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 削除します
        /// </summary>
        /// <param name="id">ヒーローＩＤ</param>
        /// <remarks>DELETE api/values/5</remarks>
        public void Delete(int id)
        {
            // ヒーローを削除
            using (var context = new OracleContext())
            {
                var hero = context.Heroes.Where(x => x.Id == id).First();
                context.Heroes.Remove(hero);
                context.SaveChanges();
            }
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
