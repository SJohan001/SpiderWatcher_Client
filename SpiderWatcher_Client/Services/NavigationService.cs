using Microsoft.AspNetCore.Components;

namespace SpiderWatcher_Client.Services
{
    public class NavigationService
    {
        public string CurrentPage { get; private set; }

        public void UpdateCurrentPage(string page)
        {
            CurrentPage = page;
        }
    }
}
