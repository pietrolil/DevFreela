﻿using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;
        private readonly DevFreelaDbContext _dbContext;
        public SkillRepository(IConfiguration configuration, DevFreelaDbContext context)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
            _dbContext = context;
        }

		public async Task AddSkillFromProjet(Project project)
		{
			var words = project.Description.Split(' ');
            var length = words.Length;

            var skill = $"{project.Id} - {words[length - 1]}";

            await _dbContext.Skills.AddAsync(new Skill(skill));
		}

		public async Task<List<SkillDTO>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Description FROM Skills";

                var skills = await sqlConnection.QueryAsync<SkillDTO>(script);

                return skills.ToList();
            }

            // COM EF CORE
            //var skills = _dbContext.Skills;

            //var skillsViewModel = skills
            //    .Select(s => new SkillViewModel(s.Id, s.Description))
            //    .ToList();

            //return skillsViewModel;
        }
    }
}
