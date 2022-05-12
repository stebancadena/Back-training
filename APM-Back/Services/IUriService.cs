using APM_Back.Models;
using System;

namespace APM_Back.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
