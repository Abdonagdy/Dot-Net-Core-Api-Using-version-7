using DbContextL;
using Domian;
using Dtos.EmailServices;
using Dtos.Reservation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using FinalProjectAPI.helper;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResrvationController : ControllerBase
    {
        private readonly Context _Context;
        private readonly UserManager<User> UserManager;
        private readonly IConfiguration _Configuration;
             

       // var _user = await UserManager.FindByEmailAsync(loginModel.Email);

        public ResrvationController(Context context, UserManager<User> _userManager ,IConfiguration configuration)
        {
            _Context = context;
             UserManager = _userManager;
            _Configuration = configuration;
            _Configuration = configuration;
      
        }

        [HttpGet("GetAllMadina")]
        public async Task<IActionResult> GetAllMadina()
        {
            try
            {

                return Ok(_Context.Madinas.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("GetAllBranshs1")]
        public async Task<IActionResult> GetAllBranshs1()
        {
            try
            {
                return Ok(_Context.branshes.Include(a => a.appointmentReversions).Where(a=>a.IsAvctive==true).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("GetAllBranshs")]
        public async Task <IActionResult> GetAllBranshs([FromQuery] string madinaid)
        {
            try
            {
                var b =  await _Context.Madinas.Include(b => b.Madins).Where(a=>a.CityName==madinaid).FirstOrDefaultAsync();
                List<Bransh>  branshes = new List<Bransh>();
                foreach (var item in b!.Madins)
                {
                    if(item.IsAvctive == true)
                    {
                        branshes.Add(item);
                    }
                    
                }
                // return Ok(_Context.branshes.Include(a=>a.appointmentReversions).ToList());
                return Ok(branshes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("GetAllres")]
        public async Task<IActionResult> GetAllres()
        {
            try
            {
                return Ok(_Context.appointmentReversions.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("Bransh")]
        public async Task<Bransh> Bransh([FromQuery] long brannum)
        {
            try
            {
                Bransh r =await _Context.branshes.FirstOrDefaultAsync(a => a.brannum == brannum);
                return r!;
            }
            catch (Exception ex)
            {
                return null!;
            }

        }

        [HttpGet("BranshId")]
        public async Task<List<AppointmentReversion>> BranshReservationId([FromQuery] long brannum)
        {
            try
            {
                var r = await _Context.appointmentReversions.Where(a=>a.braId==brannum).ToListAsync();
                return r;
            }
            catch (Exception ex)
            {
                return null!;
            }

        }

        [HttpGet("GetAllBransh")]
        public async Task<List<BranchMadina>> GetAllBransh()
        {
            try
            {
                var r = await _Context.Madinas.Include(a=>a.Madins).ToListAsync();

                List<BranchMadina> BranchMadina = new List<BranchMadina>();
                foreach (var item in r)
                {
                    foreach(var m in item.Madins)
                    {
                        BranchMadina.Add(new BranchMadina()
                        {
                            CityName = item.CityName,
                            Braname = m.Braname,
                            Location = m.Location,
                            From = m.From,
                            To = m.To,
                            Phone = m.Phone,
                        });
                    }
                    

                }
                return BranchMadina;
            }
            catch (Exception ex)
            {
                return null!;
            }

        }



        [HttpGet("GetAllresbyid")]
        public async Task<IActionResult> GetAllresbyid([FromQuery] long BranshId, [FromQuery] string dateTime , [FromQuery] string Maintaence)
        {
            try
            {

                var r = _Context.appointmentReversions.Where(b => b.braId == BranshId && b.Date==dateTime && b.Maintaence==Maintaence).ToList();

                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetAllresbydata")]
        public async Task<IActionResult> GetAllresbydata()
        {
            try
            {
                var r = _Context.appointmentReversions.ToList();
               
                //foreach (var item in r)
                //{

                //    if (TimeSpan.TryParse(item.tofromHours, out TimeSpan appointmentTime))
                //    {
                //        var currentTime = DateTime.Now.TimeOfDay;
                //        if (currentTime >= appointmentTime)
                //        {
                //            item.isav = false;
                //        }
                //    }
                //}
               // await _Context.SaveChangesAsync();
                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("Register")]
        public async Task<ReservationMinimalDto> CreateReversatopn(int resId , long branch, string mobile, string name,string email)
        {
            if (!ModelState.IsValid)
               return new ReservationMinimalDto { Message = "لقد تم حجز هذا الموعد من قبل شكرا لكم" }; ;

            try
            { 
                  
                var r = await _Context.appointmentReversions.FirstOrDefaultAsync(b => b.Id == resId);
                var bname = _Context.branshes.FirstOrDefault(b => b.brannum == r!.braId);

                if(r == null || r.isav==false) 
                {
                    return new ReservationMinimalDto { Message = "لقد تم حجز هذا الموعد من قبل شكرا لكم" };
                    
                }

                else {

                            
                           SendSmsReserveConfirmationToCustomer(mobile!, $"تم حجز موعد صيانة  \n رقم الموعد {r.revnumber} , {bname!.Braname} \n تاريخ : {r.Date} \n الوقت : {r.tofromHours}");
                            EmailSender emailSender = new EmailSender();
                            List<string> ccEmails = new List<string>();
                            StringBuilder bodySB = new StringBuilder();
                            bodySB.Append($"<div dir='rtl'>");
                            bodySB.Append($"<p style='color:red'><a href='https://mize.com.sa' dir='rtl'>مراكز مايز لصيانة السيارات</a></p>");
                            bodySB.Append($"<p>عزيزى / عزيزتى <b style='color:red'>{name}</p>");
                            bodySB.Append($"<p>رقم العميل : <b style='color:red'>{mobile}</p>");
                            bodySB.Append($"<p>تم حجز موعد صيانة برقم :<span style='color:red'> {r.revnumber}</span></p>");
                            bodySB.Append($"<p>نوع الصيانه : {r.Maintaence}</p>");
                            bodySB.Append($"<p>تاريخ : {r.Date}</p>");
                            bodySB.Append($"<p> الميعاد : {r.tofromHours}</p>");
                            bodySB.Append($"<p> الفرع : {bname!.Braname}</p>");


                    //   ccEmails.Add("customer.service@mize.sa");
                            ccEmails.Add("mizeservicecenter@gmail.com");
                            ccEmails.Add(bname.Email!);
                            emailSender.SendEmail(email!,ccEmails,"موعد صيانة مراكز مايز لصيانة السيارات", bodySB);


                            r.Email = email;
                            r.UserName=name;
                            r.PhoneNumber = mobile; 
                            r.isav = false;
                            await _Context.SaveChangesAsync();

                            return new ReservationMinimalDto { Message = "لقد تم حجز الموعد شكرا لكم",Name=name,Email=email,Revnumber=r.revnumber,TofromHours=r.tofromHours, Branshname = bname.Braname
                            };

                    
                }

            }
            catch (Exception ex) {

                return new ReservationMinimalDto { Message = "لقد تم حجز هذا الموعد من قبل شكرا لكم" }; 
            
            }
        }

        private void SendSmsReserveConfirmationToCustomer(string cusMobile, string smsBody)
        {
            string url = $"http://mshastra.com/sendurlcomma.aspx?user=20099206&pwd=Mize@388&senderid=20099206&CountryCode=+966&mobileno={cusMobile}&msgtext={smsBody}&smstype=0";
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(url);
            http.GetAsync(http.BaseAddress).Wait();
            Task.Delay(5000);
        }
    }
}