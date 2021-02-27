using AutoMapper;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
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
    public class MeetingAssembliesController : ControllerBase
    {
        private readonly IMeetingAssembliesData _MeetingAssembliesData;
        private readonly IMapper _mapper;

        public MeetingAssembliesController(IMeetingAssembliesData MeetingAssembliesData, IMapper mapper)
        {
            _MeetingAssembliesData = MeetingAssembliesData;
            _mapper = mapper;
        }

        // GET: api/<MeetingAssembliesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingAssembliesDTO>>> GetAllAsync()
        {
            var MeetingAssembliesList = await _MeetingAssembliesData.GetAllAsync();

            var DTOList = _mapper.Map<IEnumerable<MeetingAssembliesDTO>>(MeetingAssembliesList);

            return Ok(DTOList);
        }

        // GET api/<MeetingAssembliesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingAssembliesDTO>> GetByIdAsync(int id)
        {
            var MeetingAssemblies = await _MeetingAssembliesData.GetByIdAsync(id);
            var dTOModel = _mapper.Map<MeetingAssembliesDTO>(MeetingAssemblies);

            return Ok(dTOModel);
        }

        // POST api/<MeetingAssembliesController>
        [HttpPost]
        public void Post([FromBody] MeetingAssembliesDTO MeetingAssembliesDTO)
        {
            var Model = _mapper.Map<MeetingAssemblies>(MeetingAssembliesDTO);

            _MeetingAssembliesData.InsertAsync(Model);
        }

        // PUT api/<MeetingAssembliesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MeetingAssembliesDTO MeetingAssembliesDTO)
        {
            MeetingAssembliesDTO.Id = id;
            var Model = _mapper.Map<MeetingAssemblies>(MeetingAssembliesDTO);
            _MeetingAssembliesData.UpdateAsync(Model);
        }

        // DELETE api/<MeetingAssembliesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _MeetingAssembliesData.DeleteAsync(id);
        }
    }
}
