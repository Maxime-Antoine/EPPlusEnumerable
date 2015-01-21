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