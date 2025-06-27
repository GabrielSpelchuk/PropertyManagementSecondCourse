using Microsoft.AspNetCore.Mvc;
using PropertyManagement.BLL.Dtos.User;
using PropertyManagement.BLL.Services.Interfaces;
using PropertyManagement.BLL.Validation.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController (IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAllAsync());
        }

        /// <summary>
        /// Get a user by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User details</returns>
        /// <response code="200">Return the user</response>
        /// <response code="404">If the user is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserReadDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="dto">New user data</param>
        /// <returns>Created user</returns>
        /// <response code="201">User created successfylly</response>
        /// <response code="400">Invalid input data</response>
        [HttpPost]
        [ProducesResponseType(typeof(UserReadDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="id">ID of the user to update</param>
        /// <param name="dto">Updated data</param>
        /// <returns>No content</returns>
        /// <response code="204">Updated successful</response>
        /// <response code="404">User not found</response>
        /// <response code="400">Invalid input</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.UpdateAsync(id, dto);
            if (!user) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <returns>No content</returns>
        /// <response code="204">Delete successful</response>
        /// <response code="404">User not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.DeleteAsync(id);
            if (!user) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Get paginated user
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Paginated properties</returns>
        /// <response code="204">Paginated successful</response>
        /// <response code="400">Invalid input</response>
        [HttpGet("query")]
        [ProducesResponseType(typeof(IEnumerable<UserReadDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Query([FromQuery] UserQueryParameters query)
        {
            var validator = new UserQueryValidator();
            var result = validator.Validate(query);

            if (!result.IsValid)
                return BadRequest();

            var data = await _userService.QueryAsync(query);
            return Ok(data);
        }
    }
}
