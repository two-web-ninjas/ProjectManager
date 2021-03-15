using ProjectManager.Core.Entity;
using ProjectManager.Web.WebApiModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Web.Identities
{
    public interface IJwtProvider
    {
        JwtResponse GetJwtToken(User user);
    }
}
