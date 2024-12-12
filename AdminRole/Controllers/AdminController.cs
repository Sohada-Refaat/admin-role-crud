using AdminRole.Dtos;
using AdminRole.Services.Admin;
using Microsoft.AspNetCore.Mvc;

namespace AdminRole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Cors.EnableCors("CorsPolicy")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        ///  <summary>
        ///  creates admin.
        ///  </summary>
        ///  <param name="createAdminDto"></param>
        ///  <remarks>
        /// 
        ///  Request Sample:
        /// 
        ///     {
        ///       "name": "Sohada",
        ///       "email": "soha@yahoo.com",
        ///       "roleId": "AC9C2D55-D499-4360-A58F-D16CFE8F1954"
        ///     }
        ///        
        ///  
        ///  Response Sample:
        ///
        ///  
        ///      {
        ///        "id": "819b2d10-e170-42c6-b13e-c9a6f3c5ae6b",
        ///        "name": "Sohada",
        ///        "email": "soha@yahoo.com",
        ///        "isDeleted": false,
        ///        "roleId": "ac9c2d55-d499-4360-a58f-d16cfe8f1954"
        ///      }
        /// 
        ///    
        ///      
        ///  </remarks>
        ///  <returns></returns>
        [HttpPost("Create")]
        public async Task<AdminDto> Create(CreateAdminDto createAdminDto)
        {
            var adminDto = await _adminService.CreateAsync(createAdminDto);
            return adminDto;
        }

        ///  <summary>
        ///  gets admin by id.
        ///  </summary>
        ///  <param name="id"></param>
        ///  <remarks>
        ///  
        ///  Response Sample:
        ///
        ///  
        /// {
        ///   "id": "819b2d10-e170-42c6-b13e-c9a6f3c5ae6b",
        ///   "name": "Sohada",
        ///   "email": "soha@yahoo.com",
        ///   "isDeleted": false,
        ///   "roleId": "ac9c2d55-d499-4360-a58f-d16cfe8f1954"
        /// }
        /// 
        ///    
        ///      
        ///  </remarks>
        ///  <returns></returns>
        [HttpGet("GetById")]
        public async Task<AdminDto> GetById(Guid id)
        {
            var adminDto = await _adminService.GetByIdAsync(id);
            return adminDto;
        }

        ///  <summary>
        ///  gets all admins.
        ///  </summary>
        ///  <remarks>
        ///  
        ///  Response Sample:
        ///
        ///  
        ///      [
        ///       {
        ///         "id": "819b2d10-e170-42c6-b13e-c9a6f3c5ae6b",
        ///         "name": "Sohada",
        ///         "email": "soha@yahoo.com",
        ///         "isDeleted": false,
        ///         "roleId": "ac9c2d55-d499-4360-a58f-d16cfe8f1954"
        ///       }
        ///     ]
        /// 
        ///    
        ///      
        ///  </remarks>
        ///  <returns></returns>
        [HttpGet("GetAll")]
        public async Task<List<AdminDto>> GetAll()
        {
            var adminsList = await _adminService.GetAllAsync();
            return adminsList;
        }

        ///  <summary>
        ///  updates admin by id.
        ///  </summary>
        ///  <remarks>
        ///  
        ///  <param name="updateAdminDto"></param>
        ///  <remarks>
        /// 
        ///  Request Sample:
        /// 
        ///     {
        ///       "id": "819b2d10-e170-42c6-b13e-c9a6f3c5ae6b",
        ///       "name": "Sohada",
        ///       "email": "sohada@yahoo.com",
        ///       "roleId": "ac9c2d55-d499-4360-a58f-d16cfe8f1954"
        ///     }
        ///        
        ///  
        ///  Response Sample:
        ///
        ///  
        ///     {
        ///       "id": "819b2d10-e170-42c6-b13e-c9a6f3c5ae6b",
        ///       "name": "Sohada",
        ///       "email": "sohada@yahoo.com",
        ///       "isDeleted": false,
        ///       "roleId": "ac9c2d55-d499-4360-a58f-d16cfe8f1954"
        ///     }
        /// 
        ///    
        ///      
        ///  </remarks>
        ///  <returns></returns>
        [HttpPut("Update")]
        public async Task<AdminDto> Update(UpdateAdminDto updateAdminDto)
        {
            var admin = await _adminService.UpdateAsync(updateAdminDto);
            return admin;
        }

        ///  <summary>
        ///  deletes admin by id.
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
            var admin = await _adminService.DeleteAsync(id);
            return admin;
        }
    }
}
