using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuissnesLayer.DTO;
using BuissnesLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.Models;

namespace Music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService,IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllGenres()
        {
            return Ok(_mapper.Map<ICollection<GenreViewModel>>(await _genreService.GetAllGenresAsync()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateGenre(GenreViewModel genre)
        {           
            var serviceActionResult= await _genreService.AddGenreAsync(genre.Name);
            return serviceActionResult.Succeed
                        ? (IActionResult)Ok(serviceActionResult)
                        : BadRequest(serviceActionResult);
        }
        [HttpDelete]
        [Route("genreId/{genreId}")]
        public async Task<IActionResult> DeleteGenre(int genreId)
        {
            var serviceActionResult = await _genreService.DeleteGenreAsync(genreId);
            return serviceActionResult.Succeed
                        ? (IActionResult)Ok(serviceActionResult)
                        : BadRequest(serviceActionResult);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGenre(GenreViewModel genre)
        {           
            var serviceActionResult = await _genreService.UpdateGenreAsync(_mapper.Map<GenreDTO>(genre));
            return serviceActionResult.Succeed
                        ? (IActionResult)Ok(serviceActionResult)
                        : BadRequest(serviceActionResult);
        }
    }
}