using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stud_io.Dormitory.DTOs;
using Stud_io.Dormitory.Services.Interfaces;

namespace Stud_io.Dormitory.Controllers
{
    [Route("")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("GetRooms")]
        public async Task<ActionResult<List<RoomDto>>> GetRooms()
        {
            return await _roomService.GetRooms();
        }

        [HttpGet("GetRoomById/{id}")]
        public async Task<ActionResult<RoomDto>> GetRoomById(int id)
        {
            return await _roomService.GetRoomById(id);
        }

        [HttpPost("AddRoom")]
        public async Task<ActionResult> AddRoom(RoomDto roomDto)
        {
            return await _roomService.AddRoom(roomDto);
        }

        [HttpPut("UpdateRoom")]
        public async Task<ActionResult> UpdateRoom(int id, UpdateRoomDto roomDto)
        {
            return await _roomService.UpdateRoom(id, roomDto);
        }

        [HttpDelete("DeleteRoom/{id}")]
        public async Task<ActionResult> DeleteRoom(int id)
        {
            return await _roomService.DeleteRoom(id);
        }
    }
}
