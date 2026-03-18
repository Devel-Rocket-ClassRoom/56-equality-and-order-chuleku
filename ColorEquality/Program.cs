using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

Console.WriteLine("=== 동등성 비교 ===");
Color colororg = new Color(255,0,0);
Color colortemp1 = new Color(255,0,0);
Color colortemp2 = new Color(0,0,255);
Console.WriteLine($"RGB(255, 0, 0) == RGB(255, 0, 0,): {colororg.Equals(colortemp1)}");
Console.WriteLine($"RGB(255, 0, 0) == RGB(255, 0, 0,): {colororg.Equals(colortemp2)}");
Console.WriteLine();
Console.WriteLine("=== 유사 색상 판정 ===");
Color colortemp3 = new Color(255,5,3);
Color colortemp4 = new Color(200,50,30);
Console.WriteLine($"RGB(255, 0, 0)과 RGB(250, 5, 3)은 유사한가 (임계값 10): {colororg.IsSimilar(colortemp3,10)}");
Console.WriteLine($"RGB(255, 0, 0)과 RGB(200, 50, 30)은 유사한가 (임계값 10): {colororg.IsSimilar(colortemp4,10)}");

Console.WriteLine();
Console.WriteLine("=== HashSet 중복 제거 ===");
Console.WriteLine("팔레트에 추가된 색상:");
HashSet<Color> list = new HashSet<Color>();

list.Add(new Color(255, 0, 0));
list.Add(new Color(255, 0, 0));
list.Add(new Color(0, 255, 0));
list.Add(new Color(0, 255, 0));
list.Add(new Color(0, 0, 255));
list.Add(new Color(0, 0, 255));

foreach(var c in list)
{
    Console.WriteLine(c);
}
Console.WriteLine($"색상 수: {list.Count}");
Console.WriteLine();


foreach(var c in list)
{
    if(colororg.Equals(c))
    {
        Console.WriteLine($"RGB(255, 0, 0) 포함 여부: {colororg.Equals(c)}");
    }
}