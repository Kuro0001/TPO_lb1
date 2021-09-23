using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace lb1.MyClasses
{
    [TestFixture]
    class MyTests
    {
        Mydata data;

        [SetUp]
        public void SetUpClass()
        {
            data = new Mydata();
        }

        [Test]
        public void AddItemTest()
        {
            int start_count = data.Data.Count;
            data.AddItem();
            Assert.Greater(data.Data.Count, start_count);
            Assert.NotNull(data.Data[data.Data.Count-1].name);
        }

        [Test]
        public void FillListTest()
        {
            int start_count = 0;
            int all_count = 10;

            for (int i = 0; i < all_count; i++)
            {
                AddItemTest();
            }

            Assert.Greater(data.Data.Count,start_count);
            Assert.AreEqual(all_count, data.Data.Count);
        }

        [Test]
        public void ClearListTest()
        {
            FillListTest();
            data.ClearList();
            Assert.IsNotNull(data);
            Assert.LessOrEqual(data.Data.Count,0);
        }

        [Test]
        public void ChangeConditionTest()
        {
            FillListTest();

            for (int i = 0; i < data.Data.Count; i++)
            {
                Item saved_item = data.Data[i];
                Assert.AreEqual(true, data.ChangeCondition(data.Data[i]));
                Assert.AreEqual(!saved_item.condition, data.Data[i].condition);
            }
        }

        [Test]
        public void CalculateCountTrueTest()
        {
            FillListTest();
            Assert.GreaterOrEqual(data.Data.Count(i => i.condition == true), 0);
            Assert.AreEqual(data.Data.Count(i => i.condition == true), data.CalculateCountTrue());
        }

        [Test]
        public void CalculateCountFalseTest()
        {
            FillListTest();
            Assert.GreaterOrEqual(data.Data.Count(i => i.condition == false), 0);
            Assert.AreEqual(data.Data.Count(i => i.condition == false), data.CalculateCountFalse());
        }

        [Test]
        public void GetTextTtest()
        {
            FillListTest();
            string result = "";
            foreach (Item i in data.Data)
            {
                result = String.Concat(result, i.name, ' ', i.condition, '\n');
            }
            Assert.GreaterOrEqual(result.Length, 0);
            string s = data.GetText();
            Assert.AreEqual(result.Length, s.Length);
            Assert.AreEqual(result, s);
        }
    }
}
