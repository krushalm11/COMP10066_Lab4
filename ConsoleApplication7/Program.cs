using System;
using System.Collections.Generic;

namespace COMP10066_Lab4
{
    /**
     * Library of statistical functions using Generics for different statistical
     * calculations.
     * 
     * see http://www.calculator.net/standard-deviation-calculator.html
     * for sample standard deviation calculations
     *
     * @author Joey Programmer
     */
    //<Summary>
    /*This method will determine the average of the elements in the  array
     * <Parameter>
     * This method take two parameters 
     * one parameter hold the array
     * second  parameter checks the boolean
     * <return>
     * This method will return the average of the array elements  
     */
    public class ArrayCalculation
    {
        public static double CalculateAverage(List<double> list, bool checkBoolean)
        {   //Declare the sumElements varable which add all the elements of the list
            //Call Function CalculateSum and assign it to variable sumElements
            double sumElements = CalculateSum(list, checkBoolean);
            //Declare and initialize numberElements variable
            int numberElements = 0;
            //For loop to determine that each element in the list array are greater than zero
            for (int i = 0; i < list.Count; i++)
            {
                //Condition to check the elements
                if (checkBoolean || list[i] >= 0)
                {
                    //increment
                    numberElements++;
                }
            }
            //if numberElements is equal to zero than through exception
            if (numberElements == 0)
            {
                //through exception
                throw new ArgumentException("no values are > 0");
            }
            //return the average of list array
            return sumElements / numberElements;
        }
        //<Summary>
        /*This method will determine the sum of the elements in the array
         * <Parameter>
         * This method take two parameters 
         * one parameter hold the array
         * second  parameter checks the boolean
         * <return>
         * This method will return the sum of the array elements  
         */
        public static double CalculateSum(List<double> list, bool checkBoolean)
        {
            //Condition to check if there is no element then through exception
            if (list.Count < 0)
            {
                //through exception
                throw new ArgumentException("x cannot be empty");
            }
            //assign zero to sum variable
            double sum = 0.0;
            //foreach loop to to check each element in the list
            foreach (double element in list)
            {
                //Condition to check the elements are true and greater than zero
                if (checkBoolean || element >= 0)
                {
                    //assign element to sum
                    sum += element;
                }
            }
            //return sum of elements
            return sum;
        }
        //<Summary>
        /*This method will determine the median of the elements in the array
         * <Parameter>
         * This method take two parameters 
         * one parameter hold the array
         * second  parameter checks the boolean
         * <return>
         * This method will return the median of the array elements  
         */
        public static double CalculateMedian(List<double> elementsArray)
        {
            //Condition to check if there is no element then through exception
            if (elementsArray.Count == 0)
            {//through exception
                throw new ArgumentException("Size of array must be greater than 0");
            }
            //sort the elements in the array
            elementsArray.Sort();
            //Declare median 
            //Divide the number of elements in the array by 2 and assign it to median
            double median = elementsArray[elementsArray.Count / 2];
            //condition to check the elements count  is even
            if (elementsArray.Count % 2 == 0)
                //formula to get the median
                median = (elementsArray[elementsArray.Count / 2] + elementsArray[elementsArray.Count / 2 - 1]) / 2;
            //return median
            return median;
        }
        //<Summary>
        /*This method will determine the standard Deviation of the elements in the array
         * <Parameter>
         * This method take two parameters 
         * one parameter hold the array
         * second  parameter checks the boolean
         * <return>
         * This method will return the standard deviation of the array elements  
         */
        public static double CalculateStandardDeviation(List<double> elementsArray)
        {
            //Condition to check if there is no element then through exception
            if (elementsArray.Count <= 1)
            {   //through exception
                throw new ArgumentException("Size of array must be greater than 1");
            }
            //declare the size variable that count the number of elemnets in the array
            int size = elementsArray.Count;
            //Declare and initialize sum as 0
            double sum = 0;
            //Declare the average variable
            //call the calculate average method and assign it to average variable
            double average = CalculateAverage(elementsArray, true);
            //For loop to get the value of sum
            for (int i = 0; i < size; i++)
            {
                //assign array elements to v variable
                double v = elementsArray[i];
                //formula to calculate the sum
                sum += Math.Pow(v - average, 2);
            }
            //formula to calculate the standard deviation
            double standardDeviation = Math.Sqrt(sum / (size - 1));
            //return standard deviation
            return standardDeviation;
        }

        // Simple set of tests that confirm that functions operate correctly
        //Main method which calls the all methods used in this class and print the results on the screen
        static void Main(string[] args)
        {
            //Initialize test Data list
            List<Double> testData = new List<Double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };
            //Call Calculate sum method which will print the sum of the array
            Console.WriteLine("The sum of the array = {0}", CalculateSum(testData, true));
            //Call Calculate average method which will print the average of the array
            Console.WriteLine("The average of the array = {0}", CalculateAverage(testData, true));
            //Call Calculate median method which will print the median of the array
            Console.WriteLine("The median value of the Double data set = {0}", CalculateMedian(testData));
            //Call Calculate standard deviation method which will print the standard deviation of the array
            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", CalculateStandardDeviation(testData));
            Console.ReadLine();
        }
    }
}
