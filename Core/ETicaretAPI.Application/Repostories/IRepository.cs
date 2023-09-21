using System;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
	
namespace ETicaretAPI.Application.Repostories
{
	public interface IRepository<T> where T : BaseEntity
	{
		DbSet<T> Table { get; }
	}
}

