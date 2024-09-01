using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
    
    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        var users = _unitOfWork.Users.GetAll();
        return Ok(users);
    }
    
}