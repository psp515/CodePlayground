using System;
namespace DesignPatterns.Decorator;

public abstract class DataSourceDecorator : IDataSource
{
	protected IDataSource dataSource;

	public DataSourceDecorator(IDataSource dataSource)
	{
		this.dataSource = dataSource;
	}

	public abstract string ReadData();

    public abstract void WriteData(string data);
}

