using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class TaskCoordination
    {
        // CONTINUING TASK
        ////var t = Task.Factory.StartNew(() =>
        ////{
        ////    Console.WriteLine("Boiling water");
        ////    Thread.Sleep(1000);
        ////});
        ////var t2 = t.ContinueWith(cur_t =>
        ////{
        ////    Console.WriteLine($"Boiled (task {cur_t.Id}), pour water in cup");
        ////    Thread.Sleep(1000);
        ////});
        ////t2.Wait();

        //var task1 = Task.Factory.StartNew(() => "Task 1");
        //var task2 = Task.Factory.StartNew(() => "Task 2");

        ////var task3 = Task.Factory.ContinueWhenAll(new[] { task1, task2 }, tasks =>
        ////{
        ////    Console.WriteLine("Task completed:");
        ////    foreach (var tsk in tasks)
        ////    {
        ////        Console.WriteLine(" - " + tsk.Result);
        ////    }
        ////    Console.WriteLine("All Task completed");
        ////});

        //var task3 = Task.Factory.ContinueWhenAny(new[] { task1, task2 }, task =>
        //{
        //    Console.WriteLine("Task completed:");
        //    Console.WriteLine(" - " + task.Result);
        //});




        // CHILD TASK
        //var t1 = new Task(() =>
        //{
        //    var child = new Task(() =>
        //    {
        //        Console.WriteLine("Child started");
        //        Thread.Sleep(2000);
        //        Console.WriteLine("Child finished");
        //        throw new Exception();
        //    }, TaskCreationOptions.AttachedToParent);   // this links child task to parent execution

        //    child.ContinueWith(t =>
        //    {
        //        Console.WriteLine($"OK {t.Id} {t.Status}");
        //    }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion);   // options for correct completition

        //    child.ContinueWith(t =>
        //    {
        //        Console.WriteLine($"KO {t.Id} {t.Status}");
        //    }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnFaulted);   // option for exception completition

        //    child.Start();
        //});

        //t1.Start();

        //try
        //{
        //    t1.Wait();
        //}
        //catch (AggregateException ae)
        //{
        //    ae.Handle(e => true);
        //}





        // BARRIER
        //static Barrier barrier = new Barrier(2, b =>    // 2 = counter, number of tasks to wait
        //{
        //    Console.WriteLine($"Current phase {b.CurrentPhaseNumber}");
        //});

        //static void Water()
        //{
        //    Console.WriteLine("Set up and boil (slow)");
        //    Thread.Sleep(3000);
        //    barrier.SignalAndWait();        // signals to barrier completition of phase and wait number of tasks to complete to continue
        //    Console.WriteLine("Pour water (fast)");
        //    barrier.SignalAndWait();
        //    Console.WriteLine("close heater (fast)");
        //}

        //static void Cup()
        //{
        //    Console.WriteLine("choose cup (fast)");
        //    barrier.SignalAndWait();
        //    Console.WriteLine("choose tea (slow)");
        //    Thread.Sleep(2000);
        //    barrier.SignalAndWait();
        //    Console.WriteLine("add sugar (fast)");
        //}

        //var t1 = Task.Factory.StartNew(Water);
        //var t2 = Task.Factory.StartNew(Cup);

        //var t3 = Task.Factory.ContinueWhenAll(new[] { t1, t2 }, tasks =>
        //{
        //    Console.WriteLine("Enjoy tea");
        //});
        //t3.Wait();



        // COUNTDOWN
        //static int taskCount = 5;
        //static CountdownEvent cde = new CountdownEvent(taskCount);  // similar to barrier, takes count of task to be completed
        //static Random rnd = new Random();
        //for (int i = 0; i < taskCount; i++)
        //{
        //    Task.Factory.StartNew(() =>
        //    {
        //        Console.WriteLine($"Enter task {Task.CurrentId}");
        //        Thread.Sleep(rnd.Next(3000));
        //        cde.Signal();   // just signal completition
        //        Console.WriteLine($"Exit task {Task.CurrentId}");
        //    });
        //}

        //var t = Task.Factory.StartNew(() =>
        //{
        //    Console.WriteLine($"wait in task {Task.CurrentId}");
        //    cde.Wait(); // wait for all the others
        //    Console.WriteLine($"All completed");
        //});
        //t.Wait();




        // RESET EVENT
        ////var resetEvent = new ManualResetEventSlim();    // not works with counter but with one or zero

        ////Task.Factory.StartNew(() =>
        ////{
        ////    Console.WriteLine("boil water");
        ////    resetEvent.Set();   // signal completition
        ////});
        ////var t = Task.Factory.StartNew(() =>
        ////{
        ////    Console.WriteLine("waiting water...");
        ////    resetEvent.Wait();  // WAIT completition
        ////    Console.WriteLine("water ready");
        ////    bool ok = resetEvent.Wait(1000);    // already done, continues
        ////    if (ok)
        ////    {
        ////        Console.WriteLine("tea ready");
        ////    }
        ////    else
        ////    {
        ////        Console.WriteLine("no tea for you");
        ////    }
        ////});
        ////t.Wait();

        //var resetEvent = new AutoResetEvent(false);    // not works with counter but with one or zero, start as not signaled

        //Task.Factory.StartNew(() =>
        //{
        //    Console.WriteLine("boil water");
        //    resetEvent.Set();   // signal completition
        //});
        //var t = Task.Factory.StartNew(() =>
        //{
        //    Console.WriteLine("waiting water...");
        //    resetEvent.WaitOne();  // WAIT completition
        //    Console.WriteLine("water ready");   // this resets the completition before
        //    bool ok = resetEvent.WaitOne(1000);    // waits one second but no signal will arrive... fail
        //    if (ok)
        //    {
        //        Console.WriteLine("tea ready");
        //    }
        //    else
        //    {
        //        Console.WriteLine("no tea for you");
        //    }
        //});
        //t.Wait();






        // SEMAPHORE
        //var semaphore = new SemaphoreSlim(3, 10);   // specify how manu signals to receive to continue and the max possible
        //for (int i = 0; i < 20; i++)
        //{
        //    Task.Factory.StartNew(() =>
        //    {
        //        Console.WriteLine($"Enter task {Task.CurrentId}");
        //        semaphore.Wait();   // decrease counter
        //        Console.WriteLine($"exit task {Task.CurrentId}");
        //    });
        //}

        //while(semaphore.CurrentCount <= 3)
        //{
        //    Console.WriteLine($"Semaphore count {semaphore.CurrentCount}");
        //    Console.ReadKey();  // after count, wait for manual continuation
        //    semaphore.Release(2);   // new number of signals to wait for
        //}
    }
}
