using System;
using System.Collections.Generic;

namespace OgrenciDanismanTakip.Models;

public partial class Ogrenci
{
    public int OgrenciId { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string Eposta { get; set; } = null!;

    public int? DanismanId { get; set; }

    public virtual Danisman? Danisman { get; set; }

    public virtual ICollection<ProjeRaporu> ProjeRaporus { get; set; } = new List<ProjeRaporu>();

    public virtual ICollection<Randevu> Randevus { get; set; } = new List<Randevu>();
}
