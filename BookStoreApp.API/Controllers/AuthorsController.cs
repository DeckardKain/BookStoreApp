using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(BookStoreDbContext context, IMapper mapper, ILogger<AuthorsController> logger)
        {
            _context = context;
            this._mapper = mapper;
            this._logger = logger;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAuthorsDTO>>> GetAuthors()
        {
            _logger.LogInformation($"Request to {nameof(GetAuthors)}");

            try
            {
                var authors = await _context.Authors.ToListAsync();

                if (_context.Authors == null)
                {
                    return NotFound();
                }

                var authorsDTOs = _mapper.Map<List<GetAuthorsDTO>>(authors); // why list inside the map and not List<DTO> authorDTO = _mapper ... ?

                return authorsDTOs;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetAuthors)}");
                return StatusCode(500, "There was an error completing your request. Please try again later.");
            }
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAuthorDTO>> GetAuthor(int id)
        {

            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            var GetAuthorDTO = _mapper.Map<GetAuthorDTO>(author);

            return Ok(GetAuthorDTO);

        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutAuthor(int id, UpdateAuthorDTO updateAuthorDTO)
        {           

            if (id != updateAuthorDTO.Id)
            {
                return BadRequest();
            }

            /*_context.Entry(updateAuthorDTO).State = EntityState.Modified;*/

            var author = await _context.Authors.FindAsync(id);

            var updatedAuthor = _mapper.Map(updateAuthorDTO, author);

            _context.Entry(updatedAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<CreateAuthorDTO>> PostAuthor(CreateAuthorDTO authorDto)
        {

            var author = _mapper.Map<Author>(authorDto);

            if (_context.Authors == null)
            {
                return Problem("Entity set 'BookStoreDbContext.Authors'  is null.");
            }
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (_context.Authors == null)
            {
                return NotFound();
            }
            
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
