using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using IdolCardAPI.Models;


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
            string query = "SELECT GroupId, GroupName from dbo.IdolGroup";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IdolAppCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(IdolGroup ig)
        {
            string query = $"insert into dbo.IdolGroup values (@GroupName)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IdolAppCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    var p1 = myCommand.CreateParameter();
                    p1.ParameterName = "@GroupName";
                    p1.Direction = ParameterDirection.Input;
                    p1.DbType = DbType.String;
                    p1.Value = ig.GroupName;

                    myCommand.Parameters.Add(p1);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Idol Group POST success!");
        }

        [HttpPut]
        public JsonResult Put(IdolGroup ig)
        {
            string query = $"update dbo.IdolGroup set GroupName = @GroupName where GroupId = @GroupId";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IdolAppCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    var p1 = myCommand.CreateParameter();
                    p1.ParameterName = "@GroupName";
                    p1.Direction = ParameterDirection.Input;
                    p1.DbType = DbType.String;
                    p1.Value = ig.GroupName;

                    var p2 = myCommand.CreateParameter();
                    p2.ParameterName = "@GroupId";
                    p2.Direction = ParameterDirection.Input;
                    p2.DbType = DbType.String;
                    p2.Value = ig.GroupId;

                    myCommand.Parameters.Add(p1);
                    myCommand.Parameters.Add(p2);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Idol Group UPDATE success!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = $"delete from dbo.IdolGroup where GroupId = @id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IdolAppCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    var p1 = myCommand.CreateParameter();
                    p1.ParameterName = "@id";
                    p1.Direction = ParameterDirection.Input;
                    p1.DbType = DbType.String;
                    p1.Value = id;

                    myCommand.Parameters.Add(p1);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Idol Group DELETE success!");
        }
    }
}