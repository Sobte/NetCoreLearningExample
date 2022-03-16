using System;
using NUnit.Framework;

namespace ExampleTest.Grammar
{
    public class KeywordsDemo
    {
        #region 关键词 与 标识符

        // public class class // 禁止直接将 关键词 当作 标识符 使用
        public class @class
        {
            public int x;
            public int y;
        }

        [Test]
        public void Test1()
        {
            var demo = new @class();
            demo.x = 0;
            demo.y = 1;
            Console.WriteLine(demo.x);
            Console.WriteLine(demo.y);
        }

        #endregion
    }
}