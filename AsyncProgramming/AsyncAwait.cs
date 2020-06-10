using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class AsyncAwait
    {
        // CLASS ASYNC FACTORY METHOS
        //public class Foo
        //{
        //    private Foo()
        //    {
        //        // private constructor
        //    }

        //    // async initializer
        //    private async Task<Foo> InitAsync()
        //    {
        //        await Task.Delay(1000);
        //        return this;
        //    }

        //    // factory method
        //    public static Task<Foo> CreateAsync()
        //    {
        //        var f = new Foo();
        //        return f.InitAsync();
        //    }
        //}

        //Foo f = await Foo.CreateAsync();




        // ASYNC INTERFACE PATTERN
        //// interface for async task
        //public interface IAsyncInit
        //{
        //    Task InitTask { get; }
        //}
        //// the class implements interface
        //public class MyClass : IAsyncInit
        //{
        //    public Task InitTask { get; }

        //    public MyClass()
        //    {
        //        // at construction assign task
        //        InitTask = InitAsync();
        //    }

        //    private async Task InitAsync()
        //    {
        //        await Task.Delay(1000);
        //    }
        //}
        //public class MyOtherClass : IAsyncInit
        //{
        //    public readonly MyClass myClass;
        //    public Task InitTask { get; }

        //    public MyOtherClass(MyClass myClass)
        //    {
        //        this.myClass = myClass;
        //        InitTask = InitAsync();
        //    }

        //    private async Task InitAsync()
        //    {
        //        // if dependent by another async class, wait for it to complete task
        //        if (myClass is IAsyncInit ai)
        //            await ai.InitTask;
        //        await Task.Delay(1000);
        //    }
        //}

        //var myClass = new MyClass();
        //var myotherClass = new MyOtherClass(myClass);
        //// check if aync init, then await for completition
        //if (myotherClass is IAsyncInit ai)
        //    await ai.InitTask;





        // ASYNC LAZY INITIALIZATION
        //public class Stuff
        //{
        //    public static int val;

        //    // Lazy class is used to delay the initialization of variables when used
        //    // this example uses lazy initialization with async task execution...
        //    public readonly Lazy<Task<int>> AsyncIncVal = new Lazy<Task<int>>(() => Task.Run(async () =>
        //    {
        //        await Task.Delay(1000);
        //        return val++;
        //    }));

        //    public async Task<int> UseValue()
        //    {
        //        return await AsyncIncVal.Value;
        //    }
        //}
    }
}
