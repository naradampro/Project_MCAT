
namespace MCAT.Entities
{
    public class Payment
    {
        //Payment ID
        private int id;

        //Reservation ID
        private int rid;

        //Payment Amount
        private float amount;

        //Payment Date
        private string date;

        public Payment()
        {

        }

        public Payment(int id, int rid, float amount, string date)
        {
            this.id = id;
            this.rid = rid;
            this.amount = amount;
            this.date = date;
        }

        public Payment( int rid, float amount, string date)
        {
            this.rid = rid;
            this.amount = amount;
            this.date = date;
        }

        public int Id { get => id; set => id = value; }
        public int Rid { get => rid; set => rid = value; }
        public float Amount { get => amount; set => amount = value; }
        public string Date { get => date; set => date = value; }
    }
}
