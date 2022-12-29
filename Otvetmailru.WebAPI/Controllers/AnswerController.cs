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
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public AnswerController(IAnswerService answerService, IMapper mapper)
        {
            this._answerService = answerService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get Answers by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAnswer([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = _answerService.GetAnswer(limit, offset);

            return Ok(_mapper.Map<PageResponse<AnswerResponse>>(pageModel));
        }

        /// <summary>
        /// Update Answer
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateAnswer([FromRoute] Guid id, [FromBody] UpdateAnswerRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = _answerService.UpdateAnswer(id, _mapper.Map<UpdateAnswerModel>(model));

                return Ok(_mapper.Map<AnswerResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Answer
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAnswer([FromRoute] Guid id)
        {
            try
            {
                _answerService.DeleteAnswer(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Answer
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAnswer([FromRoute] Guid id)
        {
            try
            {
                var answerModel = _answerService.GetAnswer(id);
                return Ok(_mapper.Map<AnswerResponse>(answerModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// create Answer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateAnswer([FromBody] CreateAnswerRequest answer)
        {
            var validationResult = answer.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {

            var response =_answerService.CreateAnswer(_mapper.Map<CreateAnswerModel>(answer));
            return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
