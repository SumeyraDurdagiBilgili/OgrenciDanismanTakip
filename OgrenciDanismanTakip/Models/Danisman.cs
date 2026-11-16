using System;
using System.Collections.Generic;

namespace OgrenciDanismanTakip.Models;

public partial class Danisman
{
    public int DanismanId { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string? Unvan { get; set; }

    public string? Bolum { get; set; }

    public virtual ICollection<Ogrenci> Ogrencis { get; set; } = new List<Ogrenci>();

    public virtual ICollection<ProjeRaporu> ProjeRaporus { get; set; } = new List<ProjeRaporu>();

    public virtual ICollection<Randevu> Randevus { get; set; } = new List<Randevu>();
}
