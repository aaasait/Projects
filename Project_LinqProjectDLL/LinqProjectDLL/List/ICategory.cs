﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProjectDLL.List
{
    public interface ICategory
    {
        public int Category_ID { get; set; }

        public string Category_Name { get; set; }
    }
}
