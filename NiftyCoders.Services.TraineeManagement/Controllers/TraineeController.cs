using Microsoft.AspNetCore.Mvc;
using NiftyCoders.Services.TraineeManagement.Business.Models;
using NiftyCoders.Services.TraineeManagement.Business.Services;

namespace NiftyCoders.Services.TraineeManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class TraineeController: ControllerBase
{
    private readonly ITraineeServices _traineeServices;

    public TraineeController(ITraineeServices traineeServices)
    {
        _traineeServices = traineeServices;
    }

    [HttpGet]
    public IActionResult get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        return Ok(_traineeServices.GetAllTrainees(pageNumber, pageSize)); 
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult get([FromRoute]int id)
    {
        try
        {
            return Ok(_traineeServices.GetTraineeById(id));
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    [Route("get-by-email")]
    public IActionResult getByEmail([FromForm] EmailRequestModel email)
    {
        try
        {
            return Ok(_traineeServices.GetTraineeByEmail(email));
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    [Route("get-by-university")]
    public IActionResult getByUniversity([FromForm] string universityName)
    {
        try
        {
            return Ok(_traineeServices.GetTraineesByUniversity(universityName));
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    [Route("get-by-year")]

    public IActionResult getByYear([FromQuery] int year)
    {
        try
        {
            return Ok(_traineeServices.GetTrineesByYear(year));
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    [Route("get-by-trainning-period")]
    public IActionResult getByTrainningPeriod([FromBody] TrainningPeriodRequestModel trainningPeriod)
    {
        try
        {
            return Ok(_traineeServices.GetTraineesByTrainningPeriod(trainningPeriod));
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    [Route("add")]
    public IActionResult add([FromBody] TraineeCreateRequestModel trainee)
    {
        try
        {
            _traineeServices.AddTrainee(trainee);
            return Ok("Trainee added successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("remove")]
    public IActionResult remove([FromBody] EmailRequestModel email)
    {
        try
        {
            _traineeServices.RemoveTrainee(email);
            return Ok("Trainee removed successfully");
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }


    [HttpPatch]
    [Route("update-name")]
    public IActionResult updateName([FromBody] NameUpdateRequestModel trainee)
    {
        try
        {
            _traineeServices.UpdateNameOfTrainee(trainee);
            return Ok("Trainee name updated successfully");
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }



}
