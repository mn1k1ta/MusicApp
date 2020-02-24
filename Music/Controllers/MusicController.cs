using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuissnesLayer.DTO;
using BuissnesLayer.Interfaces;
using Catel.Data;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.Models;

namespace Music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;

        public MusicController(IMusicService musicService, IMapper mapper)
        {
            _musicService = musicService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("hui")]
        public async Task<IActionResult> GetMusic()
        {
            return Ok(_mapper.Map<ICollection<MusicViewModel>>( await _musicService.GetAllMusicAsync()));
        } 

        [HttpPost]
        public async Task<IActionResult> CreateMusic(MusicViewModel music)
        {
            var musicDTO = _mapper.Map<MusicDTO>(music);
            var serviceActionResult = await _musicService.AddMusicAsync(musicDTO);           
            return serviceActionResult.Succeed
                        ? (IActionResult)Ok(serviceActionResult)
                        : BadRequest(serviceActionResult);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateMusic(MusicViewModel music)
        {
            var musicDTO = _mapper.Map<MusicDTO>(music);
            var serviceActionResult = await _musicService.UpdateMusicAsync(musicDTO);
            return serviceActionResult.Succeed
                        ? (IActionResult)Ok(serviceActionResult)
                        : BadRequest(serviceActionResult);

        }

        [HttpDelete]
        [Route("musicId/{musicId}")]
        public async Task<IActionResult> DeleteMusic(int musicId)
        {
            var serviceActionResult = await _musicService.DeleteMusicAsync(musicId);
            return serviceActionResult.Succeed
                        ? (IActionResult)Ok(serviceActionResult)
                        : BadRequest(serviceActionResult);
        }
        [HttpGet]
        [Route("genresIds")]
        public async Task<IActionResult> GetAllGamesByGenres(int[] genresIds)
        {
            return Ok(await _musicService.GetAllMusicByGenreAsync(genresIds));
        }
        [HttpGet]
        [Route("musicName/{musicName}")]
        public async Task<IActionResult> SearchMusicByName(string musicName)
        {
            return Ok(await _musicService.GetMusicByNameAsync(musicName));
        }
        
    }
}