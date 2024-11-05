using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentTeacherManagement.API.DTOs;
using StudentTeacherManagement.Core.Interfaces;
using StudentTeacherManagement.Core.Models;

namespace StudentTeacherManagement.API.Controllers
{
    [ApiController]
    [Route("groups")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public GroupController(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroups([FromQuery] string? name = null,
                                                                         [FromQuery] int skip = 0,
                                                                         [FromQuery] int take = 20)
        {
            IEnumerable<Group> groups = await _groupService.GetGroups(name, skip, take);

            return Ok(_mapper.Map<IEnumerable<GroupDTO>>(groups));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDTO>> GetGroupById([FromRoute] Guid id)
        {
            var group = await _groupService.GetGroupById(id);

            if (group is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GroupDTO>(group));
        }


        [HttpPost]
        public async Task<ActionResult<GroupDTO>> CreateGroup([FromBody] GroupDTO group)
        {
            try
            {
                var newGroup = _mapper.Map<Group>(group);
                await _groupService.AddGroup(newGroup);

                var createdGroup = _mapper.Map<GroupDTO>(group);
                return Ok(createdGroup);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("addStudent")]
        public async Task<ActionResult> AddStudentToGroup([FromQuery] Guid groupId, [FromQuery] Guid studentId)
        {
            try
            {
                await _groupService.AddStudentToGroup(groupId, studentId);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGroup(Guid id)
        {
            await _groupService.DeleteGroup(id);

            return NoContent();
        }
    }
}
