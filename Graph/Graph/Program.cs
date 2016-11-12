using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Graph<T>
    {
        private Dictionary<T, HashSet<T>> _adjacencyMap;
        private Dictionary<T, int> _incomingEdges;

        public Graph()
        {
            _adjacencyMap = new Dictionary<T, HashSet<T>>();
            _incomingEdges = new Dictionary<T, int>();

        }

        /**
         * Connect two nodes by inserting one in the others adjacent set; 
         * */
        public void Connect(T u, T v)
        {
            if (!_adjacencyMap.ContainsKey(u)) _adjacencyMap.Add(u, new HashSet<T>());
            _adjacencyMap[u].Add(v);

            if (!_incomingEdges.ContainsKey(u)) _incomingEdges.Add(u, 0);
            if (!_incomingEdges.ContainsKey(v)) _incomingEdges.Add(v, 0);

            _incomingEdges.Add(v, _incomingEdges[v] + 1);
        }
        /*
         * Disconnet u from v 
         */
        public void Disconnect(T u, T v)
        {
            if (!_adjacencyMap.ContainsKey(u)) _adjacencyMap[u].Remove(v);
            if (_incomingEdges.ContainsKey(v))
                _incomingEdges.Add(v, _incomingEdges[v] - 1);

        }
        /**
         * Connect u to v and v to u
         */
        public void ConnectBidirectional(T u, T v)
        {
            Connect(u, v);
            Connect(v, u);
        }
        /*
         * get all nodes adjacent to u
         * If u is not present int he graph,
         * an empty set is returned
         */
        HashSet<T> AdjacentTo(T u)
        {
            return _adjacencyMap.ContainsKey(u) ? _adjacencyMap[u] : new HashSet<T>();
        }
        /**
         * Returns topological ordering of the current graph
         */
        List<T> TopoSort()
        {
            Stack<T> stack = new Stack<T>();
            HashSet<T> marked = new HashSet<T>();
            List<T> topoSorted = new List<T>();

            foreach (KeyValuePair<T, HashSet<T>> entry in _adjacencyMap)
            {
                if (!marked.Contains(entry.Key))
                    Visit(entry.Key, marked, stack);

            }


            while (!stack.Count.Equals(0))
            {
                topoSorted.Add(stack.Pop());
            }
            return topoSorted;
        }

        /*
         * Does PostOrder Traversal of the graph
         * Adds visited elements to a stack
         * Used to find the topological ordering
         */
        private void Visit(T u, HashSet<T> marked, Stack<T> stack)
        {
            if (!marked.Contains(u))
            {
                foreach (T neighbour in AdjacentTo(u))
                    Visit(neighbour, marked, stack);
            }
            marked.Add(u);
            stack.Push(u);
        }
        /*
         * Alternative version of topological sort
         * Uses Breadth-First Search and a Map
         * Which keeps track of incoming edges for each vertex  
         */
        List<T> TopoSortBFS()
        {
            List<T> topoSorted = new List<T>();
            Queue<T> q = new Queue<T>();

            foreach (KeyValuePair<T, int> entry in _incomingEdges)
            {
                if ((int)entry.Value == 0)
                {
                    q.Enqueue(entry.Key);
                }

            }
            while (!q.Count.Equals(0))
            {
                T front = q.Dequeue();
                topoSorted.Add(front);


                List<T> toBeRemoved = new List<T>();
                foreach (T neighbour in AdjacentTo(front))
                {
                    toBeRemoved.Add(neighbour);
                    if(_incomingEdges[neighbour] == 1)
                    {
                        q.Enqueue(neighbour);
                    }
                }
                foreach (T u in toBeRemoved)
                    Disconnect(front, u);
            }
            return topoSorted;
        }

    }
}
