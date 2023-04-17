using Microsoft.AspNetCore.Mvc;
using TemplateProject.Web.BusinessLogic.Services;
using TemplateProject.Web.Models;
using TemplateProject.Web.Models.Users;

namespace TemplateProject.Web.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserModel user)
    {
        // todo: user's props validation
        
        var result = await _userService.Create(user);

        if (result == 0)
        {
            return BadRequest("failed");
        }
        
        return Ok(new {id = result});
    }
}