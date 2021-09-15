
namespace MCAT.Entities
{
    class Payment
    {
        //Payment ID
        private int id;

        //Reservation ID
        private int rid;

        //Payment Amount
        private float amount;

        //Payment Date
        private string date;

        public int Id { get => id; set => id = value; }

        public int Rid { get => rid; set => rid = value; }

        public float Amount { get => amount; set => amount = value; }

        public string Date { get => date; set => date = value; }
    }
}
