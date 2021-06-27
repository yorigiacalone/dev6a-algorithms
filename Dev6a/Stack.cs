namespace Dev6a
{
    public class Stack<T>
    {
        public int capacity;
        public int top = -1;
        public T[] array;

        public int Size()
        {
            return capacity;
        }

        public Stack(int size = 10)
        {
            capacity = size;
            array = new T[capacity];
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public T Pop()
        {
            if (!IsEmpty()) // stack is not empty
            {
                T value = array[top];
                array[top] = default(T);
                top--;
                return value;
            }
            return default(T);
        }

        public void Push(T t)
        {
            if (top == capacity - 1) // stack is full
            {
                capacity = capacity * 2;
                var newArray = new T [capacity];
                for(int i = 0; i <= top; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
            }
            array[++top] = t;
        }
    }
}