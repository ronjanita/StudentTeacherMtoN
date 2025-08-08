using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTeacherMtoNAPI.DTO.Room;
using StudentTeacherMtoNAPI.DTO.Student;
using StudentTeacherMtoNAPI.Interface;
using StudentTeacherMtoNAPI.Models;

namespace StudentTeacherMtoNAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController(IRoomRepository RoomRepository, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRoomRepository _RoomRepository = RoomRepository;
        [HttpGet]
        public async Task<ActionResult<List<RoomDTO>>> GetAllRooms()
        {
            ICollection<Room> rooms = await _RoomRepository.GetAllRooms();
            List<RoomDTO> mappedRooms = _mapper.Map<List<RoomDTO>>(rooms);
            return Ok(mappedRooms);
        }
        [HttpPost]
        public async Task<ActionResult<RoomDTO>> AddRoom([FromBody] RoomAddDTO room)
        {

            Room mappedRoom = _mapper.Map<Room>(room);
            Room createdRoom = await _RoomRepository.AddRoom(mappedRoom);
            return Ok(createdRoom);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoomById(Guid Id)
        {
            Room room = await _RoomRepository.GetRoomById(Id);
            RoomDTO mappedRoom = _mapper.Map<RoomDTO>(room);
            return Ok(mappedRoom);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Room>> UpdateRoom(Guid Id, [FromBody] RoomDTO updatedRoomInfo)
        {
            Room updatedRoom = await _RoomRepository.UpdateRoom(updatedRoomInfo, Id);
            return Ok(updatedRoom);
        }

    }
}
