using AutoMapper;
using AutoMapperTest.Models;
using AutoMapperTest.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace AutoMapperTest.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var user = new User(1, "Carl", "Jackson", "test@test.test");

            UserViewModel viewModel = _mapper.Map<UserViewModel>(user);

            return View(viewModel);
        }
    }
}