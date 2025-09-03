using Microsoft.AspNetCore.Mvc;
using NiftyCoders.Services.TraineeManagement.Business.TraineeServices;
using NiftyCoders.Services.TraineeManagement.Business.TraineeServices.Models;

namespace NiftyCoders.Services.TraineeManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class TraineeController : ControllerBase
{
    private readonly ITraineeFetcher _traineeFetcher;
    private readonly ITraineeCreator _traineeCreator;
    private readonly ITraineeUpdate _traineeUpdate;
    private readonly ITraineeDelete _traineeDelete;
    public TraineeController(ITraineeFetcher traineeFetcher, ITraineeCreator traineeCreator, ITraineeUpdate traineeUpdate, ITraineeDelete traineeDelete)
    {
        _traineeCreator = traineeCreator;
        _traineeFetcher = traineeFetcher;
        _traineeUpdate = traineeUpdate;
        _traineeDelete = traineeDelete;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int pageNumber = 1, [FromQuery]int pageSize=10)
    {
        List<TraineeResponseModel> traineeResponseModels = _traineeFetcher.GetAllTrainee(pageNumber, pageSize);

        return Ok(traineeResponseModels);
    }

    [HttpGet("{id}", Name = "GetTraineeWithId")]
    public IActionResult Get(int id)
    {
        return Ok(_traineeFetcher.GetTrainee(id));
    }

    [HttpGet("get-with-email")]
    public IActionResult Get([FromForm] string email)
    {
        return Ok(_traineeFetcher.GetTraineeWithEmail(email));
    }

    [HttpGet("search-name")]

    public IActionResult SearchWithName([FromQuery] string name)
    {
        return Ok(_traineeFetcher.Search(name));
    }

    [HttpGet("get-within-period")]
    public IActionResult GetWithinPeriod([FromBody] TrainningPeriodRequestModel period)
    {
        return Ok(_traineeFetcher.GetAllTraineeWithinPeriod(period));
    }

    [HttpGet("get-by-year")]
    public IActionResult GetInAYear([FromQuery] int year)
    {
        return Ok(_traineeFetcher.GetAllTraineeByYear(year));
    }



    [HttpPost]
    public IActionResult CreateTrainee([FromBody] TraineeCreateRequestModel trainee)
    {
        int id = _traineeCreator.CreateNewTrainee(trainee);
        return CreatedAtRoute("GetTraineeWithId", new {id = id}, new { id = id });
    }

    [HttpPatch("update-name")]
    public IActionResult UpdateName([FromBody] NameUpdateRequest nameUpdateRequest)
    {
         _traineeUpdate.UpdateTraineeName(nameUpdateRequest);
        return NoContent();
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] string email)
    {
        _traineeDelete.DeleteTrainee(email);
        return NoContent();
    }

    [HttpPut("{email}")]
    public IActionResult Update([FromBody] TraineeUpdateRequestModel trainee, [FromRoute] string email)
    {

        int id = _traineeUpdate.UpdateTrainee(trainee, email);
        return CreatedAtRoute("GetTraineeWithId", new { id = id }, new { id = id });
    }

}
