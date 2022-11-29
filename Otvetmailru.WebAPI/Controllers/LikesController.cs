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
    public class LikesController : ControllerBase
    {
        private readonly ILikesService _likesService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public LikesController(ILikesService likesService, IMapper mapper)
        {
            this._likesService = likesService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get Likess by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetLikes([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = _likesService.GetLikes(limit, offset);

            return Ok(_mapper.Map<PageResponse<LikesResponse>>(pageModel));
        }

        /// <summary>
        /// Update Likes
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateLikes([FromRoute] Guid id, [FromBody] UpdateLikesRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = _likesService.UpdateLikes(id, _mapper.Map<UpdateLikesModel>(model));

                return Ok(_mapper.Map<LikesResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Likes
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteLikes([FromRoute] Guid id)
        {
            try
            {
                _likesService.DeleteLikes(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Likes
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetLikes([FromRoute] Guid id)
        {
            try
            {
                var likesModel = _likesService.GetLikes(id);
                return Ok(_mapper.Map<LikesResponse>(likesModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// create Likes
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateLikes([FromBody] CreateLikesModel likes)
        {
            var response =_likesService.CreateLikes(likes);
            return Ok(response);
        }
    }
