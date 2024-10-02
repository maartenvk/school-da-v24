using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD
{
    public partial class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;

        public Dictionary<string, Vertex> vertexMap;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Graph()
        {
            vertexMap = new();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Adds a vertex to the graph. If a vertex with the given name
        ///    already exists, no action is performed.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        public void AddVertex(string name)
        {
            vertexMap.TryAdd(name, new Vertex(name));
        }


        /// <summary>
        ///    Gets a vertex from the graph by name. If no such vertex exists,
        ///    a new vertex will be created and returned.
        /// </summary>
        /// <param name="name">The name of the vertex</param>
        /// <returns>The vertex withe the given name</returns>
        public Vertex GetVertex(string name)
        {
            if (vertexMap.TryGetValue(name, out Vertex vertex))
            {
                return vertex;
            }

            return vertexMap[name] = new(name);
        }


        /// <summary>
        ///    Creates an edge between two vertices. Vertices that are non existing
        ///    will be created before adding the edge.
        ///    There is no check on multiple edges!
        /// </summary>
        /// <param name="source">The name of the source vertex</param>
        /// <param name="dest">The name of the destination vertex</param>
        /// <param name="cost">cost of the edge</param>
        public void AddEdge(string source, string dest, double cost = 1)
        {
            Vertex src = GetVertex(source);
            Vertex dst = GetVertex(dest);
            Edge edge = new(dst, cost);

            src.adj.AddLast(edge);
        }


        /// <summary>
        ///    Clears all info within the vertices. This method will not remove any
        ///    vertices or edges.
        /// </summary>
        public void ClearAll()
        {
            foreach (string name in vertexMap.Keys)
            {
                Vertex v = GetVertex(name);
                v.Reset();
            }
        }

        /// <summary>
        ///    Performs the Breatch-First algorithm for unweighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Unweighted(string name)
        {
            GetVertex(name).distance = 0;

            Queue<string> order = new();
            order.Enqueue(name);

            while (order.Count > 0)
            {
                string currentName = order.Dequeue();
                Vertex current = GetVertex(currentName);
                current.known = true;

                // add current children
                foreach (Edge e in current.GetAdjacents())
                {
                    Vertex dest = e.dest;
                    double expectedDistance = current.distance + 1;

                    if (dest.distance <= expectedDistance)
                    {
                        continue;
                    }

                    dest.prev = current;
                    dest.distance = expectedDistance;
                    order.Enqueue(dest.name);
                }
            }
        }

        /// <summary>
        ///    Performs the Dijkstra algorithm for weighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Dijkstra(string name)
        {
            Vertex start = GetVertex(name);
            start.distance = 0;
            start.prev = null;

            PriorityQueue<Vertex> pq = new();
            pq.Add(start);

            while (!pq.IsEmpty())
            {
                Vertex v = pq.Remove();
                v.known = true;

                foreach (Edge e in v.GetAdjacents())
                {
                    double expectedDistance = e.cost + v.distance;

                    Vertex dest = e.dest;
                    if (dest.distance <= expectedDistance)
                    {
                        continue;
                    }

                    dest.prev = v;
                    dest.distance = expectedDistance;

                    pq.Add(dest);
                }
            }
        }

        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Converts this instance of Graph to its string representation.
        ///    It will call the ToString method of each Vertex. The output is
        ///    ascending on vertex name.
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (string key in vertexMap.Keys.OrderBy(x => x))
            {
                sb.Append(vertexMap[key].ToString());
                sb.Append('\n');
            }

            if (vertexMap.Count != 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------



        public bool IsConnected()
        {
            foreach (string source in vertexMap.Keys)
            {
                Unweighted(source);

                foreach (string name in vertexMap.Keys)
                {
                    Vertex v = GetVertex(name);
                    if (!v.known)
                    {
                        return false;
                    }
                }

                ClearAll();
            }

            return true;
        }

        public List<Vertex> ShortestRoute(string from, string to, bool doSearch = true, bool useDijkstra = false)
        {
            List<Vertex> route = new();

            if (doSearch)
            {
                ClearAll();
                if (useDijkstra)
                {
                    Dijkstra(from);
                }
                else
                {
                    Unweighted(from);
                }
            }

            Vertex v = GetVertex(to);
            while (v is not null)
            {
                route.Add(v);
                v = v.prev;
            }

            ClearAll();
            route.Reverse();
            return route;
        }
    }
}
