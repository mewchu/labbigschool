using labbigschool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace labbigschool.Controllers
{
    public class FollowingDto : ApiController
    {
        private readonly ApplicationDbContext dbContext;
        private ApplicationDbContext _dbContext;
        private Following following;

        public FollowingsController() => _dbContext = new ApplicationDbContext();

        public string FolloweeId { get; private set; }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!");
            var folowing = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();

            return Ok();
        }

    }
}