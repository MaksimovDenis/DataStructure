using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class LinkedList
    {
        public int Length { get; private set; }
        private Node _root;

        public LinkedList()
        {
            Length = 0;
            _root = null;
        }

        //Конструктор новых массивов
        public LinkedList(int[] array)
        {
            Length = array.Length;

            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;
                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
                }
            }
            else
            {
                _root = null;
            }
        }

        //Пункт 15 (Поиск индекса минимального элемента)
        public int FindMinIndexOfElement()
        {
            if (Length == 0)
            {
                throw new Exception("Массив не задан");
            }
            int index = 0;
            int min = _root.Value;
            Node tmp = _root;
            tmp = tmp.Next;
            for (int i = 1; i < Length; i++)
            {
                if (min > tmp.Value)
                {
                    min = tmp.Value;
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
                throw new Exception("Массив не задан");
            }
            int index = 0;
            int max = _root.Value;
            Node tmp = _root;
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

        //Пункт 12 (Поиск значения максимального элемента)
        public int FindMax()
        {

            Node crnt = _root;
            for (int i = 0; i < FindMaxIndexOfElement(); i++)
            {
                crnt = crnt.Next;
            }
            return crnt.Value;
        }

        //Пункт 13 (Поиск значения минимального элемента)
        public int FindMin()
        {
            Node crnt = _root;
            for (int i = 0; i < FindMinIndexOfElement(); i++)
            {
                crnt = crnt.Next;
            }
            return crnt.Value;
        }

        //Пункт 16 (Сортировка по возростанию)
        public void SortMinToMax()
        {
            Node crnti = _root;
            for (int i = 0; i < Length; i++)
            {
                Node crntj = _root;
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


        public void ArraySortReverse()
        {
            Node crnti = _root;
            for (int i = 0; i < Length; i++)
            {
                Node crntj = _root;
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
        public int this[int index]
        {

            get
            {
                if (index > Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }

            set
            {
                if (index > Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        //Пункт 7 (вернуть длину)
        public int GetLength()
        {
            return Length;
        }

        //Пункт 11 (Реверс массива)
        public void Reverse()
        {
            if (Length == 0)
            {
                return;
            }
            Node oldhead = _root;
            Node tmp;
            while (oldhead.Next != null)
            {
                tmp = oldhead.Next;
                oldhead.Next = tmp.Next;
                tmp.Next = _root;
                _root = tmp;
            }

        }

        //Пункт 9 (Индекс по значению)
        public int FindeIndexByValue(int value)
        {
            Node crnt = _root;
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


        //Пункт 2 (добавление в начало)
        public void AddByFirst(int value)
        {
            AddElementByIndex(0, value);
        }

        //Пункт 1 (добавление в конец)
        public void AddInEnd(int value)
        {
            AddElementByIndex(Length, value);
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
                Node crnt = _root;
                for (int i = 0; i < index - 1; i++)
                {
                    crnt = crnt.Next;
                }
                Node tmp = new Node(value);
                tmp.Next = crnt.Next;//tmp будет указывать на то на что указывала crnt
                crnt.Next = tmp;//говорим что crnt будет указывать на tmp
            }
            else
            {
                Node tmp = new Node(value);
                tmp.Next = _root;
                _root = tmp;
            }
            Length++;
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


        public void PopByIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0)
            {
                Node crnt = _root;
                for (int i = 0; i < index - 1; i++)
                {
                    crnt = crnt.Next;
                }
                Node tmp = crnt;
                tmp = tmp.Next;
                crnt.Next = tmp.Next;
                tmp.Next = null;

            }
            else
            {
                Node crnt = _root;
                Node tmp = crnt;
                tmp = tmp.Next;
                _root = tmp;
                crnt.Next = null;
            }
            Length--;
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
                PopInEnd();
            }
        }
        public void PopInBeginArray(int size)
        {
            for (int i = 0; i < size; i++)
            {
                PopInBegin();
            }
        }
        public void PopInEnd()
        {
            PopByIndex(Length - 1);
        }
        public void PopInBegin()
        {
            PopByIndex(0);
        }

        //Пункт 5 (удаление из списка первого элемента)
        public void DeleteByFirst()
        {
            int v = Length;
            int value = _root.Value;
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

        public void DeleteEqualValue(int value)
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
            LinkedList linkedList = (LinkedList)obj;

            if (Length != linkedList.Length)
            {
                return false;
            }

            Node tmp1 = _root;
            Node tmp2 = linkedList._root;

            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }
        public override string ToString()
        {
            string s = "";

            Node tmp = _root;
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
