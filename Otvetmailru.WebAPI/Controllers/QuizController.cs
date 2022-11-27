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
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public QuizController(IQuizService quizService, IMapper mapper)
        {
            this._quizService = quizService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get Quizs by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetQuizzes([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = _quizService.GetQuiz(limit, offset);

            return Ok(_mapper.Map<PageResponse<QuizResponse>>(pageModel));
        }

        /// <summary>
        /// Update Quiz
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateQuiz([FromRoute] Guid id, [FromBody] UpdateQuizRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = _quizService.UpdateQuiz(id, _mapper.Map<UpdateQuizModel>(model));

                return Ok(_mapper.Map<QuizResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Quiz
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteQuiz([FromRoute] Guid id)
        {
            try
            {
                _quizService.DeleteQuiz(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Quiz
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetQuiz([FromRoute] Guid id)
        {
            try
            {
                var quizModel = _quizService.GetQuiz(id);
                return Ok(_mapper.Map<QuizResponse>(quizModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
