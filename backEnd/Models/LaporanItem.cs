using System;

namespace backEnd.Models
{
    public class LaporanItem
    {
        public Guid LaporanItemId { get; set; }
        public Guid LaporanHeaderId { get; set; }
        public string Keterangan { get; set; }
        public DateTime TglBuat { get; set; }
        public Guid UserId {get; set;}
        public bool IsDeteled { get; set; }
        public User User {get; set;}
    }
}