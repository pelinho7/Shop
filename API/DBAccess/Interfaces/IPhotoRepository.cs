using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DTOs;
using API.Helpers;

namespace API.DBAccess.Interfaces
{
    public interface IPhotoRepository
    {
        void AddPhoto(Photo photo);
        Task<int> GetMaxPhotoLp(int productId);
        void DeletePhoto(int photoId);
        Task<Photo> GetPhoto(int photoId);
    }
}