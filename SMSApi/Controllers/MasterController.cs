using SchoolMSDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMSApi.Controllers
{
    public class MasterController : ApiController
    {
        [Route("api/GetSubjectCategory/{schoolId}")]
        [HttpGet]
        public IHttpActionResult GetSubjectCategory(int schoolId)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                return Ok(schoolMSEntities.Subject_Category.Where(x => x.Status == true && x.SchoolId == schoolId).ToList());

            }
        }
    }
}
