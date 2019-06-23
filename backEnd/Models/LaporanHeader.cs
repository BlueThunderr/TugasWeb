using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace backEnd.Models
{
    public class LaporanHeader
    {
        public Guid LaporanHeaderId {get; set;}
        public string JudulLaporan {get; set;}
        public string Keterangan {get; set;}
        public string StatusLaporan {get; set;}
        public Guid UserId {get; set;}
        public DateTime TglBuat {get; set;}
        public DateTime? TglSelesai {get; set;}

        // NOTE INI BAGIAN RELASI DATABASE YANG NANTI DI PAKE INCLUDE
        public User User {get; set;}
        public List<LaporanItem> LaporanItems { get; set;}

        [NotMapped] public string Status { get; set; }
    }
}