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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public CommentsController(ICommentsService commentsService, IMapper mapper)
        {
            this._commentsService = commentsService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get Commentss by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetComments([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = _commentsService.GetComments(limit, offset);

            return Ok(_mapper.Map<PageResponse<CommentsResponse>>(pageModel));
        }

        /// <summary>
        /// Update Comments
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateComments([FromRoute] Guid id, [FromBody] UpdateCommentsRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = _commentsService.UpdateComments(id, _mapper.Map<UpdateCommentsModel>(model));

                return Ok(_mapper.Map<CommentsResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Comments
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteComments([FromRoute] Guid id)
        {
            try
            {
                _commentsService.DeleteComments(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Comments
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetComments([FromRoute] Guid id)
        {
            try
            {
                var commentsModel = _commentsService.GetComments(id);
                return Ok(_mapper.Map<CommentsResponse>(commentsModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
