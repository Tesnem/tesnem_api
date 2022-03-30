﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Exceptions;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;

namespace Tesnem.Api.Data.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public EnrollmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Student> AddClasses(string enrollmentNumber, List<Guid> newClassesIds)
        {
            var toUpdate = _appDbContext.Students.FirstOrDefault(y => y.Enrollment.EnrollmentNumber == enrollmentNumber);
            if (toUpdate != null)
            {
                List<Class> newClasses = new List<Class>();
                foreach (var newClassId in newClassesIds)
                {
                    var newClass = _appDbContext.Classes.FirstOrDefault(y => y.Id == newClassId);
                    newClasses.Add(newClass);
                }
                toUpdate.Classes = (List<Class>)toUpdate.Classes.Concat(newClasses);
                var res =_appDbContext.Update(toUpdate);
            }
            else
                throw new NotFoundException(ExceptionMessages.EnrollmentNotFoundMessage, enrollmentNumber);
            return toUpdate;
        }

        public async Task<Enrollment> AddEnrollment(Enrollment enrollment)
        {   
            var resp = await _appDbContext.Enrollments.AddAsync(enrollment);
            await _appDbContext.SaveChangesAsync();
            return resp.Entity;
        }


        public async Task DeleteEnrollment(Guid id)
        {
            var delete = _appDbContext.Enrollments.FirstOrDefault(x => x.Id == id);
            if (delete != null)
                _appDbContext.Enrollments.Remove(delete);
            else
                throw new NotFoundException(ExceptionMessages.EnrollmentNotFoundMessage, id);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Enrollment> GetEnrollmentById(Guid id)
        {
            var enrollment = _appDbContext.Enrollments.FirstOrDefault(x => x.Id == id);
            return enrollment;
        }

        public async Task<Enrollment> UpdateEnrollment(Guid id, Enrollment enrollment)
        {
            var toUpdate = _appDbContext.Enrollments.FirstOrDefault(y => y.Id == id);
            if (toUpdate != null)
                _appDbContext.Update(enrollment);
            else
                throw new NotFoundException(ExceptionMessages.EnrollmentNotFoundMessage, id);
            return enrollment;
        }
    }
}
