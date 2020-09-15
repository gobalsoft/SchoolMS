using SchoolMSDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using Z.EntityFramework.Plus;

namespace SMSApi.Controllers
{

    public class SchoolController : ApiController
    {
        [Route("api/SchoolAcademic/{schoolId}")]
        [HttpGet]
        public IHttpActionResult GetSchoolAllAcademic(int schoolId)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                var schoolAca = schoolMSEntities.SchoolAcademics.Where(x => x.SchoolID == schoolId).ToList();
                if (schoolAca.Count > 0)
                    return Ok(schoolAca);
                else
                    return NotFound();

            }
        }
        [Route("api/Academic/{academicID}")]
        [HttpGet]
        public IHttpActionResult GetAcademicDetails(int academicID)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                var schoolAca = schoolMSEntities.SchoolAcademics.Where(x => x.AcademicID == academicID).ToList();
                if (schoolAca.Count > 0)
                    return Ok(schoolAca);
                else
                    return NotFound();

            }
        }
        [Route("api/Academic")]
        [HttpPost]
        public IHttpActionResult SaveSchoolAcademic(SchoolAcademic schoolAcademic)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                schoolMSEntities.SchoolAcademics.Add(schoolAcademic);
                return Ok(schoolMSEntities.SaveChanges());
            }

        }

        [Route("api/UpdateAcademic")]
        [HttpPost]
        public IHttpActionResult UpdateSchoolAcademic(SchoolAcademic schoolAcademic)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                return Ok(schoolMSEntities.SchoolAcademics
                    .Where(x => x.AcademicID == schoolAcademic.AcademicID)
                    .Update(x => new SchoolAcademic()
                    {
                        AcademicStartDate = schoolAcademic.AcademicStartDate,
                        AcademicEndDate = schoolAcademic.AcademicEndDate,
                        IsCurrentAcademic = schoolAcademic.IsCurrentAcademic
                    }));
            }
        }
        [Route("api/GetAllClass/{schoolId}")]
        [HttpGet]
        public IHttpActionResult GetAllClass(int schoolId)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                var list = schoolMSEntities.SchoolClasses.Where(x => x.Schoolid == schoolId).ToList();
                return Ok(list);
            }
        }
    }
}

