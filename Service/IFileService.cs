using Microsoft.AspNetCore.Http;
using RandomShowEnglish.Model;
using RandomShowEnglish.Model.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Service
{
    public interface IFileService
    {
        string GetPath(PathRequest pathRequest);
        Task SaveFileOnDisk(MemoryStream file, string path);
        Task<List<Word>> GetListWordAsync(IFormFile fileUpload);
    }
}
