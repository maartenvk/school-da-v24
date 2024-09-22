using System;

namespace AD
{
    // T type
    // R result
    public static class BinaryTreeWalker<T, R>
    {
        public static R OperateOn(BinaryNode<T> node, Func<(R, R), BinaryNode<T>, R> action)
        {
            if (node is null)
            {
                throw new ArgumentException();
            }

            R left = default(R);
            if (node.HasLeft())
            {
                left = OperateOn(node.GetLeft(), action);
            }

            R right = default(R);
            if (node.HasRight())
            {
                right = OperateOn(node.GetRight(), action);
            }

            R result = action.Invoke((left, right), node);
            return result;
        }
    }
}
