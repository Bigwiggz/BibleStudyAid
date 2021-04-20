using AutoMapper;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using BibleStudyInfoAPI.DTOs;
using BibleStudyInfoAPI.Validators;
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
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentsData _documentsData;
        private readonly IMapper _mapper;

        public DocumentsController(IDocumentsData documentsData, IMapper mapper)
        {
            _documentsData = documentsData;
            _mapper = mapper;
        }
        // GET: api/<DocumentsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentsDTO>>> GetAllAsync()
        {
            var documentsList = await _documentsData.GetAllAsync();

            var DTOList = _mapper.Map<IEnumerable<DocumentsDTO>>(documentsList);

            return Ok(DTOList);
        }

        // GET api/<DocumentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentsDTO>> GetByIdAsync(int id)
        {
            var documents = await _documentsData.GetByIdAsync(id);
            var dTOModel = _mapper.Map<DailyBibleReadingDTO>(documents);

            return Ok(dTOModel);
        }

        // POST api/<DocumentsController>
        [HttpPost]
        public void Post([FromBody] DocumentsDTO documentsDTO)
        {
            DocumentsValidator validator = new DocumentsValidator();
            var result = validator.Validate(documentsDTO);
            if (result.IsValid)
            {
                var model = _mapper.Map<Documents>(documentsDTO);
                _documentsData.InsertAsync(model);
            }

        }

        // PUT api/<DocumentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DocumentsDTO documentsDTO)
        {
            documentsDTO.Id = id;
            var model = _mapper.Map<Documents>(documentsDTO);
            _documentsData.UpdateAsync(model);
        }

        // DELETE api/<DocumentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _documentsData.DeleteAsync(id);
        }
    }
}
