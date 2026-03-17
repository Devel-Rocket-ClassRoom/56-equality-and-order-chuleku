using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Channels;

// 1.참조 동등성과 값 동등성
/*string s1 = "hello";
string s2 = "hello";
string s3 = new string("hello".ToCharArray());
Console.WriteLine(s1==s2);
Console.WriteLine(s1==s3);

Console.WriteLine(object.ReferenceEquals(s1,s2));
Console.WriteLine(object.ReferenceEquals(s1,s3));*/

// 2. 클래스의 기본 동등성 비교

/*Player p1 = new Player("홍길동", 25);
Player p2 = new Player("홍길동", 25);
Player p3 = p1;
Console.WriteLine($"p1 == p2: {p1==p2}");
Console.WriteLine($"p1 == p3: {p1==p3}");
Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");
class Player
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public Player(string name, int level)
    {
        Name = name;
        Level = level; 
    }
}*/

// 3. 구조체의 기본 동등성 비교
/*Position p1 = new Position(10,20);
Position p2 = new Position(10,20);
Position p3 = new Position(30,40);
Console.WriteLine($"pos1.Equals(pos2): {p1.Equals(p2)}");
Console.WriteLine($"pos1.Equals(pos3): {p1.Equals(p3)}");
struct Position
{
    public int X; 
    public int Y;
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}*/

// 4.IEquatable 구현하기
/*Item item1 = new Item("Sowrd",1);
Item item2 = new Item("Sowrd",1);
Item item3 = new Item("Arrow",2);
Console.WriteLine($"item1.Equals(item2): {item1.Equals(item2)}");
Console.WriteLine($"item1.Equals(item3): {item1.Equals(item3)}");
HashSet<Item> items = new HashSet<Item>();
items.Add(item1);
Console.WriteLine($"inventory.Contains(item2): {items.Contains(item2)}");
class Item : IEquatable<Item>
{
    public string Name { get; private set; }
    public int Id { get; private set; }
    public Item(string name, int id)
    {
        Name = name; 
        Id = id; 
    }

    public bool Equals(Item other)
    {
        if(other == null) return false;

        return Id == other.Id&&Name == other.Name;
    }
    public override bool Equals(object obj)
    {
        return Equals(obj as Item);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Id);
    }
}*/

// 5. GetHashCode의 중요성
/*BadItem b1 = new BadItem("item");
BadItem b2 = new BadItem("item");
Console.WriteLine($"b1.Equals(b2): {b1.Equals(b2)}");
Dictionary<BadItem,int> stock = new Dictionary<BadItem,int>();
stock[b1] = 10;
Console.WriteLine($"stock.ContainsKey(b2): {stock.ContainsKey(b2)}");
class BadItem
{
    public string Name;
    public BadItem(string name)
    {
        Name = name; 
    }
    public override bool Equals(object obj)
    {
       BadItem other = obj as BadItem;
        if (other == null) return false;
        return Name == other.Name;
    }
}*/

// 6. IComparable 구현하기
/*List<Monster> MonsterList = new List<Monster>
{
    new Monster("Goblin",30),
    new Monster("Dragon",100),
    new Monster("Slime",10),
    new Monster("Orc",50),
};
Console.WriteLine($"정렬 전:");
foreach(Monster m in MonsterList)
{
    Console.WriteLine(m);
}
Console.WriteLine();
Console.WriteLine("정렬 후:");
MonsterList.Sort();
foreach(Monster m in MonsterList)
{
    Console.WriteLine(m);
}
class Monster : IComparable<Monster>
{
    public string Name;
    public int Power;   

    public Monster(string name, int power)
    {
        Name = name;
        Power = power; 
    }
    public int CompareTo(Monster other)
    {
        if (other == null) return 1;
        return Power.CompareTo(other.Power);
    }
    public override string ToString()
    {
        return $"{Name}(전투력:{Power})";
    }
}*/

