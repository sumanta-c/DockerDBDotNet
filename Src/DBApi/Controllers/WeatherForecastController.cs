using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace DBApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        string strConn;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            strConn = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        public IEnumerable<TestData> Get()
        {
            /*
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            */
            List<TestData> objTestData = new List<TestData>();
            /*
            TestData objDataCS = new TestData();
            objDataCS.emp_id = 1;
            objDataCS.emp_name = strConn;
            objTestData.Add(objDataCS);
            return objTestData.AsEnumerable();
            */
            
            using(Npgsql.NpgsqlConnection objConn = new Npgsql.NpgsqlConnection(strConn))
            {
                objConn.Open();
                using(Npgsql.NpgsqlCommand objCmd = new Npgsql.NpgsqlCommand())
                {
                    objCmd.CommandText="select emp_id, emp_name from testdata";
                    objCmd.CommandType=System.Data.CommandType.Text;
                    objCmd.Connection = objConn;
                    Npgsql.NpgsqlDataReader dr = objCmd.ExecuteReader();
                    while(dr.Read())
                    {
                        TestData objData = new TestData();
                        objData.emp_id = Convert.ToInt32(dr[0].ToString());
                        objData.emp_name = dr[1].ToString();
                        objTestData.Add(objData);
                    }
                }
                objConn.Close();
            }
            return objTestData.AsEnumerable();
            
        }
    }
}
