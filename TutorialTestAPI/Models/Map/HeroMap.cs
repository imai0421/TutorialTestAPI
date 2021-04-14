using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TutorialTestAPI.Models.Map
{
    /// <summary>
    /// ヒーローEntityマッピング
    /// </summary>
    public class HeroMap : EntityTypeConfiguration<Hero>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HeroMap()
        {
            this.ToTable("Heroes");
            this.HasKey(Hero => Hero.Id);
            this.Property(Hero => Hero.Name);
        }
    }
}