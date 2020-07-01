using System.Threading.Tasks;
using Xamarin.Forms;

namespace CintelinkApp.Services.PageService
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task<Page> PopAsync();

        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);
        Task<string> DisplayPromptAsync(string title, string message, string ok, string cancel, string placeholder);
        Task<string> DisplayActionSheet(string title, string cancel, string option1, string option2, string option3 = "", string option4 = "");
        Task<Page> SetMainPage(Page page);
    }
}
