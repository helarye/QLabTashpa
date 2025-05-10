using System;

namespace QLab;
public class Program

{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Queue<int> q = new Queue<int>();
        q.Insert(7);
        q.Insert(10);
        q.Insert(3);
        Console.WriteLine(q);
        Queue<int> qCopy = SetQCopy(q);
        Console.WriteLine(q);
        Console.WriteLine(qCopy);
        q.Insert(17);
        qCopy.Insert(13);
        Console.WriteLine(q);
        Console.WriteLine(qCopy);
        int posInQ2Find = 1;
        Console.WriteLine($"The {posInQ2Find} element in the queue is: " + GetNPosInQ(q, posInQ2Find));
        posInQ2Find = 2;
        Console.WriteLine($"The  {posInQ2Find} element in the queue is: " + GetNPosInQ(q, posInQ2Find));
        posInQ2Find = 4;
        Console.WriteLine($"The  {posInQ2Find} element in the queue is: " + GetNPosInQ(q, posInQ2Find));
        Console.WriteLine(q);
        Console.WriteLine(FindLength(q));
        Console.WriteLine(q.GetQLength());
        Console.WriteLine(TwoSum(q, 24));//האם קיים בתור זוג של מספרים שסכומם שווה ל10
        Console.WriteLine(q);
    }
    public static bool TwoSum(Queue<int> q, int sum)
    {//הפונקציה מקבלת תור של מספרים שלמים ומספר שלם 
     //ומחזירה אמת אם קיים בתור זוג של מספרים שסכומם שווה ל
     //הפונק' לא שומרת על התור המקורי
        int currItem = 0;//משתנה לאחסון הפריט האחרון שנשלף מת התור הזמני
        for (int i = 1; i < q.GetQLength(); i++)//לולאת for לספירת המספרים בתור
        {
            currItem = q.Remove();//שליפת הפריט הראשון מהתור
            for (int j = 0; j < q.GetQLength(); j++)//לולאת for לספירת המספרים בתור
            {
                if (currItem + q.Head() == sum)//אם סכום הפריט הראשון והפריט הנוכחי שווה לסכום הנדרש
                    return true;//הפונקציה מחזירה true
                q.Insert(q.Remove());//החזרת הפריט שנשלף- לתור
            }
        }        
        return false;//אם לא נמצא סכום מתאים מחזירים false
    }

    public static Queue<int> SetQCopy(Queue<int> q)
    {
        Queue<int> qCopy = new();
        Queue<int> qTemp = new();
        int currItem;
        //פריקת התור המקורי ויצירת תור העתק ותור זמני
        while (!q.IsEmpty())
        {
            currItem = q.Remove();
            qTemp.Insert(currItem);
            qCopy.Insert(currItem);
        }
        //שחזור התור המקורי
        while (!qTemp.IsEmpty())
        {
            q.Insert(qTemp.Remove());
        }
        return qCopy;
    }
    public static int GetNPosInQ(Queue<int> q, int posInQ)
    {
        Queue<int> qTemp = SetQCopy(q);//יוצרים תור זמני שעליו עובדים
        int currItem = 0;//משתנה לאחסון הפריט האחרון שנשלף מהתור הזמני
        int count = 0;//סופר את כמות המספרים שנשלפו מן התור
      
        while (count<posInQ)//שליפת הכמות הנדרשת של מספרים מן התור עד המקום הנדרש
        {
            currItem = qTemp.Remove();
            qTemp.Insert(currItem);
            count++;
        }
        
        return currItem;//הפונק' מחזירה את המספר האחרון שנשלף מהתור
    }

    public static int FindLength(Queue<int> q)
    { //הפונקציה מקבלת תור ומחזירה את האורך שלו    
        Queue<int> qTemp = SetQCopy(q);
        int qLength = 0;
        while (!qTemp.IsEmpty())
        {
            qTemp.Remove();
            qLength++;
        }
        return qLength;
    }

    

}