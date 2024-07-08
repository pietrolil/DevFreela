﻿using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DevFreelaDbContext _context;
		private IDbContextTransaction _transaction;
        public UnitOfWork(
			DevFreelaDbContext dbContext,
			IProjectRepository projects,
			IUserRepository users,
			ISkillRepository skills
		)
        {
			_context = dbContext;
            Projects = projects;
			Users = users;
			Skills = skills;
        }

        public IProjectRepository Projects {  get;}

		public IUserRepository Users { get; }

		public ISkillRepository Skills { get; }

		public async Task BeginTransactionAsync()
		{
			_transaction = await _context.Database.BeginTransactionAsync();
		}

		public async Task CommitAsync()
		{
			try
			{
				await _transaction.CommitAsync();
			} 
			catch ( Exception ex)
			{
				await _transaction.RollbackAsync();
				throw ex;
			}
		}

		public async Task<int> CompleteAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			Dispose( true );
			GC.SuppressFinalize( this );
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_context.Dispose();
			}
		}
	}
}
