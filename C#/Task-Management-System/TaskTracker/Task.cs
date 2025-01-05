using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker
{
    internal class Task
    {
        public string Description { get; set; }
        public Category Category { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool IsCompleted { get; set; }

        // setting of all these properties happen in Ctor only
        // ctor overloading + ctor chaining 
        // one need status , the other set it false by default

        public Task(string description, Category category, DateTime? dueDate, PriorityLevel priority , bool isCompleted)
        {
            Description = description;
            Category = category;
            DueDate = dueDate;
            Priority = priority;
            IsCompleted = isCompleted;
        }

        public Task(string description, Category category, DateTime? dueDate, PriorityLevel priority)
            :this(description, category, dueDate, priority, false)
        {}

        public override string ToString()
           => $" Description : {Description} ,  Category : {Category} , DueDate : {DueDate} , Priority : {Priority} , IsCompleted : {IsCompleted}";
        




    }
}
