﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using MudBlazor;

namespace Io.Schnurr.Circles.App.Components.Navigation;

public sealed partial class NavigationMenu : IDisposable
{
    [Inject]
    private NavigationManager NavigationManager { get; init; }

    private readonly (string label, string href, string icon, NavLinkMatch match, bool activeOnRoot)[] navMenuItems =
    {
        ("Board", "board", Icons.Material.Filled.Dashboard, default(NavLinkMatch), true),
        ("Offer", "offer", Icons.Material.Filled.LocalOffer, default(NavLinkMatch), false),
        ("Circles", "circle", Icons.Material.Filled.BubbleChart, default(NavLinkMatch), false)
    };

    protected override async Task OnInitializedAsync()
    {
        NavigationManager.LocationChanged += HandleStateHasChanged;
        await Task.CompletedTask;
    }

    private void HandleStateHasChanged(object? sender, EventArgs e) => InvokeAsync(StateHasChanged);

    private bool IsRootPath() => string.Equals(NavigationManager.Uri, NavigationManager.BaseUri);

    public void Dispose()
    {
        NavigationManager.LocationChanged -= HandleStateHasChanged;
    }
}