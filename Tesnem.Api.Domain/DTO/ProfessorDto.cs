﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.DTO
{
    public class ProfessorDto
    {
        public string Name { get; set; }
        public PersonalData Data { get; set; }
    }
}
