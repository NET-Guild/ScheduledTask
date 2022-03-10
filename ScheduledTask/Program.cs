using Coravel;
using ScheduledTask;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScheduler();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScheduler();

var app = builder.Build();

var provider = ((IApplicationBuilder)app).ApplicationServices;
provider.UseScheduler(scheduler =>
{
    scheduler.ScheduleAsync(async () =>
        {
            var counter = new Counter();
            counter.CounterHours(DateTime.Now.Hour);
        })
        .DailyAt(1, 50);
    //UTC hour reference: https://time.is/pt_br/UTC

    scheduler.ScheduleAsync(async () =>
        {
            Console.WriteLine("In UTC the time is: "+DateTime.Now.ToUniversalTime().TimeOfDay);
        })
        .EverySecond();
});

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
