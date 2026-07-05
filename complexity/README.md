<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Table of Contents**

- [1. Asymptotic Bounding](#1-asymptotic-bounding)
- [2. Big-O Complexity](#2-big-o-complexity)
  - [2.1 O(1)](#21-o1)
  - [2.2 O(log n)](#22-olog-n)
  - [2.3 O(n)](#23-on)
  - [2.4 O(n log(n))](#24-on-logn)
  - [2.5 O(n^2)](#25-on2)
  - [2.6 O(2^n)](#26-o2n)
  - [2.7 O(n!)](#27-on)
- [3. DSAs and their asymptotic complexity](#3-dsas-and-their-asymptotic-complexity)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

- `https://www.bigocheatsheet.com/`
- `https://cathyatseneca.gitbooks.io/data-structures-and-algorithms/content/analysis/notations.html`

# 1. Asymptotic Bounding

- Big-O = Upper-bound, considered to be "loose" or conservative with worse case scenario in mind
- Big-Ω (omega) = Lower-bound, consider the best case scenario
- Big-θ (theta) = The "tight" bound, also know as the best approximation possible, or fit function

# 2. Big-O Complexity

<img width="524" height="587" alt="image" src="https://github.com/user-attachments/assets/ef3102d2-76cd-4bed-ae9d-b25ca089b36c" />

## 2.1 O(1)

- Accessing values in a hash table by key

## 2.2 O(log n)

- Divide and conquer algorithms

## 2.3 O(n)

- Traversing a list

## 2.4 O(n log(n))

- Iterations that use divide and conquer

## 2.5 O(n^2)

- 2 Nested for loops

## 2.6 O(2^n)

- Naive recursive Fibonacci sequence calculation

## 2.7 O(n!)

- Adding a nested loop for each loop

# 3. DSAs and their asymptotic complexity

## Data Structure Complexity

**Legend:** 🟢 Best performance · 🟡 Good · 🟠 Moderate · 🔴 Poor · ⚪ N/A

| Data Structure                                                                             |    Avg. Access |    Avg. Search | Avg. Insertion |  Avg. Deletion |   Worst Access |   Worst Search | Worst Insertion | Worst Deletion |      Worst Space |
| ------------------------------------------------------------------------------------------ | -------------: | -------------: | -------------: | -------------: | -------------: | -------------: | --------------: | -------------: | ---------------: |
| [Array](https://en.wikipedia.org/wiki/Array_data_structure)                                |      🟢 `Θ(1)` |      🟡 `Θ(n)` |      🟡 `Θ(n)` |      🟡 `Θ(n)` |      🟢 `O(1)` |      🟡 `O(n)` |       🟡 `O(n)` |      🟡 `O(n)` |        🟡 `O(n)` |
| [Stack](https://en.wikipedia.org/wiki/Stack_%28abstract_data_type%29)                      |      🟡 `Θ(n)` |      🟡 `Θ(n)` |      🟢 `Θ(1)` |      🟢 `Θ(1)` |      🟡 `O(n)` |      🟡 `O(n)` |       🟢 `O(1)` |      🟢 `O(1)` |        🟡 `O(n)` |
| [Queue](https://en.wikipedia.org/wiki/Queue_%28abstract_data_type%29)                      |      🟡 `Θ(n)` |      🟡 `Θ(n)` |      🟢 `Θ(1)` |      🟢 `Θ(1)` |      🟡 `O(n)` |      🟡 `O(n)` |       🟢 `O(1)` |      🟢 `O(1)` |        🟡 `O(n)` |
| [Singly-Linked List](https://en.wikipedia.org/wiki/Singly_linked_list#Singly_linked_lists) |      🟡 `Θ(n)` |      🟡 `Θ(n)` |      🟢 `Θ(1)` |      🟢 `Θ(1)` |      🟡 `O(n)` |      🟡 `O(n)` |       🟢 `O(1)` |      🟢 `O(1)` |        🟡 `O(n)` |
| [Doubly-Linked List](https://en.wikipedia.org/wiki/Doubly_linked_list)                     |      🟡 `Θ(n)` |      🟡 `Θ(n)` |      🟢 `Θ(1)` |      🟢 `Θ(1)` |      🟡 `O(n)` |      🟡 `O(n)` |       🟢 `O(1)` |      🟢 `O(1)` |        🟡 `O(n)` |
| [Skip List](https://en.wikipedia.org/wiki/Skip_list)                                       | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` |      🟡 `O(n)` |      🟡 `O(n)` |       🟡 `O(n)` |      🟡 `O(n)` | 🟠 `O(n log(n))` |
| [Hash Table](https://en.wikipedia.org/wiki/Hash_table)                                     |        ⚪ `N/A` |      🟢 `Θ(1)` |      🟢 `Θ(1)` |      🟢 `Θ(1)` |        ⚪ `N/A` |      🟡 `O(n)` |       🟡 `O(n)` |      🟡 `O(n)` |        🟡 `O(n)` |
| [Binary Search Tree](https://en.wikipedia.org/wiki/Binary_search_tree)                     | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` |      🟡 `O(n)` |      🟡 `O(n)` |       🟡 `O(n)` |      🟡 `O(n)` |        🟡 `O(n)` |
| [Cartesian Tree](https://en.wikipedia.org/wiki/Cartesian_tree)                             |        ⚪ `N/A` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` |        ⚪ `N/A` |      🟡 `O(n)` |       🟡 `O(n)` |      🟡 `O(n)` |        🟡 `O(n)` |
| [B-Tree](https://en.wikipedia.org/wiki/B-tree)                                             | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `O(log(n))` | 🟢 `O(log(n))` |  🟢 `O(log(n))` | 🟢 `O(log(n))` |        🟡 `O(n)` |
| [Red-Black Tree](https://en.wikipedia.org/wiki/Red%E2%80%93black_tree)                     | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `O(log(n))` | 🟢 `O(log(n))` |  🟢 `O(log(n))` | 🟢 `O(log(n))` |        🟡 `O(n)` |
| [Splay Tree](https://en.wikipedia.org/wiki/Splay_tree)                                     |        ⚪ `N/A` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` |        ⚪ `N/A` | 🟢 `O(log(n))` |  🟢 `O(log(n))` | 🟢 `O(log(n))` |        🟡 `O(n)` |
| [AVL Tree](https://en.wikipedia.org/wiki/AVL_tree)                                         | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `O(log(n))` | 🟢 `O(log(n))` |  🟢 `O(log(n))` | 🟢 `O(log(n))` |        🟡 `O(n)` |
| [KD Tree](https://en.wikipedia.org/wiki/K-d_tree)                                          | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` | 🟢 `Θ(log(n))` |      🟡 `O(n)` |      🟡 `O(n)` |       🟡 `O(n)` |      🟡 `O(n)` |        🟡 `O(n)` |



## Sorting Algorithm Complexity

**Legend:** 🟢 Best performance · 🟡 Good · 🟠 Moderate · 🔴 Poor

| Algorithm                                                      | Time Complexity (Best) | Time Complexity (Average) | Time Complexity (Worst) | Space Complexity (Worst) |
| -------------------------------------------------------------- | ---------------------: | ------------------------: | ----------------------: | -----------------------: |
| [Quicksort](https://en.wikipedia.org/wiki/Quicksort)           |       🟠 `Ω(n log(n))` |          🟠 `Θ(n log(n))` |              🔴 `O(n²)` |           🟢 `O(log(n))` |
| [Mergesort](https://en.wikipedia.org/wiki/Merge_sort)          |       🟠 `Ω(n log(n))` |          🟠 `Θ(n log(n))` |        🟠 `O(n log(n))` |                🟡 `O(n)` |
| [Timsort](https://en.wikipedia.org/wiki/Timsort)               |              🟡 `Ω(n)` |          🟠 `Θ(n log(n))` |        🟠 `O(n log(n))` |                🟡 `O(n)` |
| [Heapsort](https://en.wikipedia.org/wiki/Heapsort)             |       🟠 `Ω(n log(n))` |          🟠 `Θ(n log(n))` |        🟠 `O(n log(n))` |                🟢 `O(1)` |
| [Bubble Sort](https://en.wikipedia.org/wiki/Bubble_sort)       |              🟡 `Ω(n)` |                🔴 `Θ(n²)` |              🔴 `O(n²)` |                🟢 `O(1)` |
| [Insertion Sort](https://en.wikipedia.org/wiki/Insertion_sort) |              🟡 `Ω(n)` |                🔴 `Θ(n²)` |              🔴 `O(n²)` |                🟢 `O(1)` |
| [Selection Sort](https://en.wikipedia.org/wiki/Selection_sort) |             🔴 `Ω(n²)` |                🔴 `Θ(n²)` |              🔴 `O(n²)` |                🟢 `O(1)` |
| [Tree Sort](https://en.wikipedia.org/wiki/Tree_sort)           |       🟠 `Ω(n log(n))` |          🟠 `Θ(n log(n))` |              🔴 `O(n²)` |                🟡 `O(n)` |
| [Shell Sort](https://en.wikipedia.org/wiki/Shellsort)          |       🟠 `Ω(n log(n))` |        🔴 `Θ(n(log(n))²)` |      🔴 `O(n(log(n))²)` |                🟢 `O(1)` |
| [Bucket Sort](https://en.wikipedia.org/wiki/Bucket_sort)¹      |          🟢 `Ω(n + k)` |             🟢 `Θ(n + k)` |              🔴 `O(n²)` |                🟡 `O(n)` |
| [Radix Sort](https://en.wikipedia.org/wiki/Radix_sort)²        |             🟢 `Ω(nk)` |                🟢 `Θ(nk)` |              🟢 `O(nk)` |            🟡 `O(n + k)` |
| [Counting Sort](https://en.wikipedia.org/wiki/Counting_sort)³  |          🟢 `Ω(n + k)` |             🟢 `Θ(n + k)` |           🟢 `O(n + k)` |                🟡 `O(k)` |
| [Cubesort](https://en.wikipedia.org/wiki/Cubesort)             |              🟡 `Ω(n)` |          🟠 `Θ(n log(n))` |        🟠 `O(n log(n))` |                🟡 `O(n)` |

### Notes

1. **Bucket Sort:** only for integers; `k` is the number of buckets.
2. **Radix Sort:** `k` is the constant number of digits.
3. **Counting Sort:** `k` is the difference between the maximum and minimum values.

