# LeetcodeValidNumber
My solution to the Valid Number HARD problem on Leetcode.

This is for study purposes ONLY. You are not allowed to submit this code or derivatives to Leetcode. Don't be a cheat!


## Iteration 1 (the one currently committed):

Runtime: 104 ms, faster than 39.27% of C# online submissions for Valid Number.

Memory Usage: 41.9 MB, less than 5.45% of C# online submissions for Valid Number.

I know why its slower than most - there's at most 2 methods to determine if the string fits the shape of an integer or a decimal, but I wonder why the memory usage is so high? I suspect strings are being copied.... 


## Iteration 2 (not checked in)

Using in keyword to ensure const-ness for strings and int idx. Made most methods static just in case the cost of instantiating object was high.

Didn't made a blind bit of difference to performance.

Had an idea - it could be the exceptions being thrown? They do like to eat RAM.  




