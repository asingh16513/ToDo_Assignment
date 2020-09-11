﻿using Application.Helper;
using Application.Interface;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoItem.Query.GetToDoLists
{
    public class GetToDoListsQueryHandler : IRequestHandler<EmptyQuery<List<Domain.Models.ToDoListExt>>, List<Domain.Models.ToDoListExt>>
    {
        private readonly IUserManager _userAccessor;
        public GetToDoListsQueryHandler(IUserManager userAccessor)
        {
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        }
        public async Task<List<Domain.Models.ToDoListExt>> Handle(EmptyQuery<List<Domain.Models.ToDoListExt>> request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<IToDoList>();
            return await db.GetToDoList(_userAccessor.GetUserId());
        }
    }
}