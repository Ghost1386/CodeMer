﻿using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO.AuthDto;
using CodeMer.Models.Models;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace CodeMer.BusinessLogic.Services;

public class EmailService : IEmailService
{
    private const string EmailName = "PolessUp-CodeMer";
    private const string RegistrationType = "Регистрация";
    private const string ResetPasswordType = "Сброс пароля";
    private readonly string? _emailAddress;
    private readonly string? _emailPassword;
    private const string Host = "smtp.gmail.com";

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
            UserEmail = registrationUserDto.Email,
            Type = RegistrationType,
            Body = bodyBuilder,
        };

        var isSanded = await SendEmail(email);

        return isSanded;
    }
    
    public async Task<bool> ResetPasswordBody(ResetPasswordUserDto resetPasswordUserDto, string password)
    {
        var bodyBuilder = new BodyBuilder
        {
            TextBody = $"Ваш новый пароль для авторизации на сайте CodeMer\n" +
                       $"{password}"
        };
        
        var email = new Email
        {
            UserEmail = resetPasswordUserDto.Email,
            Type = ResetPasswordType,
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

            message.From.Add(new MailboxAddress(EmailName, _emailAddress));
            message.To.Add(new MailboxAddress("", email.UserEmail));
            message.Subject = email.Subject;

            message.Body = email.Body.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(Host, 465, false);
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