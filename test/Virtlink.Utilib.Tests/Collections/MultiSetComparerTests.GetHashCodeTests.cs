﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.Collections
{
    partial class MultiSetComparerTests
    {
        /// <summary>
        /// Tests the <see cref="MultiSetComparer{T}.GetHashCode"/> method.
        /// </summary>
        [TestFixture]
        public sealed class GetHashCodeTests
        {
            [Test]
            public void SameCollectionsHaveSameHashCode()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = c1;

                // Act
                int h1 = MultiSetComparer<String>.Default.GetHashCode(c1);
                int h2 = MultiSetComparer<String>.Default.GetHashCode(c2);

                // Assert
                Assert.That(h1, Is.EqualTo(h2));
            }

            [Test]
            public void EqualCollectionsHaveSameHashCode()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "b", "c"};

                // Act
                int h1 = MultiSetComparer<String>.Default.GetHashCode(c1);
                int h2 = MultiSetComparer<String>.Default.GetHashCode(c2);

                // Assert
                Assert.That(h1, Is.EqualTo(h2));
            }

            [Test]
            public void EquivalentCollectionsHaveSameHashCode()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"c", "b", "a", "b"};

                // Act
                int h1 = MultiSetComparer<String>.Default.GetHashCode(c1);
                int h2 = MultiSetComparer<String>.Default.GetHashCode(c2);

                // Assert
                Assert.That(h1, Is.EqualTo(h2));
            }
        }
    }
}