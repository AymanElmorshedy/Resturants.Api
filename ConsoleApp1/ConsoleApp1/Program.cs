using System.Numerics;

namespace ConsoleApp1
{
    internal class Program
    {
        static int BinarySearch(int[] arr, int Number)
        {
          int low = 0;
            int high = arr.Length - 1;
            int mid = (low + high)/2;
            while (low <= high)
            {
                if (arr[mid] == Number)
                {
                    return mid;
                }
                if (Number < arr[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
                return -1;
        }
        public static bool ISpalindrom(string str) 
        {
            int left = 0 ;
            int right = str.Length - 1 ;    
            if (left < right)
            {
                if (str[left] != str[right]) 
                    return false;
                left++;
                right++;
                
            }
            return true;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            int[] arr = [1, 3, 7, 11, 17, 23, 31];
            int Number = 17;
            int indexx = BinarySearch(arr, Number);
            if(indexx == -1)
                Console.WriteLine("Element is not found");
            else
                Console.WriteLine($"Element is found at index : {indexx}");

        }
    }
}
