namespace DesignPatterns.Decorator;

public interface IDataSource
{
    string ReadData();
    void WriteData(string data);
}

