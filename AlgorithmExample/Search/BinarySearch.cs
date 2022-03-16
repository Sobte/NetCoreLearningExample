using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AlgorithmExample.Search
{
    /// <summary>
    /// 二分查找
    /// 针对拥有 n 个元素的已排序集合：
    /// 时间复杂度为：O(log2 n)
    /// </summary>
    public class BinarySearch
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// 使用二分查找完成搜索 如下题目：[1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20] 搜索出 19,51,3 的对应索引
        /// <para>1、集合 必须为有序 集合</para>
        /// <para>2、每次都能排除一半的元素</para>
        /// </summary>
        [Test]
        public void Test1()
        {
            var demo = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};

            var result1 = Search(demo, 19);
            Console.WriteLine($"查找 19 的索引为：{result1}");

            var result2 = Search(demo, 51);
            Console.WriteLine($"查找 51 的索引为：{result2}");

            var result3 = Search(demo, 3);
            Console.WriteLine($"查找 3 的索引为：{result3}");
        }

        /// <summary>
        /// 测试 与 试验
        /// </summary>
        [Test]
        public void Test2()
        {
            // 生成数据
            var demo = new List<int>();
            for (var i = 0; i < 1000_000; i++)
                demo.Add(i + 1);

            var random = new Random();
            for (var i = 0; i < 20; i++) // 找 20 个 随机数字
            {
                var searchValue = random.Next(1000_000 - 1) + 1;

                var result1 = Search(demo, searchValue);
                Console.WriteLine($"版本1 查找 {searchValue} 的索引为：{result1}");

                var result2 = SearchV2(demo, searchValue, 0, demo.Count);
                Console.WriteLine($"版本2 查找 {searchValue} 的索引为：{result2}");
            }

            // log2 1000000 = 20+
        }

        /// <summary>
        /// 使用 二分查找 查找指定元素 在 集合中出现的 位置(索引) ，未查询到返回 -1
        /// </summary>
        /// <param name="collection">被搜索的集合</param>
        /// <param name="searchValue">查找的指定元素</param>
        /// <returns>指定元素的位置，未查询到返回 -1</returns>
        public static int Search<T>(IList<T> collection, T searchValue)
            where T : IComparable
        {
            var high = collection.Count;
            var step = 0;
            for (var low = 0; low <= high;) // 注意 这里的 最低索引和最高索引有可能是相同的 所以用 <=
            {
                step++;
                // 中位数 索引计算   
                // 简化推导：(high - low) / 2 + low = mid
                //  => (high - low) + 2low = 2mid
                //  => high + low = 2mid
                //  => (high + low) / 2 = mid

                // var mid = (high + low) / 2; // 暂不使用，防止溢出
                var mid = (high - low) / 2 + low;
                // 优选：(high - low) / 2 + low
                // 因：C# 中 int 是有符号的 low + high 会导致 int 溢出，可以替换 无符号 或者采用 不简化的公式解决
                var guess = collection[mid];
                var compareResult = guess.CompareTo(searchValue);
                if (compareResult == 0)
                {
                    Console.WriteLine($"总共查找了 {step} 次");
                    return mid;
                }

                if (compareResult > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// 使用 二分查找(版本2,递归实现) 查找指定元素 在 集合中出现的 位置(索引) ，未查询到返回 -1
        /// </summary>
        /// <param name="collection">被搜索的集合</param>
        /// <param name="searchValue">查找的指定元素</param>
        /// <param name="low">最低查找索引</param>
        /// <param name="high">最高查找索引</param>
        /// <returns>指定元素的位置，未查询到返回 -1</returns>
        public static int SearchV2<T>(IList<T> collection, T searchValue, int low, int high)
            where T : IComparable
        {
            var mid = low + (high - low) / 2;
            if (mid < 0 || mid >= collection.Count)
                return -1;
            var guess = collection[mid];
            var compareResult = guess.CompareTo(searchValue);
            if (compareResult == 0)
                return mid;
            if (compareResult > 0)
                return SearchV2(collection, searchValue, low, mid - 1);
            return SearchV2(collection, searchValue, mid + 1, high);
        }

        /// <summary>
        /// 二分查找 中位数 计算 溢出测试
        /// </summary>
        [Test]
        public void TestOverflow()
        {
            var low = 0B0100_0000_0000_0000_0000_0000_0000_0000; // 1073741824
            var high = 0B0100_0000_0000_0000_0000_0000_0000_0000; // 1073741824

            Console.WriteLine((high + low) / 2); // 中位数的公式一 结果：-1073741824

            // high + low =  1000 0000 0000 0000 0000 0000 0000 0000
            //     =  2147483648 as unsigned 32-bit integer
            //     = -2147483648 as signed   32-bit integer
            //     (high + low) / 2   = 1100 0000 0000 0000 0000 0000 0000 0000 = -1073741824
            // low + (high - low) / 2 = 0100 0000 0000 0000 0000 0000 0000 0000 =  1073741824

            Console.WriteLine((high - low) / 2 + low); // 中位数的公式二 结果：1073741824

            // 以下是使用 无符号的数字 参与运算，结果正常

            var uLow = 0B0100_0000_0000_0000_0000_0000_0000_0000U; // 1073741824
            var uHigh = 0B0100_0000_0000_0000_0000_0000_0000_0000U; // 1073741824

            Console.WriteLine((uHigh + uLow) / 2); // 中位数的公式一 结果：1073741824
            Console.WriteLine((uHigh - uLow) / 2 + uLow); // 中位数的公式二 结果：1073741824
        }
    }
}