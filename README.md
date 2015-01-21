# EPPlusEnumerable
Easily create multi-worksheet Excel documents from any .NET object collection.

## Usage

Let's say you're working on an ASP.NET web app and want to create a report of all users and orders.

```csharp
public ActionResult DownloadReport()
{
    IList<IEnumerable<object>> data = new List<IEnumerable<object>>();
    
    using(var db = new DataContext())
    {
        data.Add(db.Users.OrderBy(x => x.Name).ToList());
        data.Add(db.Orders.OrderByDescending(x => x.Date).ToList());
    }
    
    var bytes = Spreadsheet.Create(data);
    return File(bytes, "application/vnd.ms-excel", "MySpreadsheet.xslx");
}
```

That will give you a nicely-formatted Excel spreadsheet with tabs for both "Users" and "Orders," like so:

![output](https://raw.githubusercontent.com/bradwestness/EPPlusEnumerable/master/output.png)

There's also a `SpreadsheetLinkAttribute` class which you can use to generate links between tabs on your spreadsheet.

```csharp
[DisplayName("Orders")]
public class Order
{
    public int Number { get; set; }

    public string Item { get; set; }

    [SpreadsheetLink("Customer", "Name")]
    public string Customer { get; set; }

    public decimal Price { get; set; }

    public DateTime Date { get; set; }
}
```

In this example, the "Customer" values in the Orders tab will be linked to the corresponding Customers tab row where the Name is equal to the value of the Order object's Customer property.

![links](https://raw.githubusercontent.com/bradwestness/EPPlusEnumerable/master/links.png)

