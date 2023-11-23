namespace Pratica002;

public class Task {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool Completed { get; set; }
    
    public Task(string _title, string _description, DateTime _expirationDate) {
        Title = _title;
        Description = _description;
        ExpirationDate = _expirationDate;
        Completed = false;
    }

    public string toString() {
        return $"{Title} {(Completed ? "[X]" : "[ ]" )}\n{Description}\nAté {ExpirationDate.ToString("dd/MM/yyyy HH:mm")}";
    }
}
