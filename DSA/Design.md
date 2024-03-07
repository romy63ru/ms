
# Design

- [ ] Serialize and Deserialize BST [891](https://leetcode.com/explore/interview/card/microsoft/51/design/891/)
- [ ] Serialize and Deserialize Binary Tree [201](https://leetcode.com/explore/interview/card/microsoft/51/design/201/)
- [ ] Implement Trie (Prefix Tree) [892](https://leetcode.com/explore/interview/card/microsoft/51/design/892/)

## LRU Cache [161](https://leetcode.com/explore/interview/card/microsoft/51/design/161/)

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
