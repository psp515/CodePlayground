using System;
using static System.Net.Mime.MediaTypeNames;
using System.IO.Compression;
using System.Text;

namespace DesignPatterns.Decorator;

public class CompressionDecorator : DataSourceDecorator
{
    public CompressionDecorator(IDataSource dataSource) : base(dataSource)
    {
    }

    public override string ReadData()
    {
        var compressedText = dataSource.ReadData();
        byte[] compressedData = Convert.FromBase64String(compressedText);
        using var memoryStream = new MemoryStream(compressedData);
        using var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
        using var streamReader = new StreamReader(gzipStream);

        return streamReader.ReadToEnd();
    }

    public override void WriteData(string data)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(data);
        using var memoryStream = new MemoryStream();

        using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
        {
            gzipStream.Write(buffer, 0, buffer.Length);
        }
        memoryStream.Position = 0;
        var compressedData = new byte[memoryStream.Length];
        memoryStream.Read(compressedData, 0, compressedData.Length);
        var base64EncodedString = Convert.ToBase64String(compressedData);

        dataSource.WriteData(data);
    }
}

