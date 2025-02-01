using System;
class Fee
{
	static void Main(string[] args)
	{
		//value of fee and discountPercent.
		double fee=125000;
		double discountPercent=10;
		//calling method to calculate the fee.
		feeAndDiscount(fee,discountPercent);
	}
	//method to calculate fee after discount
	static void feeAndDiscount(double fee, double discountPercent)
	{
		double discount=(fee*discountPercent)/100;
		double discountedFee=fee-discount;
		//display the fee and discount
		Console.WriteLine($"The discount amount is INR {discount} and final discounted fee is INR {discountedFee}");
	}
}