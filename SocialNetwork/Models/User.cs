using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
namespace SocialNetwork.Models
{
  public class User
  {
    public User()
    {
      this.JoinEntities = new HashSet<User>();

    }
    public string ImageCaption { set; get; }
    public string ImageDescription { set; get; }
     [NotMapped]
    public IFormFile MyImage { set; get; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string UserAbout { get; set; }
    public string ImageUrl { get; set; }
    public string FollowerId { get; set; }
    public virtual ICollection<User> JoinEntities { get; set; }
    // public virtual ICollection<CourseInstructor> JoinEntities2 { get; }
  }
}

  // - Name
  // - Picture
  // - UserId
  // - AboutMe
  // - FollowerId
