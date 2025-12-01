using System.Net;
using System.Net.Http.Json;
using System.Web;
using Microsoft.AspNetCore.WebUtilities;
using Portfolio.Models.Blog;
using Portfolio.Models.Exceptions;
using Exception = System.Exception;

namespace Portfolio.Web.Services.BlogService;

public class ApiBlogService : IBlogService
{
    #region Fields
    
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "/api/blogs";
    
    #endregion
    
    #region Constructor
    
    public ApiBlogService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    #endregion
    
    #region Public Methods
    
    public async Task<List<BlogDto>> GetBlogsAsync(int? limit = null, int[]? tagIds = null)
    {
        try
        {
            Dictionary<string, string?> queryParams = new();

            if (limit is not null)
            {
                queryParams.Add("limit", limit.Value.ToString());
            }

            if (tagIds is not null)
            {
                foreach (var tagId in tagIds)
                {
                    queryParams.Add("tagIds", tagId.ToString());
                }
            }

            string url = QueryHelpers.AddQueryString(ApiUrl, queryParams);
            
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            string debugContent = await response.Content.ReadAsStringAsync();
            List<BlogDto> blogs = await response.Content.ReadFromJsonAsync<List<BlogDto>>() ?? new List<BlogDto>();

            return blogs;
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException(e.Message);
            }

            throw;
        }
    }

    public async Task<Blog?> GetBlogByIdAsync(int blogId)
    {
        try
        {
            string url = string.Concat(ApiUrl, "/", blogId);
            
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            
            Blog? blog = await response.Content.ReadFromJsonAsync<Blog>() ?? null;

            return blog;
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException(e.Message);
            }
            
            throw;
        }
    }

    public async Task<Blog?> GetBlogByAliasAsync(string alias)
    {
        try
        {
            string url = string.Concat(ApiUrl, "/alias/", alias);
            
            var response = await _httpClient.GetAsync(url);
            
            response.EnsureSuccessStatusCode();
            
            Blog? blog = await response.Content.ReadFromJsonAsync<Blog>() ?? null;

            return blog;
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException(e.Message);
            }
            
            throw;
        }
    }
    
    #endregion
}