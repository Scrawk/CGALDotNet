using System;
using System.Collections;
using System.Collections.Generic;

namespace CGALDotNet.CSG
{
    /// <summary>
    /// A node that take a input and returns a output.
    /// </summary>
    /// <typeparam name="INPUT">The input type.</typeparam>
    /// <typeparam name="OUTPUT">The output type.</typeparam>
    public abstract class Node<INPUT, OUTPUT> : Node
    {

        /// <summary>
        /// The nodes function.
        /// </summary>
        /// <param name="arg">The functions input.</param>
        /// <returns>The functions output.</returns>
        public abstract OUTPUT Func(INPUT arg);

        /// <summary>
        /// Add children nodes.
        /// </summary>
        /// <param name="children">The children nodes to add.</param>
        public void AddChildren(IEnumerable<Node<INPUT, OUTPUT>> children)
        {
            foreach (var child in children)
                AddChild(child);
        }

        /// <summary>
        /// Get the child at index i or return the default
        /// node if the index does not exist or the node is null.
        /// The child node type must be the same as the parents.
        /// </summary>
        /// <param name="i">The childs index.</param>
        /// <returns>The child node.</returns>
        public Node<INPUT, OUTPUT> GetChildOrDefault(int i)
        {
            var child = GetChild(i) as Node<INPUT, OUTPUT>;
            if (child == null)
                return EmptyNode<INPUT, OUTPUT>.Default;
            else
                return child;
        }

    }

    /// <summary>
    /// A node that take two inputs and returns a output.
    /// </summary>
    /// <typeparam name="INPUT1">The first input type.</typeparam>
    /// <typeparam name="INPUT2">The second input type.</typeparam>
    /// <typeparam name="OUTPUT">The output type.</typeparam>
    public abstract class Node<INPUT1, INPUT2, OUTPUT> : Node
    {
        /// <summary>
        /// The nodes function.
        /// </summary>
        /// <param name="arg1">The functions first input.</param>
        /// <param name="arg2">The functions second input.</param>
        /// <returns>The functions output.</returns>
        public abstract OUTPUT Func(INPUT1 arg1, INPUT2 arg2);

        /// <summary>
        /// Add children nodes.
        /// </summary>
        /// <param name="children">The children nodes to add.</param>
        public void AddChildren(IEnumerable<Node<INPUT1, INPUT2, OUTPUT>> children)
        {
            foreach (var child in children)
                AddChild(child);
        }

        /// <summary>
        /// Get the child at index i or return the default
        /// node if the index does not exist or the node is null.
        /// The child node type must be the same as the parents.
        /// </summary>
        /// <param name="i">The childs index.</param>
        /// <returns>The child node.</returns>
        public Node<INPUT1, INPUT2, OUTPUT> GetChildOrDefault(int i)
        {
            var child = GetChild(i) as Node<INPUT1, INPUT2, OUTPUT>;
            if (child == null)
                return EmptyNode<INPUT1, INPUT2, OUTPUT>.Default;
            else
                return child;
        }

    }

    /// <summary>
    /// The nodes abstract class.
    /// </summary>
    public abstract class Node : IEnumerable<Node>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Node()
        {
            Children = new List<Node>();
        }

        /// <summary>
        /// The nodes name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The number of children nodes.
        /// </summary>
        public int ChildrenCount => Children.Count;

        /// <summary>
        /// The nodes children.
        /// </summary>
        private List<Node> Children { get; set; }

