using Application.Contracts.User;
using Application.Features.Categories.Queries.GetCategoryDetails;
using Application.Features.Users.Commands.UpdateUsersPassword;
using DbContextL;
using Domian;
using Dtos.Account;
using Dtos.EmailServices;
using Dtos.UserEmailOption;
using Dtos.Users;
using FinalProjectAPI.helper;
using InfraStructure;
using InfraStructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace FinalProjectAPI.Controllers//.User.UserAccount
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;
        private readonly Context _context;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly Jwt _jwt;
        public UserAccountController(IUserAccountRepository userRepository, IMediator mediator, UserManager<User> userManager, IEmailService emailService, IConfiguration configuration,Context context, Jwt jwt)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _userManager = userManager;
            _emailService = emailService;
            _configuration = configuration;
            _context = context;
            _jwt = jwt;
        }
        [HttpGet("asd")]
        public async Task<IActionResult> GetPointsUserById([FromQuery] int UserId)
        {
            int collection = 0;
            var res= _context.Points.Where(a=>a.UserId== UserId);
            foreach (var item in res)
            {
                collection+= item.Collection;
            }
            return Ok(collection);
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return Ok();

        }
        [HttpPost("Register")]
      //  [ValidateAntiForgeryToken]

        public async Task<IActionResult> SigUP([FromBody] RegistrationModel registrationModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userRepository.Registration(registrationModel);

            
            if (result.IsAuthenticated)
            {
                var user = await _userManager.FindByEmailAsync(registrationModel.Email);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user!);
                user!.ReferralCode = GenerateRandomCode();
                if (!string.IsNullOrEmpty(registrationModel.UserReferralCode))
                {
                    var oldUser = await _context.Users.FirstOrDefaultAsync(u => u.ReferralCode == registrationModel.UserReferralCode);
                    if (oldUser != null)
                    {
                        ReferalUserCode referalUserCode = new ReferalUserCode();
                        referalUserCode.UserReralold = oldUser.Id;
                        referalUserCode.UserReralnew=user.Id;
                        await _context.referalUserCodes.AddAsync(referalUserCode);
                        user.UrlReferralCode = $"https://anglur1.mize.com.sa/register/{user.ReferralCode}";
                        await _context.SaveChangesAsync();

                        var pointadd = await _context.Points.FirstOrDefaultAsync(a => a.UserId == oldUser.Id);
                        pointadd!.Collection += 10;
                        await _context.SaveChangesAsync();
                    }
                }
                _context.SaveChanges();

                Points point = new Points();
                point.UserId = user!.Id;
                point.Collection = 6;
                _context.Points.Add(point);
                _context.SaveChanges();

                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }

        [Authorize]
        [HttpGet("GetCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
              
                var email = HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var result = await _userRepository.GetCurrentUser(email);

                if (!result.IsAuthenticated)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public IActionResult LogIN()
        {
            return Ok();
        }

        [HttpPost("Login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIN([FromBody] LoginModel loginModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userRepository.Login(loginModel);

                if (!result.IsAuthenticated)
                    return BadRequest(result.Message);

                return Ok(result);

            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return StatusCode(500, "Internal Server Error");
            }

        }
        
        [HttpPost("ChangePassword")]
      //  [ValidateAntiForgeryToken]
        public async Task<ChangrPasswordModel> ChangePassword([FromBody] UpdateUsersPasswordCommandQuery query)
        {
            if (!ModelState.IsValid)
                return new ChangrPasswordModel { Result="لقد حدث خطا ما حاول مره اخرى" };

            var result = await _mediator.Send(query);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
                return new ChangrPasswordModel { Result = "لقد حدث خطا ما حاول مره اخرى" };

            }
            return new ChangrPasswordModel { Result = "تم تعديل الرقم السرى بنجاح" };


        }

        [HttpPost]
     //   [ValidateAntiForgeryToken]
        public async Task<IActionResult> logOut()
        {
            _userRepository.logout();
            return RedirectToAction(nameof(LogIN));
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(int id, string token)
        {

            if (id != null && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(' ', '+');
                var result = await _userManager.ConfirmEmailAsync(await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id), token);
                if (result.Succeeded)
                {
                    //return RedirectToAction(nameof(LogIN));
                    // ViewBag.ISSuccess = true;
                    return Ok("Email Comfirm Sucessfully");
                }
            }

            return BadRequest("Email Comfirm Not Sucessfully");
        }
    
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return Ok();
        }
        [HttpPost("ForgotPassword")]
    //    [ValidateAntiForgeryToken]
        public async Task<ForgotPasswordModelResult> ForgotPassword([FromBody] ForgotPasswordModel model)//([Required]string Email)
        {
            if (ModelState.IsValid)
            {
                // code here
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    if (!string.IsNullOrEmpty(token))
                    {
                        await SendForgotPasswordEmail(user,token);
                        
                        return new ForgotPasswordModelResult { Result = $"Password Changed Request Is Sent On Email {user.Email}.Please Open Your Email & Click The Link  " };
                       // return Ok($);
                    }
                }


            }

            return new ForgotPasswordModelResult { Result = "Can not Send Link To Email.Plase Try Again" };
                ;
        }

        [HttpGet("reset-password")]
        public IActionResult ResetPassword(int id, string token)
        {
            /////
            ResetPasswordModel resetPasswordModel = new ResetPasswordModel
            {
                Token = token,
                UserId = id
            };
            return Ok(resetPasswordModel);

        }

        [HttpPost("reset-password")]

        public async Task<ResetPassWordResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                model.Token = model.Token.Replace(' ', '+');
                var result = await _userManager.ResetPasswordAsync(await _userManager.Users.FirstOrDefaultAsync(u => u.Id == model.UserId), model.Token, model.NewPassword);
                if (result.Succeeded)
                {

                    return new ResetPassWordResult {Result="Password has Been Changed" ,IsSuccess=true};//////
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return new ResetPassWordResult { Result = "Password has not Been Changed", IsSuccess = false };//////

        }
        private async Task SendEmailConfirmationEmail(User user, string token1)
        {
            // string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            //string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "UserAccount", new { id = user.Id, token = token1 }, Request.Scheme);

            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email! },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.UserName!),
                   new KeyValuePair<string, string>("{{Link}}",confirmationLink!)
                       // string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };

            await _emailService.SendEmailForEmailConfirmation(options);
        }
        private async Task SendForgotPasswordEmail(User user, string token1)
        {
           // var ForgotPasswordLink = Url.Action(nameof(ResetPassword), "UserAccount", new { id = user.Id, token = token1 }, Request.Scheme);
            string linkforget = $"https://anglur1.mize.com.sa/RestPassword?id={user.Id}&token={token1}";
            EmailSender emailSender = new EmailSender();
            List<string> ccEmails = new List<string>();
            StringBuilder bodySB = new StringBuilder();
            bodySB.Append($"<div dir='rtl'>");
            bodySB.Append($"<p style='color:red'><a href='https://mize.com.sa' dir='rtl'>مراكز مايز لصيانة السيارات</a></p>");
            bodySB.Append($"<p>عزيزى / عزيزتى <b style='color:red'>{user.UserName}</p>");
            bodySB.Append($"<p>لتغيير الرقم السرى إضغط على الرابط التالى</p>"); 
            bodySB.Append($"<p>{linkforget}</p>");
            bodySB.Append($"</div>");

            ccEmails.Add("");
            emailSender.SendEmail(user!.Email!, ccEmails,"تغيير الرقم السرى مراكز مايز لصيانة السيارات", bodySB);

        }
        // إضافة هذه الوظيفة لإنشاء رمز عشوائي
        private string GenerateRandomCode()
        {
            // يمكنك تخصيص هذه الوظيفة حسب احتياجاتك
            return Guid.NewGuid().ToString().Substring(0, 8);
        }
      
    }
}
