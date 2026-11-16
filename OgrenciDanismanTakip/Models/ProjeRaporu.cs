using System;
using System.Collections.Generic;

namespace OgrenciDanismanTakip.Models;

public partial class ProjeRaporu
{
    public int RaporId { get; set; }

    public int OgrenciId { get; set; }

    public int DanismanId { get; set; }

    public string DosyaYolu { get; set; } = null!;

    public int? NotDegeri { get; set; }

    public string? Geribildirim { get; set; }

    public virtual Danisman Danisman { get; set; } = null!;

    public virtual Ogrenci Ogrenci { get; set; } = null!;
}
