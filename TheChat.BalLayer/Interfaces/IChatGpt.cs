using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheChat.BalLayer.ViewModels;
using static TheChat.Utility.Enums.CommonEnum;

namespace TheChat.BalLayer.Interfaces
{
    public interface IChatGpt
    {
        IAsyncEnumerable<string> ChatGPT(string query, int maxTokens = ChatGPTTokensize.Default);

        Task<string> Perplexity(string query);

        Task<object> ChatGPT4(ConversationViewModel CVM);

        Task<object> Claude(ConversationViewModel CVM);

        Task<List<ConversationHistoryViewModel>> GetConversationHistory();

        Task<string> EditHistoryTitle(long historyId,string title);

        Task<string> SaveConversation(long conversationId);

        Task<string> DeleteHistoryTitle(long historyId);


        Task<List<ConversationDetailsHistoryViewModel>> GetConversationDetailsHistory(long conversationId,int ModelId);



    }
}
