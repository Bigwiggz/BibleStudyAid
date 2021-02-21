using AutoMapper;
using BibleStudyDataAccessLibrary.DataAccess;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FamilyStudyProjectsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FamilyStudyProjectsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FamilyStudyProjectsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FamilyStudyProjectsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
