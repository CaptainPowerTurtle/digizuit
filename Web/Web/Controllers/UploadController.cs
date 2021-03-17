using BookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingWeb.Service;

namespace BookingWeb.Controllers
{
    public class UploadController : Controller
    {
        [HttpGet]
        public IActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(File file)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                var rpcClient = new UploadService();
                await rpcClient.CallAsync(file);

                rpcClient.Close();
            }
            else
            {
                message = "Failed to create the product. Please try again";
            }
            return Ok();
        }
    }
}
