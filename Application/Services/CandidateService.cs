using Application.DTO;
using Application.Interfaces;
using Core.Enitity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class CandidateService(IApplicationDbContext context) : ICandidateService
{
    public async Task<IdResult> CreateOrUpdateCandidate(CreateOrUpdateCandidateDto dto)
    {
        Candidate? candidate;

        if (dto.Id.HasValue)
        {
            candidate = await context.Candidates.FirstOrDefaultAsync(x => x.Id == dto.Id.Value);

            if (candidate == null)
            {
                candidate = new Candidate { Id = dto.Id.Value };
            }
        }
        else
        {
            candidate = new Candidate { Id = Guid.NewGuid() };
            await context.Candidates.AddAsync(candidate);
        }
            
        candidate.FirstName = dto.FirstName;
        candidate.LastName = dto.LastName;
        candidate.Email = dto.Email;
        candidate.PreferredCallTimeInterval = dto.PreferredCallTimeInterval;
        candidate.Phone = dto.Phone;
        candidate.LinkedInProfile = dto.LinkedInProfile;
        candidate.GithubProfile = dto.GithubProfile;
        candidate.Comment = dto.Comment;

        await context.SaveChangesAsync(new CancellationToken());

        return new IdResult() { Id = candidate.Id };
    }
}