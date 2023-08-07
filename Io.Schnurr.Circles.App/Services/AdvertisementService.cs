using System.Net.Http.Json;
using System.Text.Json;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Enums;
using Io.Schnurr.Circles.Shared.Models;

namespace Io.Schnurr.Circles.App.Services;

public class AdvertisementService // TODO: Cleanup
{
    private HttpClient HttpClient { get; set; }

    public AdvertisementService(HttpClient HttpClient)
    {
        this.HttpClient = HttpClient;
    }

    internal async Task<IEnumerable<Advertisement>> GetAll(bool useStaticData, string? searchString = null)
    {
        IEnumerable<Advertisement>? data;

        if (useStaticData)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            data = JsonSerializer.Deserialize<IEnumerable<Advertisement>>("[{\"Title\":\"Title-3219-1\",\"Description\":\"Description-4235-1\",\"Price\":1.3,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":1,\"CreatedAt\":\"2018-01-21T20:33:15.0228543+01:00\",\"DeletedAt\":null},{\"Title\":\"Title-7908-2\",\"Description\":\"Description-4001-2\",\"Price\":2.6,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":2,\"CreatedAt\":\"2009-07-25T20:33:15.0285472+02:00\",\"DeletedAt\":null},{\"Title\":\"Title-3588-3\",\"Description\":\"Description-3204-3\",\"Price\":3.9,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":3,\"CreatedAt\":\"2014-02-14T20:33:15.0286033+01:00\",\"DeletedAt\":null},{\"Title\":\"Title-8560-5\",\"Description\":\"Description-6667-5\",\"Price\":6.5,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":5,\"CreatedAt\":\"1975-10-26T20:33:15.0286353+01:00\",\"DeletedAt\":null},{\"Title\":\"Title-944-6\",\"Description\":\"Description-5733-6\",\"Price\":7.8,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":6,\"CreatedAt\":\"2015-07-24T20:33:15.0286376+02:00\",\"DeletedAt\":null},{\"Title\":\"Title-3997-7\",\"Description\":\"Description-9779-7\",\"Price\":9.1,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":7,\"CreatedAt\":\"1987-06-27T20:33:15.0286403+02:00\",\"DeletedAt\":null},{\"Title\":\"Title-1699-9\",\"Description\":\"Description-7653-9\",\"Price\":11.7,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":9,\"CreatedAt\":\"1952-07-03T19:33:15.0286459+01:00\",\"DeletedAt\":null},{\"Title\":\"Title-82-10\",\"Description\":\"Description-293-10\",\"Price\":13.0,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":10,\"CreatedAt\":\"2011-07-19T20:33:15.0286479+02:00\",\"DeletedAt\":null},{\"Title\":\"Title-9297-11\",\"Description\":\"Description-1023-11\",\"Price\":14.3,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":11,\"CreatedAt\":\"1929-12-17T20:33:15.0286513+01:00\",\"DeletedAt\":null},{\"Title\":\"Title-3587-13\",\"Description\":\"Description-6827-13\",\"Price\":16.9,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":13,\"CreatedAt\":\"2001-02-05T20:33:15.0286542+01:00\",\"DeletedAt\":null},{\"Title\":\"Title-4816-14\",\"Description\":\"Description-7153-14\",\"Price\":18.2,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":14,\"CreatedAt\":\"1993-03-27T20:33:15.0286558+01:00\",\"DeletedAt\":null},{\"Title\":\"Title-6420-15\",\"Description\":\"Description-1658-15\",\"Price\":19.5,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":15,\"CreatedAt\":\"1944-07-15T20:33:15.028658+02:00\",\"DeletedAt\":null},{\"Title\":\"Title-8050-17\",\"Description\":\"Description-2365-17\",\"Price\":22.1,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":17,\"CreatedAt\":\"1891-08-22T19:27:15.0286617+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-7755-18\",\"Description\":\"Description-8963-18\",\"Price\":23.4,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":18,\"CreatedAt\":\"1916-05-10T20:33:15.0286636+02:00\",\"DeletedAt\":null},{\"Title\":\"Title-1160-19\",\"Description\":\"Description-4209-19\",\"Price\":24.7,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":19,\"CreatedAt\":\"1887-10-08T19:27:15.0286652+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-3905-21\",\"Description\":\"Description-9937-21\",\"Price\":27.3,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":21,\"CreatedAt\":\"1796-08-27T19:27:15.0286678+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-9669-22\",\"Description\":\"Description-3832-22\",\"Price\":28.6,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":22,\"CreatedAt\":\"1990-11-20T20:33:15.0286694+01:00\",\"DeletedAt\":null},{\"Title\":\"Title-3517-23\",\"Description\":\"Description-5905-23\",\"Price\":29.9,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":23,\"CreatedAt\":\"2016-07-16T20:33:15.0286721+02:00\",\"DeletedAt\":null},{\"Title\":\"Title-7513-25\",\"Description\":\"Description-342-25\",\"Price\":32.5,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":25,\"CreatedAt\":\"1765-05-29T19:27:15.0286766+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-9984-26\",\"Description\":\"Description-6301-26\",\"Price\":33.8,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":26,\"CreatedAt\":\"1821-04-14T19:27:15.0286784+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-7378-27\",\"Description\":\"Description-7843-27\",\"Price\":35.1,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":27,\"CreatedAt\":\"1900-08-02T19:33:15.0286828+01:00\",\"DeletedAt\":null},{\"Title\":\"Title-4319-29\",\"Description\":\"Description-854-29\",\"Price\":37.7,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":29,\"CreatedAt\":\"1639-01-23T20:27:15.0286851+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-6236-30\",\"Description\":\"Description-3397-30\",\"Price\":39.0,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":30,\"CreatedAt\":\"1771-07-07T19:27:15.0286869+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-3516-31\",\"Description\":\"Description-580-31\",\"Price\":40.3,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":31,\"CreatedAt\":\"1686-01-16T20:27:15.028689+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-1333-33\",\"Description\":\"Description-5534-33\",\"Price\":42.9,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":33,\"CreatedAt\":\"1769-04-03T19:27:15.0286916+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-3598-34\",\"Description\":\"Description-9232-34\",\"Price\":44.2,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":34,\"CreatedAt\":\"1916-01-29T20:33:15.0286932+01:00\",\"DeletedAt\":null},{\"Title\":\"Title-3029-35\",\"Description\":\"Description-9178-35\",\"Price\":45.5,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":35,\"CreatedAt\":\"1790-06-12T19:27:15.0286948+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-6574-37\",\"Description\":\"Description-9050-37\",\"Price\":48.1,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":37,\"CreatedAt\":\"1964-08-20T19:33:15.028697+01:00\",\"DeletedAt\":null},{\"Title\":\"Title-7925-38\",\"Description\":\"Description-1460-38\",\"Price\":49.4,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":38,\"CreatedAt\":\"1697-11-03T20:27:15.0286994+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-4097-39\",\"Description\":\"Description-4621-39\",\"Price\":50.7,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":39,\"CreatedAt\":\"1563-05-19T19:27:15.0287021+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-8199-41\",\"Description\":\"Description-6593-41\",\"Price\":53.3,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":41,\"CreatedAt\":\"1841-07-08T19:27:15.0287047+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-3561-42\",\"Description\":\"Description-3186-42\",\"Price\":54.6,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":42,\"CreatedAt\":\"1454-04-08T19:27:15.0287063+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-5057-43\",\"Description\":\"Description-519-43\",\"Price\":55.9,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":43,\"CreatedAt\":\"1726-03-17T20:27:15.0287079+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-2177-45\",\"Description\":\"Description-7893-45\",\"Price\":58.5,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":45,\"CreatedAt\":\"1948-10-22T19:33:15.02871+01:00\",\"DeletedAt\":null},{\"Title\":\"Title-1692-46\",\"Description\":\"Description-4968-46\",\"Price\":59.8,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":46,\"CreatedAt\":\"1997-04-09T20:33:15.0287116+02:00\",\"DeletedAt\":null},{\"Title\":\"Title-9895-47\",\"Description\":\"Description-906-47\",\"Price\":61.1,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":47,\"CreatedAt\":\"1843-06-10T19:27:15.0287131+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-8534-49\",\"Description\":\"Description-2643-49\",\"Price\":63.7,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":49,\"CreatedAt\":\"1852-07-17T19:27:15.0287177+00:54\",\"DeletedAt\":null},{\"Title\":\"Title-9862-50\",\"Description\":\"Description-5112-50\",\"Price\":65.0,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":50,\"CreatedAt\":\"1705-01-14T20:27:15.0287205+00:54\",\"DeletedAt\":null}]", options)
                .Where(o => o.DeletedAt == null);
        }
        else
        {
            data = await HttpClient.GetFromJsonAsync<Advertisement[]>("Advertisement");
        }

        if (!string.IsNullOrEmpty(searchString) && data != null)
        {
            data = FilterAdvertisements(data, searchString);
        }

        return data ?? new List<Advertisement>();
    }

    internal static IEnumerable<Advertisement>? SortAdvertisements(IEnumerable<Advertisement>? advertisements, SortColumn sortColumn, SortDirection sortDirection)
    {
        var sortAscending = sortDirection == SortDirection.Ascending;
        IEnumerable<Advertisement>? sortedAdvertisements = null;

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

    internal static IEnumerable<Advertisement>? FilterAdvertisements(IEnumerable<Advertisement>? advertisements, string searchString)
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
        }).ToArray();

        return filteredData;
    }
}