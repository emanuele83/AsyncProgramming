using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class ParallelLinq
    {
        // AS PARALLEL
        //int count = 50;
        //var values = Enumerable.Range(1, count).ToArray();
        //var results = new int[count];

        //// executes operation in not particular order but in more threads
        //values.AsParallel().ForAll(i =>
        //{
        //    int newValue = i * i * i;
        //    results[i - 1] = newValue;

        //    Console.Write($"{newValue} ({Task.CurrentId})\t");
        //});
        //Console.WriteLine();
        //Console.WriteLine();
        //Console.WriteLine();
        //// executes the calculation respecting the initial order (actually its a lazy operation... until usage of variable nothing is done)
        //var cubes = values.AsParallel().AsOrdered().Select(x => x * x * x);
        //foreach (var item in cubes)
        //{
        //    Console.Write($"{item}\t");
        //}




        // CANCELLATION
        //var cts = new CancellationTokenSource();
        //var values = ParallelEnumerable.Range(1, 20);

        //var results = values.WithCancellation(cts.Token).Select(x =>
        //{
        //    double result = Math.Log10(x);

        //    //if (result > 1) throw new InvalidOperationException();

        //    Console.WriteLine($"i = {x}, tid = {Task.CurrentId}");
        //    return result;
        //});

        //try
        //{
        //    foreach (var item in results)
        //    {
        //        if (item > 1) cts.Cancel();
        //        Console.WriteLine($"Result = {item}");
        //    }
        //}catch(AggregateException ae)
        //{
        //    ae.Handle(e =>
        //    {
        //        Console.WriteLine($"{e.GetType().Name}: {e.Message}");
        //        return true;
        //    });
        //}catch(OperationCanceledException e)
        //{
        //    Console.WriteLine("Canceld");
        //}




        // MERGE OPTIONS
        //var values = Enumerable.Range(1, 20);

        //var results = values.AsParallel()
        //    //.WithMergeOptions(ParallelMergeOptions.FullyBuffered)     // waits to consume data when all data available
        //    .WithMergeOptions(ParallelMergeOptions.NotBuffered)         // consumes data as soon it is available
        //    .Select(x =>
        //{
        //    var result = Math.Log10(x);
        //    Console.Write($"P {result}\t");
        //    return result;
        //});
        //foreach (var item in results)
        //{
        //    Console.Write($"C {item}\t");
        //}




        // CUSTOM AGGREGATION
        //var sum = Enumerable.Range(1, 1000).Sum();
        //Console.WriteLine($"sum = {sum}");
        //var sum1 = Enumerable.Range(1, 1000).Aggregate(
        //    0,          // initial value
        //    (i, accumulator) => accumulator += i);  // add cur valule to accumulator
        //Console.WriteLine($"sum = {sum1}");
        //var sum2 = ParallelEnumerable.Range(1, 1000)    // parallel option
        //    .Aggregate(
        //    0,      // initial value
        //    (i, accumulator) => accumulator += i,   // add cur value to cur task accumulator
        //    (total, subTotal) => total += subTotal,     // add each task subtotal to total calculation
        //    result => result        // get result
        //    );
        //Console.WriteLine($"sum = {sum2}");
    }
}
