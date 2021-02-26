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
    public class FamilyStudyProjectsController : ControllerBase
    {
        private readonly IFamilyStudyProjectsData _familyStudyProjectsData;
        private readonly IMapper _mapper;

        public FamilyStudyProjectsController(IFamilyStudyProjectsData familyStudyProjectsData, IMapper mapper)
        {
            _familyStudyProjectsData = familyStudyProjectsData;
            _mapper = mapper;
        }
        // GET: api/<FamilyStudyProjectsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyStudyProjectsDTO>>> GetAllAsync()
        {
            var familyStudyProjectsList = await _familyStudyProjectsData.GetAllAsync();
            var DTOList = _mapper.Map<IEnumerable<FamilyStudyProjectsDTO>>(familyStudyProjectsList);
            return Ok(DTOList);
        }

        // GET api/<FamilyStudyProjectsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyStudyProjectsDTO>> GetByIdAsync(int id)
        {
            var familyStudyProject = await _familyStudyProjectsData.GetByIdAsync(id);
            var DTO = _mapper.Map<FamilyStudyProjectsDTO>(familyStudyProject);
            return Ok(DTO);
        }

        // POST api/<FamilyStudyProjectsController>
        [HttpPost]
        public void Post([FromBody] FamilyStudyProjectsDTO familyStudyProjectsDTO)
        {
            var Model = _mapper.Map<FamilyStudyProjects>(familyStudyProjectsDTO);
            _familyStudyProjectsData.InsertAsync(Model);
        }

        // PUT api/<FamilyStudyProjectsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FamilyStudyProjectsDTO familyStudyProjectsDTO)
        {
            familyStudyProjectsDTO.Id = id;
            var Model = _mapper.Map<FamilyStudyProjects>(familyStudyProjectsDTO);
            _familyStudyProjectsData.UpdateAsync(Model);
        }

        // DELETE api/<FamilyStudyProjectsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _familyStudyProjectsData.DeleteAsync(id);
        }
    }
}
