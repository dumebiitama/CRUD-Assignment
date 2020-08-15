﻿/*
Name: Dumebi Itama (Didi)
Title: CRUD Assignment
Last Modified Date: August 15, 2020
Purpose: C# introduction - decisions, iteration and data structures
*/

using System;
using System.Collections;

namespace C__Introduction_Assignment__CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxSize = 10;
            ArrayList listOfData = new ArrayList();
            bool exit = false;

            while (!exit) {
                Console.WriteLine("\n\nProgram options ::");
                Console.WriteLine("type \"1\" and press the enter key to add data to the list");
                Console.WriteLine("type \"2\" and press the enter key to display content of the list");
                Console.WriteLine("type \"3\" and press the enter key to edit an item in the list");
                Console.WriteLine("type \"4\" and press the enter key to delete an item in the list");
                Console.WriteLine("type \"5\" and press the enter key to exit the program\n\n");

                string selection = Console.ReadLine().Trim();
                if(selection.Equals("1")){
                    addItemToList(listOfData, maxSize);
                } else if(selection.Equals("2")){
                    displayList(listOfData);
                } else if(selection.Equals("3")){
                    editItemInList(listOfData, maxSize);
                } else if(selection.Equals("4")){
                    deleteItemInList(listOfData, maxSize);
                } else if(selection.Equals("5")){
                    exit = true;
                } else {
                    Console.WriteLine("Invalid program option. Make correct selection.");
                }

            }
            Console.WriteLine("Program has terminated!");
        }

        static void addItemToList(ArrayList list, int maxSize){
            int sizeOfList = list.Count;
            if (sizeOfList < maxSize){
                Console.WriteLine("Enter data " + (sizeOfList+1));
                string data = Console.ReadLine().Trim();

                int duplicateDataIndex = isDataContainedInList(list, data);
                if(duplicateDataIndex != -1){
                    Console.WriteLine("\"" + data + "\" cannot be added to list beause \"" + ((string)list[duplicateDataIndex]) + "\" is already contained in the List." );
                    return;
                }

                list.Add(data);
                list.Sort();
                Console.WriteLine(data + " has been added to list");  
            } else {
                Console.WriteLine("The size of the list has reached the maximum limit of " + maxSize);
            }
        }

        static void displayList(ArrayList list){
            for (int i = 0; i < list.Count; i++){
                Console.WriteLine("item " + (i+1) + " is " + (string)list[i]);
            }    
        }

        static void editItemInList(ArrayList list, int maxSize){
            Console.WriteLine("Enter item number to be edited. \nNote: item number should be within the range: 1 to " + (maxSize));
            string input = Console.ReadLine().Trim();
            try
            {
                int itemNumber = Int32.Parse(input);
                if(itemNumber > maxSize || itemNumber < 1){
                    Console.WriteLine("\n\nError: Item number should be within the range: 1 to " + (maxSize));
                    return;
                }

                if(itemNumber > list.Count){
                    Console.WriteLine("\n\nAn edit cannot be performed. The list contains only " + (list.Count) + " items");
                    return;
                }

                Console.WriteLine("Enter data " + (itemNumber));
                string newData = Console.ReadLine().Trim();
                int dataIndex = itemNumber - 1; 
                string previousData = (string)list[dataIndex];

                int duplicateDataIndex = isDataContainedInList(list, newData);
                if(duplicateDataIndex != -1){
                    Console.WriteLine("\"" + previousData + "\" cannot be edited to " + "\"" + newData + "\" beause \"" + ((string)list[duplicateDataIndex]) + "\" is already contained in the List." );
                    return;
                }
                
                list.RemoveAt(dataIndex);
                list.Insert(dataIndex, newData);
                list.Sort();
                Console.WriteLine("Item " + (itemNumber) + " has been edited from " + (previousData) + " to " + (newData));
            }
            catch (FormatException e)
            {
                Console.WriteLine("\n\n" + e.Message);
                Console.WriteLine("Error: " + input + " cannot be converted to an integer");
            }
        }

        static void deleteItemInList(ArrayList list, int maxSize){
            Console.WriteLine("Enter item number to be deleted. \nNote: item number should be within the range: 1 to " + (maxSize));
            string input = Console.ReadLine().Trim();
            try
            {
                int itemNumber = Int32.Parse(input);
                if(itemNumber > maxSize || itemNumber < 1){
                    Console.WriteLine("\n\nError: Item number should be within the range: 1 to " + (maxSize));
                    return;
                }

                if(itemNumber > list.Count){
                    Console.WriteLine("\n\nAn delete cannot be performed. The list contains only " + (list.Count) + " items");
                    return;
                }

                int dataIndex = itemNumber - 1; 
                list.RemoveAt(dataIndex);
                Console.WriteLine(" item " + (itemNumber) + " has been deleted");
            }
            catch (FormatException e)
            {
                Console.WriteLine("\n\n" + e.Message);
                Console.WriteLine("Error: " + input + " cannot be converted to an integer");
            }
        }

        static int isDataContainedInList(ArrayList list, string data){
            for(int i = 0; i < list.Count; i++){
                string item = (string)list[i];
                if(item.ToLower().Equals(data.ToLower())){
                    return i;
                }
            }
            return -1;
        }
    }
}


// Working dir: /c/Users/didii/Desktop/Assignment 2 - CRUD/C# Introduction Assignment- CRUD