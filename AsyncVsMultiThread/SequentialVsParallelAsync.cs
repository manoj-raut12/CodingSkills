namespace CodingSkills.AsyncVsMultiThread
{
    public class SequentialVsParallelAsync
    {
        public async Task GetDetails(string caller)
        {
            await Task.Delay(1000);
            Console.WriteLine($"{DateTime.Now} {caller} call GetDetails() {Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task GetEmpDetails(string caller)
        {
            await Task.Delay(1000);
            Console.WriteLine($"{DateTime.Now} {caller} call GetEmpDetails() {Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task GetSalaryDetails(string caller)
        {
            await Task.Delay(1000);
            Console.WriteLine($"{DateTime.Now} {caller} call GetSalaryDetails() {Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task ExecuteParalleTask()
        {
            Console.WriteLine($"{DateTime.Now} Parallel execution started");
            await Task.WhenAll(GetEmpDetails("Task"),GetEmpDetails("Task"), GetSalaryDetails("Task"));
        }

        public async Task ExecuteAsyncTask()
        {
            Console.WriteLine($"{DateTime.Now} Sequenectial execution started");
            await GetDetails("Async");
            await GetEmpDetails("Async");
            await GetSalaryDetails("Async");
        }
    }
}
