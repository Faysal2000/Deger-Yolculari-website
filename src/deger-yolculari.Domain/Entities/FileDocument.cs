using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deger_yolculari.Domain.Common;

namespace deger_yolculari.Domain.Entities
{
    public class FileDocument: BaseEntity
    {
        public Guid AdminId { get; set; }

        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;

        public string FileType { get; set; } = string.Empty;

        public int FileSizeKB { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow; 



        public User Admin { get; set; } = null!; 
    }
}
