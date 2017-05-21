using Comics.Models;
using System;
using System.Threading.Tasks;

namespace Comics.Services
{
    public interface IComicProvider
    {
        Task<Comic> LoadLatestComicAsync();
        Task<Comic> LoadOldestComicAsync();
        Task<Comic> LoadComicAsync(Uri uri);
    }
}
