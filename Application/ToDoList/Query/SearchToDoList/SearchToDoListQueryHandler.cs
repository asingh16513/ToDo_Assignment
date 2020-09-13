using Application.Helper;
using Application.Interface;
using Domain.Models;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoList.Query.SearchToDoList
{
    public class SearchToDoListQueryHandler : IRequestHandler<SearchToDoListQuery, List<ToDoListExt>>
    {
        private readonly IUserManager _userAccessor;
        public SearchToDoListQueryHandler(IUserManager userAccessor)
        {
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        }
        public async Task<List<ToDoListExt>> Handle(SearchToDoListQuery request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<IToDoListDbManager>();
            return await db.SearchToDoList(_userAccessor.GetUserId(), request.SearchFilter.SearchString, request.SearchFilter.PageNumber,
                request.SearchFilter.PageSize);

        }
    }
}
