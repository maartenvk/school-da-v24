using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AD._Tree
{
    public class Tree<T> : ITree<T> where T : IComparable<T>
    {
        Node<T>? head;

        public bool Empty()
        {
            return head is null;
        }

        public void Insert(T item)
        {
            if (Empty())
            {
                head = new(item);
                return;
            }

            bool pickRight = false;
            Node<T>? node = head, prev = node;
            while (node is not null)
            {
                pickRight = item.CompareTo(node.Data) > 0;
                prev = node;
                node = pickRight ? node.Right : node.Left;
            }

            Node<T> generated = new(item);
            if (pickRight)
            {
                prev!.Right = generated;
            }
            else
            {
                prev!.Left = generated;
            }
        }

        public Node<T>? Find(T item)
        {
            if (Empty())
            {
                return null;
            }

            Node<T>? node = head;
            while (node is not null && !item!.Equals(node!.Data!))
            {
                node = item.CompareTo(node!.Data!) > 0 ? node.Right : node.Left;
            }

            return node;
        }

        public bool Contains(T item)
        {
            return Find(item) is not null;
        }

        public Node<T> Head()
        {
            if (Empty())
            {
                throw new EmptyTreeException();
            }

            return head!;
        }

        public void Remove(T item)
        {
            if (Empty())
            {
                throw new EmptyTreeException();
            }

            bool pickRight = false;
            Node<T>? node = head, prev = head;
            while (node is not null && !item!.Equals(node!.Data!))
            {
                pickRight = item.CompareTo(node!.Data!) > 0;
                node = pickRight ? node.Right : node.Left;
            }

            if (node is null)
            {
                throw new ElementNotInTreeException();
            }

            if (node.Left is null && node.Right is null)
            {
                if (node == head)
                {
                    head = null;
                }
                else if (pickRight)
                {
                    prev!.Right = null;
                }
                else
                {
                    prev!.Left = null;
                }

                return;
            }

            if (node.Left is null || node.Right is null)
            {
                Node<T>? child = node.Left ?? node.Right;

                if (node == head)
                {
                    head = child;
                }
                else if (pickRight)
                {
                    prev!.Right = child;
                }
                else
                {
                    prev!.Left = child;
                }

                return;
            }

            Node<T>? successorParent = node;
            Node<T>? successor = node.Right;

            while (successor!.Left is not null)
            {
                successorParent = successor;
                successor = successor.Left;
            }

            node.Data = successor.Data;

            if (successorParent != node)
            {
                successorParent!.Left = successor.Right;
            }
            else
            {
                successorParent!.Right = successor.Right;
            }
        }
    }
}
