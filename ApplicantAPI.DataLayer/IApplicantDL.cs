using ApplicantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantAPI.DataLayer
{
   public interface IApplicantDL
    {
        bool AddApplicantDL(ApplicantInfo applicantInfo);
        bool UpdateApplicantDL(ApplicantInfo applicantInfo);
        ApplicantInfo GetApplicantByIdDL(int id);
        List<ApplicantInfo> GetApplicantsDL();
        int DeleteApplicantDL(int id);
    }
}
