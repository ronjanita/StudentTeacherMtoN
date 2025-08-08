using Microsoft.EntityFrameworkCore;
using StudentTeacherMtoNAPI.Data;
using StudentTeacherMtoNAPI.DTO.Room;
using StudentTeacherMtoNAPI.DTO.Teacher;
using StudentTeacherMtoNAPI.Interface;
using StudentTeacherMtoNAPI.Models;

namespace StudentTeacherMtoNAPI.Repository
{
    public class RoomRepository(DataContext context) : IRoomRepository
    {
        private readonly DataContext _context = context;
        public async Task<ICollection<Room>> GetAllRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }
        public async Task<Room> AddRoom(Room newRoom)
        {
            await _context.Rooms.AddAsync(newRoom);
            await SaveChangesAsync();
            return newRoom;
        }
        public async Task<Room> GetRoomById(Guid Id)
        {
            Room rooms = await _context.Rooms.FindAsync(Id);
            return rooms;
        }

        async public Task<Room> UpdateRoom(RoomDTO updatedRoomInfo, Guid Id)
        {
            var room = await _context.Rooms.FindAsync(Id);
            room.RoomName = updatedRoomInfo.RoomName;
            await SaveChangesAsync();
            return room;
        }
        async public Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