// 7. 다중 기준 정렬
/*List<Student> students = new List<Student>
{
    new Student("이영희",1,92),
    new Student("정수진",1,88),
    new Student("최동훈",2,90),
    new Student("김철수",2,85),
    new Student("박민수",2,85)
};
students.Sort();
foreach(Student student in students)
{
    Console.WriteLine(student);
}
class Student : IComparable<Student>
{
    public string Name;
    public int Grade;
    public int Score;

    public Student(string name, int grade, int score)
    {
        Name = name;
        Grade = grade; 
        Score = score;
    }
    public int CompareTo(Student other)
    {
        if (other == null) return 1;
        int result1 = Grade.CompareTo(other.Grade);
        if(result1 != 0) return result1;
        int result = other.Score.CompareTo(Score);
        if(result != 0) return result;
        return Name.CompareTo(other.Name);
    }
    public override string ToString()
    {
        return $"{Grade}학년 {Name} ({Score}점)";
    }
}
*/
// 8. EqualityComparer 상속하기
/*Customer cus1 = new Customer("Kim", "cheolsu");
Customer cus2 = new Customer("Kim", "cheolsu");
Dictionary<Customer,string> dict1 = new Dictionary<Customer,string>();
dict1[cus1] = "Vip";
Console.WriteLine($"기본 Dictionary - c2 검색: {dict1.ContainsKey(cus2)}");
Dictionary<Customer, string> dict2 = new Dictionary<Customer, string>(new CustomerNameComparer());
dict2[cus1] = "Vip";
Console.WriteLine($"커스텀 Dictionary - c2 검색: {dict2.ContainsKey(cus2)}");
class Customer
{
    public string LastName;
    public string FirstName;
    public Customer(string lastName, string firstName)
    {
        LastName = lastName;
        FirstName = firstName;
    }
    public override string ToString()
    {
        return $"{LastName} {FirstName}";
    }
}
class CustomerNameComparer : EqualityComparer<Customer>
{
    public override bool Equals(Customer x, Customer y)
    {
        if(x == null && y == null)
        {
            return true; 
        }
        if(x == null || y == null)
        {
            return false; 
        }
        return x.LastName == y.LastName && x.FirstName == y.FirstName;
    }
    public override int GetHashCode(Customer obj)
    {
        if (obj == null)
        {
            return 0;
        }
        return HashCode.Combine(obj.LastName, obj.FirstName);
    }
}*/

// 9. 대소문자 무시 문자열 비교기
/*Dictionary<string, int> caseInsensitive =
    new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

caseInsensitive["Apple"] = 100;
caseInsensitive["BANANA"] = 200;

Console.WriteLine($"apple 검색: {caseInsensitive["apple"]}");
Console.WriteLine($"Banana 검색: {caseInsensitive["Banana"]}");

Dictionary<string, int> caseSensitive = new Dictionary<string, int>();
caseSensitive["Apple"] = 100;

Console.WriteLine($"\n일반 Dictionary에서 'apple' 존재 여부: {caseSensitive.ContainsKey("apple")}");*/

// 10. Comparer 상속하기
/*List<Quest> quests = new List<Quest>
{
    new Quest("드래곤 처치", 1, 10000),
    new Quest("약초 수집", 3, 100),
    new Quest("마을 방어", 2, 500),
    new Quest("보물 찾기", 2, 3000)
};

Console.WriteLine("우선순위 기준 정렬:");
quests.Sort(new QuestPriorityComparer());
foreach (Quest q in quests)
{
Console.WriteLine($"  {q}");
}

Console.WriteLine("\n보상 기준 정렬 (내림차순):");
quests.Sort(new QuestRewardComparer());
foreach (Quest q in quests)
{
Console.WriteLine($"  {q}");
}

class Quest
{
    public string Name;
    public int Priority;      
    public int RewardGold;

    public Quest(string name, int priority, int rewardGold)
    {
        Name = name;
        Priority = priority;
        RewardGold = rewardGold;
    }

    public override string ToString()
    {
        return $"[우선순위{Priority}] {Name} (보상:{RewardGold}골드)";
    }
}

class QuestPriorityComparer : Comparer<Quest>
{
    public override int Compare(Quest x, Quest y)
    {
        if (x == null && y == null)
        {
            return 0;
        }
        if (x == null)
        {
            return -1;
        }
        if (y == null)
        {
            return 1;
        }
        return x.Priority.CompareTo(y.Priority);
    }
}

class QuestRewardComparer : Comparer<Quest>
{
    public override int Compare(Quest x, Quest y)
    {
        if (x == null && y == null)
        {
            return 0;
        }
        if (x == null)
        {
            return -1;
        }
        if (y == null)
        {
            return 1;
        }
        return y.RewardGold.CompareTo(x.RewardGold);
    }
}*/

