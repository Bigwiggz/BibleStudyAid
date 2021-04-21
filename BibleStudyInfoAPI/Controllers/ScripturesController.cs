using AutoMapper;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using BibleStudyInfoAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleStudyInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScripturesController : ControllerBase
    {
        private readonly IScripturesData _ScripturesData;
        private readonly IMapper _mapper;

        public ScripturesController(IScripturesData ScripturesData, IMapper mapper)
        {
            _ScripturesData = ScripturesData;
            _mapper = mapper;
        }
        // GET: api/<ScripturesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScripturesDTO>>> GetAllAsync()
        {
            var ScripturesList = await _ScripturesData.GetAllAsync();

            var DTOList = _mapper.Map<IEnumerable<ScripturesDTO>>(ScripturesList);

            return Ok(DTOList);
        }

        // GET api/<ScripturesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScripturesDTO>> GetByIdAsync(int id)
        {
            var Scriptures = await _ScripturesData.GetByIdAsync(id);
            var dTOModel = _mapper.Map<DailyBibleReadingDTO>(Scriptures);

            return Ok(dTOModel);
        }

        // POST api/<ScripturesController>
        [HttpPost]
        public void Post([FromBody] ScripturesDTO ScripturesDTO)
        {

            var model = _mapper.Map<Scriptures>(ScripturesDTO);

            _ScripturesData.InsertAsync(model);
        }

        // PUT api/<ScripturesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ScripturesDTO ScripturesDTO)
        {
            ScripturesDTO.Id = id;
            var model = _mapper.Map<Scriptures>(ScripturesDTO);
            _ScripturesData.UpdateAsync(model);
        }

        // DELETE api/<ScripturesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ScripturesData.DeleteAsync(id);
        }
    }
}
