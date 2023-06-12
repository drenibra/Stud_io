using Stud_io.Dormitory.Models;
using Stud_io_Dormitory.Configurations;
using Stud_io_Dormitory.Models;
using System.Linq;

namespace Stud_io_Dormitory.Services.Implementations
{
    public class DormitoryDataGenerator
    {
        private readonly DormitoryDbContext _context;

        public DormitoryDataGenerator(DormitoryDbContext context)
        {
            _context = context;
        }

        public void GenerateRoomsForDormitories()
        {
            // Check if rooms are already generated for the dormitories
            if (_context.Rooms.Any())
            {
                // Rooms already exist, no need to generate them again
                return;
            }

            int totalRoomsPerFloor = 40; // Total rooms per floor
            int capacityPerRoom1 = 2; // Capacity for the first 20 rooms
            int capacityPerRoom2 = 3; // Capacity for the next 20 rooms

            int totalFloors = 5; // Total number of floors
            int roomNoIncrement = 100; // Increment value for room numbers

            // Iterate through each dormitory
            foreach (var dormitory in _context.Dormitories)
            {
                // Iterate through each floor
                for (int floor = 1; floor <= totalFloors; floor++)
                {
                    // Calculate the range of room numbers for the current floor
                    int startRoomNo = (floor * roomNoIncrement) + 1;
                    int endRoomNo = startRoomNo + totalRoomsPerFloor - 1;

                    // Generate rooms for the current floor
                    for (int roomNo = startRoomNo; roomNo <= endRoomNo; roomNo++)
                    {
                        int capacity = (roomNo <= startRoomNo + (totalRoomsPerFloor / 2)) ? capacityPerRoom1 : capacityPerRoom2;

                        Room room = new Room
                        {
                            RoomNo = roomNo,
                            Floor = floor,
                            Capacity = capacity,
                            DormitoryId = dormitory.DormNo
                        };

                        _context.Rooms.Add(room);
                    }
                }
            }

            // Save the changes to the database
            _context.SaveChanges();
        }

    }
}
