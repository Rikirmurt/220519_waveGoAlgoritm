using System;
namespace _220519_waveGoAlgoritm
{
    class Program
    {
        static void Main()
        {
            var a = new Vertex("A");
            var b = new Vertex("B");
            var c = new Vertex("C");
            var d = new Vertex("D");
            var e = new Vertex("E");
            var g = new Vertex("G");
            var f = new Vertex("F");

            var graph = new Graph();

            graph.AddEdge(a,b,4);
            graph.AddEdge(a,c,3);
            graph.AddEdge(a,e,7);
            graph.AddEdge(b,d,5);
            graph.AddEdge(b,c,6);
            graph.AddEdge(c,d,11);
            graph.AddEdge(c,e,8);
            graph.AddEdge(d,e,2);
            graph.AddEdge(d,g,10);
            graph.AddEdge(d,f,2);
            graph.AddEdge(e,g,5);
            graph.AddEdge(g,f,3);

            graph.WaveGoAlgorinm(a, b);
            graph.WaveGoAlgorinm(a, c);
            graph.WaveGoAlgorinm(a, d);
            graph.WaveGoAlgorinm(a, e);
            graph.WaveGoAlgorinm(a, f);
            graph.WaveGoAlgorinm(a, g);
            graph.WaveGoAlgorinm(d, f);
            graph.WaveGoAlgorinm(f, a);

            Console.ReadLine();

        }
    }
}
