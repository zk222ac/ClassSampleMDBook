using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ClassSampleMDBook
{

    public class Book
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string dob { get; set; }
        public string[] loves { get; set; }
        public int weight { get; set; }
        public string gender { get; set; }
        public int vampires { get; set; }
    }

}
