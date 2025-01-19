/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Add a new customer to queue
        // Expected Result: Customer gets added to end of queue
        Console.WriteLine("Test 1");
        // Establish queue amount
        var service = new CustomerService(10);
        // Add customer
        service.AddNewCustomer();
        // Display queue
        Console.WriteLine("Queue after adding a customer:");
        Console.WriteLine(service);


        // Defect(s) Found: Displays queue size. But works otherwise

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Queue is full
        // Expected Result: Display an error message
        Console.WriteLine("Test 2");
        // Set low queue amount
        service = new CustomerService(2);
        // Overfill queue
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        // Display error
        Console.WriteLine("Error: queue full");
        Console.WriteLine(service);

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: Customer has been served and needs to move out of queue
        // Expected Result: First in queue will be dequeued and will display new order
        Console.WriteLine("Test 3");
        // Set queue size
        service = new CustomerService(5);
        // Add customers
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        // Display current queue
        Console.WriteLine("Current Queue:");
        Console.WriteLine(service);
        // Serve first in queue
        service.ServeCustomer();
        // Display new queue
        Console.WriteLine("Updated Queue:");
        Console.WriteLine(service);


        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 4
        // Scenario: An Empty queue tries to serve a customer
        // Expected Result: Display error message for empty queue when serving
        Console.WriteLine("Test 4");
        // Set up new queue
        service = new CustomerService(5);
        // Attempt to serve empty queue
        service.ServeCustomer();
        // Display message displays from ServeCustomer down below


        // Defect(s) Found: Actual error occurred, fixed by adjusting ServeCustomer

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        // Adjusted by added in an queal size and clarifying an error
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Error: Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        // Add check for queue count
        if (_queue.Count == 0) {
            Console.WriteLine("Error: No customers in the queue to serve.");
            return;
        }
        
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}