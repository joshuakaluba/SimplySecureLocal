using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.Models.Static;
using SimplySecureLocal.Data.Services;

namespace SimplySecureLocal.Web.Controllers
{
    [Route("/")]
    [ApiController]
    public sealed class HomeController : Controller<HomeController>
    {
        public HomeController(ILogger<HomeController> logger)
        : base(logger)
        {
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var backendStatus = await BackendAvailabilityService.DetermineAvailability();

                const string successMessage 
                    = @"<div class='alert alert-success' role='alert'>
                          <p class='text-center'> Backend is online!</p>
                        </div>";

                const string errorMessage 
                    = @"<div class='alert alert-danger' role='alert'>
                          <p class='text-center'> Unable to connect to backend</p>
                        </div>";

                var html = @" <!doctype html>
                        <html lang='en'>
                          <head>
                            <!-- Required meta tags -->
                            <meta charset='utf-8'>
                            <meta name='viewport' content='width=device-width, initial-scale=1, shrink-to-fit=no'>
                            <link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css'>
                            <title>SimplySecureLocal Web</title>
                          </head>
                          <body>
                            <div class='container'>
                                <h1 class='text-center' style='padding-top:150px;'>The SimplySecure local server is running!</h1>

                                <p class='text-center'> Backend: <a href='" + ApplicationConfig.BackendHost + "'>" + ApplicationConfig.BackendHost + @"</a></p>

                                <div class='row justify-content-center'>

                                    <div class='col-md-7'>"
                                        + (backendStatus ? successMessage : errorMessage) +
                                    @"</div>

                                </div>
                            </div>
                            <script src='https://code.jquery.com/jquery-3.3.1.slim.min.js'></script>
                            <script src='https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js'></script>
                            <script src='https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js'></script>
                          </body>
                        </html>";

                return Content(html, "text/html", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);

                return BadRequest(new ErrorResponse(ex));
            }
        }
    }
}