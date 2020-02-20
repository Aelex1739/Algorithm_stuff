using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2 {
    class Program {
        private static Stopwatch random = new Stopwatch();
        private static int counter = 0;
        static Random rand = new Random();
        private static int basicOps = 0;

        static void Main(string[] args) {
            random.Start();
            TestCode();
            //TimeTests();
            //BasicOpsTests();
        }
        
        public static int Median(int[] array) {
            if(array.Length <= 1) {
                return array[0];
            }else {
                return Select(array, 0, (array.Length / 2), (array.Length - 1));
            }
        }
        /*
         *   if n = 1 then         
         *      return A[0]     
         *   else         
         *      return Select(A, 0, n/2, n − 1)
         * */


        public static int Select(int[] array, int l, int m, int h) {
            
            int position = Partition(array, l, h);

            if(position == m) {
                return array[position];
            }else if (position > m) {
                return Select( array, l, m, (position - 1));
            }else {
                return Select(array, (position + 1), m, h);
            }
        }
        /*
         *   ALGORITHM Select(A[0..n − 1], l, m, h)     
         *   // Returns the value at index m in array slice A[l..h], if the slice     
         *   // were sorted into nondecreasing order.       
         *   pos ← Partition(A, l, h)        
         *   if pos = m then            
         *      return A[pos]       
         *   if pos > m then            
         *      return Select(A, l, m, pos − 1)        
         *   if pos < m then         
         *      return Select(A, pos + 1, m, h) 
         * */

        public static int Partition(int[] array, int l, int h) {
            int pivotvalue = array[l];
            int pivotlocation = l;
            int temporary1;
            int temporary2;

            for (int j = l + 1; j <= h; j++) {
                if(array[j] < pivotvalue) {
                    pivotlocation += 1;
                    temporary1 = array[pivotlocation];
                    array[pivotlocation] = array[j];
                    array[j] = temporary1;
                }
            }

            temporary2 = array[l];
            array[l] = array[pivotlocation];
            array[pivotlocation] = temporary2;
            return pivotlocation;
        }
        /*
         *   ALGORITHM Partition(A[0..n − 1], l, h)     
         *   // Partitions array slice A[l..h] by moving element A[l] to the position    
         *   // it would have if the array slice was sorted, and by moving all     
         *   // values in the slice smaller than A[l] to earlier positions, and all values    
         *   // larger than or equal to A[l] to later positions. Returns the index at which     
         *   // the ‘pivot’ element formerly at location A[l] is placed.    
         *    pivotval ← A[l]  // Choose first value in slice as pivot value     
         *   pivotloc ← l      // Location to insert pivot value    
         *   for j in l + 1 to h do        
         *      if A[j] < pivotval then            
         *          pivotloc ← pivotloc + 1            
         *          swap(A[pivotloc], A[j])  // Swap elements around pivot     
         *   swap(A[l], A[pivotloc])  // Put pivot element in place     
         *   return pivotloc 
         * 
         
             */

        public static int Median2(int[] array) {
            if (array.Length <= 1) {
                return array[0];
            } else {
                return Select2(array, 0, (array.Length / 2), (array.Length - 1));
            }
        }

        public static int Select2(int[] array, int l, int m, int h) {

            int position = Partition2(array, l, h);

            if (position == m) {
                return array[position];
            } else if (position > m) {
                return Select2(array, l, m, (position - 1));
            } else {
                return Select2(array, (position + 1), m, h);
            }
        }

        public static int Partition2(int[] array, int l, int h) {
            int pivotvalue = array[l];
            int pivotlocation = l;
            int temporary1;
            int temporary2;

            for (int j = l + 1; j <= h; j++) {
                basicOps++;
                if (array[j] < pivotvalue) {
                    pivotlocation++;
                    temporary1 = array[pivotlocation];
                    array[pivotlocation] = array[j];
                    array[j] = temporary1;

                    
                }
            }

            temporary2 = array[l];
            array[l] = array[pivotlocation];
            array[pivotlocation] = temporary2;
            return pivotlocation;
        }

        /*
        ALGORITHM BruteForceMedian(A[0..n − 1])
             // Returns the median value in a given array A of n numbers.  This is     
             // the kth element, where k = n/2, if the array was sorted.     
        k ← n/2     
                for i in 0 to n − 1 do         
                    numsmaller ← 0   // How many elements are smaller than A[i]         
                    numequal ← 0     // How many elements are equal to A[i]         
                    for j in 0 to n − 1 do             
                        if A[j] < A[i] then
                            numsmaller ← numsmaller + 1             
                        else                 
                            if A[j] = A[i] then
                                numequal ← numequal + 1         
                if numsmaller<k and k ≤ (numsmaller + numequal) then             
                    return A[i]
             */


        static int BruteForceMedian(int[] A) {


            // k = A.Length/2;
            int k = (int)Math.Ceiling((double)A.Length / 2);

            for (int i = 0; i < A.Length; i++) {
                int numsmaller = 0;
                int numequal = 0;
                for (int j = 0; j < A.Length; j++) {
                    if (A[j] < A[i]) {
                        numsmaller++;
                    } else if (A[j] == A[i]) {
                        numequal++;
                    }
                }
                if (numsmaller < k && k <= (numsmaller + numequal)) {
                    return A[i];
                }
            }
            
            return -1;
        }


        static int BruteForceMedian2(int[] A) {

            // k = A.Length/2;
            int k = (int)Math.Ceiling((double)A.Length / 2);

            for (int i = 0; i < A.Length; i++) {
                int numsmaller = 0;
                int numequal = 0;
                for (int j = 0; j < A.Length; j++) {

                    basicOps++;

                    if (A[j] < A[i]) {
                        numsmaller++;
                    } else if (A[j] == A[i]) {
                        numequal++;
                    }
                }
                if (numsmaller < k && k <= (numsmaller + numequal)) {
                    return A[i];
                }
            }
            
            return -1;
        }
        public static void TestCode() {

            //the first test for integrity

            int[] first = { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine("This is the first test array, the median should be 4: ");
            for (int i = 0; i < first.Length; i++) {
                Console.Write("{0}, ", first[i]);
            }

            Console.WriteLine("\n\nThis is the median for the first array with the Brute Force Method: " + BruteForceMedian2(first));
            Console.WriteLine("\nThis is the median for the first array with the Median Method: " + Median(first));
            Console.ReadLine();

            //the second test for integrity
            int[] second = { 65 };
            Console.WriteLine("\nThis is the second test array: ");
            Console.Write("{0}, ", second[0]);

            Console.WriteLine("\n\nThis is the median from the second array with the Brute Force algorithm : " + BruteForceMedian2(second));
            Console.WriteLine("\nThis is the median from the second array with the Median algorithm : " + Median(second));
            Console.ReadLine();

            //third test for integrity
            int[] third = new int[7];

            Console.WriteLine("\nThe third array which is created randomly: ");
            for (int i = 0; i < third.Length; i++) {
                counter++;

                double seed = random.ElapsedMilliseconds;
                int randValue = (int)seed;
                Random value = new Random(counter ^ randValue);

                third[i] = value.Next(0, 20);

                Console.Write("{0}, ", third[i]);
            }

            Console.WriteLine("\n\nThe median for the third array using the Brute Force algorithm is: " + BruteForceMedian2(third));
            Console.WriteLine("\nThe median for the third array using the Median algorithm is: " + Median(third));

            Console.WriteLine("This is the array sorted to prove the median is correct");
            Array.Sort(third);
            for (int i = 0; i < third.Length; i++) {
                Console.Write("{0}, ", third[i]);
            }
            Console.ReadLine();

            //fourth test for integrity

            int[] fourth = { -8, 4, -77, 45, 17, 400, -22 };

            Console.WriteLine("\n\nThis is the fourth array with both negative and positive numbers: ");
            for (int i = 0; i < fourth.Length; i++) {
                Console.Write("{0}, ", fourth[i]);
            }

            Console.WriteLine("\n\nThis is the median for the fourth array with the Brute Force algorithm: " + BruteForceMedian2(fourth));
            Console.WriteLine("\nThis is the median for the fourth array with the Median algorithm: " + Median(fourth));
            Console.WriteLine("This is the array sorted: ");
            Array.Sort(fourth);
            for (int i = 0; i < fourth.Length; i++) {
                Console.Write("{0}, ", fourth[i]);
            }
            Console.ReadLine();

            //fifth test for integrity 

            int[] fifth = {-66, 18, -100, 76, -48, 18, -2};

            Console.WriteLine("\n\nThis is the fifth array with negative numbers, positive numbers and duplicate numbers:");
            for(int i = 0; i < fifth.Length; i++) {
                Console.Write("{0}, ", fifth[i]);
            }
            Console.WriteLine("\n\nThis is the median for the fifth array with the Brute Force algorithm: "  + BruteForceMedian2(fifth));
            Console.WriteLine("\nThis is the median for the fifth array with the Median algorithm: " + Median(fifth));
            Console.WriteLine("This is the array sorted: ");
            Array.Sort(fifth);
            for(int i = 0; i < fifth.Length; i++) {
                Console.Write("{0}, ", fifth[i]);
            }
            Console.ReadLine();

            //sixth test for integrity ''
            int[] sixth = new int[8];
            Console.WriteLine("\nThe sixth array which is created randomly: ");
            for (int i = 0; i < sixth.Length; i++) {
                counter++;

                double seed = random.ElapsedMilliseconds;
                int randValue = (int)seed;
                Random value = new Random(counter ^ randValue);

                
                sixth[i] = value.Next(0, 20);
                Console.Write("{0}, ", sixth[i]);
            }
            
            Console.WriteLine("\n\nThis is the median for the sixth array with the Brute Force algorithm: " + BruteForceMedian2(sixth));
            Console.WriteLine("\nThis is the median for the sixth array with the Median algorithm: " + Median(sixth));

            Console.ReadLine();
        }


        public static void TimeTests() {
            int arrays = 101;
            int arrayLength = 2800;
            Stopwatch timer = new Stopwatch();
            int[][] arrayOfArrays = new int[arrays][];


            for (int i = 0; i < arrays; i++) {

                int[] timeTestArray = new int[arrayLength]; 

                for(int j = 0; j < arrayLength; j++) {
                    timeTestArray[j] = rand.Next(arrays * 15);

                }
                arrayOfArrays[i] = timeTestArray;         

            }

            for (int i = 0; i < arrays; i++) {
                timer.Reset();
                timer.Start();
                BruteForceMedian(arrayOfArrays[i]);
                timer.Stop();
                double timeResult = timer.Elapsed.TotalMilliseconds;
                Console.WriteLine(timeResult);
            }
            Console.WriteLine("The Brute force is done, press enter to start median test");
            Console.ReadLine();
            for (int i = 0; i < arrays; i++) {
                timer.Reset();
                timer.Start();
                Median(arrayOfArrays[i]);
                timer.Stop();
                double timeResult = timer.Elapsed.TotalMilliseconds;
                Console.WriteLine(timeResult);
            }
            Console.ReadLine();

        }

        public static void BasicOpsTests() {
            int arrays = 100;
            int arrayLength = 3000;
            int[][] arrayOfArrays = new int[arrays][];
            int[] test = new int[10];
            
            for (int i = 0; i < arrays; i++) {

                int[] basicOpsTestArray = new int[arrayLength];

                for (int j = 0; j < arrayLength; j++) {
                    basicOpsTestArray[j] = rand.Next(arrays * 15);

                }

                arrayOfArrays[i] = basicOpsTestArray;
                           
                basicOps = 0;
                BruteForceMedian2(basicOpsTestArray);
                Console.WriteLine(basicOps);
                
            }
            Console.WriteLine("The Brute force is done, press enter to start median test");
            Console.ReadLine();

            for (int i = 0; i < arrays; i++) {
                int[] test1 = new int[arrays];
                basicOps = 0;
                test1 = arrayOfArrays[i];
                Median2(test1);
                Console.WriteLine(basicOps);
            }
            Console.ReadLine();
        }

    }
}