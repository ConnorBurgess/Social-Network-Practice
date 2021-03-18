using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.IO;

namespace SocialNetwork.Controllers
{
  public class UsersController : Controller
  {
    private readonly SocialNetworkContext _db;

    public UsersController(SocialNetworkContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<User> model = _db.Users.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(User user)
    {
      var img = user.MyImage;
      var imgCaption = user.ImageCaption;

      //Getting file meta data
      // var fileName = Path.GetFileName(user.MyImage.FileName);
      // var contentType = user.MyImage.ContentType;
      System.Console.WriteLine("img" + img);
      System.Console.WriteLine("imgCaption" + imgCaption);
      // System.Console.WriteLine("fileName" + fileName);
      // System.Console.WriteLine("contentType" + contentType);
      // do something with the above data
      // to do : return something


      _db.Users.Add(user);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisUser = _db.Users.Include(user => user.JoinEntities).FirstOrDefault(user => user.UserId == id);
      // .ThenInclude(join => join.Category)
      return View(thisUser);
    }
    public ActionResult Edit(int id)
    {
      var thisUser = _db.Users.FirstOrDefault(user => user.UserId == id);
      return View(thisUser);
    }

    [HttpPost]
    public ActionResult Edit(User user)
    {
      _db.Entry(user).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisUser = _db.Users.FirstOrDefault(student => student.UserId == id);
      return View(thisUser);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisUser = _db.Users.FirstOrDefault(user => user.UserId == id);
      _db.Users.Remove(thisUser);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddFollower(int id)
    {
      var thisUser = _db.Users.FirstOrDefault(user => user.UserId == id);
      ViewBag.UserId = new SelectList(_db.Users, "UserId", "UserName");
      return View(thisUser);
    }

    [HttpPost]
    public ActionResult AddFollower(User user, int UserId)
    {
      var thisUser = _db.Users.FirstOrDefault(entry => entry.UserId == user.UserId);
      var otherUser = _db.Users.FirstOrDefault(entry => entry.UserId.ToString() == user.FollowerId);
      // System.Console.WriteLine("user:" + user);
      // System.Console.WriteLine("should be dr. ballsacke" + thisUser.UserName);
      // System.Console.WriteLine("UserId" + UserId);
      // System.Console.WriteLine(user.FollowerId);
      thisUser.FollowerId = otherUser.UserName;
      thisUser.JoinEntities.Add(otherUser);
      // System.Console.WriteLine(thisUser.JoinEntities.Count);
      //  _db.Entry(user).State = EntityState.Modified;
      _db.SaveChanges();
      // System.Console.WriteLine("user.UserId" + user.UserId);
      // if (UserId != 0)
      // {
      //   _db.Users.Add(new User() { FollowerId = user.UserId });
      // }
      // _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
