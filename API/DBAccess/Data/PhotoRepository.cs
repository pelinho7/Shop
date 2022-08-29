using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using API.Helpers;
using System;
using API.DBAccess.Interfaces;
using API.DBAccess.Entities;
using API.DBAccess.Data;

namespace API.DBAccess.Data
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public PhotoRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddPhoto(Photo photo)
        {
            context.Photos.Add(photo);
        }

        public async Task<int> GetMaxPhotoLp(int productId)
        {
            return await context.Photos
            .Where(x=>x.ProductId==productId && !x.Deleted)
            .Select(x=>x.Lp).FirstOrDefaultAsync();
        }

        public async void DeletePhoto(int photoId)
        {
            var photo = await context.Photos.FirstOrDefaultAsync(x=>x.Id == photoId);
            photo.Deleted=true;
            photo.ModDate=System.DateTime.UtcNow;
        }

        public async Task<Photo> GetPhoto(int photoId)
        {
            return await context.Photos.Where(x=>x.Id == photoId).FirstOrDefaultAsync();
        }
    }
}