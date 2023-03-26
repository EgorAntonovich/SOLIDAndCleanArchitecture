using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Domain;
using HR.LeaveManagementSystem.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagementSystem.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async Task<bool> IsLeaveTypeNameUnique(string name)
    {
        return await _context.LeaveTypes.AnyAsync(q => q.Name == name);
    }
}