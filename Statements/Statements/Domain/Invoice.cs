using System.Collections.Generic;
using Statements.Plays;

namespace Statements.Domain;

public class Invoice
{
    public string CustomerName { get; set; }
    public List<Performance> Performances { get; set; }
}