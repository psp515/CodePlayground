using Microsoft.AspNetCore.SignalR;
using SignalRxMQTT;
using SignalRxMQTT.DataCenter;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddSingleton<DataCenterArray>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(app => app
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()); 

app.MapHub<UserHub>("datacenter");

var dataCenterArray = app.Services.GetRequiredService<DataCenterArray>();
var hubcontext = app.Services.GetRequiredService<IHubContext<UserHub, IMqttTransitionClient>>();

var dc1 = new DataCenter("dc1", "ef57f832f11b4e89960ef452f56e6aa3.s2.eu.hivemq.cloud", "quest", "Quest123", hubcontext);
var dc2 = new DataCenter("dc2", "da9c85bf397c4910b03ad4656cf8cd67.s1.eu.hivemq.cloud", "quest", "Quest123", hubcontext);

dataCenterArray.AddDataCenter(dc1);
dataCenterArray.AddDataCenter(dc2);


app.Run();
