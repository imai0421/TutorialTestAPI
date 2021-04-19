using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TutorialTestAPI.Models
{
    /// <summary>
    /// ヒーロー
    /// </summary>
    public class Hero
    {
        /// <summary>
        /// ヒーローＩＤ
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// ヒーロー名
        /// </summary>
        [MaxLength(200)]
        public string Name { get; set; }

    }
}