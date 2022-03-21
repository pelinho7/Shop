using System.Collections.Generic;

namespace API.Services.Interfaces
{
    public interface IHistoryCreatingService
    {
        void CreateHistory(List<object> historyObjList);
    }
}