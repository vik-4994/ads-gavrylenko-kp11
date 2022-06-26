using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LAB_07_ADS
{
    class Program
    {
        static Hashtable hashtable = new Hashtable();
        static HashtableAdditional hashtableAdditional = new HashtableAdditional();
        static string[] months = { "січень", "лютий", "березень", "квітень", "травень", "червень", "липень", "серпень", "вересень", "жовтень", "листопад", "грудень" };

        static void Main(string[] args)
        {
            bool bol = true;
            
            while (bol)
            {
                Console.WriteLine("Щоб увійти в мануальний мод - натисніть (0), щоб зробити контрольний приклад - натисніть (1), щоб завершити програму - натисніть (2)");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "0":
                        manunalUsing();
                        break;
                    case "1":
                        controlExample();
                        break;
                    case "2":
                        bol = false;
                        break;
                }
            }
            Console.WriteLine("Програма завершена.");

        }
        public static void controlExample()
        {
            hashtable.initHashtable();
            hashtableAdditional.initHashtable();
            Console.WriteLine("Додаємо елементи, які можуть створити колізію");
            hashtableAdditional.insertEntry(new KeyAdditional(new Date(2004, "березень", 19)), new ValueAdditional(hashtable.gettingKey().bookingCode));
            hashtable.insertEntry(hashtable.gettingKey(), new Value("Igor", 2, "Normal", new Date(2004, "березень", 19), 3));
            hashtableAdditional.insertEntry(new KeyAdditional(new Date(2002, "липень", 19)), new ValueAdditional(hashtable.gettingKey().bookingCode));
            hashtable.insertEntry(hashtable.gettingKey(), new Value("Kyrylo", 1, "Lux", new Date(2002, "липень", 19), 7));
            hashtableAdditional.insertEntry(new KeyAdditional(new Date(2005, "березень", 21)), new ValueAdditional(hashtable.gettingKey().bookingCode));
            hashtable.insertEntry(hashtable.gettingKey(), new Value("Vadym", 3, "Normal", new Date(2005, "березень", 21), 3));
            hashtableAdditional.insertEntry(new KeyAdditional(new Date(2007, "січень", 4)), new ValueAdditional(hashtable.gettingKey().bookingCode));
            hashtable.insertEntry(hashtable.gettingKey(), new Value("Rita", 2, "Normal", new Date(2007, "січень", 4), 1));
            hashtableAdditional.insertEntry(new KeyAdditional(new Date(2005, "червень", 6)), new ValueAdditional(hashtable.gettingKey().bookingCode));
            hashtable.insertEntry(hashtable.gettingKey(), new Value("Stepan", 1, "Lux", new Date(2005, "червень", 6), 4));
            hashtableAdditional.insertEntry(new KeyAdditional(new Date(2004, "березень", 19)), new ValueAdditional(hashtable.gettingKey().bookingCode));
            hashtable.insertEntry(hashtable.gettingKey(), new Value("Angela", 3, "Normal", new Date(2004, "березень", 19), 5));
            Console.WriteLine("Результат вставки");
            hashtable.print();
            Console.WriteLine("Додаємо ще елементи, які можуть створити колізію");
            hashtableAdditional.insertEntry(new KeyAdditional(new Date(2004, "січень", 4)), new ValueAdditional(hashtable.gettingKey().bookingCode));
            hashtable.insertEntry(hashtable.gettingKey(), new Value("Andrii", 2, "Normal", new Date(2004, "січень", 4), 1));
            hashtableAdditional.insertEntry(new KeyAdditional(new Date(2006, "червень", 6)), new ValueAdditional(hashtable.gettingKey().bookingCode));
            hashtable.insertEntry(hashtable.gettingKey(), new Value("Vasya", 1, "Lux", new Date(2006, "червень", 6), 4));
            hashtableAdditional.insertEntry(new KeyAdditional(new Date(2002, "березень", 19)), new ValueAdditional(hashtable.gettingKey().bookingCode));
            hashtable.insertEntry(hashtable.gettingKey(), new Value("Vlad", 3, "Normal", new Date(2002, "березень", 19), 5));
            hashtable.print();
            Console.WriteLine("Знайдемо якийсь запис по ключу 001008");
            Entry entry = hashtable.findEntry(new Key(Convert.ToInt32("001004")));
            Console.WriteLine("Спробуємо видалити певний елемент");
            Date date1 = hashtable.removeEntry(new Key(Convert.ToInt32("001004")));
            if (date1.day != 0)
            {
                hashtableAdditional.removeEntry(new KeyAdditional(date1), Convert.ToInt32("001004"));
            }
            hashtable.print();
            Console.WriteLine("Спробуємо знайти записи з однаковою датою від'їзду 19.03.2004");
            hashtableAdditional.allDeparturesAtThisDate(new Date(2004, "березень", 19));
            hashtableAdditional.insertEntry(new KeyAdditional(new Date(2006, "червень", 6)), new ValueAdditional(hashtable.gettingKey().bookingCode));
            hashtable.insertEntry(hashtable.gettingKey(), new Value("Vasya", 1, "Lux", new Date(2006, "червень", 6), 4));
            hashtableAdditional.print();
        }
        public static void manunalUsing()
        {
            bool bol = true;
            string key;
            while (bol)
            {
                Console.WriteLine("Щоб створити хеш-таблицю - натисніть (0), щоб додати елемент - натисніть (1), щоб видалити елемент за ключем - натисніть (2), щоб знайти елемент за ключем - натисніть (3), щоб вивести геш-таблицю - натисніть (4), щоб шукати всіх гостей готелю, котрі виселяються в один день - настисніть (5), щоб вийти з мануального моду - настисніть (6)");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "0":
                        hashtable.initHashtable();
                        hashtableAdditional.initHashtable();
                        Console.WriteLine("Геш-таблиця створена");
                        break;
                    case "1":
                        if(hashtable.table.Length == 0)
                        {
                            Console.WriteLine("Геш-таблиця не створена!");
                            break;
                        }
                        Console.Write("Введіть ПІБ: ");
                        string mainGuestName = Console.ReadLine();
                        Console.WriteLine();
                        Regex num = new Regex(@"\D+");
                        Regex dat = new Regex(@"(\d){2}\.(\d){2}\.(\d){4}");
                        string numberOfGuests;
                        while (true)
                        {
                            Console.Write("Введіть кількість гостей: ");
                            numberOfGuests = Console.ReadLine();
                            if (!num.Match(numberOfGuests).Success)
                            {
                                break;
                            }
                            Console.WriteLine("Некоректно введено дані");
                        }
                        string str;
                        while (true)
                        {
                            Console.Write("Введіть дату заїзду у форматі 'день.місяць.рік' (приклад: 19.03.2004): ");
                            str = Console.ReadLine();
                            if (dat.Match(str).Success)
                            {
                                break;
                            }
                            Console.WriteLine("Некоректно введено дані");
                        }
                        string[] data = str.Split('.');
                        Date date = new Date(Convert.ToInt32(data[2]), months[Convert.ToInt32(data[1]) - 1], Convert.ToInt32(data[0]));
                        Console.WriteLine();
                        string roomType;
                        while (true)
                        {
                            Console.Write("Введіть тип кімнати: ");
                            roomType = Console.ReadLine();
                            if (num.Match(roomType).Success)
                            {
                                break;
                            }
                            Console.WriteLine("Некоректно введено дані");
                        }
                        string numberOfNights;
                        while (true)
                        {
                            Console.Write("Введіть кількість ночей: ");
                            numberOfNights = Console.ReadLine();
                            if (!num.Match(numberOfNights).Success)
                            {
                                break;
                            }
                            Console.WriteLine("Некоректно введено дані");
                        }
                        Value value = new Value(mainGuestName, Convert.ToInt32(numberOfGuests), roomType, date, Convert.ToInt32(numberOfNights));
                        ValueAdditional val = new ValueAdditional(hashtable.gettingKey().bookingCode);
                        KeyAdditional keyy = new KeyAdditional(value.dateOfArrival);
                        hashtableAdditional.insertEntry(keyy, val);
                        hashtable.insertEntry(hashtable.gettingKey(), value);
                        break;
                    case "2":
                        if (hashtable.table.Length == 0)
                        {
                            Console.WriteLine("Геш-таблиця не створена!");
                            break;
                        }
                        num = new Regex(@"\d+");
                        while (true)
                        {
                            Console.Write("Введіть ключ: ");
                            key = Console.ReadLine();
                            if (num.Match(key).Success)
                            {
                                break;
                            }
                            Console.WriteLine("Некоректно введено дані");
                        }
                        Date date1 = hashtable.removeEntry(new Key(Convert.ToInt32(key)));
                        if (date1.day != 0)
                        {
                            hashtableAdditional.removeEntry(new KeyAdditional(date1), Convert.ToInt32(key));
                        }
                        break;
                    case "3":
                        if (hashtable.table.Length == 0)
                        {
                            Console.WriteLine("Геш-таблиця не створена!");
                            break;
                        }
                        num = new Regex(@"\d+");
                        while (true)
                        {
                            Console.Write("Введіть ключ: ");
                            key = Console.ReadLine();
                            if (num.Match(key).Success)
                            {
                                break;
                            }
                            Console.WriteLine("Некоректно введено дані");
                        }
                        Entry entry = hashtable.findEntry(new Key(Convert.ToInt32(key)));
                        break;
                    case "4":
                        if (hashtable.table.Length == 0)
                        {
                            Console.WriteLine("Геш-таблиця не створена!");
                            break;
                        }
                        hashtable.print();
                        break;
                    case "5":
                        if (hashtable.table.Length == 0)
                        {
                            Console.WriteLine("Геш-таблиця не створена!");
                            break;
                        }
                        dat = new Regex(@"(\d){2}\.(\d){2}\.(\d){4}");
                        string str1;
                        while (true)
                        {
                            Console.Write("Введіть дату заїзду у форматі 'день.місяць.рік' (приклад: 19.03.2004): ");
                            str1 = Console.ReadLine();
                            if (dat.Match(str1).Success)
                            {
                                break;
                            }
                            Console.WriteLine("Некоректно введено дані");
                        }
                        string[] data1 = str1.Split('.');
                        Date date2 = new Date(Convert.ToInt32(data1[2]), months[Convert.ToInt32(data1[1]) - 1], Convert.ToInt32(data1[0]));
                        hashtableAdditional.allDeparturesAtThisDate(date2);
                        break;
                    case "6":
                        bol = false;
                        break;
                }
            }
        }

        class Hashtable
        {
            public Entry[] table;
            public double loadness;
            int size;
            int nextKey;
            public Hashtable()
            {
                this.size = 0;
                this.table = new Entry[0];
                this.loadness = 0;
            }

            public void initHashtable()
            {
                this.size = 0;
                this.loadness = 0;
                this.table = new Entry[11];
                this.nextKey = 001000;
            }

            public void insertEntry(Key key, Value value)
            {
                Entry entry = new Entry(key, value);
                
                int hash = getHash(key);

                if (table[hash] != null && table[hash].key.bookingCode != -1)
                {
                    for (int i = 1; i < table.Length; i++)
                    {
                        if (table[hashDouble(hash, i)] == null || table[hashDouble(hash, i)].key.bookingCode == -1)
                        {
                            hash = hashDouble(hash, i);
                            break;
                        }
                    }
                }

                table[hash] = entry;
                this.size++;
                this.loadness = this.size * 1.0 / this.table.Length;
                this.nextKey += 1;
                this.rehashing();
                Console.WriteLine("Елемент доданий до геш-таблиці");
            }

            public Date removeEntry(Key key)
            {
                int ind = getHash(key);

                for (int i = 0; i < table.Length; i++)
                {
                    ind = hashDouble(ind, i);
                    if(table[ind] != null && table[ind].key.bookingCode == key.bookingCode)
                    {
                        table[ind].key.bookingCode = -1;
                        this.size--;
                        this.loadness = this.size * 1.0 / table.Length;
                        Console.WriteLine("Елемент видалено");
                        return table[ind].value.dateOfArrival;
                    }
                }

                Console.WriteLine("Елемента з таким ключем не знайдено!");
                return new Date(0, "1", 0);
            }

            public Entry findEntry(Key key)
            {
                int ind = getHash(key);

                for (int i = 0; i < this.table.Length; i++)
                {
                    if (table[hashDouble(ind, i)] != null && table[hashDouble(ind, i)].key.bookingCode == key.bookingCode)
                    {
                        Console.WriteLine($"00{table[hashDouble(ind, i)].key.bookingCode} - ПІБ: {table[hashDouble(ind, i)].value.mainGuestName}, Кількість гостей: {table[hashDouble(ind, i)].value.numberOfGuests}, Кількість ночей: {table[hashDouble(ind, i)].value.numberOfNights}, Тип кімнати: {table[hashDouble(ind, i)].value.roomType}, дата заїзду: {table[hashDouble(ind, i)].value.dateOfArrival.day} {table[hashDouble(ind, i)].value.dateOfArrival.month} {table[hashDouble(ind, i)].value.dateOfArrival.year}");
                        return table[hashDouble(ind, i)];
                    }
                }
                Console.WriteLine("Елемента з таким ключем не знайдено!");
                return new Entry(new Key(-1), new Value("0", 0, "0", new Date(0, "0", 0), 0));
            }

            public void rehashing()
            {
                if (this.loadness >= 0.5)
                {
                    Entry[] table = new Entry[this.table.Length + 2];
                    for (int i = 0; i < table.Length - 2; i++)
                    {
                        table[i] = this.table[i];
                    }
                    this.loadness = this.size * 1.0 / table.Length;
                    this.table = table;
                }
            }

            public int getHash(Key key)
            {
                return key.bookingCode % table.Length;
            }

            public int hashDouble(int ind, int i)
            {
                return (ind + i) % table.Length;
            }

            public Key gettingKey()
            {
                return new Key(this.nextKey);
            }

            public void print()
            {
                Console.WriteLine("Вивід:");
                for (int i = 0; i < table.Length; i++)
                {
                    if(table[i] != null && table[i].key.bookingCode != -1)
                    {
                        Console.WriteLine($"00{table[i].key.bookingCode} - ПІБ: {table[i].value.mainGuestName}, Кількість гостей: {table[i].value.numberOfGuests}, Кількість ночей: {table[i].value.numberOfNights}, Тип кімнати: {table[i].value.roomType}, дата заїзду: {table[i].value.dateOfArrival.day} {table[i].value.dateOfArrival.month} {table[i].value.dateOfArrival.year}");
                    } else
                    {
                        Console.WriteLine("null");
                    }
                }
            }
        }

        class Key
        {
            public int bookingCode;
            public Key(int bookingCode)
            {
                this.bookingCode = bookingCode;
            }
        }

        class Value
        {
            public string mainGuestName;
            public int numberOfGuests;
            public string roomType;
            public Date dateOfArrival;
            public int numberOfNights;

            public Value(string mainGuestName, int numberOfGuests, string roomType, Date dateOfArrival, int numberOfNights)
            {
                this.mainGuestName = mainGuestName;
                this.numberOfGuests = numberOfGuests;
                this.roomType = roomType;
                this.dateOfArrival = dateOfArrival;
                this.numberOfGuests = numberOfGuests;
            }
        }

        class Entry
        {
            public Key key;
            public Value value;
            public Entry(Key key, Value value)
            {
                this.key = key;
                this.value = value;
            }
        }

        class HashtableAdditional
        {
            EntryAdditional[] table;
            double loadness;
            int size;
            public HashtableAdditional()
            {
                this.size = 0;
                this.table = new EntryAdditional[0];
                this.loadness = 0;
            }

            public void initHashtable()
            {
                this.size = 0;
                this.loadness = this.size * 1.0 / this.table.Length;
                this.table = new EntryAdditional[11];
            }

            public void insertEntry(KeyAdditional key, ValueAdditional value)
            {
                EntryAdditional entry = new EntryAdditional(key, value);

                int hash = getHash(hashCode(key.dateOfDeparture));
                if (table[hash] != null && table[hash].key.dateOfDeparture.day == key.dateOfDeparture.day && table[hash].key.dateOfDeparture.month == key.dateOfDeparture.month && table[hash].key.dateOfDeparture.year == key.dateOfDeparture.year)
                {
                    table[hash].value.bookingCodes.AddRange(value.bookingCodes);
                    this.size++;
                    this.loadness = this.size * 1.0 / this.table.Length;
                    this.rehashing();
                    Console.WriteLine("Елемент доданий до геш-таблиці");
                    return;
                } else
                {
                    for (int i = 1; i < table.Length; i++)
                    {
                        if (table[hashDouble(hash, i)] != null && table[hashDouble(hash, i)].key.dateOfDeparture.day == key.dateOfDeparture.day && table[hashDouble(hash, i)].key.dateOfDeparture.month == key.dateOfDeparture.month && table[hashDouble(hash, i)].key.dateOfDeparture.year == key.dateOfDeparture.year)
                        {
                            table[hashDouble(hash, i)].value.bookingCodes.AddRange(value.bookingCodes);
                            this.size++;
                            this.loadness = this.size * 1.0 / this.table.Length;
                            this.rehashing();
                            return;
                        }
                    }
                    for (int i = 1; i < table.Length; i++)
                    {
                        if (table[hashDouble(hash, i)] == null || table[hashDouble(hash, i)].key.dateOfDeparture.day == -1)
                        {
                            hash = hashDouble(hash, i);
                            break;
                        }
                        
                    }
                }

                table[hash] = entry;
                this.size++;
                this.loadness = this.size * 1.0 / this.table.Length;
                this.rehashing();
            }

            public void removeEntry(KeyAdditional key, int bookingCode)
            {
                int ind = getHash(hashCode(key.dateOfDeparture));

                for (int i = 0; i < table.Length; i++)
                {
                    ind = hashDouble(ind, i);
                    if (table[ind] != null && table[ind].key.dateOfDeparture.day == key.dateOfDeparture.day && table[ind].key.dateOfDeparture.month == key.dateOfDeparture.month && table[ind].key.dateOfDeparture.year == key.dateOfDeparture.year && table[ind].key.dateOfDeparture.day != -1)
                    {
                        table[ind].value.bookingCodes.Remove(bookingCode);
                        if (table[ind].value.bookingCodes.Count == 0)
                        {
                            table[ind].key.dateOfDeparture.day = -1;
                            this.size--;
                            this.loadness = this.size * 1.0 / table.Length;
                        }
                        return;
                    }
                }
            }

            public void rehashing()
            {
                if (this.loadness >= 0.5)
                {
                    EntryAdditional[] table = new EntryAdditional[this.table.Length + 2];
                    for (int i = 0; i < this.table.Length; i++)
                    {
                        table[i] = this.table[i];
                    }
                    this.table = table;
                }
            }

            public int hashCode(Date dateOfDeparture)
            {
                return dateOfDeparture.day + Array.IndexOf(months, dateOfDeparture.month) + 1 + dateOfDeparture.year;
            }

            public int getHash(int hash)
            {
                return hash % table.Length;
            }

            public int hashDouble(int ind, int i)
            {
                return (ind + i) % table.Length;
            }

            public void allDeparturesAtThisDate(Date dateOfDeparture)
            {
                int ind = getHash(hashCode(dateOfDeparture));

                for (int i = 0; i < table.Length; i++)
                {
                    if (table[hashDouble(ind, i)] != null && table[hashDouble(ind, i)].key.dateOfDeparture.day == dateOfDeparture.day && table[hashDouble(ind, i)].key.dateOfDeparture.month == dateOfDeparture.month && table[hashDouble(ind, i)].key.dateOfDeparture.year == dateOfDeparture.year)
                    {
                        for (int j = 0; j < table[hashDouble(ind, i)].value.bookingCodes.Count; j++)
                        {
                            Console.WriteLine(j);
                            hashtable.findEntry(new Key(table[hashDouble(ind, i)].value.bookingCodes[j]));
                        }
                        return;
                    }
                }

                Console.WriteLine("Елемента з таким ключем не знайдено!");
            }

            public void print()
            {
                Console.WriteLine("Вивід:");
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i] != null && table[i].key.dateOfDeparture.day != -1)
                    {
                        Console.WriteLine($"{table[i].key.dateOfDeparture.day} {table[i].key.dateOfDeparture.month} {table[i].key.dateOfDeparture.year}");
                    }
                    else
                    {
                        Console.WriteLine("null");
                    }
                }
            }
        }
        
        class KeyAdditional
        {
            public Date dateOfDeparture;
            public KeyAdditional(Date dateOfDeparture)
            {
                this.dateOfDeparture = dateOfDeparture;
            }
        }

        class ValueAdditional
        {
            public List<int> bookingCodes;

            public ValueAdditional(int bookingCode)
            {
                bookingCodes = new List<int>();
                bookingCodes.Add(bookingCode);
            }
        }

        class EntryAdditional
        {
            public KeyAdditional key;
            public ValueAdditional value;
            public EntryAdditional(KeyAdditional key, ValueAdditional value)
            {
                this.key = key;
                this.value = value;
            }
        }

        struct Date
        {
            public int year;
            public string month;
            public int day;

            public Date(int year, string month, int day)
            {
                this.year = year;
                this.month = month;
                this.day = day;
            }
        }
    }
}
