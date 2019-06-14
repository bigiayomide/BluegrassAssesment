using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bluegrass.Menu.API.Helpers.Contracts
{
	public interface IActionResponseHelper
	{
		IActionResult GetTResult<TModel, TResult>(TResult result);
		IActionResult GetTResult<TModel, TResult>(TResult result, string message = "");
	}
}
