using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class ConcurrentCollections
    {

        // CONCURRENT DICTIONARY
        //static ConcurrentDictionary<string, string> dict = new ConcurrentDictionary<string, string>();
        //public static void AddParis()
        //{
        //    string curThr = Task.CurrentId != null ? Task.CurrentId.ToString() : "MainThread";
        //    if (dict.TryAdd("France", "Paris"))
        //    {
        //        Console.WriteLine($"Paris added by {curThr}");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Paris already added, failed for {curThr}");
        //    }
        //}
        //Task.Factory.StartNew(() =>
        //{
        //    AddParis();
        //});
        //AddParis();

        //dict["Russia"] = "Leningrad";
        //dict.AddOrUpdate("Russia", "Moscow", (k, old) => old + "--> Moscow");
        //Console.WriteLine($"Capital of Russia is {dict["Russia"]}");

        ////dict["Sweden"] = "Uppsala";
        //dict.GetOrAdd("Sweden", "Stockholm");

        //string removed;
        //if(dict.TryRemove("Russia", out removed))
        //{
        //    Console.WriteLine($"Removed {removed}");
        //}
        //else
        //{
        //    Console.WriteLine("Nothing removed");
        //}

        //foreach (var kv in dict)
        //{
        //    Console.WriteLine($" - {kv.Value} is capital of {kv.Key}");
        //}




        // CONCURRENT QUEUE
        //ConcurrentQueue<int> q = new ConcurrentQueue<int>();
        //q.Enqueue(1);
        //    q.Enqueue(2);

        //    int result;
        //    if(q.TryDequeue(out result))
        //    {
        //        Console.WriteLine($"Enqueued {result}");
        //    }
        //    if (q.TryPeek(out result))
        //    {
        //        Console.WriteLine($"Peeked {result}");
        //    }





        // CONCURRENT STACK
        //ConcurrentStack<int> st = new ConcurrentStack<int>();
        //st.Push(1);
        //st.Push(2);
        //st.Push(3);
        //st.Push(4);

        //int resule;
        //if (st.TryPeek(out resule))
        //    Console.WriteLine($"peeked {resule}");

        //if (st.TryPop(out resule))
        //    Console.WriteLine($"popped {resule}");

        //var list = new int[5];
        //string text = "";
        //if (st.TryPopRange(list, 0, 5) > 0)
        //{
        //    text = string.Join(", ", list.Select(x => x.ToString()));
        //}
        //Console.WriteLine($"popped range: {text}");



        // CONCURRENT BAG
        //// list with no ordering (developed for speed)
        //ConcurrentBag<int> bag = new ConcurrentBag<int>();
        //var list = new List<Task>();

        //for (int i = 0; i < 10; i++)
        //{
        //    var cnt = i;
        //    list.Add(Task.Factory.StartNew(() =>
        //    {
        //        bag.Add(cnt);
        //        Console.WriteLine($"{Task.CurrentId} added {i}");
        //        Thread.Sleep(10);
        //        int result;
        //        if (bag.TryPeek(out result))
        //        {
        //            Console.WriteLine($"{Task.CurrentId} peeked {result}");
        //        }
        //    }));
        //}

        //Task.WaitAll(list.ToArray());

        //int last;
        //if(bag.TryTake(out last))
        //{
        //    Console.WriteLine($"last {last}");
        //}




        // BLOCKING COLLECTION (wrapper of concurrent collections)
        //static BlockingCollection<int> messages = new BlockingCollection<int>(new ConcurrentBag<int>(), 10);    // 10 = max number of elements, then add is blocked
        //static CancellationTokenSource cts = new CancellationTokenSource();
        //static Random rnd = new Random();

        //static void ProduceAndConsume()
        //{
        //    var producer = Task.Factory.StartNew(RunProducer, cts.Token);
        //    var consumer = Task.Factory.StartNew(RunConsumer, cts.Token);
        //}

        //private static void RunProducer()
        //{
        //    while (true)
        //    {
        //        cts.Token.ThrowIfCancellationRequested();
        //        var i = rnd.Next(100);
        //        messages.Add(i);
        //        Console.WriteLine($"+ {i}");
        //        Thread.Sleep(100);
        //    }
        //}

        //private static void RunConsumer()
        //{
        //    foreach (var item in messages.GetConsumingEnumerable())
        //    {
        //        cts.Token.ThrowIfCancellationRequested();
        //        Console.WriteLine($"- {item}");
        //        Thread.Sleep(1000);
        //    }
        //}
        //Task.Factory.StartNew(ProduceAndConsume, cts.Token);
        //    Console.ReadKey();
        //    cts.Cancel();

    }
}
