using System.Net.Http.Json;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Enums;
using Io.Schnurr.Circles.Shared.Models;

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
        IEnumerable<Advertisement>? data = await HttpClient.GetFromJsonAsync<Advertisement[]>(nameof(Advertisement));
        return data;
    }

    internal static IEnumerable<Advertisement> SortAdvertisements(IEnumerable<Advertisement> advertisements, SortColumn sortColumn, SortDirection sortDirection)
    {
        var sortAscending = sortDirection == SortDirection.Ascending;
        IEnumerable<Advertisement> sortedAdvertisements = new List<Advertisement>();

        switch (sortColumn)
        {
            case SortColumn.CreatedAt:
                sortedAdvertisements = advertisements.Order(a => a.CreatedAt, sortAscending);
                break;
            case SortColumn.Title:
                sortedAdvertisements = advertisements.Order(a => a.Title, sortAscending);
                break;
            case SortColumn.Price:
                sortedAdvertisements = advertisements.Order(a => a.Price, sortAscending);
                break;
        }

        return sortedAdvertisements;
    }

    internal static IEnumerable<Advertisement> FilterAdvertisements(IEnumerable<Advertisement> advertisements, string searchString)
    {
        var filteredData = advertisements?.Where(d =>
        {
            bool result;

            result = string.IsNullOrWhiteSpace(searchString)
                || d.Id.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || d.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || d.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || d.Price.ToCurrency().Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || d.CreatedAt.ToShortDateString().Contains(searchString, StringComparison.OrdinalIgnoreCase);

            return result;
        });

        return filteredData ?? new List<Advertisement>();
    }
}