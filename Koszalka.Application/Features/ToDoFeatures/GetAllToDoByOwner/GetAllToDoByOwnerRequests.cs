﻿using Koszalka.Application.Features.ToDoFeatures.GetAllTodo;
using Koszalka.Application.Features.ToDoResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Koszalka.Application.Features.ToDoFeatures.GetAllToDoByOwner
{
    public sealed record GetAllToDoByOwnerRequest : IRequest<List<RequestResponse>>
    {
        public  string Owner { get; set; }

        public GetAllToDoByOwnerRequest(string owner) { Owner = owner; }

        
    };

}
