using System.Threading.Tasks;
using Xamarin.Forms;

namespace CintelinkApp.Services.PageService
{
    public class PageService : IPageService
    {
        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task<string> DisplayPromptAsync(string title, string message, string ok, string cancel, string placeholder)
        {
            return await MainPage.DisplayPromptAsync(title, message, ok, cancel, placeholder, keyboard: Keyboard.Text);
        }
        public async Task<string> DisplayActionSheet(string title, string cancel, string option1, string option2, string option3 = "", string option4 = "")
        {
            return await MainPage.DisplayActionSheet(title, cancel, null, option1, option2, option3, option4);
        }

        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        public async Task<Page> PopAsync()
        {
            return await MainPage.Navigation.PopAsync();
        }

        public async Task<Page> SetMainPage(Page page)
        {
            return Application.Current.MainPage = page;
        }

        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }
    }
}
