namespace Leetcode;

public class Solution {
    public bool ValidDigit(int n, int x) {
        // Console.Write($"Valid Digit?\n\nn: {n} --- x: {x}\n\n");

        bool found = false;

        while( n >= 10 ){
            int remainder = n % 10;
            // Console.Write($"n: {n} --- remainder: {remainder}\n");

            n /= 10;

            if(remainder == x){
                found = true;
                // Console.Write("Found!\n");
            }
        }

        // Console.Write($"Finished n: {n}\n");

        return found && n != x;
    }
}