using AutoMapper;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using BibleStudyInfoAPI.DTOs;
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
        private readonly IMapper _mapper;

        public DailyBibleReadingController(IDailyBibleReadingData dailyBibleReadingData, IMapper mapper)
        {
            _dailyBibleReadingData = dailyBibleReadingData;
            _mapper = mapper;
        }

        // GET: api/<DailyBibleReadingController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyBibleReadingDTO>>> GetAllAsync()
        {
            var dailyBibleReadingList = await _dailyBibleReadingData.GetAllAsync();

            var DTOList = _mapper.Map<IEnumerable<DailyBibleReadingDTO>>(dailyBibleReadingList);

            return Ok(DTOList);
        }

        // GET api/<DailyBibleReadingController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyBibleReadingDTO>> GetByIdAsync(int id)
        {
            var dailyBibleReading = await _dailyBibleReadingData.GetByIdAsync(id);
            var dTOModel = _mapper.Map<DailyBibleReadingDTO>(dailyBibleReading);

            return Ok(dTOModel);
        }

        // POST api/<DailyBibleReadingController>
        [HttpPost]
        public void Post([FromBody] DailyBibleReadingDTO dailyBibleReadingDTO)
        {
            var Model = _mapper.Map<DailyBibleReading>(dailyBibleReadingDTO);

            _dailyBibleReadingData.InsertAsync(Model);
        }

        // PUT api/<DailyBibleReadingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DailyBibleReadingDTO dailyBibleReadingDTO)
        {
            dailyBibleReadingDTO.Id = id;
            var Model = _mapper.Map<DailyBibleReading>(dailyBibleReadingDTO);
            _dailyBibleReadingData.UpdateAsync(Model);
        }

        // DELETE api/<DailyBibleReadingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dailyBibleReadingData.DeleteAsync(id);
        }
    }
}
