using System.Collections;

public class Book{
    public string title;
    public string author;
    public long price;
    public Book(string title, string author, long price){
        this.title = title;
        this.author = author;
        this.price = price;
    }
}
public class Books:DictionaryBase{
    public void Add(string key, Book value){
        base.InnerHashtable.Add(key, value);
    }
    public void Remove(string key){
        base.InnerHashtable.Remove(key);
    }
    public Book Items(string key){
        return (Book)base.InnerHashtable[key];
    }
}
public class Program
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}