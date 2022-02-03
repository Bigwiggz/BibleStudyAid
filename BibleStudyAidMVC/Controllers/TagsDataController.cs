using AutoMapper;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsDataController : ControllerBase
    {
        private readonly ITagsData _tagsData;
        private readonly ILogger<Tags> _logger;
        private readonly IMapper _mapper;

        public TagsDataController(ITagsData tagsData, ILogger<Tags> logger, IMapper mapper)
        {
            _tagsData = tagsData;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ActionResult<List<Tags>>> Index()
        {
            var model = await _tagsData.GetAllAsync();
            return model.ToList();
        }
    }
}
