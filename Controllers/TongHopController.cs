
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TongHopController : Controller
    {
        private readonly ITonghopService _tonghopService;

        public TongHopController(ITonghopService tonghopService)
        {
            _tonghopService = tonghopService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tonghop = await _tonghopService.GetTongHops();
            return Ok(tonghop);
        }

        [HttpGet("nganh")]
        public async Task<IActionResult> GetNganh()
        {
            var tonghop = await _tonghopService.GetTonghopNganh();
            return Ok(tonghop);
        }

        //doituong khuvuc, tinh **khoa
        [HttpGet("tinh")]
        public async Task<IActionResult> GetTinh()
        {
            var tonghop = await _tonghopService.GetTonghopTinh();
            return Ok(tonghop);
        }
        [HttpGet("doituong")]
        public async Task<IActionResult> GetDoituong()
        {
            var tonghop = await _tonghopService.GetTonghopDoituong();
            return Ok(tonghop);
        }
        [HttpGet("khuvuc")]
        public async Task<IActionResult> GetKhuVuc()
        {
            var tonghop = await _tonghopService.GetTonghopKhuvuc();
            return Ok(tonghop);
        }
    }
}