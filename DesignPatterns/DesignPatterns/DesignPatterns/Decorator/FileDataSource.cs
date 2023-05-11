using System;
namespace DesignPatterns.Decorator;

public class FileDataSource : IDataSource
{
	private readonly string name;

	public FileDataSource(string name)
	{
		this.name = name;
	}

    public string ReadData()
    {
        using var reader = new StreamReader(name);
        return reader.ReadToEnd();
    }

    public void WriteData(string data)
    {
        using var writer = new StreamWriter(name);
        writer.Write(data);
    }
}

