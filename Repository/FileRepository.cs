using Microsoft.EntityFrameworkCore;
using RandomShowEnglish.Entity;
using RandomShowEnglish.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public FileRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task Create(FileUpload file)
        {
            this._dbContext.FileUploads.Add(file);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task Delete(FileUpload file)
        {
            this._dbContext.FileUploads.Remove(file);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<FileUpload> GetFile(Guid id)
        {
            var file = await this._dbContext.FileUploads.FindAsync(id);
            return file;
        }

        public async Task<IEnumerable<FileUpload>> GetFiles()
        {
            var files = await this._dbContext.FileUploads.ToListAsync();
            return files;
        }

        public async Task Update(FileUpload file)
        {
            this._dbContext.FileUploads.Update(file);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
