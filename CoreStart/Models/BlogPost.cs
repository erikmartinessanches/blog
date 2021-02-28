using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CoreStart.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }
        public string Post { get; set; }
        [Required(ErrorMessage = "Please enter a category.")]
        /**The next two lines make Category.CategoryId a foreign key. Perhaps not ideal for
         * CategoryId to be of type string but it will illustrate that the DB won't generate
         * values for it, I suppose we'll have to do it.
         */
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        [Required(ErrorMessage = "Please enter an author.")]
        public string Author { get; set; } //Strings are nullable by default.
        [Required(ErrorMessage = "Please pick a date and a time.")]
        public DateTime? Time { get; set; } //Required attributes must be nullable.

        public string Slug
        {
            get
            {
                //Initializes a culture-invariant DateTimFormatInfo object.
                //DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                //dtfi.DateSeparator = "-";
                //dtfi.ShortDatePattern = "yyyy-m-d";
                //dtfi.TimeSeparator = "-";
                //dtfi.ShortTimePattern = "hh-mm-ss";
                //return Title?.Replace(' ', '-').ToLower() + "-" +
                //       Time?.ToString("d", dtfi);
                //+ "-" +Time?.ToString("t", dtfi);
                return Title?.Replace(' ', '-').ToLower() + "-" + Time?.Year +
                       "-" + Time?.Month.ToString("D2") + "-" + Time?.Day.ToString("D2");
            }
        }
    }
}
