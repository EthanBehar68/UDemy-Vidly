using AutoMapper;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class ApplicationUserController : ApiController
    {
        private ApplicationDbContext _context;

        public ApplicationUserController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetApplicationUsers()
        {
            var usersQuery = _context.Users;

            var userDtos = usersQuery
                .ToList()
                .Select(Mapper.Map<ApplicationUser, ApplicationUserDto>);

            return Ok(userDtos);
        }
    }
}
