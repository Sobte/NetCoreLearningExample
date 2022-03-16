using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AlgorithmExample.Search
{
    /// <summary>
    /// 顺序查找 (简单查找)
    /// 针对拥有 n 个元素的已排序集合：
    /// 时间复杂度为：O(n)
    /// </summary>
    public class SequenceSearch
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// 使用 顺序查找 完成搜索 如下题目：[1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20] 搜索出 19,51,3 的对应索引
        /// <para>1、每个元素都遍历过去，按顺序检索出所有元素进行比较，查找出对应的结果</para>
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
        /// 使用 顺序查找 查找指定元素 在 集合中出现的 位置(索引) ，未查询到返回 -1
        /// </summary>
        /// <param name="collection">被搜索的集合</param>
        /// <param name="searchValue">查找的指定元素</param>
        /// <returns>指定元素的位置，未查询到返回 -1</returns>
        public static int Search<T>(IList<T> collection, T searchValue)
        {
            for (var i = 0; i < collection.Count; i++)
            {
                if (collection[i]?.Equals(searchValue) == true)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}