using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO.AuthDto;
using CodeMer.Models.Models;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace CodeMer.BusinessLogic.Services;

public class EmailService : IEmailService
{
    private const string RegistrationType = "Регистрация";
    private readonly string? _emailAddress;
    private readonly string? _emailPassword;
    private const string Host = "smtp.yandex.ru";

    public EmailService(IConfiguration configuration)
    {
        _emailAddress = configuration["Email:Address"];
        _emailPassword = configuration["Email:Password"];
    }

    public async Task<bool> RegistrationBody(RegistrationUserDto registrationUserDto, string password)
    {
        var bodyBuilder = new BodyBuilder
        {
            TextBody = $"{registrationUserDto.Name},\n" +
                       $"Ваш пароль для авторизации на сайте CodeMer\n" +
                       $"{password}"
        };
        
        var email = new Email
        {
            Type = RegistrationType,
            Body = bodyBuilder,
        };

        var isSanded = await SendEmail(email);

        return isSanded;
    }

    private async Task<bool> SendEmail(Email email)
    {
        try
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(email.Type, _emailAddress));
            message.To.Add(new MailboxAddress("", _emailAddress));
            message.Subject = email.Subject;

            message.Body = email.Body.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(Host, 587, false);
            await client.AuthenticateAsync(_emailAddress, _emailPassword);
            await client.SendAsync(message);

            await client.DisconnectAsync(true);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}