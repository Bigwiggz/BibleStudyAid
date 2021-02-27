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
    public class ReferencesController : ControllerBase
    {
        private readonly IReferencesData _ReferencesData;
        private readonly IMapper _mapper;

        public ReferencesController(IReferencesData ReferencesData, IMapper mapper)
        {
            _ReferencesData = ReferencesData;
            _mapper = mapper;
        }
        // GET: api/<ReferencesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReferencesDTO>>> GetAllAsync()
        {
            var ReferencesList = await _ReferencesData.GetAllAsync();

            var DTOList = _mapper.Map<IEnumerable<ReferencesDTO>>(ReferencesList);

            return Ok(DTOList);
        }

        // GET api/<ReferencesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReferencesDTO>> GetByIdAsync(int id)
        {
            var References = await _ReferencesData.GetByIdAsync(id);
            var dTOModel = _mapper.Map<DailyBibleReadingDTO>(References);

            return Ok(dTOModel);
        }

        // POST api/<ReferencesController>
        [HttpPost]
        public void Post([FromBody] ReferencesDTO ReferencesDTO)
        {
            var model = _mapper.Map<References>(ReferencesDTO);

            _ReferencesData.InsertAsync(model);
        }

        // PUT api/<ReferencesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ReferencesDTO ReferencesDTO)
        {
            ReferencesDTO.Id = id;
            var model = _mapper.Map<References>(ReferencesDTO);
            _ReferencesData.UpdateAsync(model);
        }

        // DELETE api/<ReferencesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ReferencesData.DeleteAsync(id);
        }
    }
}
