﻿using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;
namespace DataStructures
{
    public class DoubleLinkedList
    {
        public int Length { get; private set; }
        private Node _head;
        private Node _end;
        DoubleLinkedList()
        {
            Length = 0;
            _head = null;
            _end = null;
        }

        //Конструктор новых массивов
        public DoubleLinkedList(int[] array)
        {
            Length = array.Length;

            if (array.Length != 0)
            {
                _head = new Node(array[0]);
                Node tmp = _head;
                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    Node crnt = tmp;
                    tmp = tmp.Next;
                    tmp.Previous = crnt;
                }
                _end = tmp;
            }
            else
            {
                _head = null;
                _end = null;
            }
        }

        //Пункт 11 (Реверс массива)
        public void Reverse()

        {
            Node left = _head, right = _end;
            while (left != right && left.Previous != right)

            {
                int tmp = left.Value;
                left.Value = right.Value;
                right.Value = tmp;
                left = left.Next;
                right = right.Previous;
            }

        }


        private Node EndOrHead(int index)
        {
            if (index > Length / 2)
            {

                return _end;
            }
            else
            {

                return _head;
            }
        }


        //Пункт 3
        public void AddElementByIndex(int index, int value)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0)
            {
                Node crnt = EndOrHead(index);
                if (crnt == _head)
                {
                    for (int i = 0; i < index - 1; i++)
                    {
                        crnt = crnt.Next;
                    }
                    Node tmp = new Node(value);
                    tmp.Next = crnt.Next;//tmp будет указывать на то на что указывала crnt
                    crnt.Next = tmp;//говорим что crnt будет указывать на tmp
                                    //tmp будет указывать на то на что указывала crnt
                    tmp.Previous = crnt;
                    crnt = crnt.Next;
                    crnt = crnt.Next;
                    crnt.Previous = tmp;
                }
                else
                {
                    if (index == Length)
                    {
                        Node tmp = new Node(value);
                        tmp.Previous = crnt;
                        crnt.Next = tmp;
                        _end = tmp;

                    }
                    else
                    {
                        for (int i = 0; i < Length - index - 1; i++)
                        {
                            crnt = crnt.Previous;
                        }
                        Node tmp = new Node(value);
                        tmp.Previous = crnt.Previous;
                        crnt.Previous = tmp;
                        crnt = crnt.Previous;
                        crnt = crnt.Previous;
                        tmp.Next = crnt.Next;
                        crnt.Next = tmp;
                    }
                }

            }
            else
            {
                Node tmp = new Node(value);
                tmp.Next = _head;
                _head.Previous = tmp;
                _head = tmp;
            }
            Length++;
        }

        //Пункт 16 (Сортировка по возростанию)
        public void SortMinToMax()
        {
            Node crnti = _head;
            for (int i = 0; i < Length; i++)
            {
                Node crntj = _head;
                crntj = crntj.Next;
                for (int j = 1; j < Length; j++)
                {
                    if (j > i)
                    {
                        if (crnti.Value > crntj.Value)
                        {

                            int tmp;
                            tmp = crnti.Value;
                            crnti.Value = crntj.Value;
                            crntj.Value = tmp;
                        }
                    }
                    crntj = crntj.Next;
                }
                crnti = crnti.Next;
            }
        }


        public void PopByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0)
            {
                Node crnt = EndOrHead(index);
                if (crnt == _head)
                {
                    for (int i = 0; i < index - 1; i++)
                    {
                        crnt = crnt.Next;
                    }
                    Node tmp = crnt;
                    tmp = tmp.Next;
                    crnt.Next = tmp.Next;
                    tmp.Next = null;
                    crnt = crnt.Next;
                    if (crnt != null)
                    {
                        crnt.Previous = tmp.Previous;
                    }

                    tmp.Previous = null;
                }
                else
                {
                    if (index == Length - 1)
                    {

                        Node tmp = crnt;
                        tmp = tmp.Previous;
                        _end = tmp;
                        crnt.Next = null;
                        crnt.Previous = null;
                    }
                    else
                    {
                        for (int i = 0; i < Length - index - 2; i++)
                        {
                            crnt = crnt.Previous;
                        }
                        Node tmp = crnt;
                        tmp = tmp.Previous;
                        crnt.Previous = tmp.Previous;
                        tmp.Previous = null;
                        crnt = crnt.Previous;
                        crnt.Next = tmp.Next;
                        tmp.Next = null;
                    }
                }
            }
            else
            {
                Node crnt = _head;
                Node tmp = crnt;
                tmp = tmp.Next;
                _head = tmp;
                crnt.Next = null;
                crnt.Previous = null;
            }
            Length--;
        }
        public void PopHead()
        {
            PopByIndex(0);
        }
        public void PopEnd()
        {
            PopByIndex(Length - 1);
        }
        public void ArraySortReverse()
        {
            Node crnti = _head;
            for (int i = 0; i < Length; i++)
            {
                Node crntj = _head;
                crntj = crntj.Next;
                for (int j = 1; j < Length; j++)
                {
                    if (j > i)
                    {
                        if (crnti.Value < crntj.Value)
                        {
                            int tmp;
                            tmp = crnti.Value;
                            crnti.Value = crntj.Value;
                            crntj.Value = tmp;
                        }
                    }
                    crntj = crntj.Next;
                }
                crnti = crnti.Next;
            }
        }

        //Пункт 15 (Поиск индекса минимального элемента)
        public int FindMinIndexOfElement()
        {
            if (Length == 0)
            {
                throw new Exception("Массив пустой");
            }
            int index = 0;
            int max = _head.Value;
            Node tmp = _head;
            tmp = tmp.Next;
            for (int i = 1; i < Length; i++)
            {
                if (max > tmp.Value)
                {
                    max = tmp.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }

        //Пункт 14 (Поиск индекса максимального элемента)
        public int FindMaxIndexOfElement()
        {
            if (Length == 0)
            {
                throw new Exception("Массив пустой");
            }
            int index = 0;
            int max = _head.Value;
            Node tmp = _head;
            tmp = tmp.Next;
            for (int i = 1; i < Length; i++)
            {
                if (max < tmp.Value)
                {
                    max = tmp.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }

        //Пункт 9 (Индекс по значению)
        public int FindeIndexByValue(int value)
        {
            Node crnt = _head;
            for (int i = 0; i < Length; i++)
            {
                if (crnt.Value == value)
                {
                    return i;
                }
                crnt = crnt.Next;
            }
            return -1;
        }

        //Пункт 7 (вернуть длину)
        public int RetrunLength()
        {
            return Length;
        }
        public int this[int index]
        {
            get
            {
                if (index > Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = EndOrHead(index);
                if (tmp == _head)
                {
                    for (int i = 0; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }
                    return tmp.Value;
                }
                else
                {
                    for (int i = 0; i < Length - index - 1; i++)
                    {
                        tmp = tmp.Previous;
                    }
                    return tmp.Value;
                }
            }

            set
            {
                if (index > Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = EndOrHead(index);
                if (tmp == _head)
                {
                    for (int i = 0; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }
                    tmp.Value = value;
                }
                else
                {
                    for (int i = 0; i < Length - index - 1; i++)
                    {
                        tmp = tmp.Previous;
                    }
                    tmp.Value = value;
                }
            }
        }
        //Пункт 12 (Поиск значения максимального элемента)
        public int FindMaxElement()
        {
            Node crnt = _head;
            for (int i = 0; i < FindMaxIndexOfElement(); i++)
            {
                crnt = crnt.Next;
            }
            return crnt.Value;
        }

        //Пункт 13 (Поиск значения максимального элемента)
        public int FindMinElement()
        {
            Node crnt = _head;
            for (int i = 0; i < FindMinIndexOfElement(); i++)
            {
                crnt = crnt.Next;
            }
            return crnt.Value;
        }

        public void AddHead(int value)
        {
            AddElementByIndex(0, value);
        }


        public void AddEnd(int value)
        {
            AddElementByIndex(Length, value);
        }


        public void PopByIndexArray(int index, int size)
        {
            if (size > Length - index)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = 0; i < size; i++)
            {
                PopByIndex(index);
            }
        }


        public void PopInEndArray(int size)
        {
            for (int i = 0; i < size; i++)
            {
                PopEnd();
            }
        }


        public void PopInBeginArray(int size)
        {
            for (int i = 0; i < size; i++)
            {
                PopHead();
            }
        }

        //Пункт 23 (Добавление массива по индексу)
        public void AddRagneByIndex(int index, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                AddElementByIndex(index + i, array[i]);
            }
        }

        //Пункт 22 (Добавление массива в начало)
        public void AddRangeByFirst(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                AddElementByIndex(i, array[i]);
            }
        }

        //Пункт 21 (Добавление массива в конец)
        public void AddRange(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                AddElementByIndex(Length + i, array[i]);
            }
        }

        //Пункт 25(Удаление из начала N элементов)
        public void DeleteByFirst()
        {
            int value = _head.Value;
            int v = Length;
            for (int j = 0; j < v; j++)
            {
                int index = FindeIndexByValue(value);
                if (index != -1)
                {
                    PopByIndex(index);

                }
                else
                {
                    return;
                }
            }
        }

        //Пункт 26 (Удаление N элементов по индексу)
        public void DeleteElementByIndex(int value)
        {

            int v = Length;
            for (int j = 0; j < v; j++)
            {
                int index = FindeIndexByValue(value);
                if (index != -1)
                {
                    PopByIndex(index);

                }
                else
                {
                    return;
                }
            }
        }



        public override bool Equals(object obj)
        {
            DoubleLinkedList DoublelinkedList = (DoubleLinkedList)obj;

            if (Length != DoublelinkedList.Length)
            {
                return false;
            }

            Node tmp = _head;
            Node tmpobj = DoublelinkedList._head;

            for (int i = 0; i < Length; i++)
            {
                if (tmp.Value != tmpobj.Value)
                {
                    return false;
                }
                tmp = tmp.Next;
                tmpobj = tmpobj.Next;
            }
            Node crnt = _end;
            Node crntobj = DoublelinkedList._end;
            for (int j = 0; j < Length; j++)
            {
                if (crnt.Value != crntobj.Value)
                {
                    return false;
                }
                crnt = crnt.Previous;
                crntobj = crntobj.Previous;
            }
            return true;
        }
        public override string ToString()
        {
            string s = "";

            Node tmp = _head;
            for (int i = 0; i < Length; i++)
            {
                s += tmp.Value + ";";
                tmp = tmp.Next;
            }
            return s;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
