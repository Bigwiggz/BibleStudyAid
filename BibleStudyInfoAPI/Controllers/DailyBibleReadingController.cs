using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibleStudyInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyBibleReadingController : ControllerBase
    {
        private readonly IDailyBibleReadingData _dailyBibleReadingData;

        public DailyBibleReadingController(IDailyBibleReadingData dailyBibleReadingData)
        {
            _dailyBibleReadingData = dailyBibleReadingData;
        }

        // GET: api/<DailyBibleReadingController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyBibleReading>>> GetAllAsync()
        {
            var dailyBibleReadingList = await _dailyBibleReadingData.GetAllAsync();

            return Ok(dailyBibleReadingList);
        }

        // GET api/<DailyBibleReadingController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyBibleReading>> GetByIdAsync(int id)
        {
            var dailyBibleReading = await _dailyBibleReadingData.GetByIdAsync(id);

            return Ok(dailyBibleReading);
        }

        // POST api/<DailyBibleReadingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<DailyBibleReadingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DailyBibleReadingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
