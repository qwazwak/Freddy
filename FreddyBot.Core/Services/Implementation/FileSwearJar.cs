#if fileSwear
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace FreddyBot.Core.Services.Implementation;

public class FileSwearJar : ISwearJar
{
    //static readonly string Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    const string FileName = "swearjar.txt";

    private class FileObject
    {
        public int SwearCount { get; set; } = 0;
        public decimal SwearValue { get; set; } = 0.25m;
        [JsonIgnore]
        public decimal TotalSwearValueCount => SwearCount * SwearValue;

        private string ToJson() => JsonSerializer.Serialize(this);

        public static async Task<FileObject> ReadAsync() => JsonSerializer.Deserialize<FileObject>(await File.ReadAllTextAsync(FileName))!;
        public static FileObject Read() => JsonSerializer.Deserialize<FileObject>(File.ReadAllText(FileName))!;
        public async Task WriteToFileAsync() => await File.WriteAllTextAsync(FileName, ToJson());
        public void WriteToFile() => File.WriteAllText(FileName, ToJson());
    }

    private readonly SemaphoreSlim slimLock = new(1);
    public FileSwearJar()
    {
        if (!File.Exists(FileName))
            new FileObject().WriteToFile();
    }

    public async Task<decimal> GetSwearCount() => (await GetFile()).SwearCount;

    public Task SetSingleSwearValue(decimal value) => ReadWrite(file => file.SwearValue = value);
    public Task AddSwear() => ReadWrite(file => file.SwearCount += 1);
    public async Task<decimal> GetSingleSwearValue() => (await GetFile()).SwearValue;
    public async Task<decimal> GetCurrentValue() => (await GetFile()).TotalSwearValueCount;

    private async Task<FileObject> GetFile()
    {
        await slimLock.WaitAsync();
        try
        {
            return await FileObject.ReadAsync();
        }
        finally
        {
            slimLock.Release();
        }
    }
    private async Task ReadWrite(Action<FileObject> action)
    {
        await slimLock.WaitAsync();
        try
        {
            FileObject file = await FileObject.ReadAsync();
            action.Invoke(file);
            await file.WriteToFileAsync();
        }
        finally
        {
            slimLock.Release();
        }
    }
}
#endif