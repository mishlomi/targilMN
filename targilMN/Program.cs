namespace targilMN;

//internal class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Hello, World!");
//    }
//}


/////////////////////////////////////////////////////////////
///check2 - StringHash.h
///

//internal class Program
//{
//    static void Main(string[] args)
//    {
//        StringHash<int> hashTable = new StringHash<int>(10);

//        // Insert some values
//        hashTable.Insert("Hello", 1);
//        hashTable.Insert("World", 2);
//        hashTable.Insert("Test", 3);

//        // Print the table
//        Console.WriteLine("Hash Table after insertions:");
//        hashTable.Print();

//        // Search for a value
//        int value = hashTable.Search("World");
//        Console.WriteLine("Search for key 'World': " + value);

//        // Remove a value
//        hashTable.Remove("World");
//        Console.WriteLine("Hash Table after removal of key 'World':");
//        hashTable.Print();

//        // Search for the removed value
//        value = hashTable.Search("World");
//        Console.WriteLine("Search for key 'World' after removal: " + value);
//    }
//}

//public class StringHash<T> : HashTable<string, T>
//{
//    public StringHash(int m = 10) : base(m) { }

//    protected override int H1(string key)
//    {
//        int hashValue = 0;
//        for (int i = 0; i < key.Length; i++)
//        {
//            hashValue = (hashValue * 256 + key[i]) % Size;
//        }
//        return hashValue;
//    }

//    protected override int H2(string key)
//    {
//        return 1; // Linear probing
//    }
//}

//public abstract class HashTable<K, T>
//{
//    protected class Item
//    {
//        public T Data { get; set; }
//        public K Key { get; set; }
//        public State Flag { get; set; }

//        public Item()
//        {
//            Flag = State.EMPTY;
//        }

//        public Item(K key, T data)
//        {
//            Data = data;
//            Key = key;
//            Flag = State.FULL;
//        }
//    }

//    protected enum State { EMPTY, FULL, DELETED }

//    protected int Size;
//    protected Item[] Table;
//    protected int NumItems;

//    public HashTable(int m)
//    {
//        Size = m;
//        Table = new Item[Size];
//        NumItems = 0;
//    }

//    protected abstract int H1(K key);
//    protected abstract int H2(K key);

//    protected int Hash(K key, int i)
//    {
//        return (H1(key) + i * H2(key)) % Size;
//    }

//    public void Insert(K key, T data)
//    {
//        int i = 0;
//        int j;
//        do
//        {
//            j = Hash(key, i);
//            if (Table[j] == null || Table[j].Flag != State.FULL)
//            {
//                Table[j] = new Item(key, data);
//                NumItems++;
//                return;
//            }
//            i++;
//        } while (i != Size);
//        throw new InvalidOperationException("Hash table overflow");
//    }

//    public T Search(K key)
//    {
//        int i = 0;
//        int j;
//        do
//        {
//            j = Hash(key, i);
//            if (Table[j] == null || Table[j].Flag == State.EMPTY)
//            {
//                return default(T); // Return default value if not found
//            }
//            if (Table[j].Flag == State.FULL && Table[j].Key.Equals(key))
//            {
//                return Table[j].Data;
//            }
//            i++;
//        } while (i != Size);
//        return default(T); // Return default value if not found
//    }

//    public void Remove(K key)
//    {
//        int i = 0;
//        int j;
//        do
//        {
//            j = Hash(key, i);
//            if (Table[j] == null || Table[j].Flag == State.EMPTY)
//            {
//                return; // Item not found
//            }
//            if (Table[j].Flag == State.FULL && Table[j].Key.Equals(key))
//            {
//                Table[j].Flag = State.DELETED;
//                NumItems--;
//                return;
//            }
//            i++;
//        } while (i != Size);
//    }

//    public void Print()
//    {
//        for (int i = 0; i < Size; i++)
//        {
//            if (Table[i] != null && Table[i].Flag == State.FULL)
//            {
//                Console.WriteLine($"{i}:\t{Table[i].Key}");
//            }
//        }
//    }
//}





