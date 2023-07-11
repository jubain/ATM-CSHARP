using AutoMapper;
using Hope.BackendServices.API.Areas.HR.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.HR.Controllers
{
    [Route("api/hr/[controller]")]
    [ApiController]
    [Authorize]
    public class RoomController : ControllerBase
    {
        private readonly IReferenceDataService<Room> _referenceDataService;
        private readonly IMapper _mapper;

        public RoomController(IReferenceDataService<Room> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoomDetails roomDetails)
        {
            var room = _mapper.Map<Room>(roomDetails);

            var createdRoom = await _referenceDataService.Create(room);

            return Ok(_mapper.Map<RoomDetails>(createdRoom));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoomDetails roomDetails)
        {
            var room = _mapper.Map<Room>(roomDetails);

            var updatedRoom = await _referenceDataService.Update(room);

            return Ok(_mapper.Map<RoomDetails>(updatedRoom));
        }




       

        [HttpGet]
        public async Task<IActionResult> GetRooms(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var rooms = await _referenceDataService.Find(e => e.Name.Contains(word));
                return Ok(_mapper.Map<IEnumerable<RoomDetails>>(rooms));

            }
            else if (statusId != null)
            {

                var rooms = await _referenceDataService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<RoomDetails>>(rooms));

            }
            else
            {
                var rooms = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<RoomDetails>>(rooms));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await _referenceDataService.Get(id);

            return room != null ? Ok(_mapper.Map<RoomDetails>(room)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _referenceDataService.Delete(id);

            return room != null ? Ok("Deleted") : NotFound();
        }



    }
}
