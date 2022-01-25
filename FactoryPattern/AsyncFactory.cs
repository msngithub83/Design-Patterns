using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class Foo
    {
        private Foo()
        {
            
        }

        private async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        public static Task<Foo> CreateAsync()
        {
            var result = new Foo();
            return result.InitAsync();
        }
    }

    public class AsyncFactory
    {
        //static async void Main(string[] args)
        //{
        //    //var foo = new Foo();
        //    //await foo.InitAsync();
        //   Foo asyncInit =  await Foo.CreateAsync();
        //}
    }
}
