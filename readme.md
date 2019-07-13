# Foreaches Benchmark

Regular foreach is a bit faster than other .ForEach(()=> ..) implementations

```
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.829 (1803/April2018Update/Redstone4)
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview6-012264
  [Host]     : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT


|            Method |       Mean |     Error |     StdDev | Ratio | RatioSD | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |-----------:|----------:|-----------:|------:|--------:|-----:|-------:|------:|------:|----------:|
|    RegularForeach |   256.2 ns |  5.005 ns |   7.643 ns |  1.00 |    0.00 |    1 | 0.2170 |     - |     - |     912 B |
| CollectionForeach |   277.2 ns |  5.520 ns |  10.094 ns |  1.09 |    0.06 |    2 | 0.2437 |     - |     - |    1024 B |
|      UnityForeach |   315.2 ns |  7.922 ns |  23.233 ns |  1.16 |    0.07 |    3 | 0.2537 |     - |     - |    1064 B |
|   ParallelForeach | 3,900.3 ns | 75.977 ns | 131.056 ns | 15.22 |    0.64 |    4 | 0.6638 |     - |     - |    2735 B |
```