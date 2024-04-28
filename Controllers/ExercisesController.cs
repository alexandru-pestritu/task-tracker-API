using Microsoft.AspNetCore.Mvc;

namespace TasksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : ControllerBase
    {
        private static List<string> Names = new List<string> { "ana", "vasile", "gheorghe", "maria", "ion" };

        [HttpGet("{routeParameter}")]
        public IActionResult GetWithParameters(string routeParameter, [FromQuery] double param1, [FromQuery] double param2)
        {
            var sum = param1 + param2;
            return Ok($"{routeParameter}: {sum}");
        }

        [HttpPost("ProcessList")]
        public IActionResult ProcessList([FromBody] List<double> numbers)
        {
            if (numbers == null || !numbers.Any())
            {
                return BadRequest("The list cannot be null or empty.");
            }

            var sum = numbers.Sum();
            return Ok(sum);
        }

        [HttpGet("GetNames")]
        public IActionResult GetNames()
        {
            return Ok(Names);
        }

        [HttpPut("UpdateName/{index}")]
        public IActionResult UpdateName(int index, [FromBody] string newName)
        {
            if (index < 0 || index >= Names.Count)
            {
                return BadRequest("Index out of bounds.");
            }

            if (string.IsNullOrEmpty(newName))
            {
                return BadRequest("New name cannot be null or empty.");
            }

            Names[index] = newName;
            return Ok(Names);
        }

        [HttpDelete("DeleteName/{index}")]
        public IActionResult DeleteName(int index)
        {
            if (index < 0 || index >= Names.Count)
            {
                return BadRequest("Index out of bounds.");
            }

            Names.RemoveAt(index);
            return Ok(Names);
        }
    }
}

