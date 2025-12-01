using Microsoft.AspNetCore.Components;
using Portfolio.Web.Services.BlogService;

namespace Portfolio.Web.Pages;

public partial class Home : ComponentBase
{
    [Inject] private IBlogService? BlogService { get; set; }

    private int? _blogCount = null;

    private bool _isLoading = false;
    
    protected override async Task OnInitializedAsync()
    {
        if (BlogService != null)
        {
            _isLoading = true;
            var blogs = await BlogService.GetBlogsAsync();

            _blogCount = blogs.Count();
            _isLoading = false;
        }
    }
}