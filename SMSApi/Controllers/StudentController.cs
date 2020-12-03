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
    }
}
