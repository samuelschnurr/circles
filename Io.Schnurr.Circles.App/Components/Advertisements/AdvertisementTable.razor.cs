﻿using System.Net.Http.Json;
using System.Text.Json;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Io.Schnurr.Circles.App.Components.Advertisements;

public partial class AdvertisementTable
{
    [Inject]
    private HttpClient HttpClient { get; set; } = default!;
    private IEnumerable<Advertisement>? pagedData;
    private MudTable<Advertisement>? table;
    private int totalItems;
    private string? searchString;

    private async Task<TableData<Advertisement>> ServerReload(TableState state, bool useStaticData)
    {
        IEnumerable<Advertisement>? data = null;
        // Testdata
        if (useStaticData)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            data = JsonSerializer.Deserialize<IEnumerable<Advertisement>>("[{\"Title\":\"Title1\",\"Description\":\"Description Description1\",\"Price\":1.3,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":1,\"CreatedAt\":\"2023-06-17T12:09:58.5322378+02:00\",\"DeletedAt\":null},{\"Title\":\"Title2\",\"Description\":\"Description Description2\",\"Price\":2.6,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":2,\"CreatedAt\":\"2023-06-16T12:09:58.5323419+02:00\",\"DeletedAt\":null},{\"Title\":\"Title3\",\"Description\":\"Description Description3\",\"Price\":3.9,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":3,\"CreatedAt\":\"2023-06-15T12:09:58.5323435+02:00\",\"DeletedAt\":null},{\"Title\":\"Title4\",\"Description\":\"Description Description4\",\"Price\":5.2,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":4,\"CreatedAt\":\"2023-06-14T12:09:58.5323439+02:00\",\"DeletedAt\":\"2023-06-18T12:05:58.5323441+02:00\"},{\"Title\":\"Title5\",\"Description\":\"Description Description5\",\"Price\":6.5,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":5,\"CreatedAt\":\"2023-06-13T12:09:58.5323551+02:00\",\"DeletedAt\":null},{\"Title\":\"Title6\",\"Description\":\"Description Description6\",\"Price\":7.8,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":6,\"CreatedAt\":\"2023-06-12T12:09:58.5323563+02:00\",\"DeletedAt\":null},{\"Title\":\"Title7\",\"Description\":\"Description Description7\",\"Price\":9.1,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":7,\"CreatedAt\":\"2023-06-11T12:09:58.5323568+02:00\",\"DeletedAt\":null},{\"Title\":\"Title8\",\"Description\":\"Description Description8\",\"Price\":10.4,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":8,\"CreatedAt\":\"2023-06-10T12:09:58.5323573+02:00\",\"DeletedAt\":\"2023-06-18T12:01:58.5323574+02:00\"},{\"Title\":\"Title9\",\"Description\":\"Description Description9\",\"Price\":11.7,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":9,\"CreatedAt\":\"2023-06-09T12:09:58.5323581+02:00\",\"DeletedAt\":null},{\"Title\":\"Title10\",\"Description\":\"Description Description10\",\"Price\":13.0,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":10,\"CreatedAt\":\"2023-06-08T12:09:58.5323628+02:00\",\"DeletedAt\":null},{\"Title\":\"Title11\",\"Description\":\"Description Description11\",\"Price\":14.3,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":11,\"CreatedAt\":\"2023-06-07T12:09:58.5323631+02:00\",\"DeletedAt\":null},{\"Title\":\"Title12\",\"Description\":\"Description Description12\",\"Price\":15.6,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":12,\"CreatedAt\":\"2023-06-06T12:09:58.5323634+02:00\",\"DeletedAt\":\"2023-06-18T11:57:58.5323647+02:00\"},{\"Title\":\"Title13\",\"Description\":\"Description Description13\",\"Price\":16.9,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":13,\"CreatedAt\":\"2023-06-05T12:09:58.532365+02:00\",\"DeletedAt\":null},{\"Title\":\"Title14\",\"Description\":\"Description Description14\",\"Price\":18.2,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":14,\"CreatedAt\":\"2023-06-04T12:09:58.5323652+02:00\",\"DeletedAt\":null},{\"Title\":\"Title15\",\"Description\":\"Description Description15\",\"Price\":19.5,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":15,\"CreatedAt\":\"2023-06-03T12:09:58.5323677+02:00\",\"DeletedAt\":null},{\"Title\":\"Title16\",\"Description\":\"Description Description16\",\"Price\":20.8,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":16,\"CreatedAt\":\"2023-06-02T12:09:58.532368+02:00\",\"DeletedAt\":\"2023-06-18T11:53:58.5323681+02:00\"},{\"Title\":\"Title17\",\"Description\":\"Description Description17\",\"Price\":22.1,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":17,\"CreatedAt\":\"2023-06-01T12:09:58.5323683+02:00\",\"DeletedAt\":null},{\"Title\":\"Title18\",\"Description\":\"Description Description18\",\"Price\":23.4,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":18,\"CreatedAt\":\"2023-05-31T12:09:58.5323686+02:00\",\"DeletedAt\":null},{\"Title\":\"Title19\",\"Description\":\"Description Description19\",\"Price\":24.7,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":19,\"CreatedAt\":\"2023-05-30T12:09:58.5323688+02:00\",\"DeletedAt\":null},{\"Title\":\"Title20\",\"Description\":\"Description Description20\",\"Price\":26.0,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":20,\"CreatedAt\":\"2023-05-29T12:09:58.532369+02:00\",\"DeletedAt\":\"2023-06-18T11:49:58.5323692+02:00\"},{\"Title\":\"Title21\",\"Description\":\"Description Description21\",\"Price\":27.3,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":21,\"CreatedAt\":\"2023-05-28T12:09:58.5323694+02:00\",\"DeletedAt\":null},{\"Title\":\"Title22\",\"Description\":\"Description Description22\",\"Price\":28.6,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":22,\"CreatedAt\":\"2023-05-27T12:09:58.5323696+02:00\",\"DeletedAt\":null},{\"Title\":\"Title23\",\"Description\":\"Description Description23\",\"Price\":29.9,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":23,\"CreatedAt\":\"2023-05-26T12:09:58.5323699+02:00\",\"DeletedAt\":null},{\"Title\":\"Title24\",\"Description\":\"Description Description24\",\"Price\":31.2,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":24,\"CreatedAt\":\"2023-05-25T12:09:58.5323701+02:00\",\"DeletedAt\":\"2023-06-18T11:45:58.5323739+02:00\"},{\"Title\":\"Title25\",\"Description\":\"Description Description25\",\"Price\":32.5,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":25,\"CreatedAt\":\"2023-05-24T12:09:58.5323756+02:00\",\"DeletedAt\":null},{\"Title\":\"Title26\",\"Description\":\"Description Description26\",\"Price\":33.8,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":26,\"CreatedAt\":\"2023-05-23T12:09:58.5323759+02:00\",\"DeletedAt\":null},{\"Title\":\"Title27\",\"Description\":\"Description Description27\",\"Price\":35.1,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":27,\"CreatedAt\":\"2023-05-22T12:09:58.5323762+02:00\",\"DeletedAt\":null},{\"Title\":\"Title28\",\"Description\":\"Description Description28\",\"Price\":36.4,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":28,\"CreatedAt\":\"2023-05-21T12:09:58.5323764+02:00\",\"DeletedAt\":\"2023-06-18T11:41:58.5323766+02:00\"},{\"Title\":\"Title29\",\"Description\":\"Description Description29\",\"Price\":37.7,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":29,\"CreatedAt\":\"2023-05-20T12:09:58.5323768+02:00\",\"DeletedAt\":null},{\"Title\":\"Title30\",\"Description\":\"Description Description30\",\"Price\":39.0,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":30,\"CreatedAt\":\"2023-05-19T12:09:58.532377+02:00\",\"DeletedAt\":null},{\"Title\":\"Title31\",\"Description\":\"Description Description31\",\"Price\":40.3,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":31,\"CreatedAt\":\"2023-05-18T12:09:58.5323773+02:00\",\"DeletedAt\":null},{\"Title\":\"Title32\",\"Description\":\"Description Description32\",\"Price\":41.6,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":32,\"CreatedAt\":\"2023-05-17T12:09:58.5323775+02:00\",\"DeletedAt\":\"2023-06-18T11:37:58.5323776+02:00\"},{\"Title\":\"Title33\",\"Description\":\"Description Description33\",\"Price\":42.9,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":33,\"CreatedAt\":\"2023-05-16T12:09:58.5323779+02:00\",\"DeletedAt\":null},{\"Title\":\"Title34\",\"Description\":\"Description Description34\",\"Price\":44.2,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":34,\"CreatedAt\":\"2023-05-15T12:09:58.5323781+02:00\",\"DeletedAt\":null},{\"Title\":\"Title35\",\"Description\":\"Description Description35\",\"Price\":45.5,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":35,\"CreatedAt\":\"2023-05-14T12:09:58.5323783+02:00\",\"DeletedAt\":null},{\"Title\":\"Title36\",\"Description\":\"Description Description36\",\"Price\":46.8,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":36,\"CreatedAt\":\"2023-05-13T12:09:58.5323786+02:00\",\"DeletedAt\":\"2023-06-18T11:33:58.5323787+02:00\"},{\"Title\":\"Title37\",\"Description\":\"Description Description37\",\"Price\":48.1,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":37,\"CreatedAt\":\"2023-05-12T12:09:58.5323814+02:00\",\"DeletedAt\":null},{\"Title\":\"Title38\",\"Description\":\"Description Description38\",\"Price\":49.4,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":38,\"CreatedAt\":\"2023-05-11T12:09:58.5323816+02:00\",\"DeletedAt\":null},{\"Title\":\"Title39\",\"Description\":\"Description Description39\",\"Price\":50.7,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":39,\"CreatedAt\":\"2023-05-10T12:09:58.5323819+02:00\",\"DeletedAt\":null},{\"Title\":\"Title40\",\"Description\":\"Description Description40\",\"Price\":52.0,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":40,\"CreatedAt\":\"2023-05-09T12:09:58.5323821+02:00\",\"DeletedAt\":\"2023-06-18T11:29:58.5323822+02:00\"},{\"Title\":\"Title41\",\"Description\":\"Description Description41\",\"Price\":53.3,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":41,\"CreatedAt\":\"2023-05-08T12:09:58.5323825+02:00\",\"DeletedAt\":null},{\"Title\":\"Title42\",\"Description\":\"Description Description42\",\"Price\":54.6,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":42,\"CreatedAt\":\"2023-05-07T12:09:58.5323827+02:00\",\"DeletedAt\":null},{\"Title\":\"Title43\",\"Description\":\"Description Description43\",\"Price\":55.9,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":43,\"CreatedAt\":\"2023-05-06T12:09:58.5323829+02:00\",\"DeletedAt\":null},{\"Title\":\"Title44\",\"Description\":\"Description Description44\",\"Price\":57.2,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":44,\"CreatedAt\":\"2023-05-05T12:09:58.5323832+02:00\",\"DeletedAt\":\"2023-06-18T11:25:58.5323833+02:00\"},{\"Title\":\"Title45\",\"Description\":\"Description Description45\",\"Price\":58.5,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":45,\"CreatedAt\":\"2023-05-04T12:09:58.5323835+02:00\",\"DeletedAt\":null},{\"Title\":\"Title46\",\"Description\":\"Description Description46\",\"Price\":59.8,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":46,\"CreatedAt\":\"2023-05-03T12:09:58.5323838+02:00\",\"DeletedAt\":null},{\"Title\":\"Title47\",\"Description\":\"Description Description47\",\"Price\":61.1,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":47,\"CreatedAt\":\"2023-05-02T12:09:58.532384+02:00\",\"DeletedAt\":null},{\"Title\":\"Title48\",\"Description\":\"Description Description48\",\"Price\":62.4,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":48,\"CreatedAt\":\"2023-05-01T12:09:58.5323842+02:00\",\"DeletedAt\":\"2023-06-18T11:21:58.5323844+02:00\"},{\"Title\":\"Title49\",\"Description\":\"Description Description49\",\"Price\":63.7,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":49,\"CreatedAt\":\"2023-04-30T12:09:58.5323846+02:00\",\"DeletedAt\":null},{\"Title\":\"Title50\",\"Description\":\"Description Description50\",\"Price\":65.0,\"Image\":{\"Name\":null,\"MimeType\":null,\"Content\":null},\"Id\":50,\"CreatedAt\":\"2023-04-29T12:09:58.5323848+02:00\",\"DeletedAt\":null}]", options)
                .Where(o => o.DeletedAt == null);
        }
        else
        {
            data = await HttpClient.GetFromJsonAsync<Advertisement[]>("Advertisement");
        }

        data = data!.Where(element =>
            {
                bool result;

                result = string.IsNullOrWhiteSpace(searchString)
                || element.Id.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || element.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || element.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || element.Price.ToCurrency().Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || element.CreatedAt.ToShortDateString().Contains(searchString, StringComparison.OrdinalIgnoreCase);

                return result;
            }).ToArray();

        totalItems = data.Count();

        switch (state.SortLabel)
        {
            case "id_field":
                data = data.OrderByDirection(state.SortDirection, o => o.Id);
                break;
            case "title_field":
                data = data.OrderByDirection(state.SortDirection, o => o.Title);
                break;
            case "description_field":
                data = data.OrderByDirection(state.SortDirection, o => o.Description);
                break;
            case "price_field":
                data = data.OrderByDirection(state.SortDirection, o => o.Price);
                break;
            case "createdAt_field":
                data = data.OrderByDirection(state.SortDirection, o => o.CreatedAt);
                break;
        }

        pagedData = data.Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray();

        return new TableData<Advertisement>() { TotalItems = totalItems, Items = pagedData };
    }

    private void OnSearch(string text)
    {
        searchString = text;
        table?.ReloadServerData();
    }
}
