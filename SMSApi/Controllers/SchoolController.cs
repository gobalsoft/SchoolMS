﻿using SchoolMSDataLayer;
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
        [Route("api/SaveSchoolClass")]
        [HttpPost]
        //Save Class
        public IHttpActionResult SaveSchoolClass(SchoolClass schoolClass)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                schoolMSEntities.SchoolClasses.Add(schoolClass);
                return Ok(schoolMSEntities.SaveChanges());
            }
        }


        [Route("api/GetAllSubject/{schoolId}")]
        [HttpGet]
        public IHttpActionResult GetAllSubject(int schoolId)
        {
            using (var schoolMSEntities = new SchoolMSEntities())
            {
                return Ok(schoolMSEntities.SchoolSubjects.Where(x => x.Schoolid == schoolId).ToList());
            }
        }
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

                ClassSubjectTemp classSubjectTemp = new ClassSubjectTemp();

                List<ClassSubjectTemp> classSubjectTempslist = new List<ClassSubjectTemp>();

                foreach (var temp in item.ToList())
                {
                    classSubjectTempslist.Add(new ClassSubjectTemp
                    {
                        SubjectName = temp.SubjectName,
                        SubjectID = temp.SubjectID,
                        IsSelect = temp.IsSelected
                    });
                }

                classSubjectTempslist.ToList().Where(y => y.IsSelect == "1").ToList().ForEach(x => x.IsSelected = true);
                classSubjectTempslist.ToList().Where(y => y.IsSelect == "0").ToList().ForEach(x => x.IsSelected = false);

                return Ok(classSubjectTempslist);
            }
        }

    }

    public class ClassSubjectTemp
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string IsSelect { get; set; }
        public bool IsSelected { get; set; }
    }
}

