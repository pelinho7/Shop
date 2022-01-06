using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Data;
using API.DBAccess.Interfaces;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AgreementsController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public AgreementsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("agreements-by-type")]
        public async Task<ActionResult<IEnumerable<AgreementDto>>> AgreementsByType([FromQuery]int? type)
        {
            if(!type.HasValue)
                return BadRequest();
            var agreements = await unitOfWork.AgreementRepository.GetAgreementsByTypeAsync((AgreementTypeEnum)type.Value);

            return Ok(agreements);;
        }
    }
}