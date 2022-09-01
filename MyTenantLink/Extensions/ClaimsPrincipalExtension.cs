﻿using System.Linq;
using System.Security.Claims;

namespace MyTenantLink.Extensions {
  public static class ClaimsPrincipalExtension {
    public static string? FirstName(this ClaimsPrincipal principal) {
      var firstName = principal.Claims.FirstOrDefault(c => c.Type == "FirstName");
      return firstName?.Value;
    }

    public static string? LastName(this ClaimsPrincipal principal) {
      var lastName = principal.Claims.FirstOrDefault(c => c.Type == "LastName");
      return lastName?.Value;
    }
  }
}
