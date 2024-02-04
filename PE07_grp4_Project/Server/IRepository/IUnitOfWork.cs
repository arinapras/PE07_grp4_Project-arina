using Microsoft.AspNetCore.Http;
using PE07_grp4_Project.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE07_grp4_Project.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Event> Events { get; }
        IGenericRepository<Organiser> Organisers { get; }
    }
}