using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with distinct priorities: "A" (1), "B" (3), "C" (5).
    // Dequeue all three items.
    // Expected Result: "C", "B", "A"  (highest priority dequeued first)
    // Defect(s) Found: DEFECT 1 - The loop condition was (index < _queue.Count - 1), so the
    // last element in the list was never checked. "C" had the highest priority but was last,
    // so it was skipped and the wrong item was returned.
    // DEFECT 2 - Dequeue() never called _queue.RemoveAt(), so the item was never removed
    // from the queue. The queue grew indefinitely and all calls returned the same first item.
    // Fix: changed loop to (index < _queue.Count) and added _queue.RemoveAt(highPriorityIndex).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue three items where two share the highest priority: "A" (5), "B" (1), "C" (5).
    // Dequeue all three items.
    // Expected Result: "A", "C", "B"  (when priorities tie, the first-added item dequeues first - FIFO)
    // Defect(s) Found: DEFECT 1 - Same loop off-by-one and missing RemoveAt() as TestPriorityQueue_1.
    // DEFECT 2 - The comparison used >= instead of >. When "A" (pri 5) and "C" (pri 5) tied,
    // >= caused highPriorityIndex to keep updating to the later item "C", returning "C" before
    // "A" and violating FIFO order for equal priorities.
    // Fix: changed >= to > so ties preserve insertion order (first-added wins).
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Call Dequeue() on an empty queue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: No defects found. The InvalidOperationException with the exact required
    // message "The queue is empty." was correctly thrown when the queue was empty.
    public void TestPriorityQueue_3()
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
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                               e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue a single item "Solo" (priority 10), dequeue it, then call
    // Dequeue() again on the now-empty queue.
    // Expected Result: First Dequeue() returns "Solo". Second Dequeue() throws
    // an InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: DEFECT - Same missing RemoveAt() defect as above. Without removing
    // the item, "Solo" was never deleted from the queue, so the second Dequeue() returned
    // "Solo" again instead of throwing an InvalidOperationException.
    // Fix: added _queue.RemoveAt(highPriorityIndex) so the item is properly removed.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Solo", 10);

        Assert.AreEqual("Solo", priorityQueue.Dequeue());

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                               e.GetType(), e.Message)
            );
        }
    }
}