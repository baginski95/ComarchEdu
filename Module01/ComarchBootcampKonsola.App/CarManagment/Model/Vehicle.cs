namespace ComarchBootcampKonsola.App.CarManagment.Model
{
    internal abstract class Vehicle
    {
        public CarTypes CarType { get; set; }
        public int Id { get; set; }
        public string? Maker { get; set; }
        public string? Model { get; set; }
        public string? GasType { get; set; }
        public int Capacity { get; set; }
        //public int SeatsCount { get; set; }
        public bool IsBorrowed { get; set; }
        public string? Borrower { get; set; }
        public abstract void Refuel(int count);
        protected Vehicle()
        {
            IsBorrowed = false;
            Borrower = "";
        }
        public virtual void Borrow(string? borrower)
        {
            IsBorrowed = true;
            Borrower = borrower;
        }
        public void Receive()
        {
            IsBorrowed = false;
            Borrower = "";
        }
    }
}
