﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.DTO.ResponseDTO
{
    public class CourseRequirementResponse
    {
        public Guid Id { get; set; }
        public List<Guid> IdRequirements { get; set; }
    }
}
