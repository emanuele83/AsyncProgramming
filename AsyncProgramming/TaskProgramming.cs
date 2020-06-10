using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class TaskProgramming
    {
// TASK CREATION
        static void Write(char c)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(c);
            }
        }
        //Task.Factory.StartNew(() => Write('.'));
        //var t = new Task(() => Write('-'));
        //t.Start();
        //Write('?');

        static void Write(object o)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(o);
            }
        }
        //Task t = new Task(Write, "abc");
        //t.Start();
        //Task.Factory.StartNew(Write, 123);

        static int TxtLen(object o)
        {
            Console.WriteLine($"Task {Task.CurrentId} is processing {o}");
            return o.ToString().Length;
        }
        //string txt1 = "hello", txt2 = "world";
        //var t1 = new Task<int>(TxtLen, txt1);
        //t1.Start();
        //Task<int> t2 = Task.Factory.StartNew<int>(TxtLen, txt2);
        //Console.WriteLine($"'{txt1}' is {t1.Result}");
        //Console.WriteLine($"'{txt2}' is {t2.Result}");





        // TASK CANCEL
        //var cts = new CancellationTokenSource();
        //var token = cts.Token;
        //token.Register(() =>
        //{
        //    Console.WriteLine($"Cancellation requested");
        //});
        //var t = new Task(() =>
        //{
        //    int i = 0;
        //    while (true)
        //    {
        //        //if (token.IsCancellationRequested)
        //        //{
        //        //    //break;    // solution 1 "soft fail"
        //        //    //throw new OperationCanceledException();   // solution 2 (not problem for exception)
        //        //}
        //        token.ThrowIfCancellationRequested();   // solution 3 (canonical solution, check request and throws exception)
        //        Console.WriteLine($"{i++}");
        //    }
        //}, token);
        //t.Start();

        //Task.Factory.StartNew(() =>
        //{
        //    // do something
        //    token.WaitHandle.WaitOne();
        //    Console.WriteLine("Handle arrived after long wait...");
        //});

        //Console.ReadKey();
        //cts.Cancel();





        // MULTI CANCEL TOKEN
        //var tk_planned = new CancellationTokenSource();
        //var tk_requested = new CancellationTokenSource();
        //var tk_emergency = new CancellationTokenSource();

        //// create a collection of many tokens
        //var paranoid = CancellationTokenSource.CreateLinkedTokenSource(tk_planned.Token, tk_requested.Token, tk_emergency.Token);

        //Task.Factory.StartNew(() =>
        //{
        //    int i = 0;
        //    while (true)
        //    {
        //        paranoid.Token.ThrowIfCancellationRequested();
        //        Console.WriteLine($"{i++}");
        //        Thread.Sleep(100);
        //    }
        //}, paranoid.Token);

        //Console.ReadKey();
        //// whatever token ask cancellation, task stops
        //tk_emergency.Cancel();





        // TASK WAIT (PS. Thread.Sleep is alternative to pause execution)
        //var cts = new CancellationTokenSource();
        //var token = cts.Token;

        //Task.Factory.StartNew(() =>
        //{
        //    Console.WriteLine("5 seconds to disarm, be quick!!!");
        //    bool cancelled = token.WaitHandle.WaitOne(5000);
        //Console.WriteLine(cancelled? "disarmed, good!" : "oh noo! BOOM!!!!");
        //}, token);

        //Console.ReadKey();
        //cts.Cancel();
        //var cts = new CancellationTokenSource();
        //var token = cts.Token;

        //var t1 = Task.Factory.StartNew(() =>
        //{
        //    Console.WriteLine("wait 5 sec");
        //    for (int i = 0; i < 5; i++)
        //    {
        //        token.ThrowIfCancellationRequested();
        //        Thread.Sleep(1000);
        //        Console.WriteLine($"1 - {i}");
        //    }
        //}, token);

        //var t2 = Task.Factory.StartNew(() =>
        //{
        //    Console.WriteLine("wait 3 sec");
        //    for (int i = 0; i < 3; i++)
        //    {
        //        token.ThrowIfCancellationRequested();
        //        Thread.Sleep(1000);
        //        Console.WriteLine($"2 - {i}");
        //    }
        //}, token);

        ////t1.Wait(6000, token); // option for single task
        ////Task.WaitAll(new[] { t1, t2 }, 4000, token);    // waits for all tasks or max time span or cancellation
        //Task.WaitAny(new[] { t1, t2 }, 4000, token);  // waits for the first to complete

        //Console.WriteLine($"task 1 in status {t1.Status}");
        //Console.WriteLine($"task 2 in status {t2.Status}");



        // EXCEPTION HANDLING
        //try
        //{
        //    Test();
        //}
        //catch (AggregateException ae)
        //{
        //    foreach(var e in ae.InnerExceptions)
        //    {
        //        Console.WriteLine($"Handled outside: {e.GetType()} from {e.Source}");
        //    }
        //}
        static void Test()
        {
            var t = Task.Factory.StartNew(() => throw new InvalidOperationException("Can't do this") { Source = "t" });
            var t2 = Task.Factory.StartNew(() => throw new AccessViolationException("Can't access this") { Source = "t2" });

            try
            {
                Task.WaitAll(t, t2);    // without this line no exception is shown on main thread
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    if (e is InvalidOperationException)
                    {
                        Console.WriteLine("invalid OP!");
                        return true;
                    }
                    else return false;
                });
            }
        }
    }
}
