using Microsoft.AspNetCore.Mvc;
using WebApplication.Application.Common.Results;

namespace WebApplication.API.Common
{
    public class ControllerApiBase : ControllerBase
    {
        [NonAction]
        public IActionResult ToActionResult(Result result)
        {
            return result.Status switch
            {
                Status.Ok => Ok(),
                Status.Forbiden => Forbid(),
                Status.Created => Created(),
                Status.NoContent => NoContent(),
                Status.Error => Problem(result.Message),
                Status.Conflict => Conflict(result.Message),
                Status.Accepted => Accepted(result.Message),
                Status.NotFound => NotFound(result.Message),
                Status.Validation => BadRequest(result.Message),
                Status.BadRequest => BadRequest(result.Message),
                _ => StatusCode(500, result.Message),
            };
        }

        [NonAction]
        public IActionResult ToActionResult<T>(Result<T> result)
        {
            return result.Status switch
            {
                Status.Ok => Ok(result.Value),
                Status.Created => Created(),
                Status.Accepted => Accepted(),
                Status.NoContent => NoContent(),
                Status.Conflict => Conflict(),
                Status.Forbiden => Forbid(),
                Status.NotFound => NotFound(),
                Status.Error => Problem(result.Message),
                Status.Validation => BadRequest(result.Message),
                Status.BadRequest => BadRequest(result.Message),
                _ => StatusCode(500, result.Message),
            };
        }
    }
}