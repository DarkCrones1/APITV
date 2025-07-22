using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography;
using APITV.Api.Responses;
using APITV.Common.Exceptions;
using APITV.Common.Functions;
using APITV.Common.Interfaces.Repositories;
using APITV.Common.Interfaces.Services;
using APITV.Domain.Dto.QueryFilters;
using APITV.Domain.Dto.Response;

// using APITV.Domain.Dto.QueryFilters;
// using APITV.Domain.Dto.Request.Create;
// using APITV.Domain.Dto.Request.Update;
// using APITV.Domain.Dto.Response;
using APITV.Domain.Entities;
using APITV.Domain.Interfaces.Services;

// using APITV.Domain.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APITV.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
// [Authorize]
public class PlatformController(IMapper mapper, IPlatformservice service) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IPlatformservice _service = service;

    [HttpGet]
    [Route("")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<PlatformResponseDto>>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<PlatformResponseDto>>))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ApiResponse<IEnumerable<PlatformResponseDto>>))]
    public async Task<IActionResult> GetAll([FromQuery] PlatformQueryFilter filter)
    {
        try
        {
            var entities = await _service.GetPaged(filter);
            var dtos = _mapper.Map<IEnumerable<PlatformResponseDto>>(entities);
            var metaDataResponse = new MetaDataResponse(
                entities.TotalCount,
                entities.CurrentPage,
                entities.PageSize
            );
            var response = new ApiResponse<IEnumerable<PlatformResponseDto>>(data: dtos, meta: metaDataResponse);
            return Ok(response);
        }
        catch (Exception ex)
        {
            throw new LogicBusinessException(ex);
        }
    }


}