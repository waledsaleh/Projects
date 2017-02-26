using System;
using NUnit.Framework;

namespace Serpent {
    [TestFixture]
    public class IntegerPathTest {

        private const float kInterval = 3;
        private readonly int[] kValues = new int[] { 1, 2, 3 };

        private IntegerPath<int> path;

        [SetUp]
        public void Init() {
            path = new IntegerPath<int>(kInterval);
        }

        [Test]
        public void InitialState() {
            Assert.AreEqual(kInterval, path.interval);
            Assert.AreEqual(0, path.Size);
            Assert.AreEqual(0, path.Length);
            Assert.AreEqual(0, path.stepsPassed);
            Assert.AreEqual(0, path.Mileage);
        }

        [Test]
        public void PushToEnd() {
            path.PushToEnd(1);
            Assert.AreEqual(1, path[0]);
            Assert.AreEqual(1, path.Size);
            Assert.AreEqual(0, path.Length);
            Assert.AreEqual(0, path.stepsPassed);
            Assert.AreEqual(0, path.Mileage);

            path.PushToEnd(2);
            Assert.AreEqual(2, path[1]);
            Assert.AreEqual(2, path.Size);
            Assert.AreEqual(kInterval, path.Length);
            Assert.AreEqual(0, path.stepsPassed);
            Assert.AreEqual(0, path.Mileage);
        }

        [Test]
        public void PushToEndArray() {
            path.PushToEnd(kValues);
            CollectionAssert.AreEqual(kValues, path);
            Assert.AreEqual(kValues.Length, path.Size);
            
            path.PushToEnd(new int[] { });
            Assert.AreEqual(kValues.Length, path.Size);

            Assert.Throws(typeof(ArgumentNullException), () => {
                path.PushToEnd((int[]) null);
            });
        }

        [Test]
        public void PopFromStart_NonEmpty() {
            path.PushToEnd(kValues);
            path.PopFromStart();

            CollectionAssert.AreEqual(new int[] { 2, 3 }, path);
            Assert.AreEqual(2, path.Size);
            Assert.AreEqual(kInterval, path.Length);
            Assert.AreEqual(kInterval, path.Mileage);
            Assert.AreEqual(1, path.stepsPassed);
        }

        [Test]
        public void PopFromStart_Empty() {
            Assert.Throws(typeof(System.InvalidOperationException), () => {
                path.PopFromStart();
            });
        }
        
        [Test]
        public void GetValueAt() {
            // Empty path
            Assert.Throws(typeof(IndexOutOfRangeException), () => {
                path.GetValueAt(0, SnakeSpace.FromHead);
            });
            Assert.Throws(typeof(IndexOutOfRangeException), () => {
                path.GetValueAt(0, SnakeSpace.FromTail);
            });
            Assert.Throws(typeof(IndexOutOfRangeException), () => {
                path.GetValueAt(0, SnakeSpace.FromStart);
            });

            path.PushToEnd(new int[] {1, 2, 3});
            path.PopFromStart();

            // SnakeSpace.FromHead
            Assert.Throws(typeof(IndexOutOfRangeException), () => {
                path.GetValueAt(-1, SnakeSpace.FromHead);
            });
            Assert.AreEqual(3, path.GetValueAt(0, SnakeSpace.FromHead));
            Assert.AreEqual(2, path.GetValueAt(1, SnakeSpace.FromHead));
            Assert.Throws(typeof(IndexOutOfRangeException), () => {
                path.GetValueAt(2, SnakeSpace.FromHead);
            });
            
            // SnakeSpace.FromTail
            Assert.Throws(typeof(IndexOutOfRangeException), () => {
                path.GetValueAt(-1, SnakeSpace.FromTail);
            });
            Assert.AreEqual(2, path.GetValueAt(0, SnakeSpace.FromTail));
            Assert.AreEqual(3, path.GetValueAt(1, SnakeSpace.FromTail));
            Assert.Throws(typeof(IndexOutOfRangeException), () => {
                path.GetValueAt(2, SnakeSpace.FromTail);
            });

            // SnakeSpace.FromStart
            Assert.Throws(typeof(IndexOutOfRangeException), () => {
                path.GetValueAt(0, SnakeSpace.FromStart);
            });
            Assert.AreEqual(2, path.GetValueAt(1, SnakeSpace.FromStart));
            Assert.AreEqual(3, path.GetValueAt(2, SnakeSpace.FromStart));
            Assert.Throws(typeof(IndexOutOfRangeException), () => {
                path.GetValueAt(3, SnakeSpace.FromStart);
            });
        }
    }
} // namespace Serpent
