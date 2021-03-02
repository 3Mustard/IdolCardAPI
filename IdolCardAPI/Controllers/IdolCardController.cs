using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using IdolCardAPI.Models;

// ** REPLACE ALL QUERIES WITH ENTITY/STORED PROCEDURES. **
namespace IdolCardAPI.Controllers
{
    [Route("api/[controller]")]
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
            string query = $"insert into dbo.IdolGroup (IdolName, IdolGroup, PhotoCardSet, DateAdded, PhotoFileName) values ('{idolCard.IdolName}', '{idolCard.IdolGroup}', '{idolCard.PhotoCardSet}', '{idolCard.DateAdded}', '{idolCard.PhotoFileName}')";
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

            return new JsonResult("Idol Card POST success!");
        }

        [HttpPut]
        public JsonResult Put(IdolCard idolCard)
        {
            string query = $"update dbo.IdolGroup set IdolName = {idolCard.IdolName}, IdolGroup = {idolCard.IdolGroup}, PhotoCardSet = {idolCard.PhotoCardSet}, DateAdded = {idolCard.DateAdded}, PhotoFileName = {idolCard.PhotoFileName} where GroupId = {idolCard.IdolId}";
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

            return new JsonResult("Idol Card UPDATE success!");
        }
    }
}
