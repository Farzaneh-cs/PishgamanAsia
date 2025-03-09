using Carpet.DBContext;
using Carpet.Domain.LogTables;

namespace Carpet.Infrastructure.LogTables;

public class logTableRepository : IlogTableRepository
{
    private readonly ApplicationDbContext _context;

    public logTableRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateErrorLog(string apiname, string Exception, string message, DateTime dateTime, int? statusCode = 0)
    {
        var errorLog = new LogTable
        {
            DATETIME = dateTime,
            Exception = Exception,
            Level = statusCode.ToString(),
            Logger = apiname,
            Message = message
        };
        _context.LogTables.Add(errorLog);
        await _context.SaveChangesAsync();
    }
}
