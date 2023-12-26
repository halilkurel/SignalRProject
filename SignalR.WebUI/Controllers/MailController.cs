using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalR.WebUI.Dtos.MailDtos;

namespace SignalR.WebUI.Controllers
{
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(CreateMailDto dto)
		{
			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailboxAddress = new MailboxAddress("SignalR Rezervasyon", "halilkurel1@gmail.com");
			mimeMessage.From.Add(mailboxAddress);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", dto.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo);
			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody=dto.Body;
			mimeMessage.Body=bodyBuilder.ToMessageBody();

			mimeMessage.Subject=dto.Subject;

			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("halilkurel1@gmail.com", "naqs qhkx idxi pdrm");
			client.Send(mimeMessage);
			client.Disconnect(true);
			return RedirectToAction("Index","Category");
		}

	}
}
