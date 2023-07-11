using AutoMapper;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Shared.Controllers
{
    [Route("api/Animation/[controller]")]
    [ApiController]
    [Authorize]
    public class ReferenceDataControllerBase<TEntity, TDetails> : ControllerBase where TEntity : ReferenceDataEntityBase
    {
        private readonly IReferenceDataService<TEntity> _referenceDataService;
        private readonly IMapper _mapper;

        public ReferenceDataControllerBase(IReferenceDataService<TEntity> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        protected async Task<IActionResult> CreateEntity(TDetails details)
        {
            TEntity entity = _mapper.Map<TEntity>(details);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            entity.CreatorId = userId;

            var createdEntity = await _referenceDataService.Create(entity);

            return Ok(_mapper.Map<TDetails>(createdEntity));
        }

       
        protected async Task<IActionResult> UpdateEntity(TDetails details)
        {
            TEntity entity = _mapper.Map<TEntity>(details);

            var updatedEntity = await _referenceDataService.Update(entity);

            return Ok(_mapper.Map<TDetails>(updatedEntity));
        }

        protected async Task<IActionResult> GetEntity(int id)
        {
            var entity = await _referenceDataService.Get(id);

            return entity != null ? Ok(_mapper.Map<TDetails>(entity)) : NotFound();
        }

        protected async Task<IActionResult> GetEntities()
        {
            var entities = await _referenceDataService.GetAll();

            return Ok(_mapper.Map<IEnumerable<TDetails>>(entities));
        }

        protected async Task<IActionResult> FindEntities(Expression<Func<TEntity, bool>> expr)
        {
            var animations = await _referenceDataService.Find(expr);
            
            return Ok(_mapper.Map<IEnumerable<TEntity>>(animations));
        }

        protected async Task<IActionResult> DeleteEntity(int id)
        {
            var entity = await _referenceDataService.Delete(id);

            return entity != null ? Ok("Deleted") : NotFound();
        }
    }

    }
