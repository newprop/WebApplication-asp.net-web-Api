using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserInfoesController : ApiController
    {
        private Employeedb db = new Employeedb();

        // GET: api/UserInfoes
        public IQueryable<UserInfo> GetUsers()
        {
            return db.Users;
        }

        // GET: api/UserInfoes/5
        [ResponseType(typeof(UserInfo))]
        public async Task<IHttpActionResult> GetUserInfo(string id)
        {
            UserInfo userInfo = await db.Users.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }

        // PUT: api/UserInfoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserInfo(string id, UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userInfo.UserName)
            {
                return BadRequest();
            }

            db.Entry(userInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserInfoes
        [ResponseType(typeof(UserInfo))]
        public async Task<IHttpActionResult> PostUserInfo(UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(userInfo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserInfoExists(userInfo.UserName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userInfo.UserName }, userInfo);
        }

        // DELETE: api/UserInfoes/5
        [ResponseType(typeof(UserInfo))]
        public async Task<IHttpActionResult> DeleteUserInfo(string id)
        {
            UserInfo userInfo = await db.Users.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            db.Users.Remove(userInfo);
            await db.SaveChangesAsync();

            return Ok(userInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserInfoExists(string id)
        {
            return db.Users.Count(e => e.UserName == id) > 0;
        }
    }
}