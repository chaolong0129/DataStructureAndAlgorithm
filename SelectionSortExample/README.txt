# Selection Sort

# 時間複雜度
比較次數 : O(n^2)
交換最少次數 : O(n)
交會最多次數 : O(n^2)
N = (n-1) + (n-2) + ... + 1 = n(n-1)/2 => O(n^2)

# 原理
在一個隨機的陣列中，依序挑選一個數值，與指標索引值做比較，如果所挑選數值，比指標索引值小，就交換該數值。

Reference : [SelectionSort](https://zh.wikipedia.org/wiki/%E9%80%89%E6%8B%A9%E6%8E%92%E5%BA%8F) 