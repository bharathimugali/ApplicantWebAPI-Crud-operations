using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicantAPI.BusinessLayer;
using ApplicantAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApplicantWebAPI.Controllers
{
    [Route("api/applicants")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantBusiness _applicantBusiness;
        public ApplicantController(IApplicantBusiness applicantBusiness)
        {
            _applicantBusiness = applicantBusiness;
        }

        [HttpPost]
        public IActionResult AddApplicant([FromBody]ApplicantInfo applicantInfo)
        {
            try
            {
                bool res = _applicantBusiness.AddApplicantBL(applicantInfo);
                if (res)
                {
                    return StatusCode(StatusCodes.Status201Created, "Applicant added successfully");
                }
                else
                {
                    return BadRequest(new { message = "couldnot add applicant" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteApplicant(int id)
        {
            try
            {
                int res = _applicantBusiness.DeleteApplicantBL(id);

                if (res>0)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "Applicant deleted successfully");
                   
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Applicant record not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet]
        public IActionResult GetApplicants()
        {
            try
            {

                List<ApplicantInfo> applicantInfos = _applicantBusiness.GetApplicantsBL();
                return Ok(applicantInfos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetApplicantById(int id)
        {
            try
            {

                ApplicantInfo applicantInfo = _applicantBusiness.GetApplicantByIdBL(id);
                if (applicantInfo == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Applicant with Id " + id.ToString() + " not found");
                }
                return Ok(applicantInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateApplicant([FromBody]ApplicantInfo applicantInfo)
        {
            try
            {
                bool res = _applicantBusiness.UpdateApplicantBL(applicantInfo);
                if (res)
                {
                    return StatusCode(StatusCodes.Status201Created, "Applicant updated successfully");
                }
                else
                {
                    return BadRequest(new { message = "couldnot updaye applicant" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}