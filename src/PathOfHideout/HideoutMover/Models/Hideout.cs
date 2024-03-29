﻿using Newtonsoft.Json;
using PathOfHideout.HideoutMover.Utilities;
using System.Collections.Generic;

namespace PathOfHideout.HideoutMover.Models;

public sealed class Hideout
{
    public Hideout()
    {
        Decorations = new(new DuplicateKeyComparer<string>());
    }

    [JsonProperty("version")]
    public int Version { get; set; }

    [JsonProperty("language")]
    public string Language { get; set; } = null!;

    [JsonProperty("hideout_name")]
    public string HideoutName { get; set; } = null!;

    [JsonProperty("hideout_hash")]
    public long HideoutHash { get; set; }

    [JsonProperty("doodads")]
    public Dictionary<string, Decoration> Decorations { get; set; }
}