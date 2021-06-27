using System;

namespace Dev6a
{
    public class FiboFloyd
    {
        public static int Fibonacci(int n, int[] storedResults) {
            if(storedResults[n] == 0) {
                var nMinOne = Fibonacci(n-1, storedResults);
                var nMinTwo = Fibonacci(n-2, storedResults);
                storedResults[n] = nMinOne + nMinTwo;
            }
            return storedResults[n];
        }
        
        public static int FibonacciIterative(int n) {
            if (n == 0)
                return 1;
            else {
                var previousFib = 1;
                var currentFib = 1;
                for(int i = 0; i < n-1; i++) {
                    var newFib = previousFib + currentFib;
                    previousFib = currentFib;
                    currentFib = newFib;
                }
                return currentFib;
            }
        }
        
        public double[,] AdjacencyMatrix { get; set; }
        public int Count { get { return AdjacencyMatrix.GetLength(0); } }

        public FiboFloyd(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new System.ArgumentException("The adjacency matrix must be a square matrix");
            AdjacencyMatrix = matrix;
        }

        public Tuple<double[,], int[,]> FloydWarshall()
        {
            var numVertices = Count;
            double[,] dist = new double[numVertices, numVertices]; // matrix of minimum distances
            int[,] next = new int[numVertices, numVertices]; // matrix of vertex indices

            // initialization of dist and next
            for (int i = 0; i < numVertices; i++)
            for (int j = 0; j < numVertices; j++)
            {
                if (i == j)
                    dist[i, j] = 0;
                else
                    dist[i, j] = AdjacencyMatrix[i, j];
        
                if (AdjacencyMatrix[i, j] != Double.PositiveInfinity)
                    next[i, j] = j;
                else
                    next[i, j] = -1;    
            }

            for (int k = 0; k < numVertices; k++)
            for (int i = 0; i < numVertices; i++)
            for (int j = 0; j < numVertices; j++)
            {
                if (dist[i, j] > dist[i, k] + dist[k, j])
                {
                    dist[i, j] = dist[i, k] + dist[k, j];
                    next[i, j] = next[i, k];
                }
            }

            return new Tuple<double[,], int[,]>(dist, next);
        }
        
        public static void Main2 (string[] args) {
            int[] mapIntermediateResults = new int[15];
            // initialize the first two values in the array which we use as a map
            mapIntermediateResults[0] = 1;
            mapIntermediateResults[1] = 1;
            // the default value of int is 0, so at all other indices we will find a zero
            var result = Fibonacci(11, mapIntermediateResults);
        }
    }
}