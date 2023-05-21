using System.Net.Http.Json;
using Io.Schnurr.Circles.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Io.Schnurr.Circles.App.Components.Board;

public partial class BoardTable
{
    [Inject]
    private HttpClient HttpClient { get; set; } = default!;
    private IEnumerable<WeatherForecast>? pagedData;
    private MudTable<WeatherForecast>? table;
    private int totalItems;
    private string? searchString;

    private async Task<TableData<WeatherForecast>> ServerReload(TableState state)
    {
        IEnumerable<WeatherForecast>? data = await HttpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");

        data = data!.Where(element =>
        {
            bool result = false;

            result = string.IsNullOrWhiteSpace(searchString)
                || element.Id.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || element.Date.ToShortDateString().Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || element.TemperatureC.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || element.TemperatureF.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || element.Summary!.Contains(searchString, StringComparison.OrdinalIgnoreCase);

            return result;
        }).ToArray();

        totalItems = data.Count();

        switch (state.SortLabel)
        {
            case "id_field":
                data = data.OrderByDirection(state.SortDirection, o => o.Id);
                break;
            case "date_field":
                data = data.OrderByDirection(state.SortDirection, o => o.Date);
                break;
            case "temperatureC_field":
                data = data.OrderByDirection(state.SortDirection, o => o.TemperatureC);
                break;
            case "temperatureF_field":
                data = data.OrderByDirection(state.SortDirection, o => o.TemperatureF);
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
