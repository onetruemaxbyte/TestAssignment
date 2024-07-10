using Application.DTO;

namespace Application.Interfaces;

public interface ICandidateService
{
    Task<IdResult> CreateOrUpdateCandidate(CreateOrUpdateCandidateDto dto);
}