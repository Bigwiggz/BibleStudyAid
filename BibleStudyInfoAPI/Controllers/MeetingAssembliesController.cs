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
    public class MeetingsAssembliesController : ControllerBase
    {
        private readonly IMeetingsAssembliesData _MeetingsAssembliesData;
        private readonly IMapper _mapper;

        public MeetingsAssembliesController(IMeetingsAssembliesData MeetingsAssembliesData, IMapper mapper)
        {
            _MeetingsAssembliesData = MeetingsAssembliesData;
            _mapper = mapper;
        }

        // GET: api/<MeetingsAssembliesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingsAssembliesDTO>>> GetAllAsync()
        {
            var MeetingsAssembliesList = await _MeetingsAssembliesData.GetAllAsync();

            var DTOList = _mapper.Map<IEnumerable<MeetingsAssembliesDTO>>(MeetingsAssembliesList);

            return Ok(DTOList);
        }

        // GET api/<MeetingsAssembliesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingsAssembliesDTO>> GetByIdAsync(int id)
        {
            var MeetingsAssemblies = await _MeetingsAssembliesData.GetByIdAsync(id);
            var dTOModel = _mapper.Map<MeetingsAssembliesDTO>(MeetingsAssemblies);

            return Ok(dTOModel);
        }

        // POST api/<MeetingsAssembliesController>
        [HttpPost]
        public void Post([FromBody] MeetingsAssembliesDTO MeetingsAssembliesDTO)
        {
            var Model = _mapper.Map<MeetingsAssemblies>(MeetingsAssembliesDTO);

            _MeetingsAssembliesData.InsertAsync(Model);
        }

        // PUT api/<MeetingsAssembliesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MeetingsAssembliesDTO MeetingsAssembliesDTO)
        {
            MeetingsAssembliesDTO.Id = id;
            var Model = _mapper.Map<MeetingsAssemblies>(MeetingsAssembliesDTO);
            _MeetingsAssembliesData.UpdateAsync(Model);
        }

        // DELETE api/<MeetingsAssembliesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _MeetingsAssembliesData.DeleteAsync(id);
        }
    }
}
