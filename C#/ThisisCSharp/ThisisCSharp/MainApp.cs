using System;
//using static System.Console;

namespace ThisisCSharp
{
    class MainApp
    {
        //static void Main(string[] args) // 프로그램 실행이 시작되는 곳
        //{
        //    P19
        //    if (args.Length == 0)
        //    {
        //        Console.WriteLine("사용법 : Hello.exe <이름>");
        //        return; // 밑에 코드 실행이 안됨
        //    }
        //    WriteLine("Hello, {0}!", args[0]); // Hello, World를 프롬프트에 출력  

        //    P39
        //    Console.WriteLine("여러분, 안녕하세요?");
        //    Console.WriteLine("반갑습니다!");
        //}



        // P49 데이터 형식에 따른 크기 확인하기
        //static void Main(string[] args)  
        //{
        //    sbyte a = -10;
        //    byte b = 40;
        //    Console.WriteLine($"a = {a}, b={b}");

        //    short c = -3000;
        //    ushort d = 6000;
        //    Console.WriteLine($"c = {c}, d={d}");

        //    int e = -10000000;
        //    uint f = 300000000;
        //    Console.WriteLine($"e = {e}, f={f}");

        //    long g = -500000000000;
        //    ulong h = 2000000000000000000;
        //    Console.WriteLine($"g = {g}, h={h}");
        //}



        // P51 각 진수에 따른 리터럴 확인
        //static void Main(string[] args)  
        //{
        //    byte a = 240; // 10진수 리터렬
        //    Console.WriteLine($"a={a}");

        //    byte b = 0b1111_0000; // 2진수 리터럴
        //    Console.WriteLine($"b={b}");

        //    byte c = 0XF0; // 16진수 리터럴
        //    Console.WriteLine($"c={c}");

        //    uint d = 0x1234_abcd; // 16진수 리터럴
        //    Console.WriteLine($"d={d}");
        //}


        // P54 보수 확인
        //static void Main(string[] args) 
        //{
        //    byte a = 255;
        //    sbyte b = (sbyte)a;

        //    Console.WriteLine(a);
        //    Console.WriteLine(b);

        //}

        // P54 Overflow
        //static void Main(string[] args)
        //{
        //    uint a = uint.MaxValue;

        //    Console.WriteLine(a);

        //    a += 1;
        //    Console.WriteLine(a);

        //}

    }
}
