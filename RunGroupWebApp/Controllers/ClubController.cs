using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interface;
using RunGroupWebApp.Models;
using RunGroupWebApp.ViewModels;

namespace RunGroupWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IClubRepository _clubRepository;
        private readonly IPhotoService _photoService;


        //database'e erişmemizi sağlayan yapı
        public ClubController(ApplicationDBContext context,IClubRepository clubRepository,IPhotoService photoService)
        {
            this._context = context;

            //club repo eklendikten sonra aslında context e gerek kalmıyor parametrelerden baslamak üzere silinebilir.
            _clubRepository = clubRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            //Bir clubtan daha fazla getiriyorsak o zaman modelde belirtiyoruz????
            var clubs =  await _clubRepository.GetAll();
            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            //include bir tabloyla diğer tabloyu bağlamaya yarıyor. club içinde adres olsada adres tablosuna erişebilmek
            //için Include kullanıyoruz
            //YÖNTEM 1
            //Club club = _context.Clubs.Include(a=>a.Address).FirstOrDefault(a => a.ID == id);
            //YÖNTEM 2
            Club club =  await _clubRepository.GetByIDAsync(id);
            return View(club);
        }

        public IActionResult AddClub()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddClub(CreateClubViewModel clubViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoSync(clubViewModel.Image);
                var club = new Club
                {
                    Title = clubViewModel.Title,
                    Description = clubViewModel.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        City = clubViewModel.Address.City,
                        State = clubViewModel.Address.State,
                        Street = clubViewModel.Address.Street
                    }

                };
                _clubRepository.Add(club);
            return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("","Photo upload failed!");
            }
            return View(clubViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var club = await _clubRepository.GetByIDAsync(id);
            if (club == null)
            {
                return View("Error");
            }
            var clubVm = new EditClubViewModel
            {
                Title = club.Title,
                Description = club.Description,
                Address = club.Address,
                AddressID = club.AddressID,
                Url = club.Image,
                ClubCategory = club.ClubCategory,

            };
            return View(clubVm);
        }

        public async Task<IActionResult> Edit(int id , CreateClubViewModel clubViewModel)
        {
            return null;
        }
    }
}
