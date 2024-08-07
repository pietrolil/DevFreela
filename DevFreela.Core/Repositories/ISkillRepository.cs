﻿using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<SkillDTO>> GetAllAsync();

        Task AddSkillFromProjet(Project project);
    }
}
