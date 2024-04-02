using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myproject.Models;
using Microsoft.Data.SqlClient;

namespace myproject.Controllers;

public class HomeController : Controller
{

    SqlConnection con=new SqlConnection();
    SqlCommand com=new SqlCommand();
    SqlDataReader? dr;


    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Companies()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    void ConnectionString(){
         con.ConnectionString="data source=192.168.1.240\\SQLEXPRESS; database=cad_jp; user ID=CADBATCH01; password=CAD@123pass; TrustServerCertificate=True;";
    
    }
[HttpPost]
 
    public IActionResult VerifyLogin(LoginModel lmodel){
        ConnectionString();
        con.Open();
        com.Connection=con;
        com.CommandText="SELECT * FROM jp_login where Email='"+lmodel.Email+"'and Password='"+lmodel.Password+"'";
        dr=com.ExecuteReader();

        if (dr.Read()){
            con.Close();
            return View("Create");
        }
        else{
              con.Close();
             return View("Error");
        }
    }
  [HttpGet]
     public IActionResult Register()
    {
        return View();
    }


    
    [HttpPost]
public IActionResult RegisterDB(RegisterModel rmodel)
{ 
    
       ConnectionString();
        con.Open();
         com.Connection=con;
         com.CommandText="insert into jp_reg1(First_Name,Middle_Name , Last_Name,Email,Phn_num,DOB,Location,Qualification) values (@FirstName,@MiddleName,@LastName,@Email,@PhnNumber,@DOB, @Location,@Qualification); insert into jp_Login("Email)";
        {
            com.Parameters.AddWithValue("@FirstName", rmodel.FirstName); // Fixing error: 'FullName' does not exist
            com.Parameters.AddWithValue("@MiddleName", rmodel.MiddleName); // Fixing error: 'UserName' does not exist
            com.Parameters.AddWithValue("@LastName", rmodel.LastName);
            com.Parameters.AddWithValue("@Email", rmodel.Email); // Fixing error: 'Email' does not exist
            com.Parameters.AddWithValue("@PhnNumber", rmodel.PhnNumber); // Fixing error: 'ContactNumber' does not exist
            com.Parameters.AddWithValue("@DOB", rmodel.DOB);
            com.Parameters.AddWithValue("@Location", rmodel.Location);
            // com.Parameters.AddWithValue("@Gender", rmodel.Gender); 
            com.Parameters.AddWithValue("@Qualification", rmodel.Qualification); // Fixing error: 'Password' does not exist
            

            int rowAffected = com.ExecuteNonQuery();
            if(rowAffected > 0)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View("Error");
            }
        }
    }
}

    //  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error();
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }

