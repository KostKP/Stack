using System;

namespace Stack
{
    public class Stack<T>
    {
        Exception NotEnoughElementsException = new Exception("Stack doesn't contain the required number of elements!");
        Exception NullStackException = new Exception("Stack doesn't contain any elements!");
        Exception WrongParamsException = new Exception("Some parameters are incorrect!");

        private class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Link { get; set; }

            public Node(Node<T> link = null)
            {
                this.Link = link;
            }
            public Node(T data, Node<T> link = null)
            {
                this.Data = data;
                this.Link = link;
            }
        }

        Node<T> storedge;

        public override string ToString()
        {
            string text = "Stack[" + Count() + "]{";
            Node<T> current = storedge;
            while (current != null)
            {
                text += current.Data.ToString() + ", ";
                current = current.Link;
            }
            text = text.Substring(0, text.Length - 2) + '}';
            return text;
        }

        public int Count()
        {
            int count = 0;
            Node<T> current = storedge;
            while (current != null)
            {
                count++;
                current = current.Link;
            }
            return count;
        }



        public void Push(params T[] data)
        {
            foreach (var i in data)
            {
                if (this.storedge == null)
                {
                    this.storedge = new Node<T>(i);
                }
                else
                {
                    storedge = new Node<T>(i, storedge);
                }
            }
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count()];
            Node<T> current = storedge;
            for (int i = 0; i < Count(); ++i)
            {
                arr[i] = current.Data;
                current = current.Link;
            }
            return arr;
        }

        public void PushStack(Stack<T> stack)
        {
            T[] arr = stack.ToArray();
            Array.Reverse(arr);
            Push(arr);
        }

        public Stack<T> Peek(int amount)
        {
            if (amount < 1)
            {
                throw WrongParamsException;
            }

            if (Count() < amount)
            {
                throw NotEnoughElementsException;
            }

            Node<T> current = storedge;
            T[] arr = new T[amount];
            for (int i = amount - 1; i >= 0; i--)
            {
                arr[i] = current.Data;
                current = current.Link;
            }
            Stack<T> stack = new Stack<T>();
            stack.Push(arr);
            return stack;
        }
        public T Peek()
        {
            return storedge.Data;
        }

        public Stack<T> Pop(int amount)
        {
            if (amount < 1)
            {
                throw WrongParamsException;
            }

            if (Count() < amount)
            {
                throw NotEnoughElementsException;
            }

            T[] arr = new T[amount];
            for (int i = amount - 1; i >= 0; i--)
            {
                arr[i] = storedge.Data;
                storedge = storedge.Link;
            }
            Stack<T> stack = new Stack<T>();
            stack.Push(arr);
            return stack;
        }

        public T Pop()
        {
            if (Count() < 1)
            {
                throw NullStackException;
            }
            T data = storedge.Data;
            storedge = storedge.Link;
            return data;
        }
    }
}