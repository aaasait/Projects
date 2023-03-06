using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqWPFProject
{
    public  class QueryList
    {
        public int QueryID { get; set; }
        public string QueryName { get; set; }

        public QueryList() { }
        public QueryList(int queryID, string queryName)
        {
            QueryID = queryID;
            QueryName = queryName;
        }
    }
}
