using System;

namespace DataStructures
{
    public class ArrayList
    {
        private int[] _array = new int[3];

        public int Length { get; private set; }
        public ArrayList()
        {
            _array = new int[3];
            Length = 0;
        }

        //Индксатор
        public int this[int index]
        {
            get
            {
                if (index > Length - 1 || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Argumen are should be in range of 0 to Length");
                }

                return _array[index];
            }

            set
            {
                if (index > Length - 1 || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Argumen are should be in range of 0 to Length");
                }

                _array[index] = value;
            }

        }

        //Конструктор новых массивов
        public ArrayList(int[] array)
        {
            _array = new int[(int)(array.Length * 1.33)];
            Array.Copy(array, _array, array.Length);
            Length = array.Length;
        }

        //Пункт 1
        public void Add(int value)
        {
            if (Length >= _array.Length)
            {
                RizeSize();
            }
            _array[Length] = value;
            Length++;
        }


        //Пункт 2
        public void AddByFirst(int value)
        {
            if (Length >= _array.Length)
            {
                RizeSize();
            }
            MoveRight(_array.Length);
            _array[0] = value;
            Length++;
        }

        //Увелечение длины списка
        private void RizeSize(int size = 1)
        {
            int newLength = Length;

            while (newLength < Length + size)
            {
                newLength = (int)(newLength * 1.33d + 1);
            }

            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray;

        }

