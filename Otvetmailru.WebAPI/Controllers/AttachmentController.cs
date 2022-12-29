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
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentsService _attachmentService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public AttachmentController(IAttachmentsService attachmentService, IMapper mapper)
        {
            this._attachmentService = attachmentService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get Attachments by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetAttachments([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = _attachmentService.GetAttachments(limit, offset);

            return Ok(_mapper.Map<PageResponse<AttachmentsResponse>>(pageModel));
        }

        /// <summary>
        /// Update Attachment
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateAttachment([FromRoute] Guid id, [FromBody] UpdateAtachmentsRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = _attachmentService.UpdateAttachments(id, _mapper.Map<UpdateAttachmentsModel>(model));

                return Ok(_mapper.Map<AttachmentsResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Attachment
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAttachment([FromRoute] Guid id)
        {
            try
            {
                _attachmentService.DeleteAttachments(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Attachment
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAttachment([FromRoute] Guid id)
        {
            try
            {
                var attachmentModel = _attachmentService.GetAttachments(id);
                return Ok(_mapper.Map<AttachmentsResponse>(attachmentModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
