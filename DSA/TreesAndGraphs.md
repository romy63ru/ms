
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

