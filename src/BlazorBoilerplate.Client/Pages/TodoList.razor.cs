using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Pages
{
    public class TodoListBase : ComponentBase
    {
        [Inject] private HttpClient Http { get; set; }
        [Inject] private IMatToaster matToaster { get; set; }

        protected bool deleteDialogOpen = false;
        protected bool dialogIsOpen = false;
        protected List<TodoDto> todos = new List<TodoDto>();
        protected TodoDto todo { get; set; } = new TodoDto();

        protected override async Task OnInitializedAsync()
        {
            await ReadTodos();
        }

        protected async Task ReadTodos()
        {
            ApiResponseDto apiResponse = await Http.GetJsonAsync<ApiResponseDto>("api/todo");

            if (apiResponse.StatusCode == 200)
            {
                matToaster.Add(apiResponse.Message, MatToastType.Success, "Todo List Retrieved");
                todos = Newtonsoft.Json.JsonConvert.DeserializeObject<TodoDto[]>(apiResponse.Result.ToString()).ToList<TodoDto>();
            }
            else
            {
                matToaster.Add(apiResponse.Message + " : " + apiResponse.StatusCode, MatToastType.Danger, "Todo List Retrieval Failed");
            }
        }


        protected async Task Update(TodoDto todo)
        {
            //this updates the IsCompleted flag only
            try
            {
                todo.IsCompleted = !todo.IsCompleted;
                ApiResponseDto apiResponse = await Http.PutJsonAsync<ApiResponseDto>("api/todo", todo);

                if (!apiResponse.IsError)
                {
                    matToaster.Add(apiResponse.Message, MatToastType.Success);
                }
                else
                {
                    matToaster.Add(apiResponse.Message + " : " + apiResponse.StatusCode, MatToastType.Danger, "Todo Save Failed");
                    todo.IsCompleted = !todo.IsCompleted; //update failed so reset IsCompleted
                }
            }
            catch (Exception ex)
            {
                matToaster.Add(ex.Message, MatToastType.Danger, "Todo Save Failed");
                todo.IsCompleted = !todo.IsCompleted; //update failed so reset IsCompleted
            }
        }

        protected async Task Delete()
        {
            try
            {
                var response = await Http.DeleteAsync("api/todo/" + todo.Id);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    matToaster.Add("Todo Deleted", MatToastType.Success);
                    todos.Remove(todo);
                }
                else
                {
                    matToaster.Add("Todo Delete Failed: " + response.StatusCode, MatToastType.Danger);
                }
                deleteDialogOpen = false;
                todo = new TodoDto(); //reset todo after delete
            }
            catch (Exception ex)
            {
                matToaster.Add(ex.Message, MatToastType.Danger, "Todo Save Failed");
            }
        }

        protected void OpenDialog()
        {
            dialogIsOpen = true;
        }

        protected void OpenDeleteDialog(long todoId)
        {
            todo = todos.Where(x => x.Id == todoId).FirstOrDefault();
            this.deleteDialogOpen = true;
        }

        protected async Task CreateTodo()
        {
            dialogIsOpen = false;
            try
            {
                ApiResponseDto apiResponse = await Http.PostJsonAsync<ApiResponseDto>("api/todo", todo);
                if (apiResponse.StatusCode == 200)
                {
                    matToaster.Add(apiResponse.Message, MatToastType.Success);
                    todo = Newtonsoft.Json.JsonConvert.DeserializeObject<TodoDto>(apiResponse.Result.ToString());
                    todos.Add(todo);
                    todo = new TodoDto(); //reset todo after insert
                }
                else
                {
                    matToaster.Add(apiResponse.Message + " : " + apiResponse.StatusCode, MatToastType.Danger, "Todo Creation Failed");
                }
            }
            catch (Exception ex)
            {
                matToaster.Add(ex.Message, MatToastType.Danger, "Todo Creation Failed");
            }
        }

    }
}
