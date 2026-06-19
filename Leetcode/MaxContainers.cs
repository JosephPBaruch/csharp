// 3492. Maximum Containers on a Ship
using System;
using System.Linq;
using System.Collections.Generic;

public class MaxContainersClass {
    private int MaxContainersOne(int n, int w, int maxWeight)
    {
        if (n <= 0 || w <= 0 || maxWeight <= 0 )
        {
            return -1;
        }

        int maxContainers = n * n;

        if(maxContainers * w <= maxWeight)
        {
            return maxContainers;
        }
        else
        {
            return maxWeight / w;
        }
        // Seems like there is really only two options here: 
        // 1. maxWeight / w (if result is less than n x n)
        // 2. n x n x w  (if result is less than maxWeight)
        // Select the one that is the most 

        // Need to watch out for maxWeight not being a multiple of w (but rounding properties of division should handle this)
    }

    public int MaxContainers(int n, int w, int maxWeight) {
        // Boom: easy cash money
        return MaxContainersOne(n, w, maxWeight);

        // What is the next thing to think about: 
        // 1. Making sure that all of the values are checked for their bounds? (Can't be negative but type checking are done by default in the language)
        // 2.  Make sure that the container weight doesn't exceed the maxWeight of the ship... should this return 0 or -1;
            // Thinking about this, there could be a ship that is 1 x 1 has a max weight less than the requested container weight. Thoughts -=> I like the idea of returning 0 in this case. Lets add a test case 
        //  Also need to watch out for overflowing when making computations
    }
}