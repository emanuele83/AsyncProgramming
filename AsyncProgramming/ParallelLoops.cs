using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class ParallelLoops
    {
        // PARALLEL LOOPS
        //static IEnumerable<int> CustomStep(int start, int end, int step)
        //{
        //    for (int i = start; i < end; i += step)
        //    {
        //        yield return i;
        //    }
        //}
        //var a = new Action(() => Console.WriteLine($"First {Task.CurrentId}"));
        //var b = new Action(() => Console.WriteLine($"Second {Task.CurrentId}"));
        //var c = new Action(() => Console.WriteLine($"Third {Task.CurrentId}"));

        //Parallel.Invoke(a, b, c);

        //var po = new ParallelOptions();     // can be created options and passed to for
        //po.CancellationToken = new CancellationToken();     
        //Parallel.For(1, 11, po, i =>    // fix step from inclusive 1 to exclusive 11 (so 10...)
        //{
        //    Console.WriteLine($"{i} sqrt = {i * i}");
        //});
        //// to have a custom step advancement
        //Parallel.ForEach(CustomStep(1, 20, 3), i =>
        //{
        //    Console.WriteLine($"Custom Step {i}");
        //});

        //string[] words = { "a", "Common", "test" };
        //Parallel.ForEach(words, word =>
        //{
        //    Console.WriteLine($"{word} length {word.Length}");
        //});




        // CANCELLATION BREAKING EXCEPTION
        //private static void Demo()
        //{
        //    var cts = new CancellationTokenSource();
        //    ParallelOptions po = new ParallelOptions();
        //    po.CancellationToken = cts.Token;
        //    ParallelLoopResult result = Parallel.For(0, 20, po, (int x, ParallelLoopState state) =>
        //    {
        //        Console.WriteLine($"{x} [{Task.CurrentId}]");
        //        if (x == 10)
        //        {
        //            //state.Stop();
        //            //state.Break();
        //            //throw new Exception();
        //            cts.Cancel();
        //        }
        //    });

        //    Console.WriteLine();
        //    Console.WriteLine($"Execution completed: {result.IsCompleted}");
        //    if(result.LowestBreakIteration.HasValue)
        //        Console.WriteLine($"Last iteration: {result.LowestBreakIteration}");
        //}
        //try
        //{
        //    Demo();
        //}
        //catch (AggregateException ae)
        //{
        //    ae.Handle(e =>
        //    {
        //        Console.WriteLine($"Error {e.GetType()}");
        //        return true;
        //    });
        //}catch(OperationCanceledException oce)
        //{
        //    // manage specific cancellation exceptio
        //    Console.WriteLine($"Error {oce.GetType()}");
        //}





        // THREAD LOCAL STORAGE
        //// this procedure allows to safely calculate the sum of the first 1000 numbers with parallel operations in thread safe mode
        //int sum = 0;
        //Parallel.For(1, 1001,
        //    () => 0,        // initial value for stored value of thread
        //    (x, state, threadLocalStorage) =>      // main execution for thread (with its local stored value)
        //    {
        //        Console.WriteLine($"{Task.CurrentId} local storage = {threadLocalStorage}");
        //        threadLocalStorage += x;
        //        return threadLocalStorage;  // return value!!!
        //    },
        //    storedSum =>       // final execution
        //    {
        //        Console.WriteLine($"{Task.CurrentId} stored sum = {storedSum}");
        //        // add partial calculated sum to the total
        //        Interlocked.Add(ref sum, storedSum);       // interlock sum variable for thread safe operation
        //    });
        //Console.WriteLine($"sum 1..1000 = {sum}");




        // PARTITIONING
        //[Benchmark]
        //public void SquareValuesNotOptimized()
        //{
        //    const int count = 100000;
        //    var values = Enumerable.Range(0, count);
        //    int[] results = new int[count];

        //    Parallel.ForEach(values, val =>
        //    {
        //        results[val] = (int)Math.Pow(val, 2);
        //    });
        //}

        //[Benchmark]
        //public void SquareValuesOptimized()
        //{
        //    const int count = 100000;
        //    int[] results = new int[count];

        //    // this method divide data in smaller chuncks
        //    var parts = Partitioner.Create(0, count, 10000);
        //    // giving partitions to foreach allows a creation of more threads = more parallel executions = faster
        //    Parallel.ForEach(parts, range =>
        //    {
        //        for (int i = range.Item1; i < range.Item2; i++)
        //        {
        //            results[i] = (int)Math.Pow(i, 2);
        //        }
        //    });
        //}
        //// build in release to see output!!
        //// takes time, shows table of timing results
        //var summary = BenchmarkRunner.Run<Program>();
    }
}
