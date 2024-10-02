using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AD
{
    public partial class Vertex : IVertex
    {
        public string name;
        public LinkedList<Edge> adj;
        public double distance;
        public Vertex prev;
        public bool known;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        /// <summary>
        ///    Creates a new Vertex instance.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        public Vertex(string name)
        {
            this.name = name;
            adj = new();
            Reset();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public string GetName()
        {
            return name;
        }

        public LinkedList<Edge> GetAdjacents()
        {
            return adj;
        }

        public double GetDistance()
        {
            return distance;
        }

        public Vertex GetPrevious()
        {
            return prev;
        }

        public bool GetKnown()
        {
            return known;
        }

        public void Reset()
        {
            prev = null;
            distance = Graph.INFINITY;
            known = false;
        }


        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Converts this instance of Vertex to its string representation.
        ///    <para>Output will be like : name (distance) [ adj1 (cost) adj2 (cost) .. ]</para>
        ///    <para>Adjecents are ordered ascending by name. If no distance is
        ///    calculated yet, the distance and the parantheses are omitted.</para>
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns>
        public override string ToString()
        {
            StringBuilder sb = new(name);
            if (distance != Graph.INFINITY)
            {
                sb.Append(" (");
                sb.Append(distance);
                sb.Append(") ");
            }

            sb.Append("[");
            foreach (Edge e in adj.OrderBy(x => x.dest.name))
            {
                sb.Append(' ');
                sb.Append(e.dest.name);
                sb.Append(" (");
                sb.Append(e.cost);
                sb.Append(')');
            }
            sb.Append(" ]");

            return sb.ToString();
        }
    }
}
