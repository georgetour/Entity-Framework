using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverridingConventions
{
    public class Tag
    {
        public Tag()
        {
            Videos = new HashSet<Video>();
        }

        public int TagId { get; set; }
        public string VideoOld { get; set; }


        public virtual ICollection<Video> Videos { get; set; }


    }
}
