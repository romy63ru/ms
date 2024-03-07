# Data Structure and Algorithms Brief
>Alex Romanov, Saturday 2 March 2024

## Data Structure

### LinkedList

`LinkedList<T>()` 
in C# cant manage nodes!

### Stack and Queue
```C#
Stack<T>()
	T Pop()
	T Peek() 
	bool Contains(T item)
	void Push(T item)
```

```C#
Queue<T>()
	void Enqueue(T item)
	T Dequeue()
```


# LinkedLists

- [ ] Reverse Linked List [169](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/169/)


## Linked List Cycle

[https://leetcode.com/explore/interview/card/microsoft/32/linked-list/184/]

Given head, the head of a linked list, determine if the linked list has a cycle in it.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

Return true if there is a cycle in the linked list. Otherwise, return false.

```C#
public class Solution {
    public bool HasCycle(ListNode head) {
        if(head==null) return false;
        List<ListNode> list = new List<ListNode>();
        ListNode node = head;
        while(node.next != null)
        {
            if(list.Contains(node))
            {
                return true;
            }
            list.Add(node);
            node = node.next;
        }
        return false;
    }
}
```

> O(N)?

- [ ] Add Two Numbers [170](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/170/)
- [ ] Add Two Numbers II [205](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/205/)
- [ ] Merge Two Sorted Lists [175](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/175/)
- [ ] Merge k Sorted Lists [209](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/209/)
- [ ] Intersection of Two Linked Lists [212](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/212/)
- [ ] Copy List with Random Pointer [168](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/168/)

# Trees and Graphs

## Validate Binary Search Tree

[152](https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/152/)

Given the root of a binary tree, determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:

- The left subtree of a node contains only nodes with keys less than the node's key.
- The right subtree of a node contains only nodes with keys greater than the node's key.
- Both the left and right subtrees must also be binary search trees.

### Example 1:

![alt text](https://assets.leetcode.com/uploads/2020/12/01/tree1.jpg)

```
Input: root = [2,1,3]
Output: true
```
### Example 2:

![alt text](https://assets.leetcode.com/uploads/2020/12/01/tree2.jpg)

```
Input: root = [5,1,4,null,null,3,6]
Output: false
Explanation: The root node's value is 5 but its right child's value is 4.
```

### Constraints:

```
The number of nodes in the tree is in the range [1, 104].
-231 <= Node.val <= 231 - 1
```

```C#
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public bool IsValidBST(TreeNode root) {
        return Evaluate(root, long.MinValue, long.MaxValue);
    }

    private bool Evaluate(TreeNode node, long min, long max)
    {
        if (node == null)
        {
            return true;
        }

        return (
            node.val > min &&
            node.val < max &&
            Evaluate(node.left, min, node.val) &&
            Evaluate(node.right, node.val, max)
        );
    }
}
```

> Time complexity: O(N) since we visit each node exactly once.
> Space complexity: O(N) since we keep up to the entire tree.

[Solution](https://leetcode.com/problems/validate-binary-search-tree/editorial/)

## Binary Tree Inorder Traversal

[153](https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/153/)

Given the root of a binary tree, return the inorder traversal of its nodes' values.

### Example1:

![Example1](https://assets.leetcode.com/uploads/2020/09/15/inorder_1.jpg)

```
Input: root = [1,null,2,3]
Output: [1,3,2]
```

### Example 2:

```
Input: root = []
Output: []
```

### Example 3:

Input: root = [1]
Output: [1]
 

### Constraints:

```
The number of nodes in the tree is in the range [0, 100].
-100 <= Node.val <= 100
``` 

> Follow up: Recursive solution is trivial, could you do it iteratively?



```C#
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> result = new List<int>();
        void InOrder(TreeNode node)
        {
            if(node!=null)
            {
                InOrder(node.left);
                result.Add(node.val);
                InOrder(node.right);
            }
        }
        InOrder(root);
        return result;
    }
}
```

## Binary Tree Level Order Traversal

[164](https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/164/)

```C#
 /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root)
    {             
        var result = new List<IList<int>>();
        if(root == null)
        {
            return result;   
        }
           
        var que = new Queue<TreeNode>();

        if(root==null) return result;

        que.Enqueue(root);
        while (que.Count != 0)
        {
            int n = que.Count;
            var subList = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (que.Peek().left != null)
                    que.Enqueue(que.Peek().left);
                if (que.Peek().right != null)
                    que.Enqueue(que.Peek().right);
                subList.Add(que.Dequeue().val);
            }
            result.Add(subList);
        }
        return result;
    }
}
```

## Binary Tree Zigzag Level Order Traversal

```C#
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if (root == null) return result;

        var queue = new Queue<IEnumerable<TreeNode>>();
        queue.Enqueue(new []{root});
        var level = 0;

        while(queue.Any())
        {
            var nextLevel = new Stack<TreeNode>();
            var levelRes = new List<int>();
            result.Add(levelRes);
            var isEven = level++%2==0;
            foreach(var node in queue.Dequeue())
            {
                levelRes.Add(node.val);
                
                var first = isEven ? node.left : node.right;
                var second = isEven ? node.right : node.left;

                if (first != null) nextLevel.Push(first);
                if (second != null) nextLevel.Push(second);
            }
            if (nextLevel.Any())
            {
                queue.Enqueue(nextLevel);
            }
        }
        return result;
    }
}
```

- [ ] Populating Next Right Pointers in Each Node [192](https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/192/)

## Populating Next Right Pointers in Each Node II

[163](https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/163/)

```C#
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        if(root == null)
        {
            return root;   
        }
           
        var que = new Queue<Node>();
        que.Enqueue(root);

        while (que.Count > 0)
        {
            int n = que.Count;
        
            for (int i = 0; i < n; i++)
            {
                Node node = que.Dequeue();

                if(i<n-1)
                {
                    node.next = que.Peek();
                }

                if (node.left != null)
                {
                    que.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    que.Enqueue(node.right);
                }
            }   
        }
        return root;
    }
}
```

## Lowest Common Ancestor of a Binary Search Tree

[182](https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/182/)

```C#
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        int parentVal = root.val;
        int pVal = p.val;
        int qVal = q.val;

        if(pVal > parentVal && qVal > parentVal)
        {
            return LowestCommonAncestor(root.right, p, q);
        }
        else if(pVal < parentVal && qVal < parentVal)
        {
            return LowestCommonAncestor(root.left, p, q);
        }
        else
        {
            return root;
        }
    }
}
```

## Lowest Common Ancestor of a Binary Tree

[181](https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/181/)

```C#
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    TreeNode ans = null;

    bool recurseTree(TreeNode currentNode, TreeNode p, TreeNode q)
    {
        if(currentNode == null)
        {
            return false;
        }

        int left = recurseTree(currentNode.left, p, q) ? 1 : 0;
        int right = recurseTree(currentNode.right, p, q) ? 1 : 0;
        int mid = (currentNode == p || currentNode == q) ? 1 : 0;

        if(mid + left + right >= 2)
        {
            ans = currentNode;
        }
        return mid + left + right > 0;
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        recurseTree(root, p, q);
        return ans;
    }
}
```

 - [ ] Construct Binary Tree from Preorder and Inorder Traversal [196](https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/196/)
 - [ ] Number of Islands [185](https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/185/)

## Clone Graph

[210](https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/210/)

```C#
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    Dictionary<Node,Node> visited = new Dictionary<Node,Node>();
    public Node CloneGraph(Node node) {
        if (node == null) return node;

        if(visited.ContainsKey(node))
        {
            return visited[node];
        }

        var cloneNode = new Node(node.val, new List<Node>());
        visited.Add(node, cloneNode);

        foreach(Node neighbor in node.neighbors) {
            cloneNode.neighbors.Add(CloneGraph(neighbor));
        }
        return cloneNode;
    }
}
```

# Backtracking

## Letter Combinations of a Phone Number

[165](https://leetcode.com/explore/interview/card/microsoft/46/backtracking/165/)

```C#
public class Solution {
     List<string> result = new List<string>();
    Dictionary<char, string> matrix = new Dictionary<char, string>(){
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"}
    };
    string phoneDigits;

    public IList<string> LetterCombinations(string digits) {
        if(string.IsNullOrEmpty(digits))
        {
            return result;
        }

        phoneDigits = digits;
        backtrack(0, new StringBuilder());
        return result;
    }

    private void backtrack(int index, StringBuilder path)
    {
        if(path.Length == phoneDigits.Length) 
        {
            result.Add(path.ToString());
            return;
        }

        string possibleLetters = matrix[phoneDigits[index]];
        foreach(char letter in possibleLetters) 
        {
            path.Append(letter);
            backtrack(index+1, path);
            path.Remove(path.Length-1, 1);
        }
    }
}
```

## Word Search II

[256](https://leetcode.com/explore/interview/card/microsoft/46/backtracking/256/)

```C#
public class TrieNode
{
    public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    public string word;
}

public class Solution {
    private List<string> result = new List<string>();
    private char[][] board;
    
    public IList<string> FindWords(char[][] board, string[] words) 
    {
        this.board = board;

        //tree contruction
        TrieNode root = new TrieNode();
        foreach(string word in words)
        {
            TrieNode node = root;
            foreach(char letter in word)
            {
                if(node.children.ContainsKey(letter))
                {
                    node = node.children[letter];
                }
                else 
                {
                    TrieNode newNode = new TrieNode();
                    node.children.Add(letter, newNode);
                    node = newNode;
                }
            }
            node.word = word;
        }

        //backtraking
        for(int row=0;row<board.Length; ++row)
        {
            for(int col = 0; col < board[row].Length; ++col)
            {
                if(root.children.ContainsKey(board[row][col]))
                {
                    backtracking(row, col, root);
                }
            }
        }

        return result;
    }
    
    private void backtracking(int row, int col, TrieNode parent)
    {
        char letter = board[row][col];
        TrieNode curNode = parent.children[letter];

        if(curNode.word != null)
        {
            result.Add(curNode.word);
            curNode.word = null;
        }

        board[row][col] = '#';

        int[] rowOffset = {-1,0,1,0};
        int[] colOffset = {0,1,0,-1};

        for(int i=0; i<4; ++i)
        {
            int newRow = row+rowOffset[i];
            int newCol = col + colOffset[i];
            if(newRow < 0 || newRow >= board.Length || newCol < 0 || newCol >= board[0].Length)
            {
                continue;
            }
            if(curNode.children.ContainsKey(board[newRow][newCol]))
            {
                backtracking(newRow, newCol, curNode);
            }
        }
        board[row][col] = letter;

        if(curNode.children.Count == 0)
        {
            parent.children.Remove(letter);
        }
    }
}
```

## Wildcard Matching

[155](https://leetcode.com/explore/interview/card/microsoft/46/backtracking/155/)

```C#
public class Solution {
    public bool IsMatch(string s, string p) {
        int sLen = s.Length;
        int pLen = p.Length;
        int sIdx = 0;
        int pIdx = 0;
        int starIdx = -1;
        int sTmpIdx = -1;
        while (sIdx < sLen)
        {
            if(pIdx<pLen && (p[pIdx]=='?' || p[pIdx] == s[sIdx]))
            {
                sIdx++;
                pIdx++;
            }
            else if (pIdx < pLen && p[pIdx] == '*')
            {
                starIdx = pIdx;
                sTmpIdx = sIdx;
                ++pIdx;
            }
            else if (starIdx == -1)
            {
                return false;
            }
            else
            {
                pIdx = starIdx + 1;
                sIdx = sTmpIdx + 1;
                sTmpIdx = sIdx;
            }
        }

        for (int i =pIdx; i<pLen; i++)
        {
            if(p[i] != '*')
            {
                return false;
            }
        }
        return true;
    }
}
```

- [ ] Regular Expression Matching [189](https://leetcode.com/explore/interview/card/microsoft/46/backtracking/189/)

# Sorting and Searching

## Remove Duplicates from Sorted Array

[257](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/257/)

```C#
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int insertIndex = 1;

        for(int i=1; i<nums.Length; i++)
        {
            if(nums[i-1]!= nums[i])
            {
                nums[insertIndex] = nums[i];
                insertIndex++;
            }
        }
        return insertIndex;
    }
}
```

- [ ] Merge Sorted Array [258](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/258/)
- [ ] Sort Colors [text](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/193/)

## Find Minimum in Rotated Sorted Array  

[206](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/206/)

```C#
public class Solution {
    public int FindMin(int[] nums) {
        int left=0, right=nums.Length-1, mid=0;
        while(left < right)
        {
            mid = (left + right) /2;
            if(nums[mid] > nums[right])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }
        return nums[left];
    }
}
```

## Find Minimum in Rotated Sorted Array II

[207](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/207/)

```C#
public class Solution {
    public int FindMin(int[] nums) {
        int left=0, right=nums.Length-1;
        while(left < right)
        {
            int mid = left + (right-left) /2;
            if(nums[mid] < nums[right])
            {
                right = mid;
            }
            else if(nums[mid]>nums[right])
            {
                left = mid+1;
            }
            else{
                right--;
            }
        }
        return nums[left];
    }
}
```

- [ ] Search in Rotated Sorted Array [191](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/191/)
- [ ]  Search a 2D Matrix [154](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/154/)
- [ ]  Search a 2D Matrix II [195](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/195/)
- [ ]  Median of Two Sorted Arrays [890](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/890/)

# Dynamic programming

## Best Time to Buy and Sell Stock

[186](https://leetcode.com/explore/interview/card/microsoft/49/dynamic-programming/186/)

```C#
public class Solution {
    public int MaxProfit(int[] prices) {
        int min = Int32.MaxValue;
        int profit  = 0; 
        for(int i = 0; i< prices.Length; i++)
        {
            if(prices[i] < min)
            {
                min = prices[i];
            }
            else if(prices[i]-min > profit)
            {
                profit = prices[i] - min;
            }
        }
        return profit;
    }
}
```

- [ ] Maximum Subarray [174](https://leetcode.com/explore/interview/card/microsoft/49/dynamic-programming/174/)

## Longest Increasing Subsequence

[156](https://leetcode.com/explore/interview/card/microsoft/49/dynamic-programming/156/)

```C#
public class Solution {
    public int LengthOfLIS(int[] nums) {
        int len = 0;
        int[] tails = new int[nums.Length];

        foreach (int num in nums) {
            int left = 0, right = len;
            
            while (left < right) {
                int mid = left + (right - left) / 2;
                if (tails[mid] < num) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            
            tails[left] = num;
            if (left == len) {
                len++;
            }
        }
        
        return len;
    }
}
```

# Design

- [ ] Serialize and Deserialize BST [891](https://leetcode.com/explore/interview/card/microsoft/51/design/891/)
- [ ] Serialize and Deserialize Binary Tree [201](https://leetcode.com/explore/interview/card/microsoft/51/design/201/)
- [ ] Implement Trie (Prefix Tree) [892](https://leetcode.com/explore/interview/card/microsoft/51/design/892/)

## LRU Cache

[161](https://leetcode.com/explore/interview/card/microsoft/51/design/161/)

```C#
public class LRUCache {
    
    public class LruListNode 
    {
        public int key;
        public int value;
        public LruListNode next;
        public LruListNode prev;

        public LruListNode(int key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }

    int capacity;
    Dictionary<int, LruListNode> dic;
    LruListNode head;
    LruListNode tail;

    
    public LRUCache(int capacity) {
        this.capacity = capacity;
        dic = new Dictionary<int,LruListNode>();
        head = new LruListNode(-1,-1);
        tail = new LruListNode(-1,-1);
        head.next = tail;
        tail.prev = head;
    }
    
    public int Get(int key) {
        if(!dic.ContainsKey(key))
        {
            return -1;
        }

        LruListNode node = dic[key];
        remove(node);
        add(node);
        return node.value;
    }
    
    public void Put(int key, int value) {
        if(dic.ContainsKey(key)) {
            LruListNode oldNode = dic[key];
            remove(oldNode);
            dic.Remove(key);
        }

        LruListNode node = new LruListNode(key,value);
        dic.Add(key, node);
        add(node);

        if(dic.Count() > capacity)
        {
            LruListNode nodeToDelete = head.next;
            remove(nodeToDelete);
            dic.Remove(nodeToDelete.key);
        }
    }

    public void add(LruListNode node) 
    {
        LruListNode previousEnd = tail.prev;
        previousEnd.next = node;
        node.prev = previousEnd;
        node.next = tail;
        tail.prev = node;
    }

    public void remove(LruListNode node)
    {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
```

# Other

- [ ] Single Number [208](https://leetcode.com/explore/interview/card/microsoft/48/others/208/)
- [ ] Roman to Integer [198](https://leetcode.com/explore/interview/card/microsoft/48/others/198/)
- [ ] Excel Sheet Column Number [183](https://leetcode.com/explore/interview/card/microsoft/48/others/183/)
- [ ] Find the Celebrity [194](https://leetcode.com/explore/interview/card/microsoft/48/others/194/)
- [ ] Integer to English Words [188](https://leetcode.com/explore/interview/card/microsoft/48/others/188/)
- [ ] The Skyline Problem [157](https://leetcode.com/explore/interview/card/microsoft/48/others/157/)