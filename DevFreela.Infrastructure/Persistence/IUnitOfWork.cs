﻿using DevFreela.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
	public interface IUnitOfWork
	{
		IProjectRepository Projects { get; }

		IUserRepository Users { get; }

		ISkillRepository Skills { get; }

		Task<int> CompleteAsync();

		Task BeginTransactionAsync();

		Task CommitAsync();
	}
}
