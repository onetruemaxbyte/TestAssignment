using Application.DTO;
using Application.Interfaces;
using Core.Enitity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class CandidateService(IApplicationDbContext context) : ICandidateService
{
    public async Task<IdResult> CreateOrUpdateCandidate(CreateOrUpdateCandidateDto dto)
    {
        Candidate candidate = await context.Candidates.FirstOrDefaultAsync(x => x.Id == dto.Id) ?? new Candidate();

        if (!dto.Id.HasValue)
            candidate.Id = Guid.NewGuid();
            
        candidate.FirstName = dto.FirstName;
        candidate.LastName = dto.LastName;
        candidate.Email = dto.Email;
        candidate.PreferredCallTimeInterval = dto.PreferredCallTimeInterval;
        candidate.Phone = dto.Phone;
        candidate.LinkedInProfile = dto.LinkedInProfile;
        candidate.GithubProfile = dto.GithubProfile;
        candidate.Comment = dto.Comment;

        await context.Candidates.AddAsync(candidate);
        await context.SaveChangesAsync(new CancellationToken());

        return new IdResult() { Id = candidate.Id };
    }
}