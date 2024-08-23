using DbContextL;
using Domian;
using Dtos.Reservation;
using FinalProjectAPI.helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanganserviceController : ControllerBase
    {
        
        private readonly Context _dbContext;
        public SanganserviceController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllModelcar")]
        public IActionResult GetAllModelcar()
        {
            try
            {

                var r = _dbContext.CarModelsses.ToList();
                if (r != null)
                    return Ok(r);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllcarBymodel")]
        public IActionResult GetAllcarBymodel([FromQuery] int modelid)
        {
            try
            {

                var r = _dbContext.carNameshes.Where(a => a.carModelid == modelid).ToList();
                if (r != null)
                    return Ok(r);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllyear")]
        public IActionResult GetAllyear([FromQuery] int id)
        {
            try
            {

                var r = _dbContext.modelYearCars.Where(a => a.carid == id).ToList();
                if (r != null)
                    return Ok(r);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
           
        }


        [HttpGet("GetEngineType")]
        public IActionResult GetEngineType([FromQuery] int id)
        {
            try
            {

                var r = _dbContext.engineTypes.Where(a => a.ModelYearCarid == id).ToList();

                if (r != null)
                    return Ok(r);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

             }



        [HttpGet("GetAllserviceforcarbydis")]
        public IActionResult GetAllserviceforcar([FromQuery] int id , [FromQuery] int disid)
        {
            try
            {

                var r = _dbContext.carServices.Include(a => a.Prices).Where(a => a.carnameId == id && a.disServiceId == disid).ToList();
                if (r != null)
                    return Ok(r);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

               
        }

        [HttpGet("GetAllDistance")]
        public IActionResult GetAllDistance()
        {

            try
            {

                var r = _dbContext.DisstanceServices.ToList();

                if (r != null)
                    return Ok(r);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        // POST api/<SanganserviceController>
        [HttpPost("Add")]
        public async Task<ReservationMinimalDto> Add([FromBody] FinshedSangan value)
        {
            try
            {
                if (value == null)
                {
                    return new ReservationMinimalDto { Message = "لقد حدث خطا حاول مرة اخرى من فضلك" };
                }

              
                var availableAppointment = await FindAvailableAppointment(value.Region);
                if (availableAppointment == null)
                {
                    return new ReservationMinimalDto { Message = "لقد حدث خطا حاول مرة اخرى من فضلك" };
                }

                UpdateAppointment(availableAppointment, value);


                ConfirmSangan confirmSangan = CreateConfirmSangan(availableAppointment,value);

                await _dbContext.confirmSangans.AddAsync(confirmSangan);
                await _dbContext.SaveChangesAsync();

                var BR =await _dbContext.branshes.Where(a => a.brannum == value.Region).FirstOrDefaultAsync();

                SendSmsReserveConfirmationToCustomer(value.PhoneNumber!, $"تم حجز موعد صيانة رقم {availableAppointment.revnumber} , {BR!.Braname} \n تاريخ : {availableAppointment.Date} \n الوقت : {availableAppointment.tofromHours} \n اجمالى المبلغ : {value.Totalprice}");
               
                 SendConfirmationEmail(value.Email!, availableAppointment,value);

                return new ReservationMinimalDto
                {
                    Message = "لقد تم حجز الموعد شكرا لكم",
                    Name = availableAppointment.UserName,
                    Email = value.Email,
                    Revnumber = availableAppointment.revnumber,
                    TofromHours = availableAppointment.tofromHours,
                    Branshname = BR.Braname
                };
            }
            catch
            {
                return new ReservationMinimalDto { Message = "لقد حدث خطا حاول مرة اخرى من فضلك" };
            }
        }

        private ConfirmSangan CreateConfirmSangan(AppointmentReversion appointment, FinshedSangan value)
        {
            var model = _dbContext.CarModelsses.FirstOrDefault(a => a.id == value.Model);
            var car = _dbContext.carNameshes.FirstOrDefault(a => a.id == value.Car);
            var modelyear = _dbContext.modelYearCars.FirstOrDefault(a => a.id == value.Year);
            var distansce = _dbContext.DisstanceServices.FirstOrDefault(a => a.id == value.Distance);
            var engintype = _dbContext.engineTypes.FirstOrDefault(a => a.id == value.EngineType);
            var city = _dbContext.Madinas.FirstOrDefault(a => a.CityName == value.City);
            var regin = _dbContext.branshes.FirstOrDefault(a => a.brannum == value.Region);

           List<ServiceConfirmSangan> serviceConfirmSangans = new List<ServiceConfirmSangan>();

            foreach(var item in value.SelectedServices!)
            {
                serviceConfirmSangans.Add(new ServiceConfirmSangan { Name=item.Name,
                    
                   Prices= item.Prices.Select(a=>new PriceConfirmShangan { name=a.name , price=a.price,}).ToList()
                }
                
                );
            }

            var confirmSangan = new ConfirmSangan
            {
                Email = value.Email,
                PhoneNumber = value.PhoneNumber,
                Fname = value.Fname,
                Lname = value.Lname,
                Model =model!.Name,
                Year = modelyear!.YearNname,
                Distance = distansce!.name,
                City=city!.CityName,
                CarNamesh=car!.Name,
                Region = regin!.Braname,
                EngineType = engintype!.name,
                Totalprice=value.Totalprice,
                Tax=value.Tax,
                SelectedServices = serviceConfirmSangans,
                //AppointmentReversionid = appointment.Id  
            };

            return confirmSangan;
        }

        private async Task<AppointmentReversion> FindAvailableAppointment(long region)
        {
            var appointments = await _dbContext.appointmentReversions.ToListAsync();


            var currentDate = DateTime.Now;
            var futureDate = currentDate.AddDays(2);

            //var cur = currentDate.ToString("dd/MM/yyyy");
            //var fu= futureDate.ToString("dd/MM/yyyy");
          
            foreach (var appointment in appointments)
            {

                if (!string.IsNullOrEmpty(appointment.Date))
                {
                    if (DateTime.TryParse(appointment.Date, out DateTime parsedDate))
                    {
                                if (parsedDate.Date >= currentDate.Date
                                  && parsedDate.Date  >=  futureDate.Date
                                  && appointment.isav == true
                                  && appointment.Maintaence == "صيانة دورية"
                                  && appointment.braId == region)
                                {
                                    return appointment;
                                }

                    }
                    else
                    {
                        return null!;
                    }
                }
          
            }
            return null!;
       
        }


        private void UpdateAppointment(AppointmentReversion appointment, FinshedSangan value)
        {
            appointment.isav = false;
            appointment.Email = value.Email;
            appointment.UserName = $"{value.Fname} {value.Lname}";
            appointment.PhoneNumber = value.PhoneNumber;
        }

        
        private void SendConfirmationEmail(string email, AppointmentReversion appointment , FinshedSangan value)
        {
            var BR = _dbContext.branshes.Where(a=>a.brannum==value.Region).FirstOrDefault();

            EmailSender emailSender = new EmailSender();
            List<string> ccEmails = new List<string>();
            StringBuilder bodySB = new StringBuilder();
            bodySB.Append($"<div dir='rtl'>");
            bodySB.Append($"<p style='color:red'><a href='https://mize.com.sa' dir='rtl'>مراكز مايز لصيانة السيارات</a></p>");
            bodySB.Append($"<p>عزيزى / عزيزتى <b style='color:red'>{appointment.UserName}</p>");
            bodySB.Append($"<p>تم حجز موعد صيانة برقم :<span style='color:red'> {appointment.revnumber}</span></p>");
            bodySB.Append($"<p>نوع الصيانه : {appointment.Maintaence}</p>");
            bodySB.Append($"<p>تاريخ : {appointment.Date}</p>");
            bodySB.Append($"<p> الميعاد : {appointment.tofromHours}</p>");
            bodySB.Append($"<p> الفرع : {BR!.Braname}</p>");
            bodySB.Append($"<p> الاجمالى : {value.Totalprice}ريال سعودى</p>");


            //   ccEmails.Add("customer.service@mize.sa");
            ccEmails.Add("mizeservicecenter@gmail.com");
            ccEmails.Add("nagdnadgy2017@gmail.com");
            emailSender.SendEmail(value.Email!, ccEmails, "موعد صيانة مراكز مايز لصيانة السيارات", bodySB);
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
