using Microsoft.AspNetCore.Mvc;
using BEdotnetdrive.Models;

namespace BEdotnetdrive.Controllers;

[ApiController]
[Route("api/driver")]
public class DriverController : ControllerBase
{

    //Entities object
    public readonly DriverdbContext DrivDB;

    public DriverController(DriverdbContext Drivdb)
    {
        this.DrivDB=Drivdb;
    }

    //Display all Drivers  from db
    [HttpGet("GetAllDrivers")]

    public IQueryable<Driverapply> GetAllDrivers()
    {
        try{
            return DrivDB.Driverapplies;
        }
        catch(System.Exception)
        {
            throw;
        }
        
    }
    
    //To add the registration detail to the DB
    [HttpPost("InsertDriver")]
    
    public object InsertDriver(ApplyForm regobj)
    {
        try{
            Driverapply dl = new Driverapply();
            if(dl.Id==0)
            {
                dl.Firstname=regobj.RegFirstname;
                dl.Lastname=regobj.RegLastname;
                dl.Email=regobj.RegEmail;
                dl.LicenseNo=regobj.RegLicenseNo;
                dl.WorkExperience=regobj.RegWorkExperience;
                dl.DriverAddress=regobj.RegDriverAddress;
                dl.OwnorRent=regobj.RegOwnorRent;
                

                //Add
                DrivDB.Driverapplies.Add(dl);

                //Save it in Database
                DrivDB.SaveChanges();

                return new Response{Status="Success", Message="Driver Added!"};
            }

        }
        catch(System.Exception)
        {
            throw;  
        }
        return new Response{Status="Error", Message="Invalid Information!"};
    }

    // [HttpPost("Login")]

    // public IActionResult LoginCheck(Login log)
    // {
        
    //     var logindetail = DrivDB.Driverapplies.Where(x=>x.DriverEmail.Equals(log.DriverEmail)&&x.DriverPassword.Equals(log.DriverPassword)).FirstOrDefault();
    //     if(logindetail == null)
    //     {
    //     return Ok(new Response{Status="Verified",Message="Welcome User!."});
        
    //     }        
    //     else{
    //     return Ok(new Response{Status="NotValid",Message="Invalid Credentials"});    
    //     }
    // }
    
    [HttpDelete("DeleteDriverDetails/{uid}")]
    public IActionResult DeleteDriver(int uid)
    {
        string message = "";
            var user = this.DrivDB.Driverapplies.Find(uid);
            if (user == null)
            {
                return NotFound();
            }

            this.DrivDB.Driverapplies.Remove(user);
            int result = this.DrivDB.SaveChanges();
            if (result > 0)
            {
                message = "User has been successfully deleted";
            }
            else
            {
                message = "failed";
            }

            return Ok(message);
        }
       
    //     [HttpPost("InsertDriverDetails")]
    // public IActionResult CreateUser(Driverapply newuser)
    // {
    //         string message = ""; 
    //             try
    //             {
    //                 this.DrivDB.Driverapplies.Add(newuser);
    //                 int result = this.DrivDB.SaveChanges();
    //                 if (result > 0)
    //                 {
    //                     message = "User has been sussfully added";
    //                 }
    //                 else
    //                 {
    //                     message = "failed";
    //                 }
    //             }
    //             catch (Exception)
    //             {
    //                 throw;
    //             }
        
    //         return Ok(message);
            
    // }

}
