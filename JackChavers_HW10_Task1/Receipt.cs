namespace a
{
    public class Receipt
    {
        public int CustomerID { get; set; }
        public int CogQuantity { get; set; }
        public int GearQuantity { get; set; }
        public DateTime SalesDate { get; set; }
        private double SalesTaxPercent { get; set; }
        private double CogPrice { get; set; }
        private double GearPrice { get; set; }

        public Receipt()
        {
            this.CustomerID = 0;
            this.CogQuantity = 0;
            this.GearQuantity = 0;

            this.SalesDate = DateTime.Now;
            this.SalesTaxPercent = 0.089;
            this.CogPrice = 79.99;
            this.GearPrice = 250.00;
        }
        public Receipt(int id, int cog, int gear)
        {
            CustomerID = id;
            CogQuantity = cog;
            GearQuantity = gear;

            this.SalesDate = DateTime.Now;
            this.SalesTaxPercent = 0.089;
            this.CogPrice = 79.99;
            this.GearPrice = 250.00;
        }

        public double CalculateTotal() 
        {
            double netAmount = this.CalculateNetAmount();
            double salesTaxAmount = this.CalculateTaxAmount();
            double totalAmount = netAmount + salesTaxAmount;
            return totalAmount;
        }
        public void PrintReciept()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("RECEIPT");
            Console.WriteLine($"Customer ID: {this.CustomerID}");
            Console.WriteLine($"# of Cogs: {this.CogQuantity}");
            Console.WriteLine($"# of Gogs: {this.GearQuantity}");
            Console.WriteLine($"Net Amount: {this.CalculateNetAmount():C2}");
            Console.WriteLine($"Sales Tax: {this.CalculateTaxAmount():C2}");
            Console.WriteLine($"Grand Total: {this.CalculateTotal():C2}");
            Console.WriteLine($"Time: {this.SalesDate}");
            Console.WriteLine("==================================");
        }
        private double CalculateTaxAmount()
        {
            double netAmount = this.CalculateNetAmount();
            double salesTax = netAmount * this.SalesTaxPercent;
            return salesTax;
        }
        private double CalculateNetAmount() 
        {
            double markupPer = 0.15;
            if (this.CogQuantity > 10 || this.GearQuantity>10 || this.CogQuantity+this.GearQuantity>16)
            {
                markupPer = 0.125;
            }
            else
            {
                markupPer = 0.15;
            }
            double netAmount=this.CogQuantity*this.CogPrice*(1+markupPer)+this.GearQuantity*this.GearPrice*(1+markupPer);
                return netAmount;
        }
    }


}