using System;
using System.Collections.Generic;
using System.Linq;
namespace _220519_waveGoAlgoritm
{
    class Graph
    {
        public List<Edge> edges = new List<Edge>(); 
        private  List<Vertex> wayList = new List<Vertex>(); 
        private int SumWeight { get; set; } // расстояние короткого пути 
        /// <summary>
        /// Добавление вновь созданного ребра в  список всех рёбер (edges) графа . 
        /// </summary>
        public void AddEdge(Vertex point1,Vertex point2,int weight)
        {
            var edge = new Edge(point1, point2, weight);
            edges.Add(edge);
        }
        /// <summary>
        /// Создание путевого листа (wayList).
        /// </summary>
        public List<Vertex> GetVertexisWayList(Vertex start,Vertex finish)   
        {
            start.Level = 0;
            wayList.Add(start);
            for (int i = 0; i < wayList.Count; i++)
            {
                var vertex = wayList[i];
                foreach (var v in GetRelatedVertexis(vertex))
                {
                    if (!wayList.Contains(v)) // если не посещали
                    {
                        v.Level = vertex.Level + 1;
                        wayList.Add(v);
                        if (wayList.Contains(finish)) break; 
                    }
                }
                if (wayList.Contains(finish)) break;
            }
            return wayList; 
        }
        /// <summary>
        /// Создание списка смежных вершин от Point1(From).
        /// </summary>
        public List<Vertex> GetRelatedVertexis(Vertex vertex) // список смежных вершин от Point1
        {

            var resultV = new List<Vertex>();
            foreach (var edge in edges)
            {
                if (edge.Point1 == vertex)
                {
                    resultV.Add(edge.Point2);
                }
            }
            return resultV;
        }
        /// <summary>
        /// Создание списка рёбер от Point2, если другая точка ребра на 1 уровень меньше и присутствует в wayList.
        /// </summary>
        public List<Edge> GetListEdgesP2(Vertex vertex) // список ребер   от Point 2 ниже уровня 
        {
            var resultE = new List<Edge>();
            foreach (var edge in edges)
            {
                if (edge.Point2 == vertex && edge.Point1.Level == vertex.Level - 1&&wayList.Contains(edge.Point1)) // проверить последнее условие
                {
                    resultE.Add(edge);
                }
            }
            return resultE;
        }
        /// <summary>
        /// Алгоритм обхода графа в ширину (волновой алгоритм).
        /// </summary>
        public void WaveGoAlgorinm (Vertex start, Vertex finish)
        {
            SumWeight = 0;
            wayList.Clear();
            wayList = GetVertexisWayList(start,finish);
            if (wayList.Contains(finish))
            {
                var list = new List<Vertex>
                {
                    finish
                };
                var vertex = finish;
              
                while (true)
                {
                    var bestEdge = GetListEdgesP2(vertex).OrderBy(edge => edge.Weight).ElementAt(0); // сортировка рёбер по весу. Ребро с меньшим весом -> в начало списка.
                    vertex = bestEdge.Point1;
                    list.Add(vertex);
                    SumWeight = bestEdge.Weight + SumWeight;
                    if (vertex == start) break;
                }
                list.Reverse();
                Console.Write($"Из точки {start} в точку {finish} есть путь : ");
                foreach (var v in list)
                {
                    Console.Write(v+" ,");
                }
                Console.WriteLine( $" который равен  {SumWeight} км.");
            }
            else
            Console.WriteLine($"Из точки {start} в точку {finish} пути нет.");
        }
    }
}
