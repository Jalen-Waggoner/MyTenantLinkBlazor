using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;

namespace MyTenantLink.Services
{
    public static class EmailSenderExtensions
  {
    public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
    {
      return emailSender.SendEmailAsync(email, "Confirm your email",
          $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(link)}'>clicking here</a>.");
    }

    public static Task SendResetPasswordAsync(this IEmailSender emailSender, string email, string callbackUrl)
    {
      return emailSender.SendEmailAsync(email, "Reset Password",
          $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
    }

    public static Task SendEmailInviteAsync(this IEmailSender emailSender, string email, string link)
    {
      return emailSender.SendEmailAsync(email, "Setup Your Account ",
          $"You have been invited setup a Kirby Risk Service Trac account <a href='{HtmlEncoder.Default.Encode(link)}'>clicking here</a>.");
    }

  }
}
