using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurveyTest.Business.Models.Data;
using SurveyTest.Business.Models;
using SurveyTest.Business.ViewModel;
using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using SurveyTest.Business.WebApp.Hubs;
using Microsoft.EntityFrameworkCore;

namespace SurveyTest.Controllers
{
    public class FormsController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IHubContext<SignalRHub> _hubContext;
        public FormsController(DataDbContext context, IHubContext<SignalRHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public IActionResult Index()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.AppUsers.Find(Guid.Parse(userId));
            var ls = _context.Forms.Where(x => x.IdUser == user).ToList();
            return View(ls);
        }
        [Route("tao-moi")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFormAsync(string questions, string nameVal, string desVal)
        {
            List<QuestionViewModel> questionList = JsonConvert.DeserializeObject<List<QuestionViewModel>>(questions);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Forms newRecord = new Forms()
            {
                Id = Guid.NewGuid(),
                Name = nameVal,
                Title = nameVal,
                Description = desVal,
                Publish = false,
                Type = 0,
                IdUser = _context.AppUsers.Find(Guid.Parse(userId)),
                IsActive = false,
                CreatedDate = DateTime.Now,
                CreatedTime = DateTime.Now,
                CreatedBy = userId,
                DeletedBy = "",
                IsDeleted = false,
                ModifiedBy = userId,
                ModifiedDate = DateTime.Now,
                ModifiedTime = DateTime.Now
            };
            await _context.Forms.AddAsync(newRecord);
            foreach (var item in questionList)
            {
                FormQuestion newQS = new FormQuestion()
                {

                    Id = Guid.NewGuid(),
                    IdForm = newRecord,
                    Order = item.Number,
                    Question = item.Question,
                    Description = item.DescriptionQuestion,
                    Title = item.NameQuestion,
                    IsActive = false,
                    CreatedDate = DateTime.Now,
                    CreatedTime = DateTime.Now,
                    CreatedBy = userId,
                    DeletedBy = "",
                    IsDeleted = false,
                    ModifiedBy = userId,
                    ModifiedDate = DateTime.Now,
                    ModifiedTime = DateTime.Now
                };
                await _context.FormQuestion.AddAsync(newQS);

                Tablet oneTable = _context.Tablet.Where(x => x.Type == item.Type).FirstOrDefault();
                FormTablet newFT = new FormTablet()
                {
                    Id = Guid.NewGuid(),

                    IdFormQuestion = newQS,
                    IdTablet = oneTable,
                    IsActive = false,
                    CreatedDate = DateTime.Now,
                    CreatedTime = DateTime.Now,
                    CreatedBy = userId,
                    DeletedBy = "",
                    IsDeleted = false,
                    ModifiedBy = userId,
                    ModifiedDate = DateTime.Now,
                    ModifiedTime = DateTime.Now
                };

                await _context.FormTablet.AddAsync(newFT);



            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("xem-thu/{id}")]
        public async Task<IActionResult> Preview(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.AppUsers.Find(Guid.Parse(userId));
            var ls = _context.Forms.Where(x => x.Id == id).FirstOrDefault();
            return View(ls);
        }

        [HttpGet]
        [Route("survey/{id}")]
        public async Task<IActionResult> Surveys(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.AppUsers.Find(Guid.Parse(userId));
            var ls = _context.Forms.Where(x => x.Id == id).FirstOrDefault();
            var check = _context.FormRequest.Where(x => x.IdForm == ls && x.IdUser == Guid.Parse(userId)).ToList();
            if (check.Count > 0)
            {
                return RedirectToAction("notification", "forms");
            }
            return View(ls);
        }

        [HttpPost]
        [Route("pushSurvey")]
        public async Task<IActionResult> PushSurvey(IFormCollection form)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.AppUsers.Find(Guid.Parse(userId));

            int numberCount = int.Parse(form["numberCount"]);
            Guid idForm = Guid.Parse(form["idForm"]);
            var check = _context.FormRequest.Where(x => x.IdForm == _context.Forms.Find(idForm) && x.IdUser == Guid.Parse(userId)).ToList();
            if (check.Count > 0)
            {
                return NotFound();
            }
            FormRequest newRecord = new FormRequest()
            {
                Id = Guid.NewGuid(),
                IdForm = _context.Forms.Find(idForm),
                IdUser = Guid.Parse(userId),
                IsActive = false,
                CreatedDate = DateTime.Now,
                CreatedTime = DateTime.Now,
                CreatedBy = userId,
                DeletedBy = "",
                IsDeleted = false,
                ModifiedBy = userId,
                ModifiedDate = DateTime.Now,
                ModifiedTime = DateTime.Now
            };
            _context.FormRequest.Add(newRecord);
            for (var i = 1; i <= numberCount; i++)
            {
                string data = form["name_" + i];
                var question = _context.FormQuestion.Where(x => x.Order == i && x.IdForm == _context.Forms.Find(idForm)).FirstOrDefault();
                FormAnswer newData = new FormAnswer()
                {
                    Id = Guid.NewGuid(),
                    IdUser = Guid.Parse(userId),
                    IdFormQuestion = question,
                    Answer = data,
                    IsActive = false,
                    CreatedDate = DateTime.Now,
                    CreatedTime = DateTime.Now,
                    CreatedBy = userId,
                    DeletedBy = "",
                    IsDeleted = false,
                    ModifiedBy = userId,
                    ModifiedDate = DateTime.Now,
                    ModifiedTime = DateTime.Now
                };
                _context.FormAnswer.Add(newData);
                FormRequestAnswer newData2 = new FormRequestAnswer()
                {
                    Id = Guid.NewGuid(),
                    IdFormAnswer = newData,
                    IdFormRequest = newRecord,
                    IsActive = false,
                    CreatedDate = DateTime.Now,
                    CreatedTime = DateTime.Now,
                    CreatedBy = userId,
                    DeletedBy = "",
                    IsDeleted = false,
                    ModifiedBy = userId,
                    ModifiedDate = DateTime.Now,
                    ModifiedTime = DateTime.Now
                };
                _context.FormRequestAnswer.Add(newData2);
            }
            _context.SaveChanges();
            await _hubContext.Clients.Users(_context.Forms.Find(idForm).CreatedBy).SendAsync("LoadNotifications");
            return View();
        }

        public IActionResult Notification()
        {
            return View();
        }

        [Route("change/{id}")]
        public IActionResult Change(Guid id)
        {
            var check = _context.Forms.FirstOrDefault(x => x.Id == id);
            if (check == null)
            {
                return NotFound();
            }
            check.Publish = !check.Publish;
            _context.Forms.Update(check);
            _context.SaveChanges();
            return RedirectToAction("index", "forms");
        }

        [HttpGet]
        [Route("danh-sach/{id}")]
        public async Task<IActionResult> Info(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var form = await _context.Forms.FirstOrDefaultAsync(x => x.Id == id);
            //var dataUser = _context.AppUsers.Where(x => x.Id == dataUserFriend.IdUsers.Id).FirstOrDefault();
            return View(form);
        }

        [HttpGet]
        [Route("list/{id}")]
        public async Task<IActionResult> List(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var formRequest = await _context.FormRequest.Where(x => x.IdForm == _context.Forms.Find(id)).ToListAsync();
            return Ok(formRequest);
        }

        [HttpGet]
        [Route("tra-xuat-du-lieu/{id}/{idUser}")]
        public async Task<IActionResult> ResponseData(Guid id, Guid idUser)
        {
            var data = await _context.FormRequest.Where(x => x.IdForm == _context.Forms.Find(id) && x.IdUser == idUser).FirstOrDefaultAsync();
            var allData = await _context.FormRequestAnswer.Include(i => i.IdFormAnswer).ThenInclude(ti => ti.IdFormQuestion).Where(x => x.IdFormRequest == data).ToListAsync();

            return View(allData);
        }
    }
}