        //Пункт 3
        public void AddElementByIndex(int index, int value)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length >= _array.Length)
            {
                RizeSize();
            }
            MoveRight(_array.Length, index);
            _array[index] = value;
            Length++;
        }

        //Пункт 4 (удаление из списка последнего элемента)
        public void DeleteLastElement()
        {
            if (Length >= _array.Length)
            {
                RizeSize();
            }
            Length = Length - 1;
        }


        //Пункт 5 (удаление из списка первого элемента)
        public void DeleteFirstElement()
        {
            if (Length >= _array.Length)
            {
                RizeSize();
            }
            for (int i = 0; i < _array.Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            Length = Length-1;
        }

        //Пункт 6 (удаление из списка  элемента по индексу)
        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Length))
            {
                for (int i = index; i < Length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
                Length--;
            }
        }

        //Пункт 7 (вернуть длину)
        public int RetrunLength()
        {
            int f = Length;
            return f;
        }

        //Пункт 8 (Элемент по иднексу)
        public int FindeValueByIndex(int value)
        {
            int s = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (i == value - 1)
                {
                    s = _array[i];
                }

            }
            if (s == 0)
            {
                throw new IndexOutOfRangeException("");
            }
            else
            {
                return s;
            }

        }

        //Пункт 9 (Индекс по значению)
        public int FindeIndexByValue(int value)
        {
            int s = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == value)
                {
                    s = i + 1;
                }
            }

            return s;

        }

        //Пункт 10 (Изменение по индексу)
        public void RenameIndex(int value, int temp)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (i == value - 1)
                {
                    _array[i] = temp;
                }
            }
            if (value > Length)
            {
                throw new IndexOutOfRangeException("");
            }

        }

        //Пункт 11 (Реверс массива)
        public void Reverse()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                int a = _array[i];
                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = a;
            }
        }

        //Пункт 12 (Поиск значения максимального элемента)
        public int FindMaxElement()
        {
            int max;
            max = _array[0];

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }

        //Пункт 13 (Поиск значения максимального элемента)
        public int FindMinElement()
        {
            int min;
            min = _array[0];

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }
            return min;
        }

        //Пункт 14 (Поиск индекса максимального элемента)
        public int FindMaxIndexOfElement()
        {
            int x;
            int max;
            x = 0;
            max = _array[0];

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    x = i;
                }
            }
            return x + 1;
        }

        //Пункт 15 (Поиск индекса минимального элемента)
        public int FindMinIndexOfElement()
        {
            int x;
            int min;
            x = 0;
            min = _array[0];

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                    x = i;
                }
            }
            return x + 1;
        }

        //Пункт 16 (Сортировка по возростанию)
        public int[] SortMinToMax()
        {
            int[] f = CopyArray(_array);

            int temp, smallest;
            for (int i = 0; i < _array.Length - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < _array.Length; j++)
                {
                    if (_array[j] < _array[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = _array[smallest];
                _array[smallest] = _array[i];
                _array[i] = temp;
            }
            return _array;
        }

        //Пункт 17 (Сортировка по возростанию)
        public int[] SortMaxToMin()
        {
            int[] f = CopyArray(_array);

            int temp, biggest;
            for (int i = 0; i < _array.Length - 1; i++)
            {
                biggest = i;
                for (int j = i + 1; j < _array.Length; j++)
                {
                    if (_array[j] > _array[biggest])
                    {
                        biggest = j;
                    }
                }
                temp = _array[biggest];
                _array[biggest] = _array[i];
                _array[i] = temp;
            }
            return _array;
        }

        //Пункт 18 (удаление из списка первого элемента по значению)
        public int IndexOf(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Remove(int value)
        {
            RemoveAt(IndexOf(value));
        }

        //Пункт 19 (удаление из списка элементов по значению)
        public void RemoveAll(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    RemoveAt(IndexOf(_array[i]));
                    i = i - 1;
                }
            }
        }


        //Пункт 21 (Добавление массива в конец)
        public void AddRange(int[] array)
        {
            if (Length + array.Length >= _array.Length)
            {
                RizeSize(array.Length);
            }
            int s=0;
            for (int i = 0; i < array.Length; i++)
            {
                _array[Length+s] = array[i];
                s++; 
            }
            Length += array.Length;
        }

        //Пункт 22 (Добавление массива в начало)
        public void AddRangeByFirst(int[] array)
        {
            if (Length + array.Length >= _array.Length)
            {
                RizeSize(array.Length);
            }
            MoveRight(_array.Length, 0, array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }
            Length += array.Length;
        }
        //Пункт 23 (Добавление массива по индексу)
        public void AddRagneByIndex(int index, int[] array)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length + array.Length >= _array.Length)
            {
                RizeSize(array.Length);
            }
            MoveRight(_array.Length, index, array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                _array[i + index] = array[i];
            }
            Length += array.Length;
        }

        //Пункт 24 (Удаление из конца N элементов)
        public void DeleteByEnd(int v)
        {
            int value = _array[0];
            for (int j =Length;  j > v; j--)
            {
                int index = FindeIndexByValue(value - 1);
                if (index != -1)
                {
                    RemoveAt(index);

                }
                else
                {
                    return;
                }
            }
        }
        //Пункт 25(Удаление из начала N элементов)
        public void DeleteByFirst(int v)
        {
            int value = _array[0];
            for (int j = 0; j < v; j++)
            {
                int index = FindeIndexByValue(value-1);
                if (index != -1)
                {
                    RemoveAt(index);

                }
                else
                {
                    return;
                }
            }
        }

        //Пункт 26 (Удаление N элементов по индексу)
        public void DeleteElementByIndex(int value,  int v)
        {
            for (int j = 0; j < v; j++)
            {
                if (value > Length || value < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                int index = FindeIndexByValue(value);
                if (index != -1)
                {
                    RemoveAt(index);

                }
                else
                {
                    return;
                }
            }
        }

        public void ShowArrayList()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.Write(_array[i] +  "");
            }
        }

        public int[] CopyArray(int[] _array)
        {
            int[] f = new int[_array.Length];
            Array.Copy(_array, f, _array.Length);
            return f;
        }

        public override string ToString()
        {
            return string.Join(";", _array.Length);
        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void MoveRight(int newlenght, int index = 0, int size = 1)
        {
            for (int i = Length - 1; i >= index; i--)
            {
                _array[i + size] = _array[i];

            }
         }

        private void MoveLeft(int newlenght, int index = 0, int size = 1)
        {
            if (size > Length - index)
            {
                throw new Exception();
            }
            if (Length == 1)
            {
                int[] newarray = new int[] { };
                _array = newarray;
            }
            else
            {
                for (int i = index; i < Length - 1; i++)
                {
                    
                    _array[i] = _array[i + size];
                }
            }
        }









    }   
}
