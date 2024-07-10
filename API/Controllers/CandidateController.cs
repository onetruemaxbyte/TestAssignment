using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidateController(ICandidateService candidateService) :  ControllerBase
{
    [HttpPost("createOrUpdate")]
         public async Task<IActionResult> CreateOrUpdateCandidate([FromBody] CreateOrUpdateCandidateDto dto)
         {
             if (dto is null) 
                 return BadRequest("Candidate data is null."); 
             
             var result = await candidateService.CreateOrUpdateCandidate(dto);
             return Ok(result);
         }
}