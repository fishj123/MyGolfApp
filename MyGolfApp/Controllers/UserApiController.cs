using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyGolfApp.Authentication;
using MyGolfApp.Interfaces;
using MyGolfApp.Models;
using MyGolfApp.Repository;
using MyGolfApp.Repository.Models;

namespace MyGolfApp.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class UserApiController : ControllerBase
{
    private readonly IUserService _userService;
    public UserApiController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public ActionResult<int> Post(UserCreate model)
    {
        var id = _userService.Create(model.Email, model.Username, model.Password);
        return Ok(id);
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<UserResponse>> Get()
    {
        var users = _userService.GetAll();

        if (users.Any() == false)
        {
            return Ok();
        }

        var response = users.Select(x => new UserResponse()
        {
            Email = x.Email,
            Username = x.Username,
            CreateDate = x.CreateDate,
            ModifiedDate = x.ModifiedDate
        });
        
        return Ok(response);
    }
    
}