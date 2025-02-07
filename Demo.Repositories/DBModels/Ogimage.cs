using System;
using System.Collections.Generic;

namespace Demo.Repositories.DBModels;

public partial class Ogimage
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Ext { get; set; }

    public string? LocalExt { get; set; }

    public bool LocalMirrorFile { get; set; }
}
