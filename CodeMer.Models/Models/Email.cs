using MimeKit;

namespace CodeMer.Models.Models;

public class Email
{
    public string Type { get; set; }

    public BodyBuilder Body { get; set; }

    public string Subject { get; set; }
}