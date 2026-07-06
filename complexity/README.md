<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Table of Contents**

- [1. Asymptotic Bounding](#1-asymptotic-bounding)
- [1.1 References](#11-references)
- [2. Big-O Complexity](#2-big-o-complexity)
  - [2.1 O(1)](#21-o1)
  - [2.2 O(log n)](#22-olog-n)
  - [2.3 O(n)](#23-on)
  - [2.4 O(n log(n))](#24-on-logn)
  - [2.5 O(n^2)](#25-on2)
  - [2.6 O(2^n)](#26-o2n)
  - [2.7 O(n!)](#27-on)
- [3. Little-o](#3-little-o)
- [4. DSAs and their asymptotic complexity](#4-dsas-and-their-asymptotic-complexity)
  - [4.1 Data Structure Complexity](#41-data-structure-complexity)
  - [4.2 Sorting Algorithm Complexity](#42-sorting-algorithm-complexity)
    - [Notes](#notes)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

General References:
- [Big-O Cheat Sheet](https://www.bigocheatsheet.com/)
- [DSA](https://cathyatseneca.gitbooks.io/data-structures-and-algorithms/content/analysis/notations.html)

# 1. Complexity Measurements

The main measurements of complexity are:

## 1.1 Time Complexity

The time it takes (how fast it runs) as the input size increases and tend to infinite.

## 1.2 Space Complexity

How much memory it uses as the input size increases and tend to infinite.

## 1.3 Other Less Common Complexity Measurements

Considering other forms of complexity measurements we can organize these into:

```
COMPLEXITY MEASURES
│
├── Sequential computation
│   ├── Time
│   └── Space
│
├── Memory hierarchy
│   ├── I/O operations
│   └── Cache misses
│
├── Distributed systems
│   ├── Communication
│   ├── Messages
│   └── Communication rounds
│
├── Parallel computation
│   ├── Work
│   └── Span / Depth
│
├── Black-box computation
│   └── Query complexity
│
└── Circuit computation
    ├── Circuit size
    └── Circuit depth
```

### 1.3.1 I/O Complexity

How much I/O operations the algorithm executes as the input size increases. [Link](https://cs.au.dk/~gerth/emF03/)

- Storage → RAM
- RAM → CPU Cache

Depending on the context, for example, operations with a database, the number of CPU instructions might not be as important as the IO operations.

- Algorithm A:
10 billon CPU ops
100 storage reads

- Algorithm B:
1 million CPU ops
1 million storage reads

In this case A might run faster.

### 1.3.2 Communication Complexity

How many bits are required to solve the problem? [Link](https://theory.stanford.edu/~tim/w15/l/w15.pdf)

### 1.3.3 Query Complexity

Measures how many times the algorithm needs to query a data source. (Database, API, Black Box Function). [Link](https://www.cs.cmu.edu/~odonnell/quantum15/lecture05.pdf)

### 1.3.4 Parallel Computation (Work / Span)

TBD [Link](https://ocw.mit.edu/courses/6-172-performance-engineering-of-software-systems-fall-2018/497aa98bab1b3b9e643653a8a2af2a3b_a_R_DpsENfk.pdf?utm_source=chatgpt.com)

### 1.3.5 Circuit Size and Circuit Depth

TBD

# 2. Asymptotic Bounding

- Big-O = Upper-bound, considered to be "loose" or conservative with worse case scenario in mind
- Big-Ω (omega) = Lower-bound, consider the best case scenario
- Big-θ (theta) = The "tight" bound, also know as the best approximation possible, or fit function

or more complete:

- f(n)=O(g(n)) : asymptotic upper bound
- f(n)=o(g(n)) : strict asymptotic upper bound (little o)
- f(n)=Ω(g(n)) : asymptotic lower bound
- f(n)=ω(g(n)) : strict asymptotic lower bound (little omega)
- f(n)=Θ(g(n)) : same asymptotic order

In other words:

* $T(n)$ is $O(f(n))$: growth rate of $T(n)$ $\le$ growth rate of $f(n)$
* $T(n)$ is $o(f(n))$: growth rate of $T(n)$ $<$ growth rate of $f(n)$
* $T(n)$ is $\Omega(f(n))$: growth rate of $T(n)$ $\ge$ growth rate of $f(n)$
* $T(n)$ is $\omega(f(n))$: growth rate of $T(n)$ $>$ growth rate of $f(n)$
* $T(n)$ is $\Theta(f(n))$: growth rate of $T(n)$ $=$ growth rate of $f(n)$

## 2.1 References

- [Back to Back SWE Youtube Video](https://www.youtube.com/watch?v=0oDAlMwTrLo)

# 3. Big-O Complexity

<img width="612" height="598" alt="image" src="https://github.com/user-attachments/assets/f58a2f1f-aa26-4914-91cb-7e1355ab0931" />

## 3.1 O(1)

- Accessing values in a hash table by key

## 3.2 O(log n)

- Divide and conquer algorithms

## 3.3 O(n)

- Traversing a list

## 3.4 O(n log(n))

- Iterations that use divide and conquer

## 3.5 O(n^2)

- 2 Nested for loops

## 3.6 O(2^n)

- Naive recursive Fibonacci sequence calculation

## 3.7 O(n!)

- Adding a nested loop for each loop

# 4. Little-o

* f(n) = O(g(n))    → same growth or slower
* f(n) = o(g(n))    → strictly slower

$$
f(n)=o(g(n))
\iff
\lim_{n\to\infty}\frac{f(n)}{g(n)}=0
$$

| Statement      | True? | Reason                 |
| -------------- | ----: | ---------------------- |
| 1 = o(n)       |     ✅ | 1/n → 0               |
| log n = o(n)   |     ✅ | log n/n → 0           |
| n = o(n^2)     |     ✅ | 1/n → 0               |
| n = o(n log n))|     ✅ | 1/log n → 0           |
| n = o(2n)      |     ❌ | n/(2n) = 1/2          |
| n^2 = o(n^2)   |     ❌ | ratio is (1)          |
| 3n^2 = o(n^2)  |     ❌ | ratio is (3)          |
| n^2 = O(n^2)   |     ✅ | same asymptotic order |

$$
o(g(n)) \subset O(g(n))
$$


# 5. DSAs and their asymptotic complexity

## 5.1 Data Structure Complexity
**Legend:** <img src="../docs/images/green.svg"> Best · <img src="../docs/images/lightgreen.svg"> Very Good
· <img src="../docs/images/yellow.svg"> Good · <img src="../docs/images/orange.svg"> Moderate · <img src="../docs/images/red.svg"> Poor · ⚪ N/A

<table>
  <thead>
    <tr>
      <th rowspan="3">Data&nbsp;Structure</th>
      <th colspan="8">Time Complexity</th>
      <th rowspan="3">Worst&nbsp;Space&nbsp;Complexity</th>
    </tr>
    <tr>
      <th colspan="4">Average</th>
      <th colspan="4">Worst</th>
    </tr>
    <tr>
      <th>Access</th>
      <th>Search</th>
      <th>Insert</th>
      <th>Delete</th>
      <th>Access</th>
      <th>Search</th>
      <th>Insert</th>
      <th>Delete</th>
    </tr>
  </thead>
  <tbody>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/Array_data_structure">Array</a></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;Θ(1)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;Θ(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;Θ(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;Θ(n)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;O(1)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
</tr>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/Stack_(abstract_data_type)">Stack</a></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;Θ(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;Θ(n)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;Θ(1)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;Θ(1)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;O(1)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;O(1)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
</tr>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/Queue_(abstract_data_type)">Queue</a></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;Θ(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;Θ(n)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;Θ(1)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;Θ(1)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;O(1)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;O(1)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
</tr>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/Singly_linked_list#Singly_linked_lists">Singly-Linked&nbsp;List</a></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;Θ(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;Θ(n)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;Θ(1)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;Θ(1)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;O(1)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;O(1)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
</tr>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/Doubly_linked_list">Doubly-Linked&nbsp;List</a></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;Θ(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;Θ(n)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;Θ(1)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;Θ(1)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;O(1)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;O(1)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
</tr>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/Skip_list">Skip&nbsp;List</a></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/orange.svg">&nbsp;O(n&nbsp;log(n))</nobr></td>
</tr>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/Hash_table">Hash&nbsp;Table</a></td>
  <td><nobr>⚪&nbsp;N/A</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;Θ(1)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;Θ(1)</nobr></td>
  <td><nobr><img src="../docs/images/green.svg">&nbsp;Θ(1)</nobr></td>
  <td><nobr>⚪&nbsp;N/A</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
</tr>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/Binary_search_tree">Binary&nbsp;Search&nbsp;Tree</a></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
</tr>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/Cartesian_tree">Cartesian&nbsp;Tree</a></td>
  <td><nobr>⚪&nbsp;N/A</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr>⚪&nbsp;N/A</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
</tr>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/B-tree">B-Tree</a></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
</tr>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/Red%E2%80%93black_tree">Red-Black&nbsp;Tree</a></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
</tr>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/Splay_tree">Splay&nbsp;Tree</a></td>
  <td><nobr>⚪&nbsp;N/A</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr>⚪&nbsp;N/A</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
</tr>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/AVL_tree">AVL&nbsp;Tree</a></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;O(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
</tr>
<tr>
  <td><a href="https://en.wikipedia.org/wiki/K-d_tree">KD&nbsp;Tree</a></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/lightgreen.svg">&nbsp;Θ(log(n))</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
  <td><nobr><img src="../docs/images/yellow.svg">&nbsp;O(n)</nobr></td>
</tr>
</tbody>
</table>

## 5.2 Sorting Algorithm Complexity

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

