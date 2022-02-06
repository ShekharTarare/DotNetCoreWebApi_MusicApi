using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ApiDbContext _db;

        public SongsController(ApiDbContext db)
        {
            _db = db;
        }
        // GET: api/<SongsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //return _db.Songs;
            //return BadRequest();
            //return NotFound();            
            //return StatusCode(StatusCodes.Status200OK);
            return Ok(await _db.Songs.ToListAsync());
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var song = await _db.Songs.FindAsync(id);
            if (song == null)
                return NotFound();
            else
            {
                return Ok(song);
            }
        }

        // POST api/<SongsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Song song)
        {
            await _db.Songs.AddAsync(song);
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Song song)
        {
            var songDet = await _db.Songs.FindAsync(id);
            if (songDet == null)
                return NotFound("No record found");
            else
            {
                songDet.Title = song.Title;
                songDet.Language = song.Language;
                await _db.SaveChangesAsync();
                return Ok("Record updated successfully!");
            }
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var song =await _db.Songs.FindAsync(id);
            if (song == null)
                return NotFound("No record found");
            else
            {
                _db.Songs.Remove(song); //We can't use await here and we also don't have RemoveAsync
                await _db.SaveChangesAsync();
                return Ok("Record deleted!");
            }
        }
    }
}
