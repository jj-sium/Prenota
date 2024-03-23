using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ghinelli.prenota._5h.Models;

namespace ghinelli.prenota._5h.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private static List<Utente> Utenti = new List<Utente>();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Prenota()
    {
        return View();
    }

    public IActionResult Prenotazioni()
    {
        string? nomeUtente = HttpContext.Session.GetString("NomeUtente");
        if (string.IsNullOrEmpty(nomeUtente))
            return Redirect("\\home\\index");
        dbContext db = new dbContext();
        return View(db);
    }
    [HttpPost]
    public IActionResult Prenotato( Utente u )
    {
        dbContext db = new dbContext();
        db.Utenti.Add(u);
        db.SaveChanges();
        return View(u);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
