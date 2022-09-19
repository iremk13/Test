using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interface;
using RunGroupWebApp.Models;
using RunGroupWebApp.Repository;
using RunGroupWebApp.ViewModels;

namespace RunGroupWebApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IRaceRepository _raceRepository;
        private readonly IPhotoService _photoService;

        public RaceController(ApplicationDBContext context,IRaceRepository raceRepository,IPhotoService photoService)
        {
            this._context = context;
            this._raceRepository = raceRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            //YÖNTEM 1
            //var races = _context.Races.ToList();
            //YÖNTEM 2
            IEnumerable<Races> races = await _raceRepository.GetAll();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id)
        {
            //YÖNTEM 1
            //var race = _context.Races.Include(a => a.Address).FirstOrDefault(a => a.ID == id); //burada var yerine Races da gelebilir
            //YÖNTEM 2
            Races race = await _raceRepository.GetByIDAsync(id);
            return View(race);
        }
        public async Task<IActionResult> CreateRace()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRace(CreateRaceViewModel raceViewModel)
        {
            //validasyonlara göre string yerine int gönderdiğin zamanlarda kontrol ediyor
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoSync(raceViewModel.Image);
                var race = new Races
                {
                    Title = raceViewModel.Title,
                    Description = raceViewModel.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        City = raceViewModel.Address.City,
                        State = raceViewModel.Address.State,
                        Street = raceViewModel.Address.Street
                    }

                };
                _raceRepository.Add(race);
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed!");
            }
            return View(raceViewModel);
        }
    }
}
