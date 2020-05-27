using RandomShowEnglish.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Repository
{
    public interface IFileRepository
    {
        Task<IEnumerable<FileUpload>> GetFiles();
        Task<FileUpload> GetFile(Guid id);
        Task Create(FileUpload file);
        Task Update(FileUpload file);
        Task Delete(FileUpload file);
    }
}
