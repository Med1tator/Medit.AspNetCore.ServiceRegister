using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medit.AspNetCore.ServiceRegister.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medit.AspNetCore.ServiceRegister.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicPlayer _musicPlayer;

        public MusicController(IMusicPlayer musicPlayer)
        {
            _musicPlayer = musicPlayer;
        }

        [HttpGet]
        public IActionResult PlayJayChou()
        {
            _musicPlayer.PlayJayChou();
            return Ok();
        }
    }
}