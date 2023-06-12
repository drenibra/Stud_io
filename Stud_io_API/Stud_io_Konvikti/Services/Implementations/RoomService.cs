using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Dormitory.DTOs;
using Stud_io.Dormitory.Models;
using Stud_io.Dormitory.Services.Interfaces;
using Stud_io_Dormitory.Configurations;

namespace Stud_io.Dormitory.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly DormitoryDbContext _context;
        private readonly IMapper _mapper;

        public RoomService(DormitoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<RoomDto>>> GetRooms() =>
            _mapper.Map<List<RoomDto>>(await _context.Rooms.ToListAsync());

        public async Task<ActionResult<RoomDto>> GetRoomById(int id)
        {
            var mappedRoom = _mapper.Map<RoomDto>(await _context.Rooms.FindAsync(id));
            return mappedRoom == null
                ? new NotFoundObjectResult("Room doesn't exist!!")
                : new OkObjectResult(mappedRoom);
        }

        public async Task<ActionResult> AddRoom(RoomDto roomDTO)
        {
            if (roomDTO == null)
                return new BadRequestObjectResult("Room can not be null!!");
            var mappedRoom = _mapper.Map<Room>(roomDTO);
            await _context.Rooms.AddAsync(mappedRoom);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Room added successfully!");
        }

        public async Task<ActionResult> UpdateRoom(int id, UpdateRoomDto updateRoomDTO)
        {
            if (updateRoomDTO == null)
                return new BadRequestObjectResult("Room can not be null!!");

            var dbRoom = await _context.Rooms.FindAsync(id);
            if (dbRoom == null)
                return new NotFoundObjectResult("Room doesn't exist!!");

            dbRoom.RoomNo = updateRoomDTO.RoomNo ?? dbRoom.RoomNo;
            dbRoom.Floor = updateRoomDTO.Floor ?? dbRoom.Floor;
            dbRoom.Capacity = updateRoomDTO.Capacity ?? dbRoom.Capacity;
            dbRoom.DormitoryId = updateRoomDTO.DormitoryId ?? dbRoom.DormitoryId;

            await _context.SaveChangesAsync();

            return new OkObjectResult("Room updated successfully!");
        }

        public async Task<ActionResult> DeleteRoom(int id)
        {
            var dbRoom = await _context.Rooms.FindAsync(id);
            if (dbRoom == null)
                return new NotFoundObjectResult("Room doesn't exist!!");

            _context.Rooms.Remove(dbRoom);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Room deleted successfully!");
        }

        /*
        public bool IsRoomBooked(Room room)
        {
            return room.Students.Count >= room.Capacity;
        }
        */
    }
}
