using System;
using System.Linq;
using System.Collections.Generic;

public class TrimMeanClass {
    private double TrimMeanOne(int[] arr)
    {
        // This works but it is not very efficient at all. I am thinking what we really need, is to remove

        int[] sorted = arr.OrderBy(x => x).ToArray(); // NOTE: This allocates a new array so this isn't that efficient. Array.Sort(arr) would do this in place. 

        int slice = arr.Length / 20; // also allocates more space

        int[] cutSorted = sorted[slice..^slice]; // also allocates more space

        return cutSorted.Average();
    }

    private double TrimMeanTwo(int[] arr)
    {
        // What can i learn from this? Don't assume that the logic on every step is correct. 
        int slice = arr.Length / 20;

        Stack<double> min = new Stack<double>();
        min.Push(arr[0]);
        Stack<double> max = new Stack<double>();
        max.Push(arr[0]);

        // make two lists of slice length (min and max 5%); find these at the same time
        // This is called a circular buffer ( don't necessarily need this if I can just use the first n items)
        for (var a = 1; a < arr.Length; a++)
        {
            double curr = arr[a];

            if (curr >= max.Peek())
            {
                max.Push(curr);
            }
            
            if(curr <= min.Peek())
            {
                min.Push(curr);
            }
            
        }

        // Console.Write($"Max: {max.Peek()}\nMin: {min.Peek()}");

        // Console.Write($"Slice: {slice}\nTake MaxSum: {max.Take(slice).Sum()}\nTake MinSum: {min.Take(slice).Sum()}\n");

        // var values =  max.Take(slice);

        double newSum = arr.Sum() - max.Take(slice).Sum() - min.Take(slice).Sum();

        return newSum / (arr.Length - (2 * slice));

        // sum the two lists and subtract against the sum of the arr, then divide against arr.Length - 2*slice
        // this is the new average
    }

    private double TrimMeanThree(int[] arr)
    {
        // I could also totally do this with a min and max heap. Aren't those really fast? I think it would still take a long time to create the heaps though
        // -> Yeah, I don't think this will really improve much
        // Remember, sorting is O(nlogn) and since heapifying is nlogk and k is proportional to n, this isn't any better
        return 0.0;
    }
    
    private double TrimMeanFour(int[] arr)
    {
        int n = arr.Length;
        Array.Sort(arr); // no allocation here
        int fivePercent = n / 20;
        int total = n - 2 * fivePercent, to = n - fivePercent;
        double sum = 0;
        for(int i = fivePercent; i< to; i++)
            sum += arr[i]; // no allocation here
        return sum / total; // no need to iterate through the array for the sum as well.
    }

    public double TrimMean(int[] arr) {

        // Succeed: This works but it is not optimal
        // return TrimMeanOne(arr);

        // FAIL: This does not work because it needs to be sorted!! This approach finds the local peaks and valleys but not the ultimate. I would need to have sorted array for this to work. I did not see this coming and should have approached this better. 
        // return TrimMeanTwo(arr);

        // NOTE: I think at this point, it would be better to just learn what a good solution would be. 


        return TrimMeanFour(arr);


        // NOTE: Final thoughts: 
        // I need to pay attention to memory allocation because that can take up more time than needed. Although, I had the same general solution, the way that I went by achieving this was not as efficient as it could have been.

    }
}