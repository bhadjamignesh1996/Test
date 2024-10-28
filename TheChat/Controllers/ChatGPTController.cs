using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheChat.BalLayer.Interfaces;
using TheChat.BalLayer.ViewModels;
using TheChat.Utility.Common;
using static TheChat.Utility.Enums.CommonEnum;

namespace TheChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGPTController : ControllerBase
    {
        private readonly IChatGpt chatGPTService;
        public ChatGPTController(IChatGpt _chatGPTService)
        {
            chatGPTService = _chatGPTService;
        }

        [HttpPost]
        [Route("ChatGPTSearch4")]
        public async Task<IActionResult> ChatGPTSearch4(ConversationViewModel CVM)
        {

            try
            {
                var _solutions = await chatGPTService.ChatGPT4(CVM);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(_solutions);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpGet]
        [Route("ChatGPTSearch/{query}")]
        public async Task ChatGPTSearch(string query)
        {
            try
            {
                // Set the content type to `text/event-stream` for Server-Sent Events (SSE)
                Response.ContentType = "text/event-stream";

                //string result = string.Empty;
                // Get the streamed results as an `IAsyncEnumerable` from the ChatGPT service
                await foreach (var contentChunk in chatGPTService.ChatGPT(query))
                {
                    //result += contentChunk;
                    // Write each chunk of content as a server-sent event
                    await Response.WriteAsync($"data: {contentChunk}\n\n");


                    // Flush the response to ensure the client receives the data as soon as it's available
                    await Response.Body.FlushAsync();
                }

                // Ensure the response is properly terminated
                //await Response.WriteAsync("data: [DONE]\n\n");
                //await Response.Body.FlushAsync();
            }
            catch (Exception ex)
            {
                // Handle the error, send the error message as SSE
                var errorMessage = $"Error: {ex.Message}";
                await Response.WriteAsync($"data: {errorMessage}\n\n");
                await Response.Body.FlushAsync();
            }
        }

        [HttpGet]
        [Route("Perplexity/{query}")]
        public async Task<IActionResult> Perplexity(string query)
        {

            try
            {
                var _solutions = await chatGPTService.Perplexity(query);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(_solutions);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }


        [HttpPost]
        [Route("Claude")]
        public async Task<IActionResult> Claude(ConversationViewModel CVM)
        {

            try
            {
                var _solutions = await chatGPTService.Claude(CVM);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(_solutions);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpGet]
        [ServiceFilter(typeof(ActionFilters.TokenVerify))]
        [Route("GetConversationHistory")]
        public async Task<IActionResult> GetConversationHistory()
        {

            try
            {
                var history = await chatGPTService.GetConversationHistory();

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(history);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpPut]
        [ServiceFilter(typeof(ActionFilters.TokenVerify))]
        [Route("EditHistoryTitle/{historyId}/{title}")]
        public async Task<IActionResult> EditHistoryTitle(long historyId,string title)
        {

            try
            {
                var history = await chatGPTService.EditHistoryTitle(historyId, title);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(null, Message.UpdatedSuccessfully);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }


        [HttpGet]
        [Route("GetConversationDetailsHistory/{conversationId}/{ModelId}")]
        public async Task<IActionResult> GetConversationDetailsHistory(long conversationId,int ModelId)
        {

            try
            {
                var conversationDetails = await chatGPTService.GetConversationDetailsHistory(conversationId, ModelId);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(conversationDetails);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpDelete]
        [ServiceFilter(typeof(ActionFilters.TokenVerify))]
        [Route("DeleteHistoryTitle/{historyId}")]
        public async Task<IActionResult> DeleteHistoryTitle(long historyId)
        {
            try
            {
                await chatGPTService.DeleteHistoryTitle(historyId);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(null, Message.DeletedSuccessfully);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpPut]
        [ServiceFilter(typeof(ActionFilters.TokenVerify))]
        [Route("SaveConversation/{conversationId}")]
        public async Task<IActionResult> SaveConversation(long conversationId)
        {
            try
            {
                await chatGPTService.SaveConversation(conversationId);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(null, Message.SavedSuccessfully);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }
    }
}
