using Framebook.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Framebook.Business.Interfaces
{
    public interface IBusinessServiceGestaoAuth
    {
        ActionResult<dynamic> Add(RefreshToken obj);
    }
}
