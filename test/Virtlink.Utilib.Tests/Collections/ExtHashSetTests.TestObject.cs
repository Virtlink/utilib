using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtlink.Utilib.Collections
{
    partial class ExtHashSetTests
    {
        /// <summary>
        /// A test object, which has two fields,
        /// but only one field participates in the equality checking.
        /// </summary>
        public sealed class TestObject : IEquatable<TestObject>
        {
            /// <summary>
            /// Gets the key value.
            /// </summary>
            /// <value>The key value.</value>
            public string Key { get; }

            /// <summary>
            /// Gets the value value.
            /// </summary>
            /// <value>The value value.</value>
            public string Value { get; set; }

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="TestObject"/> class.
            /// </summary>
            /// <param name="key">The key value.</param>
            /// <param name="value">The value value.</param>
            public TestObject(string key, string value)
            {
                #region Contract
                if (key == null)
                    throw new ArgumentNullException(nameof(key));
                #endregion

                this.Key = key;
                this.Value = value;
            }
            #endregion
            
            /// <inheritdoc />
            public override bool Equals(object obj) => Equals(obj as TestObject);

            /// <inheritdoc />
            public bool Equals(TestObject other)
            {
                if (Object.ReferenceEquals(other, null) ||      // When 'other' is null
                    other.GetType() != this.GetType())          // or of a different type
                    return false;                               // they are not equal.
                return this.Key == other.Key;
            }

            /// <inheritdoc />
            public override int GetHashCode() => this.Key.GetHashCode();

            /// <inheritdoc />
            public override string ToString() => $"{this.Key}: {this.Value}";
        }
    }
}
