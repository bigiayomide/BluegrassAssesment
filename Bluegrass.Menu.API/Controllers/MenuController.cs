using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bluegrass.Menu.API.Helpers.Contracts;
using Bluegrass.Menu.API.ViewModels;
using Bluegrass.Menu.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bluegrass.Menu.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MenuController : ControllerBase
  {
    private readonly IMenuService _menuService;
    private readonly IActionResponseHelper _actionResponseHelper;
    private readonly IMapper _mapper;

    public MenuController(IMenuService menuService, IActionResponseHelper actionResponseHelper, IMapper mapper)
    {
      _menuService = menuService;
      _actionResponseHelper = actionResponseHelper;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var result = await _menuService.GetAll();
      return _actionResponseHelper.GetTResult<IEnumerable<MenuViewModel>, IEnumerable<Models.Menu>>(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get(int Id)
    {
      return _actionResponseHelper.GetTResult<MenuViewModel, Models.Menu>(await _menuService.GetById(Id));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MenuModel model)
    {
      var menu = _mapper.Map<Models.Menu>(model);
      await _menuService.Create(menu);
      return CreatedAtAction("Post", model);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(int Id, [FromBody] MenuModel model)
    {
      var menu = _mapper.Map<Models.Menu>(model);
      await _menuService.Update(menu);
      return CreatedAtAction("Put", model);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
      await _menuService.Delete(Id);
      return Ok();
    }
  }
}