using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace lb1.MyClasses
{
    [TestFixture]
    class Store_Tests
    {
        Store data;

        [SetUp]
        public void SetUpClass()
        {
            data = new Store();
        }

        [Test]
        public void AddItemTest()
        {
            int start_count = data.Items.Count;
            Random rand = new Random();
            data.AddItem("name" + (data.Items.Count + 1));
            Assert.Greater(data.Items.Count, start_count);
            Assert.NotNull(data.Items[data.Items.Count-1].name);
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

            Assert.Greater(data.Items.Count,start_count);
            Assert.AreEqual(all_count, data.Items.Count);
        }

        [Test]
        public void ClearStoreTest()
        {
            FillListTest();
            data.ClearStore();
            Assert.IsNotNull(data);
            foreach (Item i in data.Items)
            {
                Assert.AreEqual(i.laid_out, false);
            }
        }

        [Test]
        public void PutItemOnCounterTest()
        {
            FillListTest();

            for (int i = 0; i < data.Items.Count; i++)
            {
                Item saved_item = data.Items[i];
                Assert.AreEqual(true, data.PutItemOnCounter(data.Items[i]));
                Assert.AreEqual(!saved_item.laid_out, data.Items[i].laid_out);
            }
        }

        [Test]
        public void CalculateCountOnCounterTest()
        {
            FillListTest();
            Assert.GreaterOrEqual(data.Items.Count(i => i.laid_out == true), 0);
            Assert.AreEqual(data.Items.Count(i => i.laid_out == true), data.CalculateCountOnCounter());
        }

        [Test]
        public void CalculateCountNotOnCounterTest()
        {
            FillListTest();
            Assert.GreaterOrEqual(data.Items.Count(i => i.laid_out == false), 0);
            Assert.AreEqual(data.Items.Count(i => i.laid_out == false), data.CalculateCountNotOnCounter());
        }

        [Test]
        public void GetListAsTextTtest()
        {
            FillListTest();
            string result = "";
            foreach (Item i in data.Items)
            {
                result = String.Concat(result, i.name, ' ', i.laid_out, '\n');
            }
            Assert.GreaterOrEqual(result.Length, 0);
            string s = data.GetListAsText();
            Assert.AreEqual(result.Length, s.Length);
            Assert.AreEqual(result, s);
        }
    }
}
