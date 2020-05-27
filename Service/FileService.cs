using ClosedXML.Excel;
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
    public class FileService : IFileService
    {
        public async Task<List<Word>> GetListWordAsync(IFormFile fileUpload)
        {
            return await Task.FromResult(GetListWord(fileUpload));
        }

        public string GetPath(PathRequest pathRequest)
        {
            var year = DateTime.Now.Year.ToString();
            var month = DateTime.Now.Month.ToString();
            var date = DateTime.Now.Day.ToString();
            var pathDirectory = Path.Combine(pathRequest.ServerPath, year, month, date);
            if (string.IsNullOrEmpty(pathRequest.FileName))
            {
                return pathDirectory;
            }

            return Path.Combine(pathDirectory, pathRequest.FileName);
        }

        public async Task SaveFileOnDisk(MemoryStream file, string path)
        {
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    await file.FlushAsync();
                }
            }
        }

        private List<Word> GetListWord(IFormFile fileUpload)
        {
            List<Word> listWord = new List<Word>();
            using (var workbook = new XLWorkbook(fileUpload.OpenReadStream()))
            {
                // get first worksheet
                var ws = workbook.Worksheet(1);

                // get row and column is used
                var rows = ws.RangeUsed().RowsUsed().ToList();
                var columns = ws.RangeUsed().ColumnsUsed().ToList();
                foreach (var row in rows)
                {
                    Word word = new Word();
                    int count = 0;
                    foreach (var column in columns)
                    {
                        // get column and row number
                        var columNumber = column.ColumnNumber();
                        var rowNumer = row.RowNumber();

                        // get cell data
                        var cell = ws.Cell(rowNumer, columNumber);
                        var data = cell.Value.ToString();

                        switch (count)
                        {
                            // for first cell of row is Name of Word
                            case 0:
                                word.Name = data;
                                break;

                            // for second cell of row is Sysnonyme of Word
                            case 1:
                                word.Synonym = data;
                                break;

                            // for third cell of row is Mean of Word
                            default:
                                word.Mean = data;
                                break;
                        }
                        count++;
                    }

                    listWord.Add(word);
                }
            }
            return listWord;
        }
    }
}
