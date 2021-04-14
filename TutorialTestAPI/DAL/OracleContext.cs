using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using TutorialTestAPI.Models;

namespace TutorialTestAPI.DAL
{
    /// <summary>
    /// ORACLE接続用のカスタムコンテキスト
    /// </summary>
    public class OracleContext: DbContext
    {
        /// <summary>
        /// ヒーローテーブル
        /// </summary>
        public DbSet<Hero> Heroes { set; get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OracleContext() : base("name=OracleContext")
        {
            // NULL値検索を許容
            Configuration.UseDatabaseNullSemantics = true;
        }

        /// <summary>
        /// モデル生成時
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // スキーマ設定
            modelBuilder.HasDefaultSchema("ADMIN");
            // ＤＢ初期化
            Database.SetInitializer<OracleContext>(new OracleInitializer());
        }
    }
}