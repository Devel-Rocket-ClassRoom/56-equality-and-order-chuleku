using System;

Console.WriteLine("=== 동등성 비교 ===");
Color colororg = new Color(255,0,0);
Color colortemp1 = new Color(255,0,0);
Color colortemp2 = new Color(0,0,255);
Console.WriteLine($"RGB(255, 0, 0) == RGB(255, 0, 0,): {colororg.Equals(colortemp1)}");
Console.WriteLine($"RGB(255, 0, 0) == RGB(255, 0, 0,): {colororg.Equals(colortemp2)}");
