using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace StrVsSpan;

[MemoryDiagnoser]
public class MultipleStrs
{
    private readonly List<string> _words = new ()
        { "[Lorem]","ipsum","[dolor]","[sit]","[amet]","[consectetur]",
            "[adipiscing]","[elit]","[sed]","[do]","[eiusmod]","[tempor]",
            "[incididunt]","[ut]","[labore]","[et]","[dolore]","[magna]",
            "[aliqua.]","[Ut]","[enim]","[ad]","[minim]","[veniam]","[quis]",
            "[nostrud]","[exercitation]","[ullamco]","[laboris]","[nisi]",
            "[ut]","[aliquip]","[ex]","[ea]","[commodo]","[consequat.]",
            "[Duis]","[aute]","[irure]","[dolor]","[in]","[reprehenderit]",
            "[in]","[voluptate]","[velit]","[esse]","[cillum]","[dolore]",
            "[eu]","[fugiat]","[nulla]","[pariatur.]","[Excepteur]","[sint]",
            "[occaecat]","[cupidatat]","[non]","[proident,]","[sunt]","[in]",
            "[culpa]","[qui]","[officia]","[deserunt]","[mollit]","[anim]","[id]","[est]","[laborum.]" };

    [Benchmark]
    public List<string> ChangeAllWordsStr()
    {
        var list = new List<string>();
        foreach (var word in _words)
        {
            list.Add(ChangeAsStr(word));
        }

        return list;
    }

    [Benchmark]
    public List<string> ChangeAllWordsSpan()
    {
        var list = new List<string>();
        foreach (var word in _words)
        {
            list.Add(ChangeAsSpan(word));
        }

        return list;
    }
    
    private static string ChangeAsStr(string str) => $"%{str.TrimStart('[').TrimEnd(']')}%";
    
    private static string ChangeAsSpan(string str) => $"%{str.AsSpan().TrimStart('[').TrimEnd(']')}%";
}