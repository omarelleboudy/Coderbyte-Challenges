using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    /*
    Graph Challenge
    Have the function GraphChallenge(strArr) take strArr which will be an array of strings
    which models a non-looping Graph. 
    The structure of the array will be as follows: 
    The first element in the array will be the number of nodes N (points) in the array as a string.
    The next N elements will be the nodes which can be anything (A, B, C .. Brick Street, Main Street .. etc.).
    Then after the Nth element, the rest of the elements in the array
    will be the connections between all of the nodes.
    They will look like this: (A-B, B-C .. Brick Street-Main Street .. etc.).
    Although, there may exist no connections at all.

    An example of strArr may be: ["4","A","B","C","D","A-B","B-D","B-C","C-D"].
    Your program should return the shortest path from the first Node to the last Node in the array separated by dashes.
    So in the example above the output should be A-B-D.
    Here is another example with strArr being
    ["7","A","B","C","D","E","F","G","A-B","A-E","B-C","C-D","D-F","E-D","F-G"].
    The output for this array should be A-E-D-F-G. There will only ever be one shortest path for the array. 
    If no path between the first and last node exists, return -1. The array will at minimum have two nodes.
    Also, the connection A-B for example, means that A can get to B and B can get to A.
    */
    class Program
    {

        public static string GraphChallenge(string[] strArr)
        {
            string result = "-1";
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            List<string> reversePath = new List<string>(); //To Backtrack to the start.
            HashSet<string> seen = new HashSet<string>();  //To avoid visiting a node twice.

            // Parsing the input and building the graph
            int numOfNodes = int.Parse(strArr[0]);
            for (var i = 1; i <= numOfNodes; i++)
            {
                graph.Add(strArr[i], new List<string>());
            }
            for (var i = numOfNodes + 1; i < strArr.Length; i++)
            {
                var nodes = strArr[i].Split('-');
                graph[nodes[0]].Add(nodes[1]);
            }

            // the start is the first node and the end is the last node (given in the problem)
            string start = strArr[1];
            string end = strArr[numOfNodes];

            // for keeping track of the ancestor to back track to start
            Dictionary<string, string> nodeToAncestor = new Dictionary<string, string>();

            // BFS to find the shortest path
            Queue<string> q = new Queue<string>();
            q.Enqueue(start);
            while (q.Count > 0)
            {
                start = q.Dequeue();
                foreach (var predecessor in graph[start])
                {
                    if (!seen.Contains(predecessor))
                    {
                        seen.Add(predecessor);

                        nodeToAncestor[predecessor] = start;
                        if (predecessor != end)
                        {
                            q.Enqueue(predecessor);
                        }
                        else
                        {
                            // we have reached the target, track back the ancestors and exit
                            string current = predecessor;
                            while (current != strArr[1])
                            {
                                reversePath.Add(current);
                                current = nodeToAncestor[current];
                            }
                            reversePath.Add(strArr[1]);

                            break;
                        }
                    }
                }
            }
            reversePath.Reverse();
            if (reversePath.Count > 0) result = string.Join("-", reversePath);
            return result;

        }

        static void Main(string[] args)
        {
            var strArr = new string[] { "5", "A", "B", "C", "D", "F", "A-B", "A-C", "B-C", "C-D", "D-F" };
            //{ "7", "A", "B", "C", "D", "E", "F", "G", "A-B", "A-E", "B-C", "C-D", "D-F", "E-D", "F-G" };
            //{ "4", "A", "B", "C", "D", "A-B", "B-D", "B-C", "C-D" };
            Console.WriteLine(GraphChallenge(strArr));
        }
    }
}
