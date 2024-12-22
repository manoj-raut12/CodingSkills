namespace CodingSkills.AsyncVsMultiThread
{
    public class SequentialVsParallelAsync
    {
        public async Task GetDetails()
        {
            await Task.Delay(1000);
            Console.WriteLine($"{DateTime.Now} call GetDetails() {Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task GetEmpDetails()
        {
            await Task.Delay(1000);
            Console.WriteLine($"{DateTime.Now} call GetEmpDetails() {Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task GetSalaryDetails()
        {
            await Task.Delay(1000);
            Console.WriteLine($"{DateTime.Now} call GetSalaryDetails() {Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task ExecuteParalleTask()
        {
            Console.WriteLine($"{DateTime.Now} Parallel execution started");
            await Task.WhenAll(GetEmpDetails(),GetEmpDetails(), GetSalaryDetails());
        }

        public async Task ExecuteAsyncTask()
        {
            Console.WriteLine($"{DateTime.Now} Sequenectial execution started");
            await GetDetails();
            await GetEmpDetails();
            await GetSalaryDetails();
        }
    }
}
