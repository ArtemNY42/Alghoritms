using System.Diagnostics;

namespace Alghoritms;
class Program
{   
    static List<int> testList = new List<int>();
    static void Main(string[] args)
    {
        testList = InitializeList(1000);
        testList.Sort();
        ShowMenu();
        //var watch = Stopwatch.StartNew();
        
        //watch.Stop();
        
        //Console.WriteLine("\n" + watch.Elapsed);
        //Console.ReadKey();
    }

    public static void ShowMenu(){
        Console.Clear();
        Console.WriteLine("Alghoritms\n");
        Console.WriteLine("1. Binary search");

        Console.Write("Выберите пункт списка / Select a list item ");
        char input = Console.ReadKey().KeyChar;
        Console.WriteLine();
        while(true){
            if(input != '1'){
                Console.Write("Выберите корректный пункт списка / Select a correct list item ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } else {
                break;
            }
        }
        switch(input){
            case '1':
                ShowBinarySearch();
                break;
            // case '2':
            //     ShowDoubleLinkedListMenu();
            //     break;
            // case '3':
            //     ShowStackMenu();
            //     break;
            // case '4':
            //     ShowQueueMenu();
            //     break;
            // case '5':
            //     ShowSetMenu();
            //     break;
        }
        Console.ReadKey();
    }

    public static void ShowBinarySearch(){
        Console.Clear();
        Console.WriteLine("Binary search");
        Console.WriteLine();
        Console.WriteLine("1. To the main menu");
        Console.WriteLine("2. Search element");
        Console.WriteLine();

        Console.Write("Выберите пункт списка / Select a list item ");
        char input = Console.ReadKey().KeyChar;
        Console.WriteLine();
        while(true){
            if(input != '1' && input != '2'){
                Console.Write("Выберите корректный пункт списка / Select a correct list item ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } else {
                break;
            }
        }

        switch(input){
            case '1':
                ShowMenu();
                break;
            case '2':
                for(int i = 0; i < testList.Count; i++){
                    Console.WriteLine(i + ". " + testList[i]);
                }
                Console.WriteLine("Введите значение элемента / Type value of element: ");
                string data = Console.ReadLine();
                int intData;
                while(true){
                    try{
                        intData = Int32.Parse(data);
                        break;
                    } catch{
                        Console.WriteLine("Введите корректное значение элемента / Type correct value of element: ");
                        data = Console.ReadLine();
                    }
                }
                var watch = Stopwatch.StartNew();
                int result = BinarySearch(testList, intData);
                watch.Stop();
                Console.WriteLine("\nYours element position: " + result);
                Console.WriteLine("Time: " + watch.Elapsed);
                break;
        }
        Console.ReadKey();
        ShowBinarySearch();
    }

    public static List<int> InitializeList(int n){
        List<int> result = new List<int>();
        Random rnd = new Random();
        for(int i = 0; i < n; i++){
            int newNumber = rnd.Next(0,10000);
            // while(result.Contains(newNumber)){
            //     newNumber = rnd.Next(0,100);
            // }
            result.Add(newNumber);
        }
        return result;
    }

    public static int BinarySearch(List<int> sortedList, int searchedNumber){
        int result = 0;
        int low = 0;
        int height = sortedList.Count - 1;
        int middle;
        while(low <= height){
            middle = (low + height) / 2;
            if(sortedList[middle] == searchedNumber) return middle;
            if(sortedList[middle] > searchedNumber) height = middle - 1;
            else low = middle + 1;
        }
        return -1;
    }

}

