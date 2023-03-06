using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TodoWebApi.Data;
using TodoWebApi.Models.Dto;

namespace TodoWebApi.Controllers
{
    [Route("api/Todo")]
    [ApiController]
    public class TodoAPIController : ControllerBase
    {
     
        TodoDal todoDal= new TodoDal();


        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetTodos()
        {
            var result =await  todoDal.GetTodo();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpGet("{id:int}", Name = "GetTodo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200,Type=typeof(TodoDto))]
        public async Task<ActionResult> GetTodo(int id)
        {
            var result = await todoDal.GetTodo(id);
            if (result != null || id!=0)
            {
                return Ok(result);
            }
            return BadRequest();

           
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateTodo([FromBody] TodoDto todoDto)
        {
            bool result = await todoDal.InsertTodo(todoDto);
            
            if (result == true || todoDto != null)
            {
                return Ok(result);
            }
            return BadRequest();

            // other way
            #region Other Way
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //if (TodoStore.TodoList.FirstOrDefault(u => u.Name.ToLower() == todoDto.Name.ToLower()) != null)
            //{
            //    ModelState.AddModelError("CustomError", "Todo Already Exist");
            //    return BadRequest(ModelState);
            //}
            //if (todoDto == null)
            //{
            //    return BadRequest(todoDto);
            //}
            //if (todoDto.Id > 0)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}
            //todoDto.Id = TodoStore.TodoList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            //TodoStore.TodoList.Add(todoDto);
            //return CreatedAtRoute("GetTodo", new { id = todoDto.Id }, todoDto);
            #endregion

        }


        [HttpDelete("{id:int}", Name = "DeleteTodo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  async Task<ActionResult> DeleteTodo(int id)
        {
            bool result = await todoDal.DeleteTodo(id);           
            if (result == true || id != 0)
            {
                return Ok(result);
            }
            return BadRequest();

           

        }

        [HttpPut("{id:int}", Name = "UpdateTodo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateTodo(int id, [FromBody] TodoDto todoDto)
        {

            bool result =await todoDal.UpdateTodo(todoDto);
            if (result != false || todoDto != null)
            {
                return Ok(result);
            }
            return BadRequest();

            //  OTHER WAY
            #region Other Way
            //if (todoDto == null || id != todoDto.Id)
            //{
            //    return BadRequest();
            //}
            //var todo = TodoStore.TodoList.FirstOrDefault(u => u.Id == id);
            //todo.Name = todoDto.Name;
            //todo.Complated = todoDto.Complated;

            //return NoContent();
            #endregion

        }

        // PARTIAL UPDATE TRYING
        #region Tryin Partial Update
        //[HttpPatch("id:int", Name = "UpdatePartialTodo")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult UpdatePartialTodo(int id, JsonPatchDocument<TodoDto> patchDto)
        //{
        //    if (patchDto == null || id == 0)
        //    {
        //        return BadRequest();
        //    }
        //    var todo = TodoStore.TodoList.FirstOrDefault(u => u.Id == id);
        //    if (todo == null)
        //    {
        //        return BadRequest();
        //    }
        //    patchDto.ApplyTo(todo, ModelState);
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    return NoContent();

        //}
        #endregion

    }
}
