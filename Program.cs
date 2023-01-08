using System.Diagnostics;

namespace Alghoritms;
class Program
{   
    static List<int> testList = new List<int>();
    static List<int> bufferList = new List<int>();
    static List<int> sortedList = new List<int>();
    static void Main(string[] args)
    {
        testList = InitializeList(1000);
        bufferList = new List<int>(testList);

        Console.WriteLine("Alghoritms\n");

        var watch = Stopwatch.StartNew();
        sortedList = selectionSort(testList);
        watch.Stop();
        Console.WriteLine("\nTime spent to selection sort:" + watch.Elapsed);
        testList = new List<int>(bufferList);

        Console.ReadKey();
        ShowMenu();
        //var watch = Stopwatch.StartNew();
        
        //watch.Stop();
        
        //Console.WriteLine("\n" + watch.Elapsed);
        //Console.ReadKey();
    }

    public static void ShowMenu(){
        Console.Clear();
        
        Console.WriteLine("Alghoritms\n");

        Console.WriteLine("\n1. Show original list");
        Console.WriteLine("2. Show sorted list");
        Console.WriteLine("3. Binary search");

        Console.WriteLine("\nВыберите пункт списка / Select a list item ");
        char input = Console.ReadKey().KeyChar;
        Console.WriteLine();
        while(true){
            if(input != '1' && input != '2' && input != '3'){
                Console.WriteLine("Выберите корректный пункт списка / Select a correct list item ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } else {
                break;
            }
        }
        switch(input){
            case '1':
                for(int i = 0; i < testList.Count; i++){
                    Console.WriteLine(i + ". " + testList[i]);
                }
                break;
            case '2':
                for(int i = 0; i < sortedList.Count; i++){
                    Console.WriteLine(i + ". " + sortedList[i]);
                }
                break;
            case '3':
                Console.WriteLine("\nВведите значение элемента / Type value of element: ");
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
                int result = BinarySearch(sortedList, intData);
                watch.Stop();
                Console.WriteLine("\nYours element position: " + result);
                Console.WriteLine("Spent time: " + watch.Elapsed);
                break;
            // case '4':
            //     ShowQueueMenu();
            //     break;
            // case '5':
            //     ShowSetMenu();
            //     break;
        }
        Console.ReadKey();
        ShowMenu();
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

    public static int FindSmallestElement(List<int> inputArray){
        int smallest = inputArray[0];
        int smallestIndex = 0;
        for(int i = 1; i < inputArray.Count; i++){
            if(smallest > inputArray[i]){
                smallest = inputArray[i];
                smallestIndex = i;
            }
        }
        return smallestIndex;
    }

    public static List<int> selectionSort(List<int> inputArray){
        List<int> resultArray = new List<int>();
        int count = inputArray.Count;
        for(int i = 0; i < count; i++){
            int smallestIndex = FindSmallestElement(inputArray);
            resultArray.Add(inputArray[smallestIndex]);
            inputArray.RemoveAt(smallestIndex);
        }
        return resultArray;
    }

}

