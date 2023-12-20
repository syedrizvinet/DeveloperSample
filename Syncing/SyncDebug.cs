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
            Parallel.ForEach(items,  i =>
            {
                //var r = await Task.Run(() => i).ConfigureAwait(false);
                var r =  Task.Run(() => i);
                bag.Add(r.Result);
            });

            var list = bag.ToList();
            return list;
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();
            int counter = 0;

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var threads = Enumerable.Range(0, 3)
                .Select(i => new Thread(() => {
                    foreach (var item in itemsToInitialize)
                    {
                       if(!concurrentDictionary.ContainsKey(item))
                        {
                            lock (concurrentDictionary)
                            {
                                concurrentDictionary.GetOrAdd(item, getItem);
                            }
                        }
                       
                    }
                    
                }))
                .ToList();

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}