using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and dequeue
    // Expected Result: "high", "medium", "low"
    // Defect(s) Found: None

    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("medium", 2);
        priorityQueue.Enqueue("high", 3);

        Assert.AreEqual("high", priorityQueue.Dequeue()); // "high" should be dequeued first
        Assert.AreEqual("medium", priorityQueue.Dequeue()); // "medium" next
        Assert.AreEqual("low", priorityQueue.Dequeue()); // "low" last
    
    }

    [TestMethod]
    // Scenario: Add items with the same priority and check FIFO behavior
    // Expected Result: "first", "second", "third"
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 1);
        priorityQueue.Enqueue("second", 1);
        priorityQueue.Enqueue("third", 1);

        Assert.AreEqual("first", priorityQueue.Dequeue()); // "first" should be dequeued first
        Assert.AreEqual("second", priorityQueue.Dequeue()); // "second" next
        Assert.AreEqual("third", priorityQueue.Dequeue()); // "third" last
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException
    // Defect(s) Found: None
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}