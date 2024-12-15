using Microsoft.AspNetCore.Mvc;
using MyDictionary.Redis.Interfaces;

namespace MyDictionary.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RedisTestController(IRedisService redisService) : ControllerBase
    {
        private readonly IRedisService redisService = redisService;

        [HttpGet("GetValue")]
        public IActionResult GetValue(string Key)
        {
            try
            {
                return Ok(redisService.GetValue(Key));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetValueAsync")]
        public async Task<IActionResult> GetValueAsync(string Key)
        {
            try
            {
                var _resp = await redisService.GetValueAsync(Key);
                return Ok(_resp);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("SetValue")]
        public IActionResult SetValue(string Key, string value)
        {
            try
            {
                return Ok(redisService.SetValue(Key, value));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("SetValueAsync")]
        public async Task<IActionResult> SetValueAsync(string Key, string value)
        {
            try
            {
                var _resp = await redisService.SetValueAsync(Key, value);
                return Ok(_resp);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("ClearAll")]
        public IActionResult ClearAll()
        {
            try
            {
                var _resp = redisService.ClearAll();
                return Ok(_resp);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
