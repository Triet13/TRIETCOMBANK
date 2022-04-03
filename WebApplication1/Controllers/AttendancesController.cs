using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers
{
    public class AttendancesController : ApiController
    {
        [Authorize]
        public class AttendancesController : ApiController
        {
            private ApplicationDbContext _dbContext;

            public object User { get; private set; }

            public AttendancesController()
            {
                _dbContext = new ApplicationDbContext();
            }
            [HttpPost]
            public IHttpActionResult Attend(AttendanceDto attendanceDto)
            {
                var userId = User.Identity.GetUserId();
                if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                    return BadRequest("The Attendance already exists!");
                var attendance = new Attendance
                {
                    CourseId = attendanceDto.CourseId,
                    AttendeeId = User.Identity.GetUserId()
                };

                _dbContext.Attendances.Add(attendance);
                _dbContext.SaveChanges();
                return Ok();
            }

            private IHttpActionResult Ok()
            {
                throw new NotImplementedException();
            }

            private IHttpActionResult BadRequest(string v)
            {
                throw new NotImplementedException();
            }
        }
    }