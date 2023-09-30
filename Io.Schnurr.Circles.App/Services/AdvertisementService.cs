using System.Net.Http.Json;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Enums;
using Io.Schnurr.Circles.Shared.Models;
using Io.Schnurr.Circles.Shared.TestData;

namespace Io.Schnurr.Circles.App.Services;

public class AdvertisementService
{
    private HttpClient HttpClient { get; set; }

    public AdvertisementService(HttpClient HttpClient)
    {
        this.HttpClient = HttpClient;
    }

    internal async Task<IEnumerable<Advertisement>?> GetAll()
    {
        try
        {
            return await HttpClient.GetFromJsonAsync<Advertisement[]>(nameof(Advertisement));
        }
        catch (HttpRequestException)
        {
            return Array.Empty<Advertisement>();
        }
    }

    internal async Task<IEnumerable<Advertisement>?> GetByUser()
    {
        try
        {
            return await HttpClient.GetFromJsonAsync<Advertisement[]>($"{nameof(Advertisement)}/{TestUserContext.MailAddress}");
        }
        catch (HttpRequestException)
        {
            return Array.Empty<Advertisement>();
        }
    }

    internal async Task PostAdvertisement(Advertisement advertisement)
    {
        await HttpClient.PostAsJsonAsync($"{nameof(Advertisement)}", advertisement);
    }

    internal static IEnumerable<Advertisement>? SortAdvertisements(IEnumerable<Advertisement>? advertisements, SortColumn sortColumn, SortDirection sortDirection)
    {
        var sortAscending = sortDirection == SortDirection.Ascending;
        IEnumerable<Advertisement>? sortedAdvertisements = new List<Advertisement>();

        switch (sortColumn)
        {
            case SortColumn.CreatedAt:
                sortedAdvertisements = advertisements?.Order(a => a.CreatedAt, sortAscending);
                break;
            case SortColumn.Title:
                sortedAdvertisements = advertisements?.Order(a => a.Title, sortAscending);
                break;
            case SortColumn.Price:
                sortedAdvertisements = advertisements?.Order(a => a.Price, sortAscending);
                break;
        }

        return sortedAdvertisements;
    }

    internal static IEnumerable<Advertisement>? FilterAdvertisements(IEnumerable<Advertisement> advertisements, string searchString)
    {
        var filteredAdvertisements = advertisements?.Where(a =>
        {
            bool result;

            result = string.IsNullOrWhiteSpace(searchString)
                || a.Id.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || a.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || a.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || a.Price.ToCurrency().Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || a.CreatedAt.ToShortDateString().Contains(searchString, StringComparison.OrdinalIgnoreCase);

            return result;
        });

        return filteredAdvertisements;
    }
}