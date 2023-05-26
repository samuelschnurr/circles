using System.Net.Http.Json;
using System.Text.Json;
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

    private async Task<TableData<WeatherForecast>> ServerReload(TableState state, bool useStaticData)
    {
        IEnumerable<WeatherForecast>? data = null;
        // Testdata
        if (useStaticData)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            data = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>("[{\"id\":1,\"date\":\"2023-05-22\",\"temperatureC\":0,\"summary\":\"Sweltering\",\"temperatureF\":32},{\"id\":2,\"date\":\"2023-05-23\",\"temperatureC\":-3,\"summary\":\"Cool\",\"temperatureF\":27},{\"id\":3,\"date\":\"2023-05-24\",\"temperatureC\":48,\"summary\":\"Cool\",\"temperatureF\":118},{\"id\":4,\"date\":\"2023-05-25\",\"temperatureC\":21,\"summary\":\"Chilly\",\"temperatureF\":69},{\"id\":5,\"date\":\"2023-05-26\",\"temperatureC\":21,\"summary\":\"Mild\",\"temperatureF\":69},{\"id\":6,\"date\":\"2023-05-27\",\"temperatureC\":28,\"summary\":\"Freezing\",\"temperatureF\":82},{\"id\":7,\"date\":\"2023-05-28\",\"temperatureC\":11,\"summary\":\"Scorching\",\"temperatureF\":51},{\"id\":8,\"date\":\"2023-05-29\",\"temperatureC\":37,\"summary\":\"Chilly\",\"temperatureF\":98},{\"id\":9,\"date\":\"2023-05-30\",\"temperatureC\":22,\"summary\":\"Cool\",\"temperatureF\":71},{\"id\":10,\"date\":\"2023-05-31\",\"temperatureC\":-14,\"summary\":\"Mild\",\"temperatureF\":7},{\"id\":11,\"date\":\"2023-06-01\",\"temperatureC\":25,\"summary\":\"Bracing\",\"temperatureF\":76},{\"id\":12,\"date\":\"2023-06-02\",\"temperatureC\":41,\"summary\":\"Mild\",\"temperatureF\":105},{\"id\":13,\"date\":\"2023-06-03\",\"temperatureC\":51,\"summary\":\"Mild\",\"temperatureF\":123},{\"id\":14,\"date\":\"2023-06-04\",\"temperatureC\":-19,\"summary\":\"Freezing\",\"temperatureF\":-2},{\"id\":15,\"date\":\"2023-06-05\",\"temperatureC\":-4,\"summary\":\"Cool\",\"temperatureF\":25},{\"id\":16,\"date\":\"2023-06-06\",\"temperatureC\":-13,\"summary\":\"Bracing\",\"temperatureF\":9},{\"id\":17,\"date\":\"2023-06-07\",\"temperatureC\":23,\"summary\":\"Scorching\",\"temperatureF\":73},{\"id\":18,\"date\":\"2023-06-08\",\"temperatureC\":33,\"summary\":\"Mild\",\"temperatureF\":91},{\"id\":19,\"date\":\"2023-06-09\",\"temperatureC\":10,\"summary\":\"Mild\",\"temperatureF\":49},{\"id\":20,\"date\":\"2023-06-10\",\"temperatureC\":41,\"summary\":\"Chilly\",\"temperatureF\":105},{\"id\":21,\"date\":\"2023-06-11\",\"temperatureC\":-13,\"summary\":\"Cool\",\"temperatureF\":9},{\"id\":22,\"date\":\"2023-06-12\",\"temperatureC\":25,\"summary\":\"Balmy\",\"temperatureF\":76},{\"id\":23,\"date\":\"2023-06-13\",\"temperatureC\":-13,\"summary\":\"Warm\",\"temperatureF\":9},{\"id\":24,\"date\":\"2023-06-14\",\"temperatureC\":40,\"summary\":\"Mild\",\"temperatureF\":103},{\"id\":25,\"date\":\"2023-06-15\",\"temperatureC\":3,\"summary\":\"Hot\",\"temperatureF\":37},{\"id\":26,\"date\":\"2023-06-16\",\"temperatureC\":0,\"summary\":\"Hot\",\"temperatureF\":32},{\"id\":27,\"date\":\"2023-06-17\",\"temperatureC\":7,\"summary\":\"Mild\",\"temperatureF\":44},{\"id\":28,\"date\":\"2023-06-18\",\"temperatureC\":27,\"summary\":\"Hot\",\"temperatureF\":80},{\"id\":29,\"date\":\"2023-06-19\",\"temperatureC\":14,\"summary\":\"Mild\",\"temperatureF\":57},{\"id\":30,\"date\":\"2023-06-20\",\"temperatureC\":5,\"summary\":\"Sweltering\",\"temperatureF\":40},{\"id\":31,\"date\":\"2023-06-21\",\"temperatureC\":6,\"summary\":\"Scorching\",\"temperatureF\":42},{\"id\":32,\"date\":\"2023-06-22\",\"temperatureC\":52,\"summary\":\"Chilly\",\"temperatureF\":125},{\"id\":33,\"date\":\"2023-06-23\",\"temperatureC\":-13,\"summary\":\"Scorching\",\"temperatureF\":9},{\"id\":34,\"date\":\"2023-06-24\",\"temperatureC\":13,\"summary\":\"Scorching\",\"temperatureF\":55},{\"id\":35,\"date\":\"2023-06-25\",\"temperatureC\":26,\"summary\":\"Chilly\",\"temperatureF\":78},{\"id\":36,\"date\":\"2023-06-26\",\"temperatureC\":24,\"summary\":\"Sweltering\",\"temperatureF\":75},{\"id\":37,\"date\":\"2023-06-27\",\"temperatureC\":22,\"summary\":\"Chilly\",\"temperatureF\":71},{\"id\":38,\"date\":\"2023-06-28\",\"temperatureC\":5,\"summary\":\"Hot\",\"temperatureF\":40},{\"id\":39,\"date\":\"2023-06-29\",\"temperatureC\":16,\"summary\":\"Freezing\",\"temperatureF\":60},{\"id\":40,\"date\":\"2023-06-30\",\"temperatureC\":35,\"summary\":\"Hot\",\"temperatureF\":94},{\"id\":41,\"date\":\"2023-07-01\",\"temperatureC\":37,\"summary\":\"Scorching\",\"temperatureF\":98},{\"id\":42,\"date\":\"2023-07-02\",\"temperatureC\":-7,\"summary\":\"Balmy\",\"temperatureF\":20},{\"id\":43,\"date\":\"2023-07-03\",\"temperatureC\":8,\"summary\":\"Chilly\",\"temperatureF\":46},{\"id\":44,\"date\":\"2023-07-04\",\"temperatureC\":-1,\"summary\":\"Warm\",\"temperatureF\":31},{\"id\":45,\"date\":\"2023-07-05\",\"temperatureC\":5,\"summary\":\"Bracing\",\"temperatureF\":40},{\"id\":46,\"date\":\"2023-07-06\",\"temperatureC\":10,\"summary\":\"Cool\",\"temperatureF\":49},{\"id\":47,\"date\":\"2023-07-07\",\"temperatureC\":25,\"summary\":\"Freezing\",\"temperatureF\":76},{\"id\":48,\"date\":\"2023-07-08\",\"temperatureC\":9,\"summary\":\"Mild\",\"temperatureF\":48},{\"id\":49,\"date\":\"2023-07-09\",\"temperatureC\":43,\"summary\":\"Freezing\",\"temperatureF\":109},{\"id\":50,\"date\":\"2023-07-10\",\"temperatureC\":17,\"summary\":\"Bracing\",\"temperatureF\":62},{\"id\":51,\"date\":\"2023-07-11\",\"temperatureC\":54,\"summary\":\"Sweltering\",\"temperatureF\":129},{\"id\":52,\"date\":\"2023-07-12\",\"temperatureC\":18,\"summary\":\"Cool\",\"temperatureF\":64},{\"id\":53,\"date\":\"2023-07-13\",\"temperatureC\":33,\"summary\":\"Warm\",\"temperatureF\":91},{\"id\":54,\"date\":\"2023-07-14\",\"temperatureC\":-12,\"summary\":\"Balmy\",\"temperatureF\":11},{\"id\":55,\"date\":\"2023-07-15\",\"temperatureC\":37,\"summary\":\"Freezing\",\"temperatureF\":98},{\"id\":56,\"date\":\"2023-07-16\",\"temperatureC\":0,\"summary\":\"Cool\",\"temperatureF\":32},{\"id\":57,\"date\":\"2023-07-17\",\"temperatureC\":34,\"summary\":\"Sweltering\",\"temperatureF\":93},{\"id\":58,\"date\":\"2023-07-18\",\"temperatureC\":-14,\"summary\":\"Hot\",\"temperatureF\":7},{\"id\":59,\"date\":\"2023-07-19\",\"temperatureC\":29,\"summary\":\"Freezing\",\"temperatureF\":84},{\"id\":60,\"date\":\"2023-07-20\",\"temperatureC\":-14,\"summary\":\"Cool\",\"temperatureF\":7},{\"id\":61,\"date\":\"2023-07-21\",\"temperatureC\":7,\"summary\":\"Hot\",\"temperatureF\":44},{\"id\":62,\"date\":\"2023-07-22\",\"temperatureC\":6,\"summary\":\"Mild\",\"temperatureF\":42},{\"id\":63,\"date\":\"2023-07-23\",\"temperatureC\":-5,\"summary\":\"Bracing\",\"temperatureF\":24},{\"id\":64,\"date\":\"2023-07-24\",\"temperatureC\":38,\"summary\":\"Mild\",\"temperatureF\":100},{\"id\":65,\"date\":\"2023-07-25\",\"temperatureC\":14,\"summary\":\"Hot\",\"temperatureF\":57},{\"id\":66,\"date\":\"2023-07-26\",\"temperatureC\":-9,\"summary\":\"Chilly\",\"temperatureF\":16},{\"id\":67,\"date\":\"2023-07-27\",\"temperatureC\":22,\"summary\":\"Bracing\",\"temperatureF\":71},{\"id\":68,\"date\":\"2023-07-28\",\"temperatureC\":-10,\"summary\":\"Chilly\",\"temperatureF\":15},{\"id\":69,\"date\":\"2023-07-29\",\"temperatureC\":39,\"summary\":\"Freezing\",\"temperatureF\":102},{\"id\":70,\"date\":\"2023-07-30\",\"temperatureC\":40,\"summary\":\"Sweltering\",\"temperatureF\":103},{\"id\":71,\"date\":\"2023-07-31\",\"temperatureC\":-11,\"summary\":\"Freezing\",\"temperatureF\":13},{\"id\":72,\"date\":\"2023-08-01\",\"temperatureC\":-6,\"summary\":\"Mild\",\"temperatureF\":22},{\"id\":73,\"date\":\"2023-08-02\",\"temperatureC\":28,\"summary\":\"Balmy\",\"temperatureF\":82},{\"id\":74,\"date\":\"2023-08-03\",\"temperatureC\":23,\"summary\":\"Mild\",\"temperatureF\":73},{\"id\":75,\"date\":\"2023-08-04\",\"temperatureC\":26,\"summary\":\"Hot\",\"temperatureF\":78},{\"id\":76,\"date\":\"2023-08-05\",\"temperatureC\":47,\"summary\":\"Cool\",\"temperatureF\":116},{\"id\":77,\"date\":\"2023-08-06\",\"temperatureC\":-2,\"summary\":\"Cool\",\"temperatureF\":29},{\"id\":78,\"date\":\"2023-08-07\",\"temperatureC\":-9,\"summary\":\"Warm\",\"temperatureF\":16},{\"id\":79,\"date\":\"2023-08-08\",\"temperatureC\":19,\"summary\":\"Mild\",\"temperatureF\":66},{\"id\":80,\"date\":\"2023-08-09\",\"temperatureC\":-6,\"summary\":\"Scorching\",\"temperatureF\":22},{\"id\":81,\"date\":\"2023-08-10\",\"temperatureC\":4,\"summary\":\"Balmy\",\"temperatureF\":39},{\"id\":82,\"date\":\"2023-08-11\",\"temperatureC\":14,\"summary\":\"Freezing\",\"temperatureF\":57},{\"id\":83,\"date\":\"2023-08-12\",\"temperatureC\":23,\"summary\":\"Sweltering\",\"temperatureF\":73},{\"id\":84,\"date\":\"2023-08-13\",\"temperatureC\":-5,\"summary\":\"Freezing\",\"temperatureF\":24},{\"id\":85,\"date\":\"2023-08-14\",\"temperatureC\":14,\"summary\":\"Warm\",\"temperatureF\":57},{\"id\":86,\"date\":\"2023-08-15\",\"temperatureC\":19,\"summary\":\"Chilly\",\"temperatureF\":66},{\"id\":87,\"date\":\"2023-08-16\",\"temperatureC\":0,\"summary\":\"Scorching\",\"temperatureF\":32},{\"id\":88,\"date\":\"2023-08-17\",\"temperatureC\":11,\"summary\":\"Hot\",\"temperatureF\":51},{\"id\":89,\"date\":\"2023-08-18\",\"temperatureC\":42,\"summary\":\"Hot\",\"temperatureF\":107},{\"id\":90,\"date\":\"2023-08-19\",\"temperatureC\":-5,\"summary\":\"Freezing\",\"temperatureF\":24},{\"id\":91,\"date\":\"2023-08-20\",\"temperatureC\":24,\"summary\":\"Warm\",\"temperatureF\":75},{\"id\":92,\"date\":\"2023-08-21\",\"temperatureC\":33,\"summary\":\"Warm\",\"temperatureF\":91},{\"id\":93,\"date\":\"2023-08-22\",\"temperatureC\":-11,\"summary\":\"Mild\",\"temperatureF\":13},{\"id\":94,\"date\":\"2023-08-23\",\"temperatureC\":-17,\"summary\":\"Warm\",\"temperatureF\":2},{\"id\":95,\"date\":\"2023-08-24\",\"temperatureC\":20,\"summary\":\"Chilly\",\"temperatureF\":67},{\"id\":96,\"date\":\"2023-08-25\",\"temperatureC\":1,\"summary\":\"Bracing\",\"temperatureF\":33},{\"id\":97,\"date\":\"2023-08-26\",\"temperatureC\":-3,\"summary\":\"Warm\",\"temperatureF\":27},{\"id\":98,\"date\":\"2023-08-27\",\"temperatureC\":43,\"summary\":\"Hot\",\"temperatureF\":109},{\"id\":99,\"date\":\"2023-08-28\",\"temperatureC\":9,\"summary\":\"Balmy\",\"temperatureF\":48},{\"id\":100,\"date\":\"2023-08-29\",\"temperatureC\":4,\"summary\":\"Cool\",\"temperatureF\":39},{\"id\":101,\"date\":\"2023-08-30\",\"temperatureC\":31,\"summary\":\"Bracing\",\"temperatureF\":87},{\"id\":102,\"date\":\"2023-08-31\",\"temperatureC\":18,\"summary\":\"Chilly\",\"temperatureF\":64},{\"id\":103,\"date\":\"2023-09-01\",\"temperatureC\":18,\"summary\":\"Warm\",\"temperatureF\":64},{\"id\":104,\"date\":\"2023-09-02\",\"temperatureC\":34,\"summary\":\"Balmy\",\"temperatureF\":93},{\"id\":105,\"date\":\"2023-09-03\",\"temperatureC\":24,\"summary\":\"Scorching\",\"temperatureF\":75},{\"id\":106,\"date\":\"2023-09-04\",\"temperatureC\":-20,\"summary\":\"Sweltering\",\"temperatureF\":-3},{\"id\":107,\"date\":\"2023-09-05\",\"temperatureC\":41,\"summary\":\"Chilly\",\"temperatureF\":105},{\"id\":108,\"date\":\"2023-09-06\",\"temperatureC\":11,\"summary\":\"Balmy\",\"temperatureF\":51},{\"id\":109,\"date\":\"2023-09-07\",\"temperatureC\":49,\"summary\":\"Hot\",\"temperatureF\":120},{\"id\":110,\"date\":\"2023-09-08\",\"temperatureC\":-15,\"summary\":\"Freezing\",\"temperatureF\":6},{\"id\":111,\"date\":\"2023-09-09\",\"temperatureC\":5,\"summary\":\"Hot\",\"temperatureF\":40},{\"id\":112,\"date\":\"2023-09-10\",\"temperatureC\":41,\"summary\":\"Sweltering\",\"temperatureF\":105},{\"id\":113,\"date\":\"2023-09-11\",\"temperatureC\":22,\"summary\":\"Chilly\",\"temperatureF\":71},{\"id\":114,\"date\":\"2023-09-12\",\"temperatureC\":-17,\"summary\":\"Warm\",\"temperatureF\":2},{\"id\":115,\"date\":\"2023-09-13\",\"temperatureC\":24,\"summary\":\"Chilly\",\"temperatureF\":75}]", options);
        }
        else
        {
            data = await HttpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }

        data = data!.Where(element =>
            {
                bool result;

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
        table?.ReloadServerData();
    }
}
