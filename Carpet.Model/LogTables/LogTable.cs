namespace Carpet.Domain.LogTables;

public class LogTable
{
    public Guid Id { get; set; }
    public DateTime DATETIME { get; set; }
    public string Level { get; set; }
    public string Logger { get; set; }
    public string Message { get; set; }
    public string Exception { get; set; }
}
