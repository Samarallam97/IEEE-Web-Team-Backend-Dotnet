

#region array VS arrayList  VS List VS linkedList

//////////////////Array/////////////////////

//1.random access memory :
//accessing data is O(1) as : array is a block | | | | once you know the address (1st cell in the arr)
// you can do just artimatic statement by adding index , you can access the needed cell
// accessing 1st cell = last cell = the same O()   O(1)

//2. fixed size , once you defined data you can't change its size

//3. can't change its elements directly :
//int[] arr = {1,2, 3};
//arr = {4,5,6}; // can't change the data or the size
/// in C# you cannot directly assign a new set of values to an existing array without creating a new array object.
//arr = new int[] { 1, 2 }; // passed : U created new array

//////////////////ArrayList/////////////////////

//1. to create list of different data types
// it accespt any object that can casted to system.object
//2. array with variable size
// when the size increased , it creates new array with new size & copy data to it

/// problems :
///1- InvalidCastException
///2- boxing & unboxing with valueTypes
///3- can't enforce specific datatype (less readable)
///4- less type safety

//////////////////LinkedList/////////////////////

// 1. variable length (max length = size available in memory)
// but it isn't random access , to get to place n , do n statements

//////////////////List/////////////////////

///solved system.object problems
/// performance of array : random access accessing any cell O(1) 
///indexer : retrieve & update i can't use it to add
///List<> : is array with variable size
/// if you didn't indicate size of array :empty array  , size zero , capacity zero

// storage : 
// list starts with empty array & default capacity 4
// it accepts adding as there is space , (occupie all the capacity)
// with the first new elemnt with no space 
// it realocate anew object with double capacity & copy data to it
// overhead : allocating new object , in linkedlist (accessing elements)

#endregion

#region switch case with int or string
//using integers can be more efficient in terms of memory and performance,
// Integers are typically faster to compare than strings

//strings can make your code more readable and maintainable,
//especially if the cases correspond to distinct text values.
//This approach is often preferred when dealing with user input or configurations that are naturally represented as strings.

#region switch with int
// jump table , better than if/else

//switch (X)
//{
//    case 1:
//        Console.WriteLine("Jan");
//        break;
//    case 2:
//        Console.WriteLine("Feb");
//        break;
//    case 3:
//        Console.WriteLine("Mar");
//        break;
//    default:
//        Console.WriteLine("Not in Q03");
//        break;
//} 
#endregion

#region swith with string (little cases)

//String str = Console.ReadLine();

// with string little cases => better implemented to if/else

//switch (str)
//{
//    case "a":
//    case "A":
//        Console.WriteLine("Option 01");
//        break;

//    case "B":
//    case "b":
//        Console.WriteLine("Option 02");
//        break;

//    case "c":
//    case "C":
//        Console.WriteLine("Option 03");
//        break;
//}

#endregion

#region switch with string (many cases)
//string with large number of cases => hash table , switch better
//switch (str)
//{
//    case "1":
//        Console.WriteLine("Jan");
//break;

//    case "2":
//    Console.WriteLine("Feb");
//    break;
//case "3":
//    Console.WriteLine("Mar");
//    break;
//case "4":
//    Console.WriteLine("Apr");
//    break;
//case "5":
//    Console.WriteLine("May");
//    break;
//case "6":
//    Console.WriteLine("Jun");
//    break;
//case "7":
//    Console.WriteLine("Jul");
//    break;


//default:
//    Console.WriteLine("NA");
//    break;
//}

#endregion


#endregion
