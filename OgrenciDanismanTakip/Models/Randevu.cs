using System;
using System.Collections.Generic;

namespace OgrenciDanismanTakip.Models;

public partial class Randevu
{
    public int RandevuId { get; set; }

    public int OgrenciId { get; set; }

    public int DanismanId { get; set; }

    public DateTime TarihSaat { get; set; }

    public string? Durum { get; set; }

    public virtual Danisman Danisman { get; set; } = null!;

    public virtual Ogrenci Ogrenci { get; set; } = null!;
}
