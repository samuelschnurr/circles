﻿using Io.Schnurr.Circles.App.Models;

namespace Io.Schnurr.Circles.App.Pages;

public partial class Circles
{
    internal PaperSwitchItem[] circles = new PaperSwitchItem[]
    {
        new PaperSwitchItem("Work", true, false, true),
        new PaperSwitchItem("Family", false, true, true),
        new PaperSwitchItem("Friends", false, true, true),
    };
}
