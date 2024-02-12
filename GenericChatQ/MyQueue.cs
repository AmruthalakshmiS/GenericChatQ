// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

// Define the generic queue class
public class MyQueue<T>
{
    private Queue<T> queue;
    private int maxSize;

    public MyQueue(int maxSize)
    {
        this.maxSize = maxSize;
        queue = new Queue<T>();
    }

    public void Enqueue(T item = default)
    {
        if (item == null)
        {
            item = Activator.CreateInstance<T>();
        }

        if (queue.Count < maxSize)
        {
            queue.Enqueue(item);
            Console.WriteLine($"Enqueued item: {item}");
        }
        else
        {
            Console.WriteLine("Queue is full. Cannot enqueue more items.");
        }
    }

    public T Dequeue()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty. Cannot dequeue.");
        }
        return queue.Dequeue();
    }

    public bool IsEmpty()
    {
        return queue.Count == 0;
    }

    public bool IsFull()
    {
        return queue.Count == maxSize;
    }
}
