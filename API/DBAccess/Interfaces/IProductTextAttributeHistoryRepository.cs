using API.DBAccess.Entities;

namespace API.DBAccess.Interfaces
{
    public interface IProductTextAttributeHistoryRepository
    {
        void AddProductTextAttributeHistory(ProductTextAttribute productTextAttribute); 
    }
}