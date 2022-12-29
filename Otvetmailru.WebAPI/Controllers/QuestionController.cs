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
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Doctors controller
    /// </summary>
    public QuestionController(IQuestionService questionService, IMapper mapper)
    {
        this._questionService = questionService;
        this._mapper = mapper;
    }

    /// <summary>
    /// Get Questions by pages
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("")]
    public IActionResult GetQuestions([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = _questionService.GetQuestion(limit, offset);

        return Ok(_mapper.Map<PageResponse<QuestionResponse>>(pageModel));
    }

    /// <summary>
    /// Update Question
    /// </summary>
    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateQuestion([FromRoute] Guid id, [FromBody] UpdateQuestionRequest model)
    {
        var validationResult = model.Validate();
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var resultModel = _questionService.UpdateQuestion(id, _mapper.Map<UpdateQuestionModel>(model));

            return Ok(_mapper.Map<QuestionResponse>(resultModel));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Delete Question
    /// </summary>
    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteQuestion([FromRoute] Guid id)
    {
        try
        {
            _questionService.DeleteQuestion(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get Question
    /// </summary>
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetQuestion([FromRoute] Guid id)
    {
        try
        {
            var questionModel = _questionService.GetQuestion(id);
            return Ok(_mapper.Map<QuestionResponse>(questionModel));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// create Question
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult CreateQuestion([FromBody] CreateQuestionRequest question)
    {
        var validationResult = question.Validate();
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var response = _questionService.CreateQuestion(_mapper.Map<CreateQuestionModel>(question));
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}