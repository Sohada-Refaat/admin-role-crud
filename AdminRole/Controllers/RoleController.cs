using AdminRole.Dtos;
using AdminRole.Services.Role;
using Microsoft.AspNetCore.Mvc;

namespace AdminRole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Cors.EnableCors("CorsPolicy")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        ///  <summary>
        ///  creates role.
        ///  </summary>
        ///  <param name="createRoleDto"></param>
        ///  <remarks>
        /// 
        ///  Request Sample:
        /// 
        ///     {
        ///        "name": "Main Supervisor"
        ///     }
        ///        
        ///  
        ///  Response Sample:
        ///
        ///  
        ///      {
        ///        "id": "string",
        ///        "name": "string",
        ///        "isDeleted": true
        ///      }
        /// 
        ///    
        ///      
        ///  </remarks>
        ///  <returns></returns>
        [HttpPost("Create")]
        public async Task<RoleDto> Create(CreateRoleDto createRoleDto)
        {
            var roleDto = await _roleService.CreateAsync(createRoleDto);
            return roleDto;
        }

        ///  <summary>
        ///  gets role by id.
        ///  </summary>
        ///  <param name="id"></param>
        ///  <remarks>
        ///  
        ///  Response Sample:
        ///
        ///  
        ///      {
        ///        "id": "ac9c2d55-d499-4360-a58f-d16cfe8f1954",
        ///        "name": "Sub Customer",
        ///        "isDeleted": false
        ///      }
        /// 
        ///    
        ///      
        ///  </remarks>
        ///  <returns></returns>
        [HttpGet("GetById")]
        public async Task<RoleDto> GetById(Guid id)
        {
            var roleDto = await _roleService.GetByIdAsync(id);
            return roleDto;
        }

        ///  <summary>
        ///  gets all roles.
        ///  </summary>
        ///  <remarks>
        ///  
        ///  Response Sample:
        ///
        ///  
        ///      [
        ///        {
        ///          "id": "ac9c2d55-d499-4360-a58f-d16cfe8f1954",
        ///          "name": "Sub Customer",
        ///          "isDeleted": false
        ///        }
        ///      ]
        /// 
        ///    
        ///      
        ///  </remarks>
        ///  <returns></returns>
        [HttpGet("GetAll")]
        public async Task<List<RoleDto>> GetAll()
        {
            var rolesList = await _roleService.GetAllAsync();
            return rolesList;
        }

        ///  <summary>
        ///  updates role by id.
        ///  </summary>
        ///  <remarks>
        ///  
        ///  <param name="updateRoleDto"></param>
        ///  <remarks>
        /// 
        ///  Request Sample:
        /// 
        ///     {
        ///       "id": "AC9C2D55-D499-4360-A58F-D16CFE8F1954",
        ///       "name": "Main Supervisor"
        ///     }
        ///        
        ///  
        ///  Response Sample:
        ///
        ///  
        ///      {
        ///        "id": "ac9c2d55-d499-4360-a58f-d16cfe8f1954",
        ///        "name": "Sub Customer",
        ///        "isDeleted": false
        ///      }
        /// 
        ///    
        ///      
        ///  </remarks>
        ///  <returns></returns>
        [HttpPut("Update")]
        public async Task<RoleDto> Update(UpdateRoleDto updateRoleDto)
        {
            var role = await _roleService.UpdateAsync(updateRoleDto);
            return role;
        }

        ///  <summary>
        ///  deletes role by id.
        ///  </summary>
        ///  <remarks>
        ///  
        ///  <param name="id"></param>
        ///  <remarks>
        ///  
        ///  Response Sample:
        ///
        ///  
        ///      true
        /// 
        ///    
        ///      
        ///  </remarks>
        ///  <returns></returns>
        [HttpDelete("Delete")]
        public async Task<bool> Delete(Guid id)
        {
            var role = await _roleService.DeleteAsync(id);
            return role;
        }
    }
}
