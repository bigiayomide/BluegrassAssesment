using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Bluegrass.Menu.API.Helpers.Contracts;

namespace Bluegrass.Menu.API.Helpers
{
	public class ActionResponseHelper : ControllerBase, IActionResponseHelper
	{
		private readonly IMapper _mapper;
		public ActionResponseHelper(IMapper mapper) => _mapper = mapper;

		public IActionResult GetTResult<TModel, TResult>(TResult result)
		{
			if (result != null)
			{
				var returnResult = _mapper.Map<TModel>(result);
				return Ok(returnResult);
			}
			return NoContent();
		}

		public IActionResult GetTResult<TModel, TResult>(TResult result, string message = "")
		{
			if (result != null)
			{
				var returnResult = _mapper.Map<TModel>(result);
				return Ok(returnResult);
			}
			return BadRequest(new { message });
		}
	}
}
