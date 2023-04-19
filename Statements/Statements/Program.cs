using System;
using System.Collections.Generic;
using Statements.Domain;
using Statements.Domain.Plays;
using Statements.Formatters;
using Statements.Plays;

namespace Statements;

public class Program
{
    private static void Main()
    {
        var plays = new List<Play>
        {
            PlayFactory.Create("hamlet", "Hamlet", PlayTypeEnum.Tragedy),
            PlayFactory.Create("as-like", "As you like IT", PlayTypeEnum.Comedy),
            PlayFactory.Create("othello", "Othello", PlayTypeEnum.Tragedy)
        };

        var invoice = new Invoice
        {
            CustomerName = "METRO",
            Performances = new List<Performance>
            {
                new() { Audience = 55, PlayId = "hamlet" },
                new() { Audience = 35, PlayId = "as-like" },
                new() { Audience = 40, PlayId = "othello" }
            }
        };

        IInvoiceBuilder builder = new TextInvoiceBuilder();
        // Or use the HTML builder
        // IInvoiceBuilder builder = new HtmlInvoiceBuilder();

        var statement = new Statement(plays, builder);
        var statementDetails = statement.Generate(invoice);
        Console.WriteLine(statementDetails);
    }
}