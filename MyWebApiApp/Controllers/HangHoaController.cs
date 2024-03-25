using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var result = hangHoas.SingleOrDefault(hangHoa => hangHoa.MaHangHoa == Guid.Parse(id));
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM HangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = HangHoaVM.TenHangHoa,
                DonGia = HangHoaVM.DonGia,
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hanghoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoaVM HangHoaEdit)
        {
            try
            {
                var result = hangHoas.SingleOrDefault(hangHoa => hangHoa.MaHangHoa == Guid.Parse(id));
                if (result == null) 
                { 
                    return NotFound(); 
                }
                if (id != result.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                result.TenHangHoa = HangHoaEdit.TenHangHoa;
                result.DonGia = HangHoaEdit.DonGia;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = hangHoas.SingleOrDefault(hangHoa => hangHoa.MaHangHoa == Guid.Parse(id));
                if (result == null)
                {
                    return NotFound();
                }
                hangHoas.Remove(result);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
