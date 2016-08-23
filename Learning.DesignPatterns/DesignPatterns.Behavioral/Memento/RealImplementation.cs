using System;

namespace DesignPatterns.Behavioral.Memento
{
    /// <summary>
    /// MainApp startup class for Real-World 
    /// RealMemento Design Pattern.
    /// </summary>
    class RealMainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            SalesProspect s = new SalesProspect();
            s.Name = "Noel van Halen";
            s.Phone = "(412) 256-0990";
            s.Budget = 25000.0;

            // Store internal state
            ProspectMemory m = new ProspectMemory();
            m.Memento = s.SaveMemento();

            // Continue changing originator
            s.Name = "Leo Welch";
            s.Phone = "(310) 209-7111";
            s.Budget = 1000000.0;

            // Restore saved state
            s.RestoreMemento(m.Memento);

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Originator' class
    /// </summary>
    class SalesProspect
    {
        private string _name;
        private string _phone;
        private double _budget;

        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Console.WriteLine("Name:  " + _name);
            }
        }

        // Gets or sets phone
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                Console.WriteLine("Phone: " + _phone);
            }
        }

        // Gets or sets budget
        public double Budget
        {
            get { return _budget; }
            set
            {
                _budget = value;
                Console.WriteLine("Budget: " + _budget);
            }
        }

        // Stores memento
        public RealMemento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new RealMemento(_name, _phone, _budget);
        }

        // Restores memento
        public void RestoreMemento(RealMemento memento)
        {
            Console.WriteLine("\nRestoring state --\n");
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Budget = memento.Budget;
        }
    }

    /// <summary>
    /// The 'RealMemento' class
    /// </summary>
    class RealMemento
    {
        private string _name;
        private string _phone;
        private double _budget;

        // Constructor
        public RealMemento(string name, string phone, double budget)
        {
            this._name = name;
            this._phone = phone;
            this._budget = budget;
        }

        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Gets or set phone
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        // Gets or sets budget
        public double Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }
    }

    /// <summary>
    /// The 'Caretaker' class
    /// </summary>
    class ProspectMemory
    {
        private RealMemento _memento;

        // Property
        public RealMemento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}