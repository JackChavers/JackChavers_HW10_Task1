// MIS 3013 HW 10

using a;
string userChoiceStr;

Console.Write("Do you want to enter a new receipt? (y/n) ");
userChoiceStr = Console.ReadLine();
userChoiceStr = userChoiceStr.ToLower();

List<Receipt> receiptList= new List<Receipt>();

while(userChoiceStr=="yes" || userChoiceStr=="y")
{
    Console.Write("Please input the number of cogs: ");
    string nCogsStr = Console.ReadLine();
    int nCogInt = Convert.ToInt32(nCogsStr);

    Console.Write("Please input the number of gears: ");
    string nGearsStr = Console.ReadLine();
    int nGearsInt = Convert.ToInt32(nGearsStr);

    Console.Write("Please input the Customer ID");
    string customerIDStr = Console.ReadLine();
    int customerIDInt = Convert.ToInt32(customerIDStr);

    //Receipt r = new Receipt();
    //r.CustomerID = customerIDInt;
    //r.CogQuantity = nCogInt;
    //r.GearQuantity = nGearsInt;

    Receipt r=new Receipt(customerIDInt,nCogInt,nGearsInt);

    r.PrintReciept();

    receiptList.Add(r);
    Console.Write("Do you want to enter a new receipt? (y/n): ");
    userChoiceStr = Console.ReadLine();
    userChoiceStr = userChoiceStr.ToLower();
}

do
{
    Console.WriteLine("Please choose from the options:");
    Console.WriteLine("1. Print all receipt of one customer");
    Console.WriteLine("2: Print all receipt for today");
    Console.WriteLine("3: Print the highest total receipt");
    Console.WriteLine("4: Print the average grand total");
    Console.WriteLine("Press other keys to end");

    userChoiceStr = Console.ReadLine();

    if(userChoiceStr=="1")
    {
        Console.Write("Please enter a customer id: ");
        string idStr = Console.ReadLine();
        int idInt=Convert.ToInt32(idStr);
        for(int i=0; i<=receiptList.Count; i++)
        {
            if (receiptList[i-1].CustomerID==idInt)
            {
                receiptList[i-1].PrintReciept();
            }
        }
    }
    else if(userChoiceStr=="2")
    {
        for (int i = 0; i < receiptList.Count; i++)
        {                     
                receiptList[i].PrintReciept();
        }
    }
    else if (userChoiceStr == "3")
    {
        Receipt highest = receiptList[0];
        for(int i = 0;i<=receiptList.Count;i++)
        {
            if (receiptList[i-1].CalculateTotal()>highest.CalculateTotal())
            {
                highest = receiptList[i - 1];
            }
        }

        Console.WriteLine("Receipt with highest total:");
        highest.PrintReciept();
    }
    else if (userChoiceStr == "4")
    {
        double sumTotal = 0;
        for(int i=0;i<receiptList.Count;i++)
        {
            sumTotal = sumTotal + receiptList[i].CalculateTotal();
        }
        double averageTotal=sumTotal/receiptList.Count;
        Console.WriteLine($"The average of the grand totals is: {averageTotal:C2}");
    }







}
while (userChoiceStr=="1" || userChoiceStr=="2" || userChoiceStr=="3" || userChoiceStr =="4");

Console.WriteLine("Thank you and goodbye!");

Console.ReadKey();