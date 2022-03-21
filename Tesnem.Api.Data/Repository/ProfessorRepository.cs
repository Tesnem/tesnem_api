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
    public class ProfessorRepository : IProfessorRepository

    {
        private readonly AppDbContext _appDbContext;
        public ProfessorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Professor> AddProfessor(Professor professor)
        {
            var resp = await _appDbContext.Professors.AddAsync(professor);
            await _appDbContext.SaveChangesAsync();
            return resp.Entity;
        }

        public async Task DeleteProfessor(string id)
        {
            var delete = _appDbContext.Professors.FirstOrDefault(x => x.Id == id);
            if (delete != null)
                _appDbContext.Professors.Remove(delete);
            else
                throw new ErrorException(new ErrorResponse { Message = "not found", StatusCode = 404 });
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Professor> GetProfessorById(string id)
        {
            var prof = _appDbContext.Professors.FirstOrDefault(x => x.Id == id);
            return prof;
        }

        public async Task<Professor> UpdateProfessor(string id, Professor professor)
        {
            var toUpdate = _appDbContext.Professors.FirstOrDefault(y => y.Id == id);
            if (toUpdate != null)
                _appDbContext.Update(professor);
            else
                throw new ErrorException(new ErrorResponse { Message = "not found", StatusCode = 404 });
            return professor;
        }
    }
}