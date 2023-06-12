using Microsoft.AspNetCore.Mvc;
using Stud_io.Dormitory.DTOs;

namespace Stud_io.Dormitory.Services.Interfaces
{
    public interface IRoomService
    {
        public Task<ActionResult<List<RoomDto>>> GetRooms();
        public Task<ActionResult<RoomDto>> GetRoomById(int id);
        public Task<ActionResult> AddRoom(RoomDto roomDTO);
        public Task<ActionResult> UpdateRoom(int id, UpdateRoomDto updateRoomDTO);
        public Task<ActionResult> DeleteRoom(int id);
        public Task<ActionResult<List<RoomDto>>> GetRoomsData();


    }
}
