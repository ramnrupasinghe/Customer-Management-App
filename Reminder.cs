using System;

namespace CustomerManagementApp
{
    public class RReminder
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Customer AssociatedCustomer { get; set; }
        public string Priority { get; set; }
        public string Category { get; set; }
        public DateTime ReminderTime { get; set; }

        
        public bool IsRecurring { get; set; }
        public RecurrenceFrequency RecurrenceFrequency { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
