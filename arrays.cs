using System;
class ArrayUtils {
    static void Diagonal1(int[,] arr, int n)
    {
        int[] arr1=new int[n];
        for (int i=0; i<n; i++)
        {
            arr1[i]=arr[i, i];
            Console.Write("{0}    ", arr1[i]);
        }
    }
    static void Diagonal2(int[,] arr, int n) //n is the smalles size
    {
        int[] arr1=new int[n];
        for (int i=0; i<n; i++)
        {
            arr1[i]=arr[i, i];
            Console.Write("{0}    ", arr1[i]);
        }
    }
    static void Triangularize (int[,] arr, int n) //without enum
    {
        int[,] arr1=new int[n, n];
        for (int i=0; i<n; i++)
        {
            for (int j=0; j<n; j++)
            {
                if (i>j)
                {
                    arr1[i, j]=0;
                }
                else { arr1[i, j]=arr[i, j];}
            }
        }  
        for (int i=0; i<n; i++)
        {
            for (int j=0; j<n; j++)
            {
                Console.Write("{0}    ", arr1[i, j]);
            }
            Console.WriteLine();
        }
    }
    static void Flatten (int[,] arr, int n, int m) //without enum
    {
        int[] arr1= new int[n*m];
        int k=0;
        for (int i=0; i<n; i++)
        {
            for (int j=0; j<m; j++)
            {
                arr1[k]=arr[i, j];
                k++;
            }
        }
        for (int i=0; i<n*m; i++)
        {
            Console.Write("{0}   ", arr1[i]);
        }
    }
    static void Main() {
    int n=5, k=3; 
    int[,] arr=new int[n, n];
    int[,] arr1=new int[n, k];
    for (int i=0; i<n; i++)
    {
        for (int j=0; j<n; j++)
        {
            arr[i, j]=2*i+3*j+4;
            Console.Write("{0}    ", arr[i, j]);
        }
        Console.WriteLine();
    }
    /*for (int i=0; i<n; i++)
    {
        for (int j=0; j<k; j++)
        {
            arr1[i, j]=2*i+3*j+3;
            Console.Write("{0}    ", arr1[i, j]);
        }
        Console.WriteLine();
    }*/
    Console.WriteLine();
    Flatten(arr, n, n);
  }}
