using cleanFlow.Dtos.AuditDtos;

namespace cleanFlow.Repositories.AuditRepository
{
    public interface IAuditRepository
    {
        Task<List<ResultAuditDto>> GetAllAudit();
        Task<List<ResultAuditDto>> GetAuditById(int auditId);
        Task CreateAudit(CreateAuditDto createAuditDto);
        Task AddPersonelToAudit(UpdateAuditDto updateAuditDto);
        Task DeleteAudit(int[] auditId);
        Task DeletePersonelFromAudit(int personelId);
    }
}
