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
                var list = schoolMSEntities.Classes.Where(x => x.Schoolid == schoolId).ToList();
                return Ok(list);
            }
        }
        [Route("api/SaveSchoolClass")]
        [HttpPost]
        public IHttpActionResult SaveSchoolClass(Class schoolClass)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                schoolMSEntities.Classes.Add(schoolClass);
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
                var item = (from subjectmaster in schoolMSEntities.SubjectsMasters
                            join category in schoolMSEntities.Subject_Category
                            on subjectmaster.Category_id equals category.Category_id into temp
                            from t in temp.DefaultIfEmpty()
                            where subjectmaster.Schoolid == schoolId
                            select new
                            {
                                SubjectID = subjectmaster.SubjectID,
                                Subjectcode = subjectmaster.Subjectcode,
                                Subjectname = subjectmaster.Subjectname,
                                CategoryName = t.CategoryName,
                            }).ToList();
                return Ok(item);
            }
        }
        [Route("api/SaveSchoolSubject")]
        [HttpPost]
        public IHttpActionResult SaveSchoolSubject(SubjectsMaster schoolSubject)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                schoolMSEntities.SubjectsMasters.Add(schoolSubject);
                return Ok(schoolMSEntities.SaveChanges());
            }
        }

        //Class Subject
        [Route("api/SaveClassSubject")]
        [HttpPost]
        public IHttpActionResult SaveClassSubject(ClassSubject classSubject)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                schoolMSEntities.ClassSubjects.Add(classSubject);
                return Ok(schoolMSEntities.SaveChanges());
            }
        }
        [Route("api/GetClassSubject/{schoolId}/{classId}")]
        [HttpGet]
        public IHttpActionResult GetClassSubject(int schoolId, int classId)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {

                var item = schoolMSEntities.GetClassSubject(classId, schoolId).ToList();

                //var item = (from classSubject in schoolMSEntities.ClassSubjects
                //            join subjectMaster in schoolMSEntities.SubjectsMasters
                //            on classSubject.SubjectId equals subjectMaster.SubjectID
                //            join classes in schoolMSEntities.Classes
                //            on classSubject.ClassId equals classes.ClassID
                //            where classSubject.ClassId == classId
                //            select new
                //            {
                //                //ClassSubjectId = classSubject.ClassSubjectId,
                //                // ClassId = classes.ClassID,
                //                //ClassName = classes.ClassName,
                //                SubjectId = subjectMaster.SubjectID,
                //                SubjectName = subjectMaster.Subjectname,
                //            });

                //var queryable = (from subjectMaster in schoolMSEntities.SubjectsMasters
                //                 join classSubject in schoolMSEntities.ClassSubjects
                //                 on subjectMaster.SubjectID equals classSubject.SubjectId into temp
                //                 from t in temp.DefaultIfEmpty()
                //                 where t.ClassId == classId
                //                 select new
                //                 {
                //                     //ClassSubjectId = t.ClassSubjectId,
                //                     //ClassId = classes.ClassID,
                //                     //ClassName = classes.ClassName,
                //                     SubjectId = subjectMaster.SubjectID,
                //                     SubjectName = subjectMaster.Subjectname,
                //                 });

                //var a = item.Union(queryable).Distinct().ToList();
                //return Ok(item);
                return Ok(item);

            }
        }

    }
}

