using TodoWebApi.Models.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TodoWebApi.Data
{

    public static class TodoStore
    {
        public static List<TodoDto> TodoList = new List<TodoDto> {
             new TodoDto{Id=1,Name="Make",Complated=1},
             new TodoDto{Id=2,Name="Play",Complated=0},
             new TodoDto{Id=3,Name="Go",Complated=1}
        };

        
    }
}
