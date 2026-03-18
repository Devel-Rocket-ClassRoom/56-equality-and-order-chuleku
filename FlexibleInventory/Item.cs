using System;
using System.Collections.Generic;
using System.Text;

class Item
{
    public string Name { get; private set; }
    public string Type { get; private set; }
    public string Grade {  get; private set; }
    public Item(string name, string type, string grade)
    {
        Name = name;
        Type = type;
        Grade = grade;
    }
}
