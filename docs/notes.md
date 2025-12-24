# Advent of Code 2025 Notes

These are my notes for each day's solutions, if I had any.

## Current Plan

Just keep swimming...

# Day 1

## Part 1

`255` - That's too low.

Oops, need to account for numbers larger than 99.

## Part 2
`5043` - too low
`6127` - still too low

98, R5 => 103, which is actually 3, and I would've crossed 0

# Day 2

## Part 1

95381

9, 5, 3, 8, 1
95, 38, 1

5381908431, length 10

5, 3, 8, 1, 9, 0, 8, 4, 3, 1   1 to 9
53, 81, 90, 84, 31             1 to 4
538, 190, 843, 1               1 to 3
5381, 9084, 31                 1 to 2
53819, 08431                   1 to 1

538538538538

5, 3, 8, 5, 3, 8, 5, 3, 8, 5, 3, 8
53, 85, 38, 53, 85, 38
538, 538, 538, 538

`31000881061`

## Part 2

123456789012 - Length 12

Factor of 3, length is 3 => 4 groups, 123, 456, 789, 012
Root chunk = "123"

# Day 3

## Part 2

N starts at 12

startingIndex = 0

We go from the right over N characters. We find the biggest character in the set to the left, and also its' first index (position). Then we repeat that for N - 1, N - 2, ..., except "the characters to the left" start at the index of the previous maximum number + 1.

As an example: 818181911112111. This is length 15

`.AsSpan(startingIndex, length - startingIndex - N + 1)`

N = 12, startingIndex = 0
1 character: we look at `.AsSpan(0, 15 - 0 - 12 + 1)`, or `.AsSpan(0, 4)`, or "8181". The largest character is '8', at index 0. startingIndex = 0 + 1 = 1

N = 11, startingIndex = 1
2 character: we look at `.AsSpan(1, 15 - 1 - 11 + 1)`, or `.AsSpan(1, 4)`, or "1818". The largest character is '8', at index 2. startingIndex = 2 + 1 = 3

N = 10, startingIndex = 3
3 character: we look at `.AsSpan(3, 15 - 3 - 10 + 1)`, or `.AsSpan(3, 3)`, or "181". The largest character is '8', at index 4. startingIndex = 4 + 1 = 5

N = 9, startingIndex = 5
4 character: we look at `.AsSpan(5, 15 - 5 - 9 + 1)`, or `.AsSpan(5, 2)`, or "19". The largest character is '9', at index 6. startingIndex = 6 + 1 = 7

N = 8, startingIndex = 7
5 character: we look at `.AsSpan(7, 15 - 7 - 8 + 1)`, or `.AsSpan(7, 1)`, or "1". The largest character is '1', at index 7. startingIndex = 7 + 1 = 8

N = 7, startingIndex = 8
6 character: we look at `.AsSpan(8, 15 - 8 - 7 + 1)`, or `.AsSpan(8, 1)`, or "1". The largest character is '1', at index 8. startingIndex = 8 + 1 = 9

N = 6, startingIndex = 9
7 character: we look at `.AsSpan(9, 15 - 9 - 6 + 1)`, or `.AsSpan(9, 1)`, or "1". The largest character is '1', at index 9. startingIndex = 9 + 1 = 10

N = 5, startingIndex = 10
8 character: we look at `.AsSpan(10, 15 - 10 - 5 + 1)`, or `.AsSpan(10, 1)`, or "1". The largest character is '1', at index 10. startingIndex = 10 + 1 = 11

N = 4, startingIndex = 11
9 character: we look at `.AsSpan(11, 15 - 11 - 4 + 1)`, or `.AsSpan(11, 1)`, or "2". The largest character is '2', at index 11. startingIndex = 11 + 1 = 12

N = 3, startingIndex = 12
10 character: we look at `.AsSpan(12, 15 - 12 - 3 + 1)`, or `.AsSpan(12, 1)`, or "1". The largest character is '1', at index 12. startingIndex = 12 + 1 = 13

N = 2, startingIndex = 13
11 character: we look at `.AsSpan(13, 15 - 13 - 2 + 1)`, or `.AsSpan(13, 1)`, or "1". The largest character is '1', at index 13. startingIndex = 13 + 1 = 14

N = 1, startingIndex = 14
12 character: we look at `.AsSpan(14, 15 - 14 - 1 + 1)`, or `.AsSpan(14, 1)`, or "1". The largest character is '1', at index 14. startingIndex = 14 + 1 = 15

So, the resulting number is `888911112111`

888911112111
888911112111

# Day 7

## Part 1

* Look at each character:
    * '.' => If the previous one is a '|' or 'S', then change it to a '|'
    * '|' => Do nothing
    * '^' => If the previous one is a '|', update the split count, and change the characters to the immediate left and right to '|', assuming it's not out of bounds