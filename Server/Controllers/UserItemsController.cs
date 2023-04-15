using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;
namespace Server.Controllers
{
    [Route("api/WunderlustItems")]
    [ApiController]
    public class UserItemsController : ControllerBase
    {
        private WunderlustContext _context;
        public UserItemsController(WunderlustContext context)
        {
            _context = context;
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult<UserItem>> GetUserItem(long id)
        {
            var userItem = await _context.UserItems.FindAsync(id);

            if (userItem == null)
            {
                return NotFound();
            }
            return userItem;

        }
        [HttpPost("register")]
        public async Task<ActionResult<UserItem>> PostUserItem([FromBody] UserItem userItem)
        {
            if(ModelState.IsValid)
            {
                _context.UserItems.Add(userItem);
                await _context.SaveChangesAsync();

                return CreatedAtAction(
                    nameof(GetUserItem),
                    new {id = userItem.Id},
                    userItem);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }

}