using AutoMapper;
using Hope.BackendServices.API.Areas.ConceptArt.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.ConceptArt.Controllers
{
    [Route("api/ConceptArt/[controller]")]
    [ApiController]
    [Authorize]
    public class ArtAssetController : ControllerBase
    {
        private readonly IReferenceDataService<ArtAsset> _referenceDataService;
        private readonly IMapper _mapper;

        public ArtAssetController(IReferenceDataService<ArtAsset> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArtAssetDetails artAssetDetails)
        {
            var artAsset = _mapper.Map<ArtAsset>(artAssetDetails);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            artAsset.CreatorId = userId;

            var createdArtAsset = await _referenceDataService.Create(artAsset);

            return Ok(_mapper.Map<ArtAssetDetails>(createdArtAsset));

        }

        [HttpPut]
        [StatusAuthorization]
        public async Task<IActionResult> Put([FromBody] ArtAssetDetails artAssetDetails)
        {
            var artAsset = _mapper.Map<ArtAsset>(artAssetDetails);
            var updatedArtAsset = await _referenceDataService.Update(artAsset);

            return Ok(_mapper.Map<ArtAssetDetails>(updatedArtAsset));
        }

        [HttpGet]
        public async Task<IActionResult> GetArtAssets(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var artAssets = await _referenceDataService.Find(e => e.Name.Contains(word));
                return Ok(_mapper.Map<IEnumerable<ArtAssetDetails>>(artAssets));

            }
            else if (statusId != null)
            {

                var artAssets = await _referenceDataService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<ArtAssetDetails>>(artAssets));

            }
            else
            {
                var artAssets = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<ArtAssetDetails>>(artAssets));
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtAsset(int id)
        {
            var artAsset = await _referenceDataService.Get(id);

            return artAsset != null ? Ok(_mapper.Map<ArtAssetDetails>(artAsset)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtAsset(int id)
        {
            var artAsset = await _referenceDataService.Delete(id);

            return artAsset != null ? Ok("Deleted") : NotFound();
        }



    }
}
