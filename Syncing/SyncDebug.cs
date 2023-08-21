using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            Parallel.ForEach(items, i =>
            {
                var r = i;
                bag.Add(r);
            });
            var list = bag.ToList();
            return list;
        }


        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var threads = itemsToInitialize.Count;

            var countdownEvent = new CountdownEvent(threads);

            foreach (var item in itemsToInitialize)
            {
                ThreadPool.QueueUserWorkItem(state =>
                {
                    var index = (int)state;
                    concurrentDictionary.TryAdd(index, getItem(index));
                    countdownEvent.Signal();
                }, item);
            }

            countdownEvent.Wait();

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

    }
}