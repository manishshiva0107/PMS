using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;
using PMS.Core.Entities.User;
using PMS.Core.Repository.User;
using PMS.Infrastructure.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PMS.Infrastructure.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetSection("DBInfo:ConnectionString").Value;

        }

        //public UserDetails InsertUpdate(UserDetails entity)
        //{
        //    UserDetails response = new UserDetails();
        //    PlpgSqlHelper plpgSqlHelper = new PlpgSqlHelper(_connectionString);
        //    #region ProductBasicInformation Params
        //    object[] sqlParams = new object[] {
        //        new NpgsqlParameter("in_id",entity.Id){ NpgsqlDbType=NpgsqlDbType.Uuid,Direction=ParameterDirection.Input},
        //        new NpgsqlParameter("in_thirdpartyid",entity.UserName){ NpgsqlDbType=NpgsqlDbType.Uuid,Direction=ParameterDirection.Input}
        //    };
        //    #endregion
        //    string out_insertedid = ((IDictionary<string, Object>)(plpgSqlHelper.ExecuteSingleDynamic(PlpgSqlConstants.GetUserDetails, sqlParams))).Values.ElementAt(0).ToString();
        //    var MessageCode = Convert.ToInt32(out_insertedid);

        //    return response;

        //}
        public async Task<UserDetails> Login(UserDetails userDetails)
        {
            PlpgSqlHelper plpgSqlHelper = new PlpgSqlHelper(_connectionString);
            UserDetails response = null;
            #region SqlParams
            object[] sqlParams = new object[] {
                new NpgsqlParameter("in_userid",userDetails.UserName){NpgsqlDbType=NpgsqlDbType.Varchar,Direction=ParameterDirection.Input }
            };
            #endregion
            try
            {
                DataTable dt = plpgSqlHelper.ExecuteDynamicDataTable(PlpgSqlConstants.GetUserDetails, sqlParams);

                foreach (DataRow dr in dt.Rows)
                {
                    response = new UserDetails();

                    if (dr["Id"] != System.DBNull.Value)
                        response.Id = Convert.ToInt32(dr["Id"]);
                    if (dr["UserId"] != System.DBNull.Value)
                        response.UserName = Convert.ToString(dr["UserId"]);

                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }

       
    }
}
