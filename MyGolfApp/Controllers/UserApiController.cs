using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyGolfApp.Models;
using MyGolfApp.Repository;
using MyGolfApp.Repository.Models;

namespace MyGolfApp.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class UserApiController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public UserApiController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    [HttpPost]
    public ActionResult<int> Post(UserCreate model)
    {
        var now = DateTime.UtcNow;

        var user = new User()
        {
            Email = model.Email,
            Password = model.Password,
            ModifiedDate = now,
            CreateDate = now,
            Username = model.Username
        };
        
        _unitOfWork.Users.Add(user);
        var id = _unitOfWork.Complete();
        return Ok(id);
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<UserResponse>> Get()
    {
        var users = _unitOfWork.Users.GetAll().ToList();

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