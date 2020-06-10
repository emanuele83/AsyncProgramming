using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncForms
{
    public partial class Form1 : Form
    {
        //// blocking mode
        //public int Calculate()
        //{
        //    Thread.Sleep(5000);
        //    return 123;
        //}

        //// with task
        //public Task<int> CalculateValueAsync()
        //{
        //    return Task.Factory.StartNew(() =>
        //    {
        //        Thread.Sleep(5000);
        //        return 123;
        //    });
        //}


        // with async await
        // NB the method signature must have async keyword
        public async Task<int> CalculateValueAsync()
        {
            await Task.Delay(5000);
            return 123;
        }


        public Form1()
        {
            InitializeComponent();
        }

        // NB the method signature must have async keyword to use await keyword
        private async void button1_Click(object sender, EventArgs e)
        {
            //// blocking mode
            //int n = Calculate();
            //label1.Text = n.ToString();

            //// with task
            //var calculation = CalculateValueAsync();
            //calculation.ContinueWith(t =>
            //{
            //    label1.Text = t.Result.ToString();
            //}, TaskScheduler.FromCurrentSynchronizationContext());

            //with async await
            var calc = await CalculateValueAsync();
            label1.Text = calc.ToString();  // with async/await the following lines are as in the ContinueWith function of Task

            await Task.Delay(5000);
            label1.Text = "Let's get web content";

            using (var wc = new WebClient())
            {
                var text = await wc.DownloadStringTaskAsync("http://google.com/robots.txt");
                label1.Text = text.Split('\n')[0].Trim();
            }

            // Task.Run wraps sync or async delegates, the first await unwraps from the returned Task object of Run call
            // the required result type
            // Task.Run = Task.Factory.StartNew  =>  both return Task<T> => with the await keyword the type T is returned
            // sync delegate
            label2.Text = await Task.Run(() =>
            {
                return "Waiting";
            });
            // async delegate
            label2.Text = await Task.Run(async () =>
            {
                await Task.Delay(3000);
                return "Completed";
            });

            var t = Task.Run(() =>
            {
                Thread.Sleep(1000);
                return "fast";
            });

            var t2 = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return "slow";
            });

            // if the returned value is Task<Task<T>> can be used more await keywords to unwrap result type!!!
            // whenAny waits for any task to complete ( and return a resulting  task)
            //label3.Text = await await Task.WhenAny(new[] { t, t2 });        
            // whenAll waits for all task to complete ( and return a resulting  task)
            label3.Text = string.Join(", ", await Task.WhenAll(new[] { t, t2 }));        
        }
    }
}
