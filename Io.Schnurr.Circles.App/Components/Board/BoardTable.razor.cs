using System.Net.Http.Json;
using Io.Schnurr.Circles.Shared;
using MudBlazor;

namespace Io.Schnurr.Circles.App.Shared.Board;

public partial class BoardTable
{
    private IEnumerable<WeatherForecast> pagedData;
    private MudTable<WeatherForecast> table;

    private int totalItems;
    private string searchString = null;

    /// <summary>
    /// Here we simulate getting the paged, filtered and ordered data from the server
    /// </summary>
    private async Task<TableData<WeatherForecast>> ServerReload(TableState state)
    {
        IEnumerable<WeatherForecast>? data = await HttpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        await Task.Delay(300);
        data = data!.Where(element =>
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Summary!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }).ToArray();
        totalItems = data.Count();
        switch (state.SortLabel)
        {
            case "id_field":
                data = data.OrderByDirection(state.SortDirection, o => o.Id);
                break;
            case "summary_field":
                data = data.OrderByDirection(state.SortDirection, o => o.Summary);
                break;
        }

        pagedData = data.Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray();
        return new TableData<WeatherForecast>() { TotalItems = totalItems, Items = pagedData };
    }

    private void OnSearch(string text)
    {
        searchString = text;
        table.ReloadServerData();
    }
}
