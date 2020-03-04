using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{

    // I'm willing to bet this isn't
    // The best way to update user roles.
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;

        public string userId { get; set; }

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult GetUsers()
        {
            var usersQuery = _context.Users;

            var userDtos = usersQuery
                .Select(Mapper.Map<ApplicationUser, ApplicationUserDto>)
                .ToList();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            // Get the role you need (CanManageMovies role in this case)
            var role = roleManager.FindByName(RoleName.CanManageMovies);

            // All the user ids that have this role
            var userIds = role.Users.Select(u => u.UserId);

            // Get all user objects
            var userNamesWithAdmin = _context.Users.Where(u => userIds.Contains(u.Id)).ToList().Select(u => u.UserName);

            // This is probably a super convulted way to achieve this
            foreach (ApplicationUserDto userDto in userDtos)
                userDto.isAdmin = userNamesWithAdmin.Contains(userDto.UserName);

            return Ok(userDtos.AsEnumerable());
        }

        [HttpPut]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateUser(string id)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Id == id);

            // Some how not found but EXTREMELY unlikely based on how this is executed
            if (userInDb == null)
                return NotFound();

            // Don't allow users to change their own Role
            if (User.Identity.GetUserName() == userInDb.UserName)
                return BadRequest();

            var store = new UserStore<ApplicationUser>(_context);
            var userManager = new UserManager<ApplicationUser>(store);

            //get user's assigned roles
            IList<string> userRoles = userManager.GetRoles(id);

            if(userRoles.Contains(RoleName.CanManageMovies))
            { 
                var result = userManager.RemoveFromRole(id, RoleName.CanManageMovies);
                if (!result.Succeeded)
                    return BadRequest();
            }
            else
            {
                var result = userManager.AddToRole(id, RoleName.CanManageMovies);
                if (!result.Succeeded)
                    return BadRequest();
            }

            //_context.SaveChanges();

            return Ok();
        }
    }
}