/////////////////////////////////////////////////////////////
///check1 - IntHash.h

//namespace targilMN
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            IntHash<string> hashTable = new IntHash<string>(10);

//            // Insert some values
//            hashTable.Insert(1, "One");
//            hashTable.Insert(2, "Two");
//            hashTable.Insert(3, "Three");

//            // Print the table
//            Console.WriteLine("Hash Table after insertions:");
//            hashTable.Print();

//            // Search for a value
//            string value = hashTable.Search(2);
//            Console.WriteLine("Search for key 2: " + value);

//            // Remove a value
//            hashTable.Remove(2);
//            Console.WriteLine("Hash Table after removal of key 2:");
//            hashTable.Print();

//            // Search for the removed value
//            value = hashTable.Search(2);
//            Console.WriteLine("Search for key 2 after removal: " + value);
//        }
//    }

//    public class IntHash<T> : HashTable<int, T>
//    {
//        public IntHash(int m = 10) : base(m) { }

//        protected override int H1(int key)
//        {
//            return key % Size;
//        }

//        protected override int H2(int key)
//        {
//            return 1 + (key % (Size - 1));
//        }
//    }

//    public abstract class HashTable<K, T>
//    {
//        protected class Item
//        {
//            public T Data { get; set; }
//            public K Key { get; set; }
//            public State Flag { get; set; }

//            public Item()
//            {
//                Flag = State.EMPTY;
//            }

//            public Item(K key, T data)
//            {
//                Data = data;
//                Key = key;
//                Flag = State.FULL;
//            }
//        }

//        protected enum State { EMPTY, FULL, DELETED }

//        protected int Size;
//        protected Item[] Table;
//        protected int NumItems;

//        public HashTable(int m)
//        {
//            Size = m;
//            Table = new Item[Size];
//            NumItems = 0;
//        }

//        protected abstract int H1(int key);
//        protected abstract int H2(int key);

//        protected int Hash(int key, int i)
//        {
//            return (H1(key) + i * H2(key)) % Size;
//        }

//        public void Insert(K key, T data)
//        {
//            int i = 0;
//            int j;
//            do
//            {
//                j = Hash(key.GetHashCode(), i);
//                if (Table[j] == null || Table[j].Flag != State.FULL)
//                {
//                    Table[j] = new Item(key, data);
//                    NumItems++;
//                    return;
//                }
//                i++;
//            } while (i != Size);
//            throw new InvalidOperationException("Hash table overflow");
//        }

//        public T Search(K key)
//        {
//            int i = 0;
//            int j;
//            do
//            {
//                j = Hash(key.GetHashCode(), i);
//                if (Table[j] == null || Table[j].Flag == State.EMPTY)
//                {
//                    return default(T); // Return default value if not found
//                }
//                if (Table[j].Flag == State.FULL && Table[j].Key.Equals(key))
//                {
//                    return Table[j].Data;
//                }
//                i++;
//            } while (i != Size);
//            return default(T); // Return default value if not found
//        }

//        public void Remove(K key)
//        {
//            int i = 0;
//            int j;
//            do
//            {
//                j = Hash(key.GetHashCode(), i);
//                if (Table[j] == null || Table[j].Flag == State.EMPTY)
//                {
//                    return; // Item not found
//                }
//                if (Table[j].Flag == State.FULL && Table[j].Key.Equals(key))
//                {
//                    Table[j].Flag = State.DELETED;
//                    NumItems--;
//                    return;
//                }
//                i++;
//            } while (i != Size);
//        }

//        public void Print()
//        {
//            for (int i = 0; i < Size; i++)
//            {
//                if (Table[i] != null && Table[i].Flag == State.FULL)
//                {
//                    Console.WriteLine($"{i}:\t{Table[i].Key}");
//                }
//            }
//        }
//    }
//}