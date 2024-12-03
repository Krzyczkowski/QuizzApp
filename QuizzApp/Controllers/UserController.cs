

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/user")]
[Authorize]
public class UserController:ControllerBase, IUserController{

    private readonly UserService _userService;

    public UserController(UserService userService){
        _userService = userService;
    }
    [HttpGet("points")]
    public IActionResult GetPoints()
    {
        return _userService.GetPoints();
    }

    
}