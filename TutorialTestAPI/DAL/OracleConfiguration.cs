using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.EntityFramework;

namespace TutorialTestAPI.DAL
{
    /// <summary>
    /// ORACLEのカスタム構成
    /// </summary>
    public class OracleConfiguration : DbConfiguration
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OracleConfiguration()
        {
            // プロバイダ初期化
            SetProviderServices("Oracle.ManagedDataAccess.Client", EFOracleProviderServices.Instance);
        }
    }
}