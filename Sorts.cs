using System;

namespace ClassLibrarySorts
{
    public static class Sorts
    {
        /// <summary>
        /// Сортировка пузырьками
        /// </summary>
        /// <param name="M"></param>
        /// <param name="sortPlus"></param>
        /// <returns></returns>
       public static void BubbleSort(int[]M,bool sortPlus)
        {
            if (sortPlus)   //Возрастание     
            {
                int N = M.GetLength(0);
                for (int i = N - 1; i >= 0; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (M[j] > M[j + 1])
                        {
                            int t = M[j];
                            M[j] = M[j + 1];
                            M[j + 1] = t;
                            
                        }
                    }
                }
                   
            }
            else   //убывание         
            {
                int N = M.GetLength(0);
                for (int i = N - 1; i >= 0; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (M[j] < M[j + 1])
                        {
                            int t = M[j];
                            M[j] = M[j + 1];
                            M[j + 1] = t;
                            
                        }
                    }
                }

                
            }
            
        }
        //сортировка вставками по возрастанию. Среднее время O(n^2)
        public static void InsertionSort(int[] M,bool SortPlus)
        {
            if (SortPlus)  //для возрастания
            {
                int N = M.GetLength(0);
                for (int i = 1; i < N; i++)
                {
                    int j = i;
                    while (M[j] < M[j - 1])
                    {
                        int T = M[j];
                        M[j] = M[j - 1];
                        M[j - 1] = T;
                        j--;
                        if (j == 0)
                        {
                            break;
                        }
                    }
                    
                }
                
            }
            else                //для убывания
            {
                int N = M.GetLength(0);
                for (int i = 1; i < N; i++)
                {
                    int j = i;
                    while (M[j] > M[j - 1])
                    {
                        int T = M[j];
                        M[j] = M[j - 1];
                        M[j - 1] = T;
                        j--;
                        if (j == 0)
                        {
                            break;
                        }
                    }
                   
                }
                
            }
        }    
        
        
        //Быстрая сортировка по
        public static void quicksort(int[] M, bool SortPlus)
        {
                int N = M.GetLength(0);
                if (SortPlus)
                {
                    QuickSortRange(M ,0, N - 1);
                    
                }
                else
                {
                    QuickSortRangeRevers(M,0, N - 1);
                    
                }
        }
        public static void QuickSortRangeRevers(int[]M,int Left, int Right)   //для убывания
        {
            QuickSortRange(M,Left, Right);
            int N = M.GetLength(0);
            for (int i = 0; i < N - 1; i++)
            {
                int t = M[i];
                M[i] = M[N - 1];
                M[N - 1] = t;
                N--;
            }
        }
        public static void QuickSortRange(int[]M,int Left, int Right)   //для возрастания
        {
            
            int a = Left, b = Right, p = M[(Left + Right) / 2];
            while (a < b)
            {
                while (M[a] < p)
                    a++;
                while (M[b] > p)
                    b--;
                if (a <= b)
                {
                    int t = M[a];
                    M[a] = M[b];
                    M[b] = t;
                    a++;
                    b--;
                }
            }
            if (Left < b)
                QuickSortRange(M,Left, b);
            if (a < Right)
                QuickSortRange(M,a, Right);
            
        }
        public static void MergeSort (int[] M, bool SortPlus)
        {
            int N = M.GetLength(0);
            if (SortPlus)
            {
                MergeSortRange(M,0, N - 1);
                
            }
            else
            {
                MergeSortRangeRevers(M,0, N - 1);
                
            }
        }
        public static void MergeSortRangeRevers(int[]M,int Left, int Right)   //для убывания
        {
            MergeSortRange(M,Left, Right);
            int N = M.GetLength(0);
            for (int i = 0; i < N - 1; i++)
            {
                int t = M[i];
                M[i] = M[N - 1];
                M[N - 1] = t;
                N--;
            }
        }
        public static void MergeSortRange(int[]M,int Left, int Right)         //для возрастания
        {
            
            if (Right - Left > 1)
            {
                int a1 = Left;
                int b1 = (Left + Right) / 2;
                int a2 = (Left + Right) / 2 + 1;
                int b2 = Right;
                MergeSortRange(M,a1, b1);
                MergeSortRange(M,a2, b2);
                int[] T = new int[Right - Left + 1];
                for (int k = Left; k <= Right; k++)
                    T[k - Left] = M[k];
                int i = a1;
                int j = a2;
                for (int k = Left; k <= Right; k++)
                    if (i <= b1 && j <= b2)
                        if (T[i - Left] < T[j - Left])
                        {
                            M[k] = T[i - Left];
                            i++;
                        }
                        else
                        {
                            M[k] = T[j - Left];
                            j++;
                        }
                    else
                        if (i > b1)
                    {
                        M[k] = T[j - Left];
                        j++;
                    }
                    else
                    {
                        M[k] = T[i - Left];
                        i++;
                    }
            }
            else if (Right - Left == 1)
            {
                if (M[Left] > M[Right])
                {
                    int t = M[Left];
                    M[Left] = M[Right];
                    M[Right] = t;
                }
            }
            
        }
        public static void HeapSort(int[]M,bool SortPlus)
        {
            int N = M.GetLength(0);
            for (int i = N / 2 - 1; i >= 0; i--)
            {
                Heapfy(M,N, i);               
            }
            if (SortPlus)
            {
                for (int i = N - 1; i >= 0; i--)
                {
                    int t = M[i];
                    M[i] = M[0];
                    M[0] = t;
                    Heapfy(M,i, 0);
                }
                
            }
            else
            {
                for (int i = N - 1; i >= 0; i--)
                {
                    int t = M[i];
                    M[i] = M[0];
                    M[0] = t;
                    Heapfy(M,i, 0);
                }
                HeapSortRevers(M);
                
            }
        }
        public static void Heapfy(int[]M,int N, int i)        //приведение к куче
        {
            int iM = i;
            int L = 2 * i + 1;
            int R = 2 * i + 2;
            if (L < N && M[L] > M[iM])
                iM = L;
            if (R < N && M[R] > M[iM])
                iM = R;
            if (iM != i)
            {
                int t = M[i];
                M[i] = M[iM];
                M[iM] = t;
                Heapfy(M,N, iM);
            }
        }
        public static void HeapSortRevers(int[] M)
        {
            int N = M.GetLength(0);
            for (int i = 0; i < N - 1; i++)
            {
                int t = M[i];
                M[i] = M[N - 1];
                M[N - 1] = t;
                N--;
            }
        }
        




    }
    
}
