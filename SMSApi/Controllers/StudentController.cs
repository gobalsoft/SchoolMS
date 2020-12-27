using SchoolMSDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMSApi.Controllers
{
    public class StudentController : ApiController
    {
        [Route("api/GetReligion/{schoolId}")]
        [HttpGet]
        public IHttpActionResult GetReligion(int schoolId)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                return Ok(schoolMSEntities.Religions.Where(x => x.SchoolID == schoolId).ToList());
            }
        }
        [Route("api/GetNationality/{schoolId}")]
        [HttpGet]
        public IHttpActionResult GetNationality(int schoolId)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                return Ok(schoolMSEntities.Nationalities.Where(x => x.SchoolID == schoolId).ToList());
            }
        }
        [Route("api/GetCategory/{schoolId}")]
        [HttpGet]
        public IHttpActionResult GetCategory(int schoolId)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                return Ok(schoolMSEntities.Categories.Where(x => x.SchoolID == schoolId).ToList());
            }
        }
    }
    
    
}


