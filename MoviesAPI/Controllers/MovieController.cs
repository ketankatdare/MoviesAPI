using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoviesAPI.Models.Entity;

namespace MoviesAPI.Controllers
{
    public class MovieController : ApiController
    {
        // POST api/movie
        public IHttpActionResult Post(Movies movie)
        {
            try
            {
                using (DBMoviesEntities ctx = new DBMoviesEntities())
                {
                    ctx.Movies.Add(movie);
                    ctx.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // GET api/movie
        public IHttpActionResult Get()
        {
            try
            {
                using (DBMoviesEntities ctx = new DBMoviesEntities())
                {
                    var movies = ctx.Movies.ToList();
                    return Ok(movies);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // GET api/movie
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (DBMoviesEntities ctx = new DBMoviesEntities())
                {
                    var movie = ctx.Movies.Where(r => r.MovieID == id).FirstOrDefault();

                    if (movie == null)
                        return BadRequest();

                    return Ok(movie);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // PUT api/movie
        public IHttpActionResult Put(Movies movie)
        {
            try
            {
                using (DBMoviesEntities ctx = new DBMoviesEntities())
                {
                    var obj = ctx.Movies.Where(r => r.MovieID == movie.MovieID).FirstOrDefault();

                    if (obj == null)
                        return BadRequest();

                    obj.MovieName = movie.MovieName;
                    obj.Rating = movie.Rating;
                    obj.Director = movie.Director;
                    obj.Description = movie.Description;

                    ctx.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // DELETE api/movie
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (DBMoviesEntities ctx = new DBMoviesEntities())
                {
                    var movie = ctx.Movies.Where(r => r.MovieID == id).FirstOrDefault();

                    if (movie == null)
                        return BadRequest();

                    ctx.Movies.Remove(movie);
                    ctx.SaveChanges();

                    return Ok();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
