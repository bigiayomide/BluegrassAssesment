using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bluegrass.Menu.API.Helpers.Contracts;
using Bluegrass.Menu.API.ViewModels;
using Bluegrass.Menu.Models;
using Bluegrass.Menu.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bluegrass.Menu.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IActionResponseHelper _actionResponseHelper;
		private readonly IMapper _mapper;

		public UserController(IUserService userService, IActionResponseHelper actionResponseHelper, IMapper mapper)
		{
			_userService = userService;
			_actionResponseHelper = actionResponseHelper;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var result = await _userService.GetAll();
			return _actionResponseHelper.GetTResult<IEnumerable<UserViewModel>, IEnumerable<User>>(result);
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> Get(int Id)
		{
			return _actionResponseHelper.GetTResult<UserViewModel, User>(await _userService.GetById(Id));
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] UserViewModel model)
		{
			var user = _mapper.Map<User>(model);
			await _userService.Create(user);
			return CreatedAtAction("Post", model);
		}

		[HttpPut("{Id}")]
		public async Task<IActionResult> Put(int Id, [FromBody] UserViewModel model)
		{
			var user = _mapper.Map<User>(model);
			await _userService.Update(user);
			return CreatedAtAction("Put", model);
		}

		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete(int Id)
		{
			await _userService.Delete(Id);
			return Ok();
		}
	}
}