// 11. StringComparer 정렬
/*string[] fruits = { "apple", "Banana", "CHERRY", "date", "Elderberry" };
Console.WriteLine("Ordinal 정렬 (대소문자 구분):");
Array.Sort(fruits, StringComparer.Ordinal);
Console.WriteLine(string.Join(", ",fruits));
Console.WriteLine();
Console.WriteLine("ordinalIgnoreCase 정렬:");
Array.Sort(fruits, StringComparer.OrdinalIgnoreCase);
Console.WriteLine(string.Join(", ",fruits));*/

// 12. Comparer.Create() 메서드
/*List<Product> products = new List<Product>
{
    new Product("키보드", 50000),
    new Product("마우스", 30000),
    new Product("모니터", 300000),
    new Product("헤드셋", 80000)
};

Comparer<Product> priceAsc = Comparer<Product>.Create(
    (x, y) => x.Price.CompareTo(y.Price)
);

products.Sort(priceAsc);
Console.WriteLine("가격 오름차순:");
foreach (Product p in products)
{
Console.WriteLine($"  {p}");
}

Comparer<Product> nameDesc = Comparer<Product>.Create(
    (x, y) => y.Name.CompareTo(x.Name)
);

products.Sort(nameDesc);
Console.WriteLine("\n이름 내림차순:");
foreach (Product p in products)
{
Console.WriteLine($"  {p}");
}
class Product
{
    public string Name;
    public int Price;

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name}: {Price}원";
    }
}*/
// 13. SortedDictionary와 비교기
/*SortedDictionary<int, string> scoreboard = new SortedDictionary<int, string>(
    Comparer<int>.Create((x, y) => y.CompareTo(x))
);

scoreboard[85] = "Kim";
scoreboard[92] = "Lee";
scoreboard[78] = "Park";
scoreboard[92] = "Choi";

Console.WriteLine("점수 순위표:");
int rank = 1;
foreach(KeyValuePair<int,string> entry in scoreboard)
{
    Console.WriteLine($" {rank++}위: {entry.Value} ({entry.Key}점)");
}*/
//14. HashSet과 동등성 비교
/*HashSet<Equipment> weapon = new HashSet<Equipment>(new EquipmentTypeComparer());

weapon.Add(new Equipment("불꽃 검","무기"));
weapon.Add(new Equipment("철 갑옷","방어구"));
weapon.Add(new Equipment("가죽 장갑","장갑"));
Console.WriteLine("장착된 장비:");
foreach(Equipment e in weapon)
{
    Console.WriteLine(e);
}
class Equipment
{
    public string Name;
    public string Type;
    public Equipment(string name, string type)
    {
        Name = name;
        Type = type;
    }
    public override string ToString()
    {
        return $"{Type}: {Name}";
    }
}
class EquipmentTypeComparer : EqualityComparer<Equipment>
{
    public override bool Equals(Equipment x, Equipment y)
    {
        if (x == null && y == null) return true;
        if (x == null || y == null) return false;
        return x.Type == y.Type;
    }
    public override int GetHashCode(Equipment obj)
    {
        return obj.Type?.GetHashCode() ?? 0; 
    }
}*/

// 15. EqualityComparer.Default
int[] num = { 1, 2, 3, 4, 5 };
string[] fluits = { "apple", "banana", "cherry" };
Console.WriteLine($"number에 3 포함: {Contains(num,3)}");
Console.WriteLine($"number에 10 포함: {Contains(num,10)}");
Console.WriteLine($"words에 \"banana\" 포함: {Contains(fluits,"banana")}");
Console.WriteLine($"words에 \"grape\" 포함: {Contains(fluits,"grape")}");
static bool Contains<T>(T[] array, T target)
{
    EqualityComparer<T> comparer = EqualityComparer<T>.Default;
    foreach(T item in array)
    {
        if(comparer.Equals(item, target))
        {
            return true;
        }

    }
    return false;
}