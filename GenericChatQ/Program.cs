//// See https://aka.ms/new-console-template for more information
//using GenericChatQ;
//using System;
//using System.Collections.Generic;

//// Define the ChatMessage class

//class Program
//{
//    static void Main(string[] args)
//    {
//        // Instantiate the queue with a maximum size of 5
//        MyQueue<ChatMessage> chatQueue = new MyQueue<ChatMessage>(5);

//        // Example: Enqueueing ChatMessages
//        chatQueue.Enqueue(new ChatMessage(DateTime.Now, 1));
//        chatQueue.Enqueue(new ChatMessage(DateTime.Now.AddMinutes(5), 2));
//        chatQueue.Enqueue(new ChatMessage(DateTime.Now.AddMinutes(10), 3));

//        // Example: Dequeueing ChatMessages
//        while (!chatQueue.IsEmpty())
//        {
//            ChatMessage message = chatQueue.Dequeue();
//            Console.WriteLine($"Dequeued message: TimeStamp - {message.TimeStamp}, SourceId - {message.SourceId}");
//        }

//        Console.ReadLine();
//    }
//}

using GenericChatQ;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the maximum size of the queue:");
        int maxSize;
        if (!int.TryParse(Console.ReadLine(), out maxSize) || maxSize <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer value for the maximum size.");
            return;
        }

        // Instantiate the queue with the maximum size provided by the user
        MyQueue<ChatMessage> chatQueue = new MyQueue<ChatMessage>(maxSize);

        while (true)
        {
            Console.WriteLine("\nEnter your choice:");
            Console.WriteLine("1. Enqueue ChatMessage");
            Console.WriteLine("2. Dequeue ChatMessage");
            Console.WriteLine("3. Check if queue is empty");
            Console.WriteLine("4. Check if queue is full");
            Console.WriteLine("5. Exit");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    // Enqueue ChatMessage
                    Console.WriteLine("Enter the timestamp (yyyy-MM-dd HH:mm:ss):");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime timeStamp))
                    {
                        Console.WriteLine("Invalid timestamp format. Please enter in the format 'yyyy-MM-dd HH:mm:ss'.");
                        continue;
                    }

                    Console.WriteLine("Enter the source ID:");
                    if (!int.TryParse(Console.ReadLine(), out int sourceId))
                    {
                        Console.WriteLine("Invalid source ID. Please enter an integer value.");
                        continue;
                    }

                    // Create and enqueue the ChatMessage
                    chatQueue.Enqueue(new ChatMessage(timeStamp, sourceId));
                    break;

                case 2:
                    // Dequeue ChatMessage
                    try
                    {
                        ChatMessage message = chatQueue.Dequeue();
                        Console.WriteLine($"Dequeued message: TimeStamp - {message.TimeStamp}, SourceId - {message.SourceId}");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 3:
                    // Check if queue is empty
                    Console.WriteLine("Queue is empty: " + chatQueue.IsEmpty());
                    break;

                case 4:
                    // Check if queue is full
                    Console.WriteLine("Queue is full: " + chatQueue.IsFull());
                    break;

                case 5:
                    // Exit program
                    Console.WriteLine("Exiting program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option (1-5).");
                    break;
            }
        }
    }
}


