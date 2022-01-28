// https://leetcode.com/problems/the-earliest-moment-when-everyone-become-friends/
/*
* There are n people in a social group labeled from 0 to n - 1. You are given an array logs where logs[i] = [timestampi, xi, yi] indicates that xi and yi will be friends at the time timestampi.
* Friendship is symmetric. That means if a is friends with b, then b is friends with a. Also, person a is acquainted with a person b if a is friends with b, or a is a friend of someone acquainted with b.
* Return the earliest time for which every person became acquainted with every other person. If there is no such earliest time, return -1.
*/
// solution with optimization for disjoint set: find/union
// Time Complexity: O(N + M \log M + M \alpha (N))O(N+MlogM+Mα(N))
// Space Complexity: O(N + M)O(N+M) or O(N + \log M)O(N+logM)
public class Solution {
    public int EarliestAcq(int[][] logs, int n) {
        // 0. Sort logs array to asc because we want to know earliest time
        // 1. create Disjoint Set which should return bool - IsAllConnected for the UnionAndCheck
        // 2. when all vertex are connected it should return true
        // 3. when UnionAndCheck returns true we should skip union operation and return current item timestamp
        var ds = new DisjointSet(n);
        SortAsc(logs);
        
        for(int i=0; i<logs.Length; i++){
            if(ds.UnionAndCheck(logs[i][1], logs[i][2])){
                return logs[i][0];
            }
        }
        
        return -1;
    }
    
    private void SortAsc(int[][] logs){
        //  quicksort algorithm where space complexity is O(\log{M})O(logM)
        Array.Sort(logs, (a, b) => { return a[0] - b[0]; });
    }
    
    public class DisjointSet{
        private int[] _arr;
        private int _componentsCount;
        private int[] _rank;
        
        public DisjointSet(int vertexCount){
            _arr = new int[vertexCount];
            _rank = new int[vertexCount];
            _componentsCount = vertexCount;
            for(int i=0; i<vertexCount; i++){
                _arr[i] = i;
                _rank[i] = 0;
            }
        }
        
        public int Find(int vertex){
            if(_arr[vertex] == vertex){
                return vertex;
            }
            
            return _arr[vertex] = Find(_arr[vertex]);
        }
        
        public bool UnionAndCheck(int v1, int v2){
            var p1 = Find(v1);
            var p2 = Find(v2);
            if(p1 == p2){
                return false;
            }
            
            if(_rank[p1] > _rank[p2]){
                _arr[p2] = p1;    
            } else if(_rank[p1] < _rank[p2]){
                _arr[p1] = p2;
            } else {
                _arr[p2] = p1;
                _rank[p1] =+1;
            }

            _componentsCount--;
            
            if(_componentsCount-1 == 0){
                return true;
            } else {
                return false;
            }
        }
    }
}
