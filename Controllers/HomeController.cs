using System;
using System.Diagnostics;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Videos.Data;
using Videos.Models;

namespace Videos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IVideoServices services;

    public HomeController(ILogger<HomeController> logger, IVideoServices services)
    {
        _logger = logger;
        this.services = services;
    }

    public IActionResult Index()
    {
        var videos = this.services.GetAll();
        return View(videos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Create(string link)
    { 
        var result = await this.services.Create(link);
        ModelState.Clear();
        return View("Index", result);
    }

    public async Task<IActionResult> Get(int Id)
    {
        var result = await this.services.Get(Id);
        return View("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await this.services.Delete(id);
        return View("Index", result);
    }
}
