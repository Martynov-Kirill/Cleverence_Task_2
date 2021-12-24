static async Task HandlerAsync(CancellationToken token)
{
	while (!token.IsCancellationRequested)
	{
		Console.WriteLine("Enter Handler");
		Thread.Sleep(1000);
		Console.WriteLine("Enter Handler");
		Thread.Sleep(1000);
		Console.WriteLine("Enter Handler");
		Thread.Sleep(1000);
	}
}

await Main(args);

static async Task Main(string[] args)
{
	CancellationTokenSource source = new CancellationTokenSource();

	var delay = 5000;
	var task = new Task(() => HandlerAsync(source.Token)
		.ContinueWith(ex => { ex.Exception.Handle(e => true); }, TaskContinuationOptions.OnlyOnCanceled));

	task.Start();

	if (await Task.WhenAny(task, Task.Delay(delay)) == task)
	{
		Console.WriteLine("Completed successfully");
	}
	else
	{
		source.Cancel();
		Console.WriteLine("Timeout occured");
	}

	Console.WriteLine("Done.");
}