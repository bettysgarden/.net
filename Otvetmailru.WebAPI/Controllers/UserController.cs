using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Otvetmailru.Services.Abstract;
using Otvetmailru.Services.Models;
using Otvetmailru.WebAPI.Models;


namespace Otvetmailru.WebAPI.Controllers;

    /// <summary>
    /// Doctors endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public UsersController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get users by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetUsers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = _userService.GetUsers(limit, offset);

            return Ok(_mapper.Map<PageResponse<UserResponse>>(pageModel));
        }

        /// <summary>
        /// Update user
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = _userService.UpdateUser(id, _mapper.Map<UpdateUserModel>(model));

                return Ok(_mapper.Map<UserResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete user
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get user
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser([FromRoute] Guid id)
        {
            try
            {
                var userModel = _userService.GetUser(id);
                return Ok(_mapper.Map<UserResponse>(userModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
