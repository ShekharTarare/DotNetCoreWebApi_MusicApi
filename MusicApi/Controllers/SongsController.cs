using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            //return _db.Songs;
            //return BadRequest();
            //return NotFound();            
            //return StatusCode(StatusCodes.Status200OK);
            return Ok(_db.Songs);
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var song = _db.Songs.Find(id);
            if (song == null)
                return NotFound();
            else
            {
                return Ok(song);
            }
        }

        // POST api/<SongsController>
        [HttpPost]
        public IActionResult Post([FromBody] Song song)
        {
            _db.Songs.Add(song);
            _db.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Song song)
        {
            var songDet = _db.Songs.Find(id);
            if (songDet == null)
                return NotFound("No record found");
            else
            {
                songDet.Title = song.Title;
                songDet.Language = song.Language;
                _db.SaveChanges();
                return Ok("Record updated successfully!");
            }
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var song =_db.Songs.Find(id);
            if (song == null)
                return NotFound("No record found");
            else
            {
                _db.Songs.Remove(song);
                _db.SaveChanges();
                return Ok("Record deleted!");
            }
        }
    }
}