        /// <summary>
        /// The node as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Node: Children={0}]", ChildrenCount);
        }

        /// <summary>
        /// Add a child node.
        /// </summary>
        /// <param name="child">The node to add.</param>
        public void AddChild(Node child)
        {
            Children.Add(child);
        }

        /// <summary>
        /// Add children nodes.
        /// </summary>
        /// <param name="children">The children nodes to add.</param>
        public void AddChildren(IEnumerable<Node> children)
        {
            Children.AddRange(children);
        }

        /// <summary>
        /// Remove a child node.
        /// </summary>
        /// <param name="child">The node to remove.</param>
        /// <returns>True if the node was removed.</returns>
        public bool RemoveChild(Node child)
        {
            return Children.Remove(child);
        }

        /// <summary>
        /// Remove the node at index i.
        /// </summary>
        /// <param name="i">The nodes index.</param>
        public void RemoveChild(int i)
        {
            Children.RemoveAt(i);
        }

        /// <summary>
        /// Clear all children nodes.
        /// </summary>
        public void ClearChildren()
        {
            Children.Clear();
        }

        /// <summary>
        /// Does the nodes have a child at index i.
        /// </summary>
        /// <param name="i">The nodes index.</param>
        /// <returns>True if the nodes has child at index i.</returns>
        public bool HasChild(int i)
        {
            if (i < 0 || i >= Children.Count)
                return false;
            else
                return Children[i] != null;
        }

        /// <summary>
        /// Get the child node at index i.
        /// </summary>
        /// <param name="i">The nodes index.</param>
        /// <returns>The node at index i.</returns>
        public Node GetChild(int i)
        {
            if (i < 0 || i >= ChildrenCount)
                return null;
            else
                return Children[i];
        }

        /// <summary>
        /// Get the child node at index i.
        /// </summary>
        /// <typeparam name="T">The nodes type.</typeparam>
        /// <param name="i">The nodes index.</param>
        /// <returns>The node at index i.</returns>
        public T GetChild<T>(int i) where T : Node
        {
            return GetChild(i) as T;
        }

        /// <summary>
        /// Get the child at index i or return the default
        /// node if the index does not exist or the node is null.
        /// </summary>
        /// <typeparam name="I">The nodes input type.</typeparam>
        /// <typeparam name="O">The node output type.</typeparam>
        /// <param name="i">The childs index.</param>
        /// <returns>The child node.</returns>
        public Node<I, O> GetChildOrDefault<I, O>(int i)
        {
            var child = GetChild(i) as Node<I, O>;
            if (child == null)
                return EmptyNode<I, O>.Default;
            else
                return child;
        }

        /// <summary>
        /// Get the child at index i or return the default
        /// node if the index does not exist or the node is null.
        /// </summary>
        /// <typeparam name="I1">The nodes first input type.</typeparam>
        /// <typeparam name="I2">The nodes second input type.</typeparam>
        /// <typeparam name="O">The node output type.</typeparam>
        /// <param name="i">The childs index.</param>
        /// <returns>The child node.</returns>
        public Node<I1, I2, O> GetChildOrDefault<I1, I2, O>(int i)
        {
            var child = GetChild(i) as Node<I1, I2, O>;
            if (child == null)
                return EmptyNode<I1, I2, O>.Default;
            else
                return child;
        }

        /// <summary>
        /// Find the first node of the type.
        /// </summary>
        /// <typeparam name="T">The nodes type.</typeparam>
        /// <returns>The found node or null.</returns>
        public T Find<T>() where T : Node
        {
            if (this is T)
                return this as T;

            foreach (var child in Children)
            {
                if (child == null) continue;

                var node = child.Find<T>();
                if (node != null) return node;
            }

            return null;
        }

        /// <summary>
        /// Find the first node with the name.
        /// </summary>
        /// <param name="name">The nodes name.</param>
        /// <returns>The found node or null</returns>
        public Node Find(string name)
        {
            if (Name == name)
                return this;

            foreach (var child in Children)
            {
                if (child == null) continue;

                var node = child.Find(name);
                if (node != null) return node;
            }

            return null;
        }

        /// <summary>
        /// Enumerate all children and grandchildren nodes.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<Node> GetEnumerator()
        {
            return ((IEnumerable<Node>)Children).GetEnumerator();
        }

        /// <summary>
        /// Enumerate all children and grandchildren nodes.
        /// </summary>
        /// <returns>The enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Children).GetEnumerator();
        }
    }

}