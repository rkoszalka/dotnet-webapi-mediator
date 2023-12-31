﻿using Koszalka.Application.Repositories;
using Koszalka.Domain.Entities;
using Koszalka.Persistence.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koszalka.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Save(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public int Delete(ToDo todo)
        {
            _context.Attach(todo);
            _context.Remove(todo);
            return _context.SaveChanges();
        }

        public int Update(ToDo toDo)
        {
            _context.Update(toDo);
            return _context.SaveChanges();
        }
    }
}
