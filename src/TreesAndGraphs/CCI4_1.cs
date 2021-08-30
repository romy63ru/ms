using System;
using System.Collections.Generic;

namespace TreesAndGraphs
{
    public enum State { Unvisited, Visited, Visiting }

    public class Node
    {
        public string Name;
        public Node[] Children = new Node[3];
        public State State;
    }

    public class Graph
    {
        public Node[] Nodes = new Node[3];
    }

    public class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int value)
        {
            this.value = value;
        }
    }

    /// <summary>
    /// 4.1 Given a directed graph, design an algorithm to find out whether there is a route between two nodes.
    /// </summary>
    public class CCI4_1
    { 
        public static bool Task4and1(Graph g, Node start, Node end)
        {
            if (start==end)
            {
                return true;
            }
            var q = new LinkedList<Node>();
            foreach (var n in g.Nodes)
            {
                n.State = State.Unvisited;
            }
            start.State = State.Visiting;
            q.AddLast(start);
            Node u;

            while (q.Count > 0)
            {
                u = q.First.Value;
                q.RemoveFirst();
                if (u != null)
                {
                    foreach (var v in u.Children)
                    {
                        if (v != null)
                        {
                            if (v.State == State.Unvisited)
                            {
                                if (v == end)
                                {
                                    return true;
                                }
                                else
                                {
                                    v.State = State.Visiting;
                                    q.AddLast(v);
                                }
                            }
                        }
                    }
                    u.State = State.Visited;
                }
            }
            return false;
        }
    }
}
