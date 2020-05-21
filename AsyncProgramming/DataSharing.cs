using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class DataSharing
    {
        // CRITICAL SECTION
        //public class BankAccount
        //{
        //    object padlock = new object();
        //    public int Balance { get; private set; }
        //    public void Deposit(int amount)
        //    {
        //        lock (padlock)    // shorthand for Monitor.Enter() / Monitor.Exit() functions.. cuold be used Monitor.TryEnter(timeout) for exit after some time
        //        {
        //            Balance += amount;
        //        }
        //    }
        //    public void Withdraw(int amount)
        //    {
        //        lock (padlock)
        //        {
        //            Balance -= amount;
        //        }
        //    }
        //}
        //var tasks = new List<Task>();
        //var ba = new BankAccount();
        //for (int i = 0; i < 10; i++)
        //{
        //    tasks.Add(Task.Factory.StartNew(() =>
        //    {
        //        for (int j = 0; j < 1000; j++)
        //        {
        //            ba.Deposit(100);
        //        }
        //    }));

        //    tasks.Add(Task.Factory.StartNew(() =>
        //    {
        //        for (int j = 0; j < 1000; j++)
        //        {
        //            ba.Withdraw(100);
        //        }
        //    }));
        //}
        //Task.WaitAll(tasks.ToArray());
        //Console.WriteLine($"Current balance {ba.Balance}");




        //INTERLOCK (for low level primitives)
        //public class BankAccount
        //{
        //    private int _balance;

        //    public int Balance { get => _balance; private set => _balance = value; }
        //    public void Deposit(int amount)
        //    {
        //        Interlocked.Add(ref _balance, amount);
        //    }
        //    public void Withdraw(int amount)
        //    {
        //        Interlocked.Add(ref _balance, -amount);

        //        //// this methods below force CPU to not execute following operation before having executed the previuos ones
        //        //Interlocked.MemoryBarrier();
        //        //// or
        //        //Thread.MemoryBarrier();

        //        //// methods to increment/decrement integer atomically
        //        //Interlocked.Increment
        //        //Interlocked.Decrement

        //        //// method for assignment of int var
        //        //Interlocked.Exchange
        //        //// method for conditionally assignment of int var
        //        //Interlocked.CompareExchange
        //    }
        //}
        //var tasks = new List<Task>();
        //var ba = new BankAccount();
        //for (int i = 0; i < 10; i++)
        //{
        //    tasks.Add(Task.Factory.StartNew(() =>
        //    {
        //        for (int j = 0; j < 1000; j++)
        //        {
        //            ba.Deposit(100);
        //        }
        //    }));

        //    tasks.Add(Task.Factory.StartNew(() =>
        //    {
        //        for (int j = 0; j < 1000; j++)
        //        {
        //            ba.Withdraw(100);
        //        }
        //    }));
        //}
        //Task.WaitAll(tasks.ToArray());
        //Console.WriteLine($"Current balance {ba.Balance}");




        // SPIN LOCK
        //public class BankAccount
        //{
        //    public int Balance { get; private set; }
        //    public void Deposit(int amount)
        //    {
        //        Balance += amount;
        //    }
        //    public void Withdraw(int amount)
        //    {
        //        Balance -= amount;
        //    }
        //}
        //var tasks = new List<Task>();
        //var ba = new BankAccount();
        //// spin... methods pause execution and wait but without "releasing" CPU (opposite to thread.sleep)
        //SpinLock sl = new SpinLock();
        //for (int i = 0; i < 10; i++)
        //{
        //    tasks.Add(Task.Factory.StartNew(() =>
        //    {
        //        for (int j = 0; j < 1000; j++)
        //        {
        //            var lockTAken = false;
        //            try
        //            {
        //                sl.Enter(ref lockTAken);
        //                ba.Deposit(100);
        //            }
        //            finally
        //            {
        //                if (lockTAken) sl.Exit();
        //            }
        //        }
        //    }));
        //    tasks.Add(Task.Factory.StartNew(() =>
        //    {
        //        for (int j = 0; j < 1000; j++)
        //        {
        //            var lockTAken = false;
        //            try
        //            {
        //                sl.Enter(ref lockTAken);
        //                ba.Withdraw(100);
        //            }
        //            finally
        //            {
        //                if (lockTAken) sl.Exit();
        //            }
        //        }
        //    }));
        //}
        //Task.WaitAll(tasks.ToArray());
        //Console.WriteLine($"Current balance {ba.Balance}");



        // MUTEX
        //public class BankAccount
        //{
        //    public int Balance { get; private set; }
        //    public void Deposit(int amount)
        //    {
        //        Balance += amount;
        //    }
        //    public void Withdraw(int amount)
        //    {
        //        Balance -= amount;
        //    }
        //    public void Transfer(BankAccount dest, int amount)
        //    {
        //        Withdraw(amount);
        //        dest.Deposit(amount);
        //    }
        //}
        //var tasks = new List<Task>();
        //var ba = new BankAccount();
        //var ba2 = new BankAccount();

        //var mutex = new Mutex();
        //var mutex2 = new Mutex();

        //for (int i = 0; i < 10; i++)
        //{
        //    tasks.Add(Task.Factory.StartNew(() =>
        //    {
        //        for (int j = 0; j < 1000; j++)
        //        {
        //            bool haveMutex = mutex.WaitOne(); // is possible to add a timeout to avoid dead lock (exit after timeout)
        //            try
        //            {
        //                ba.Deposit(1);
        //            }
        //            finally
        //            {
        //                if (haveMutex) mutex.ReleaseMutex();
        //            }
        //        }
        //    }));

        //    tasks.Add(Task.Factory.StartNew(() =>
        //    {
        //        for (int j = 0; j < 1000; j++)
        //        {
        //            bool haveMutex = mutex2.WaitOne(); // is possible to add a timeout to avoid dead lock
        //            try
        //            {
        //                ba2.Deposit(1);
        //            }
        //            finally
        //            {
        //                if (haveMutex) mutex2.ReleaseMutex();
        //            }
        //        }
        //    }));

        //    tasks.Add(Task.Factory.StartNew(() =>
        //    {
        //        for (int j = 0; j < 1000; j++)
        //        {
        //            bool haveMutex = Mutex.WaitAll(new[] { mutex, mutex2 });      // WaitHandle class wrapper
        //            try
        //            {
        //                ba.Transfer(ba2, 1);
        //            }
        //            finally
        //            {
        //                if (haveMutex)
        //                {
        //                    mutex.ReleaseMutex();
        //                    mutex2.ReleaseMutex();
        //                }
        //            }
        //        }
        //    }));
        //}
        //Task.WaitAll(tasks.ToArray());
        //Console.WriteLine($"Current ba balance {ba.Balance}");
        //Console.WriteLine($"Current ba2 balance {ba2.Balance}");

        // APP MUTEX
        //const string appName = "MyApp";

        //// OPTION 1
        //bool owned;
        //Mutex mutex = new Mutex(true, appName, out owned);
        //if (!owned)
        //{
        //    Console.WriteLine($"{appName} already running");
        //    // Console app
        //    System.Environment.Exit(1);
        //}
        //else
        //{
        //    Console.WriteLine("Running");
        //}

        //// OPTION 2
        //Mutex mutex;
        //try
        //{
        //    mutex = Mutex.OpenExisting(appName);
        //    Console.WriteLine($"{appName} already running");
        //    // Console app
        //    System.Environment.Exit(1);
        //}
        //catch
        //{
        //    mutex = new Mutex(true, appName);
        //    Console.WriteLine("Running");
        //}

        //Console.WriteLine("script ended");
        //Console.ReadKey();
        //mutex.ReleaseMutex();



        // READ WRITE LOKS (allows to manage lock differently if reading or writing operation)
        //ReaderWriterLockSlim rwl = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion); // is possible to use recursively...
        //int x = 0;
        //Task.Factory.StartNew(() =>
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        //rwl.EnterReadLock(); // common use, able only to read, not write meanwhile
        //        //rwl.EnterReadLock(); // if recursion activated, could be able to call it many times...
        //        rwl.EnterUpgradeableReadLock(); // this function gives ability to enter write lock while in read lock...

        //        Console.WriteLine($"t1 x = {x}");

        //        if(i%2 == 0)
        //        {
        //            rwl.EnterWriteLock();
        //            x++;
        //            rwl.ExitWriteLock();
        //        }

        //        rwl.ExitUpgradeableReadLock();
        //        //rwl.ExitReadLock(); // if recursion activated, could be able to call it many times...
        //        //rwl.ExitReadLock();
        //    }
        //});
        //Task.Factory.StartNew(() =>
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        //rwl.EnterReadLock(); // common use, able only to read, not write meanwhile
        //        //rwl.EnterReadLock(); // if recursion activated, could be able to call it many times...
        //        rwl.EnterUpgradeableReadLock(); // this function gives ability to enter write lock while in read lock...

        //        Console.WriteLine($"t2 x = {x}");

        //        if (i % 2 == 0)
        //        {
        //            rwl.EnterWriteLock();
        //            x++;
        //            rwl.ExitWriteLock();
        //        }

        //        rwl.ExitUpgradeableReadLock();
        //        //rwl.ExitReadLock(); // if recursion activated, could be able to call it many times...
        //        //rwl.ExitReadLock();
        //    }
        //});

    }
}
