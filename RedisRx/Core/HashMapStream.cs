﻿using System;
using System.Reactive.Linq;
using StackExchange.Redis;

namespace RedisRx
{
    public static class X
    {
        public static IObservable<TResult> CombineWithPrevious<TSource, TResult>(
            this IObservable<TSource> source,
            Func<TSource, TSource, TResult> resultSelector)
        {
            return source.Scan(Tuple.Create(default(TSource), default(TSource)),
                (previous, current) => Tuple.Create(previous.Item2, current))
                .Select(t => resultSelector(t.Item1, t.Item2));
        }
    }

    //public class MockProvider : IHashMapProviderAsync
    //{
    //    public Task<HashEntry[]> GetNext(string k)
    //    {
    //        return Task.FromResult(new HashEntry[2]);
    //    }
    //}

    public class HashEntryComparer
    {
        public HashEntry[] Compare(HashEntry[] prev, HashEntry[] current)
        {
            return current;
        }
    }
}