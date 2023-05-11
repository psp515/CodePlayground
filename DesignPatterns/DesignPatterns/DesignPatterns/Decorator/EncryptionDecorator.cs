using System;
using System.Text;

namespace DesignPatterns.Decorator;

public class EncryptionDecorator : DataSourceDecorator
{
    public EncryptionDecorator(IDataSource dataSource) : base(dataSource)
    {
    }

    public override string ReadData()
    {
        var encodedData = dataSource.ReadData();
        var decodedBytes = Convert.FromBase64String(encodedData);
        return Encoding.UTF8.GetString(decodedBytes);
    }

    public override void WriteData(string data)
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        var encodedData = Convert.ToBase64String(bytes);
        dataSource.WriteData(encodedData);
    }
}

