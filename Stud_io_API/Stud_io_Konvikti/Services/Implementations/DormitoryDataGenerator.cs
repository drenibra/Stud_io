using Stud_io.Dormitory.Models;
using Stud_io_Dormitory.Configurations;
using Stud_io_Dormitory.Models;

namespace Stud_io_Dormitory.Services.Implementations
{
    public class DormitoryDataGenerator
    {
        private readonly DormitoryDbContext _context;

        public DormitoryDataGenerator(DormitoryDbContext context)
        {
            _context = context;
        }

       public void GenerateDormitories()
        {
            List<Dormitory> dormitories = new List<Dormitory>();

            // Generate rooms for each dormitory
            for (int dormitoryId = 1; dormitoryId <= 8; dormitoryId++)
            {
                Dormitory dormitory = new Dormitory
                {
                    //DormNo = dormitoryId,
                    Gender = (dormitoryId <= 4) ? 'F' : 'M',
                    NoOfRooms = 200
                    // Set other dormitory properties as needed
                };

                List<Room> rooms = GenerateRoomsForDormitory(dormitoryId);
                dormitory.Rooms = rooms;

                dormitories.Add(dormitory);
            }

            _context.Dormitories.AddRange(dormitories);
            _context.SaveChanges();
        }

        private List<Room> GenerateRoomsForDormitory(int dormitoryId)
        {
            List<Room> rooms = new List<Room>();
            int roomId = 1;
            int capacityPerRoom1 = 2; // Capacity for the first 100 rooms
            int capacityPerRoom2 = 3; // Capacity for the next 100 rooms

            // Iterate through each floor
            for (int floor = 1; floor <= 5; floor++)
            {
                // Calculate the range of room numbers for the current floor
                int startRoomNo = ((floor - 1) * 100) + 101;
                int endRoomNo = (floor * 100) + 100;

                // Generate rooms for the current floor
                for (int roomNo = startRoomNo; roomNo <= endRoomNo; roomNo++)
                {
                    int capacity = (roomNo <= (startRoomNo + 100)) ? capacityPerRoom1 : capacityPerRoom2;

                    Room room = new Room
                    {
                        RoomNo = roomNo,
                        Floor = floor,
                        Capacity = capacity,
                        DormitoryId = dormitoryId
                    };

                    rooms.Add(room);
                    roomId++;
                }
            }

            return rooms;
        }
    
    }
}
