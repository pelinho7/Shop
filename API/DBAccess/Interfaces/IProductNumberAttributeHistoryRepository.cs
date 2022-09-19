using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Entities;

namespace API.DBAccess.Interfaces
{
    public interface IProductNumberAttributeHistoryRepository
    {
        void AddProductNumberAttributeHistory(ProductNumberAttribute productNumberAttribute);
    }
}