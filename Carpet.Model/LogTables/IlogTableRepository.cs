using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpet.Domain.LogTables;

public interface IlogTableRepository
{
    Task CreateErrorLog(string apiname,string Exception,string message,DateTime dateTime , int? statusCode = 0);
}
