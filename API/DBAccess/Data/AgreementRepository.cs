using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using API.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DBAccess.Data
{
    public class AgreementRepository:IAgreementRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public AgreementRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddAgreement(Agreement agreement)
        {
            context.Agreements.Add(agreement);
        }

        public int Count()
        {
            return context.Agreements.Count();
        }

        public async Task<IEnumerable<Agreement>> GetAgreementsAsync(bool? obligatory=null)
        {
            var query=context.Agreements.AsQueryable();
            if(obligatory.HasValue){
                query=query.Where(x=>x.Obligatory==obligatory.Value).AsQueryable();
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<AgreementDto>> GetAgreementsByTypeAsync(AgreementTypeEnum agreementType)
        {
            var agreements=context.Agreements.Where(x=>x.Type.HasValue && x.Type.Value==(int)agreementType).ToList();
            return mapper.Map<List<AgreementDto>>(agreements);
        }
    }
}