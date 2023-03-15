using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using System;
using System.Collections;
using System.Collections.Generic;

namespace JuniorTask3.Models
{
    public class Node // узел списка
    {
        public Node(int x) // конструктор
        {
            value = x;
        }

        public int value { get; set; }
        public Node? next { get; set; }
        public Node? prev { get; set; }
    }

    public class IntList // двусвязный список целых чисел
    {
        Node? head;
        Node? tail;
        int count = 0;

        #region Внешние операции

        public void FromArr(int[] arr) // формирование списка из массива
        {
            foreach (var item in arr) AddRight(item);
        }

        public void Swap(Node i, Node j) // обмен значений в узлах i и j
        {
            i.value = i.value + j.value;
            j.value = i.value - j.value;
            i.value = i.value - j.value;
        }

        public int[] ToArr() // упаковка списка в массив
        {
            int[] arr = new int[count];
            for (int i = 0; i < count; i++)
                arr[i] = GetValueById(i);
            return arr;
        }

        #endregion

        #region Получение информации из списка

        public bool IsEmpty() // проверка на пустоту
        {
            return count == 0;
        }

        public int Count() // длина списка
        {
            return count;
        }

        public bool Contains(int data) // проверка на содержание списком узла со значением data
        {
            Node? curr = head;
            while (curr != null)
            {
                if (curr.value.Equals(data)) return true;
                curr = curr.next;
            }
            return false;
        }

        public Node GetNodeById(int id)// получение узла по номеру 
        {
            Node curr = head;
            for (int i = 0; i < id; i++)
                curr = curr.next;
            return curr;
        }

        public int GetValueById(int id)//получение значения узла с номером id
        {
            Node? curr = head;
            for (int i = 0; i < id; i++)
                curr = curr.next;
            return curr.value;
        }

        public void ConsolePrint() // вывод в консоль (для отладки)
        {
            Node curr = head;
            Console.WriteLine("----------------------------------------------------------------------------");
            for (int i = 0; i < count; i++)
            {
                Console.Write("[(" + i + "):" + curr.value + "] ");
                curr = curr.next;
            }
            Console.WriteLine("----------------------------------------------------------------------------");
        }

        #endregion

        #region Добавление элементов

        public void AddRight(int data) // добавление в конец
        {
            Node newNode = new Node(data);
            newNode.next = null;
            if (head == null)
            {
                head = newNode;
                newNode.prev = null;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
            }
            tail = newNode;

            count++;
        }

        public void AddLeft(int data)// добавление в начало
        {
            Node newNode = new Node(data);
            newNode.prev = null;
            if (tail == null)
            {
                tail = newNode;
                newNode.next = null;
            }
            else
            {
                head.prev = newNode;
                newNode.next = head;
            }
            head = newNode;
            count++;
        }

        #endregion

        #region Удаление элементов

        public bool Remove(int data) // удаление по значению
        {
            Node toRemove = head;
            while (toRemove != null)
            {
                if (toRemove.value.Equals(data))
                {
                    if (toRemove.prev != null) { if (toRemove == tail) tail = toRemove.prev; toRemove.prev.next = toRemove.next; }
                    if (toRemove.next != null) { if (toRemove == head) head = toRemove.next; toRemove.next.prev = toRemove.prev; }
                    count--;
                    return true;
                }
                toRemove = toRemove.next;
            }
            return false;
        }

        public bool Remove(Node d) // удаление по узлу
        {
            Node toRemove = head;
            while (toRemove != null)
            {
                if (toRemove.Equals(d))
                {
                    if (toRemove.prev != null) { if (toRemove == tail) tail = toRemove.prev; toRemove.prev.next = toRemove.next; }
                    if (toRemove.next != null) { if (toRemove == head) head = toRemove.next; toRemove.next.prev = toRemove.prev; }
                    count--;
                    return true;
                }
                toRemove = toRemove.next;
            }
            return false;
        }

        public void Clear() //очистка списка
        {
            head = null;
            tail = null;
            count = 0;
        }

        #endregion

    }
}
