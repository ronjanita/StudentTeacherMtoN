using StudentTeacherMtoNAPI.DTO.Room;
using StudentTeacherMtoNAPI.DTO.Student;
using StudentTeacherMtoNAPI.Models;


namespace StudentTeacherMtoNAPI.Interface

{
    public interface IRoomRepository
    {
        Task<ICollection<Room>> GetAllRooms();
        Task<Room> AddRoom(Room newRoom);
        Task<Room> GetRoomById(Guid Id);
        Task<Room> UpdateRoom(RoomDTO updatedRoomInfo, Guid Id);
    }
}

