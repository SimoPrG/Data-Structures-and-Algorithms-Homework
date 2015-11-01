namespace TreesAndTraversals.Tree
{
    using System.Collections.Generic;

    class TreeNode<T>
    {
        public TreeNode(T element)
        {
            this.Element = element;
        }

        public T Element { get; }

        public bool HasParent { get; set; } = false;

        public List<TreeNode<T>> Children { get; } = new List<TreeNode<T>>();

        public override string ToString()
        {
            return this.Element.ToString();
        }
    }
}