using System;
using System.Collections.Generic;

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
        public List<string> AttachedFiles { get; set; }
        public List<string> AttachedUrls { get; set; } = new List<string>();
        public RecurrencePattern RecurrencePattern { get; set; }


        public RReminder()
        {
            AttachedFiles = new List<string>();
        }


        public bool IsRecurring { get; set; }
        public RecurrenceFrequency RecurrenceFrequency { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
