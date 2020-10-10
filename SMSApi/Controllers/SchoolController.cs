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
        //Academic page
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

        //Class
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
        [Route("api/SaveSchoolClass")]
        [HttpPost]
        public IHttpActionResult SaveSchoolClass(SchoolClass schoolClass)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                schoolMSEntities.SchoolClasses.Add(schoolClass);
                return Ok(schoolMSEntities.SaveChanges());
            }
        }

        //School Subject
        [Route("api/GetAllSubject/{schoolId}")]
        [HttpGet]
        public IHttpActionResult GetAllSubject(int schoolId)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                return Ok(schoolMSEntities.SchoolSubjects.Where(x => x.Schoolid == schoolId).ToList());
            }
        }
        [Route("api/SaveSchoolSubject")]
        [HttpPost]
        public IHttpActionResult SaveSchoolSubject(SchoolSubject schoolSubject)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                schoolMSEntities.SchoolSubjects.Add(schoolSubject);
                return Ok(schoolMSEntities.SaveChanges());
            }
        }

        //Class Subject
        [Route("api/SaveClassSubject")]
        [HttpPost]
        //Save Calss Subject
        public IHttpActionResult SaveClassSubject(ClassSubject classSubject)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                schoolMSEntities.ClassSubjects.Add(classSubject);
                return Ok(schoolMSEntities.SaveChanges());
            }
        }

        [Route("api/GetClassSubject/{schoolId}")]
        [HttpGet]
        public IHttpActionResult GetClassSubject(int schoolId, int classId)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                var a = from p in schsms.exe

                return Ok();
            }
        }

    }
}

