namespace SignalRxMQTT.DataCenter;

public class DataCenterArray
{
    public List<DataCenter> DataCenters { get; set; }
    public DataCenterArray()
    {
        DataCenters = new List<DataCenter>();
    }

    public void AddDataCenter(DataCenter dataCenter)
    {
        DataCenters.Add(dataCenter);
    }

    public DataCenter GetDataCenter(string name)
    {
        return DataCenters.FirstOrDefault(x => x.Name == name);
    }

}
