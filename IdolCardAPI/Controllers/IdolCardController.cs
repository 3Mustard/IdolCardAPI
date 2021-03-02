using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using IdolCardAPI.Models;

namespace IdolCardAPI.Controllers
{
    [Route("api/[controller]")] // api/IdolCard
    [ApiController]
    public class IdolCardController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public IdolCardController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = "SELECT IdolId, IdolName, IdolGroup, PhotoCardSet, convert(varchar(10), DateAdded, 120) as DateAdded, PhotoFileName from dbo.IdolCard";
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
        public JsonResult Post(IdolCard idolCard)
        {
            string query = $"insert into dbo.IdolCard (IdolName, IdolGroup, PhotoCardSet, DateAdded, PhotoFileName) values (@IdolName, @IdolGroup, @PhotoCardSet, @DateAdded, @PhotoFileName)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IdolAppCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    var p1 = myCommand.CreateParameter();
                    p1.ParameterName = "@IdolName";
                    p1.Direction = ParameterDirection.Input;
                    p1.DbType = DbType.String;
                    p1.Value = idolCard.IdolName;

                    var p2 = myCommand.CreateParameter();
                    p2.ParameterName = "@IdolGroup";
                    p2.Direction = ParameterDirection.Input;
                    p2.DbType = DbType.String;
                    p2.Value = idolCard.IdolGroup;

                    var p3 = myCommand.CreateParameter();
                    p3.ParameterName = "@PhotoCardSet";
                    p3.Direction = ParameterDirection.Input;
                    p3.DbType = DbType.String;
                    p3.Value = idolCard.PhotoCardSet;

                    var p4 = myCommand.CreateParameter();
                    p4.ParameterName = "@DateAdded";
                    p4.Direction = ParameterDirection.Input;
                    p4.DbType = DbType.String;
                    p4.Value = idolCard.DateAdded;

                    var p5 = myCommand.CreateParameter();
                    p5.ParameterName = "@PhotoFileName";
                    p5.Direction = ParameterDirection.Input;
                    p5.DbType = DbType.String;
                    p5.Value = idolCard.PhotoFileName;

                    myCommand.Parameters.Add(p1);
                    myCommand.Parameters.Add(p2);
                    myCommand.Parameters.Add(p3);
                    myCommand.Parameters.Add(p4);
                    myCommand.Parameters.Add(p5);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Idol Card POST success!");
        }

        [HttpPut]
        public JsonResult Put(IdolCard idolCard)
        {
            string query = $"update dbo.IdolCard set IdolName = @IdolName, IdolGroup = @IdolGroup, PhotoCardSet = @PhotoCardSet, DateAdded = @DateAdded, PhotoFileName = @PhotoFileName where IdolId = @IdolId";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IdolAppCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    var p1 = myCommand.CreateParameter();
                    p1.ParameterName = "@IdolName";
                    p1.Direction = ParameterDirection.Input;
                    p1.DbType = DbType.String;
                    p1.Value = idolCard.IdolName;

                    var p2 = myCommand.CreateParameter();
                    p2.ParameterName = "@IdolGroup";
                    p2.Direction = ParameterDirection.Input;
                    p2.DbType = DbType.String;
                    p2.Value = idolCard.IdolGroup;

                    var p3 = myCommand.CreateParameter();
                    p3.ParameterName = "@PhotoCardSet";
                    p3.Direction = ParameterDirection.Input;
                    p3.DbType = DbType.String;
                    p3.Value = idolCard.PhotoCardSet;

                    var p4 = myCommand.CreateParameter();
                    p4.ParameterName = "@DateAdded";
                    p4.Direction = ParameterDirection.Input;
                    p4.DbType = DbType.String;
                    p4.Value = idolCard.DateAdded;

                    var p5 = myCommand.CreateParameter();
                    p5.ParameterName = "@PhotoFileName";
                    p5.Direction = ParameterDirection.Input;
                    p5.DbType = DbType.String;
                    p5.Value = idolCard.PhotoFileName;

                    var p6 = myCommand.CreateParameter();
                    p6.ParameterName = "@IdolId";
                    p6.Direction = ParameterDirection.Input;
                    p6.DbType = DbType.String;
                    p6.Value = idolCard.IdolId;

                    myCommand.Parameters.Add(p1);
                    myCommand.Parameters.Add(p2);
                    myCommand.Parameters.Add(p3);
                    myCommand.Parameters.Add(p4);
                    myCommand.Parameters.Add(p5);
                    myCommand.Parameters.Add(p6);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Idol Card UPDATE success!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = $"delete from dbo.IdolCard where IdolId = @id";
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
