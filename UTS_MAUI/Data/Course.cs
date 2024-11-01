using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTS_MAUI.Data
{
    [Serializable]
    public class Course
    {
        public int courseId { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; } // Add this property to hold the selected category's ID
        public Category Category { get; set; }
    }
}
