using System.Collections.Generic;
using System.Linq;
using API.DTOs;

namespace API.Services.Interfaces
{
    public interface ICreateHistoryService
    {
        List<HistoryDto> CreateHistory<T>(List<IGrouping<int, T>> groupedData, int timezone, string location);
    }
}