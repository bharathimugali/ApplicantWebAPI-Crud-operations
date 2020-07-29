using ApplicantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantAPI.BusinessLayer
{
   public interface IApplicantBusiness
    {
        bool AddApplicantBL(ApplicantInfo applicantInfo);
        bool UpdateApplicantBL(ApplicantInfo applicantInfo);
        ApplicantInfo GetApplicantByIdBL(int id);
        List<ApplicantInfo> GetApplicantsBL();
        int DeleteApplicantBL(int id);
    }
}
