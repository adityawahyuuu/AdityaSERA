using AdityaSERA.Backend.Model.Domain;
using AdityaSERA.Backend.Model.DTO;
using AdityaSERA.Backend.Repositories.Cat;
using AdityaSERA.Backend.Services.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdityaSERA.Backend.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            var categories = await _categoryRepository.getCategory();

            var categoriesDTO = _mapper.Map<List<GetAllCategoryRequest>>(categories);
            return Ok(categoriesDTO);
        }
    }
}
