using System;
using BenchmarkDotNet.Running;

namespace StrVsSpan;

static class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<MultipleStrs>();
    }
}