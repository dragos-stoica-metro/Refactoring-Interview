namespace Statements.Formatters;

public interface IInvoiceBuilder
{
    IInvoiceBuilder AddHeader(string customerName);
    IInvoiceBuilder AddPlay(string playName, double playAmount, int audience);
    IInvoiceBuilder AddTotalAmount(double totalAmount);
    IInvoiceBuilder AddVolumeCredits(string volumeCredits);
    string Build();
}