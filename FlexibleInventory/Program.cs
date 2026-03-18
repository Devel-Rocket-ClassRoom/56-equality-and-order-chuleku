using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

HashSet<Item> item = new HashSet<Item>(new ItemTypeComparer());
HashSet<Item> item1 = new HashSet<Item>(new ItemTypeComparer());
item.Add(new Item("불꽃 검", "무기", "전설"));
item.Add(new Item("얼음 단검", "무기", "희귀"));
item.Add(new Item("철 갑옷", "방어구", "일반"));
item.Add(new Item("미스릴 방패", "방어구", "희귀"));
item.Add(new Item("체력 물약", "소비", "일반"));
item1.Add(new Item("불꽃 검", "무기", "전설"));
item1.Add(new Item("얼음 단검", "무기", "희귀"));
item1.Add(new Item("철 갑옷", "방어구", "일반"));
item1.Add(new Item("미스릴 방패", "방어구", "희귀"));
item1.Add(new Item("체력 물약", "소비", "일반"));
var type = new HashSet<Item>(new ItemTypeComparer());
type = item;
int weaponcount = 0;
int defencecount = 0;
int posioncount = 0;
var check = new Dictionary<Item, Item>
{
    {item,item1 }
};

foreach(var itemType in type)
{
    if(itemType.Type == "무기")
    {
        weaponcount++; 
        if(weaponcount ==1)
        {
            Console.WriteLine("[무기]");
        }
       
        Console.WriteLine($"- {itemType.Name} ({itemType.Type})");
    }
    if(itemType.Type == "방어구")
    {
        defencecount++;
        if (defencecount ==1)
        {
            Console.WriteLine("[방어구]");
        }
    
        Console.WriteLine($"- {itemType.Name} ({itemType.Type})");
    }
    
    if(itemType.Type == "소비")
    {
        posioncount++;
        if (posioncount==1)
        {

            Console.WriteLine("[소비]");
        }
        Console.WriteLine($"- {itemType.Name} ({itemType.Type})");
    }
}
Console.WriteLine();
Console.WriteLine("=== 등급별 그룹핑 ===");
var grade = new HashSet<Item>(new ItemGradeComparer());
grade = item;
int legendcout = 0;
int normalcount = 0;
int rarecount = 0;
foreach (var g in grade)
{
    if (g.Grade == "전설")
    {
        legendcout++;
        if (legendcout == 1)
        {
            Console.WriteLine("[전설]");
        }

        Console.WriteLine($"- {g.Name} ({g.Type})");
    }
    if (g.Grade == "일반")
    {
        normalcount++;
        if (normalcount == 1)
        {
            Console.WriteLine("[일반]");
        }

        Console.WriteLine($"- {g.Name} ({g.Type})");
    }

    if (g.Grade == "희귀")
    {
        rarecount++;
        if (rarecount == 1)
        {
            Console.WriteLine("[희귀]");
        }
        Console.WriteLine($"- {g.Name} ({g.Type})");
    }
}