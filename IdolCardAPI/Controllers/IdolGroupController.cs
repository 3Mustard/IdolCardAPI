using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace IdolCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdolGroupController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public IdolGroupController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            // Declare variables for query
            string query = @"SELECT GroupId, GroupName from dbo.IdolGroup";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IdolAppConn");
            SqlDataReader myReader;

            using(SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}
