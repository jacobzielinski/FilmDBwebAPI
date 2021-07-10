using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TT_Education_webAPI.API.Models;


namespace TT_Education_webAPI.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "ApiUser")]
    [ApiController]
    public class FilmModelsController : ControllerBase
    {
        private readonly DbFilmsContext _context;

        public FilmModelsController(DbFilmsContext context)
        {
            _context = context;
        }


        // GET: api/FilmModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmModel>>> GetFilmModels()
        {
            return await _context.FilmModels.Where(x => !x.IsDeleted).ToListAsync();
        }

        // GET: api/FilmModels/5
        [EnableCors]
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmModel>> GetFilmModel(int id)
        {
            var filmModel = await _context.FilmModels.FindAsync(id);

            if (filmModel == null)
            {
                return NotFound();
            }

            return filmModel;
        }

        // PUT: api/FilmModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmModel(int id, FilmModel filmModel)
        {
            if (id != filmModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(filmModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmModelExists(id))
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

        // POST: api/FilmModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmModel>> PostFilmModel(FilmModel filmModel)
        {
            _context.FilmModels.Add(filmModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmModel", new { id = filmModel.Id }, filmModel);
        }

        // DELETE: api/FilmModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmModel(int id)
        {
            var filmModel = await _context.FilmModels.FindAsync(id);

            if (filmModel == null)
            {
                return NotFound();
            }

            filmModel.IsDeleted = true;


            //_context.FilmModels.Remove(filmModel);
            _context.Entry(filmModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmModelExists(int id)
        {
            return _context.FilmModels.Any(e => e.Id == id);
        }

        //public async Task<IActionResult> GetToken()
        //{

        //    {
        //        var client = _clientFactory.CreateClient();

        //        client.BaseAddress = new Uri(_authConfigurations.Value.ProtectedApiUrl);

        //        var access_token = await _apiTokenClient.GetApiToken(
        //            "ProtectedApi",
        //            "scope_used_for_api_in_protected_zone",
        //            "api_in_protected_zone_secret"
        //        );

        //        client.SetBearerToken(access_token);

        //        var response = await client.GetAsync("api/values");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var responseContent = await response.Content.ReadAsStringAsync();
        //            var data = JArray.Parse(responseContent);

        //            return data;
        //        }


        //    }
        //}
    }
}
