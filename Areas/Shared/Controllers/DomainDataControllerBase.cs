using AutoMapper;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Shared.Controllers
{
    [Route("api/Shared/[controller]")]
    [ApiController]
    [Authorize]
    public class DomainDataControllerBase<TEntity, TDetails> : ControllerBase where TEntity : class
    {
        private readonly IDomainService<TEntity> _domainService;
        private readonly IMapper _mapper;

        public DomainDataControllerBase(IDomainService<TEntity> domainService, IMapper mapper)
        {
            _domainService = domainService;
            _mapper = mapper;
        }

        protected async Task<IActionResult> CreateEntity(TDetails details)
        {
            TEntity entity = _mapper.Map<TEntity>(details);

            //var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //entity.CreatorId = userId;

            var createdEntity = await _domainService.Create(entity);

            return Ok(_mapper.Map<TDetails>(createdEntity));
        }


        protected async Task<IActionResult> UpdateEntity(TDetails details)
        {
            TEntity entity = _mapper.Map<TEntity>(details);

            var updatedEntity = await _domainService.Update(entity);

            return Ok(_mapper.Map<TDetails>(updatedEntity));
        }

        protected async Task<IActionResult> GetEntity(int id)
        {
            var entity = await _domainService.Get(id);

            return entity != null ? Ok(_mapper.Map<TDetails>(entity)) : NotFound();
        }

        protected async Task<IActionResult> GetEntities()
        {
            var entities = await _domainService.GetAll();

            return Ok(_mapper.Map<IEnumerable<TDetails>>(entities));
        }

        protected async Task<IActionResult> FindEntities(Expression<Func<TEntity, bool>> expr)
        {
            var animations = await _domainService.Find(expr);

            return Ok(_mapper.Map<IEnumerable<TEntity>>(animations));
        }

        protected async Task<IActionResult> DeleteEntity(int id)
        {
            var entity = await _domainService.Delete(id);

            return entity != null ? Ok("Deleted") : NotFound();
        }
    }
}
