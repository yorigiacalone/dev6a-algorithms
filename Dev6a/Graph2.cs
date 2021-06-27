using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev6a
{
  public class Graph2
  {
    public double[,] AdjacencyMatrix { get; set; }
    public int Count { get { return AdjacencyMatrix.GetLength(0); } }

    public Graph2(double[,] matrix)
    {
      if (matrix.GetLength(0) != matrix.GetLength(1))
        throw new System.ArgumentException("The adjacency matrix must be a square matrix");
      AdjacencyMatrix = matrix;
    }

    public List<int> Neighbors(int node)
    {
      List<int> neighbors = new List<int>();
      for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
      {
        if (AdjacencyMatrix[node, i] < Double.PositiveInfinity)
          neighbors.Add(i);
      }
      return neighbors;
    }

    public Tuple<double[], int[]> SingleSourceShortestPath(int source) //distance and prev arrays
    {
      double[] distance = new double[Count];
      int[] prev = new int[Count];
      List<int> unvisitedNodes = new List<int>(Count);
      // initialization of distance, prev and unvisitedNodes
      for (int i = 0; i < Count; i++)
      {
        distance[i] = Double.PositiveInfinity;
        prev[i] = -1;
        unvisitedNodes.Add(i);
      }
      // set distance of source
      distance[source] = 0;
      while (unvisitedNodes.Count > 0) // unvisitedNodes is not empty
      {
        int firstUnvisited = unvisitedNodes.First();
        double min = distance[firstUnvisited];
        int minIndex = firstUnvisited;
        for (int i = 0; i < unvisitedNodes.Count; i++)
        { // find closest node in unvisitedNodes
          if (distance[unvisitedNodes[i]] < min)
          {
            minIndex = unvisitedNodes[i];
            min = distance[unvisitedNodes[i]];
          }
        }
        // remove the closest node from unvisitedNodes
        unvisitedNodes.Remove(minIndex);
        List<int> neighbors = Neighbors(minIndex);

        for (int i = 0; i < neighbors.Count; i++)
        {
          if(unvisitedNodes.Contains(neighbors[i])) { // calculate distance and update if smaller
            double alt = distance[minIndex] + AdjacencyMatrix[minIndex, neighbors[i]];
            if (alt < distance[neighbors[i]])
            {
              distance[neighbors[i]] = alt;
              prev[neighbors[i]] = minIndex;
            }
          }
        }
      }

      return new Tuple<double[], int[]>(distance, prev);
    }

  }
}