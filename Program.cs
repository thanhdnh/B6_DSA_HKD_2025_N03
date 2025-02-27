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
    public void PrintListofBook(){
        Console.WriteLine("{0, 10}{1, 30}{2, 30}{3, 10}", 
                        "ISBN", "Title", "Authors", "Price");
        Console.WriteLine("------------------------------------------------------------------------------------");
        /*foreach(DictionaryEntry entry in base.InnerHashtable){
            Book book = (Book)entry.Value;
            Console.WriteLine("{0, 10}{1, 30}{2, 30}{3, 10}", 
                        entry.Key, book.title, book.author, 
                            book.price);
        }*/
        IDictionaryEnumerator num = 
                    base.InnerHashtable.GetEnumerator();
        while(num.MoveNext()){
            Book book = (Book)num.Value;
            Console.WriteLine("{0, 10}{1, 30}{2, 30}{3, 10}", 
                        num.Key, book.title, book.author, 
                            book.price);
        }
    }
    public Book FindBook(string keyword){
        foreach(DictionaryEntry entry in base.InnerHashtable){
            Book book = (Book)entry.Value;
            if(book.title.Contains(keyword)){
                return book;
            }
        }
        return null;
    }
}
public class Program
{

    public static void Main(string[] args)
    {
        Console.Clear();
        Book book1 = new Book("C# Programming", "John Doe", 100);
        Book book2 = new Book("Java Programming", "Jane Doe", 200);
        Book book3 = new Book("Python Programming", "Jack Doe", 300);
        Books bookdict = new Books();
        bookdict.Add("ISBN01", book1);
        bookdict.Add("ISBN02", book2);
        bookdict.Add("ISBN03", book3);
        //Console.WriteLine("Title: {0}", bookdict.Items("ISBN01").title);
        //bookdict.Remove("ISBN02");
        bookdict.PrintListofBook();

        string keyword = "Python";
        Book book = bookdict.FindBook(keyword);
        if(book != null)
            Console.WriteLine("Book with [{0}] Found: {1}, {2}, {3}", 
                    keyword, book.title, book.author, book.price);
    }
}