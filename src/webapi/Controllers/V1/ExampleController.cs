using Api.Core.Catalogs.Example.Commands.Add;
using Api.Core.Catalogs.Example.Commands.Delete;
using Api.Core.Catalogs.Example.Commands.Update;
using Api.Core.Catalogs.Example.Queries.GetAll;
using Api.Core.Catalogs.Example.Queries.GetById;
using Api.Domain.Common;
using Api.Infrastructure.Authentication;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers.V1;

[ApiVersion("1.0")]
//[Authorize]
public class ExampleController : BaseApiController
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    //[HasPermission(CatalogPermission.WriteUser)]
    public async Task<IActionResult> Add(AddExampleCommand command)
    {
        var result = await Mediator!.Send(command);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut]
    //[HasPermission(CatalogPermission.WriteUser)]
    public async Task<IActionResult> Update(UpdateExampleCommand command)
    {
        var result = await Mediator!.Send(command);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("{exampleId:guid}")]
    //[HasPermission(CatalogPermission.DeleteUser)]
    public async Task<IActionResult> LogicalDeleteByIdAsync(Guid exampleId)
    {
        DeleteExampleCommand request = new()
        {
            ExampleId = exampleId
        };
        var result = await Mediator!.Send(request);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    //[HasPermission(CatalogPermission.ReadUser)]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetAllExamplesQuery query)
    {
        var result = await Mediator!.Send(query);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("GetUser")]
    [HttpGet]
    public async Task<IActionResult> GetUserById([FromQuery] GetExampleByIdQuery query)
    {
        var result = await Mediator!.Send(query);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}
