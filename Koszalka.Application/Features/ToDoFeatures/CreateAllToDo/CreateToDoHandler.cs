﻿using AutoMapper;
using Koszalka.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Koszalka.Domain.Entities;


namespace Koszalka.Application.Features.ToDoFeatures.CreateToDoTask
{
    public sealed class CreateTodoHandler : IRequestHandler<CreateTodoRequest, CreateTodoResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;

        public CreateTodoHandler(IUnitOfWork unitOfWork, IToDoRepository toDoRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public async Task<CreateTodoResponse> Handle(CreateTodoRequest request, CancellationToken cancellationToken)
        {
            var toDo = _mapper.Map<ToDo>(request);
            _toDoRepository.Create(toDo);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CreateTodoResponse>(toDo);
        }
    }

}
