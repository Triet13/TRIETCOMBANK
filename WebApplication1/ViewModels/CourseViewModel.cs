using System;
using System.Collections.Generic;
using WebApplication1.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace WebApplication1.ViewModels
{
    public class CourseViewModel
    {
       [Required]
        public  string Place { get; set; }
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public byte Category { get; set; }
       
        public IEnumerable<Category> Categories { get; set; }
        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}
// xem lại đoạn code trước cái trang đó đi, có code sai hay thiếu j ko chứ nhận thì nó có nhận r nhưng lại ko hiện ở trong SQL
