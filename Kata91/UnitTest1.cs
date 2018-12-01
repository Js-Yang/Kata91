using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Kata91
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase(106, "2", true)]
        [TestCase(106, "11", true)]
        [TestCase(106, "0", false)]
        [TestCase(106, "12", false)]
        [TestCase(106, "99", true)]
        [TestCase(107, "2a", true)]
        [TestCase(107, "2b", true)]
        [TestCase(107, "14", true)]
        [TestCase(107, "1", true)]
        [TestCase(107, "2", false)]
        [TestCase(107, "12", false)]
        [TestCase(107, "99", true)]
        [TestCase(107, "abc", false)]
        public void valid_list(int year, string content, bool expected)
        {
            var medical = new Medical(year, content);
            Assert.AreEqual(expected, medical.IsValid());
        }
    }

    public class Medical
    {
        private readonly int _year;
        private readonly string _content;

        public Medical(int year, string content)
        {
            _year = year;
            _content = content;
        }
        
        public bool IsValid()
        {
            var years = new[] { 106, 107 };
            if (!years.Contains(_year))
            {
                return false;
            }

            return (_year == 107 ? GenerateWhiteList107() : GenerateWhiteList106()).Contains(_content);
        }

        private List<string> GenerateWhiteList107()
        {
            var whiteList = new List<string>();
            for (int i = 1; i <= 14; i++)
            {
                whiteList.Add(i.ToString());
            }

            whiteList.Add("99");
            whiteList.Add("2b");
            whiteList.Add("2a");
            whiteList.Remove("2");
            whiteList.Remove("12");
            return whiteList;
        }

        private static List<string> GenerateWhiteList106()
        {
            var whiteList = new List<string>();
            for (int i = 1; i <= 11; i++)
            {
                whiteList.Add(i.ToString());
            }

            whiteList.Add("99");
            return whiteList;
        }
    }
}
