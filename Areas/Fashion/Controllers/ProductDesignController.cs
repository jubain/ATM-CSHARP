using AutoMapper;
using Hope.BackendServices.API.Areas.Fashion.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Controllers
{
    [Route("api/Fashion/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductDesignController : ReferenceDataControllerBase<ProductDesign, ProductDesignDetails>
    {
        //private readonly IReferenceDataService<ProductDesign> _productDesignService;
        //private readonly IMapper _mapper;

        public ProductDesignController(IReferenceDataService<ProductDesign> productDesignService, IMapper mapper)
            : base(productDesignService, mapper)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDesignDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDesignDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDesign(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDesign(int id)
        {
            return await DeleteEntity(id);
        }



    }
}
