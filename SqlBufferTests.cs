// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


using System;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient.Optimized;
using Xunit;

namespace Microsoft.Data.SqlClient.Tests
{
    public sealed class SqlBufferTests
    {
        private readonly SqlBuffer _target = new();

        [Fact]
        public void GuidShouldThrowWhenSqlGuidNullIsSet()
        {
            _target.SqlGuid = SqlGuid.Null;

            Assert.Throws<SqlNullValueException>(() => _target.Guid);
        }

        [Theory]
        [InlineData((int)SqlBuffer.StorageType.Guid)]
        [InlineData((int)SqlBuffer.StorageType.SqlGuid)]
        public void GuidShouldThrowWhenSetToNullOfTypeIsCalled(int storageType)
        {
            _target.SetToNullOfType((SqlBuffer.StorageType)storageType);

            Assert.Throws<SqlNullValueException>(() => _target.Guid);
        }

        [Fact]
        public void GuidShouldReturnWhenGuidIsSet()
        {
            var expected = Guid.NewGuid();
            _target.Guid = expected;

            Assert.Equal(expected, _target.Guid);
        }

        [Fact]
        public void GuidShouldReturnExpectedWhenSqlGuidIsSet()
        {
            var expected = Guid.NewGuid();
            _target.SqlGuid = expected;

            Assert.Equal(expected, _target.Guid);
        }

        [Theory]
        [InlineData((int)SqlBuffer.StorageType.Guid)]
        [InlineData((int)SqlBuffer.StorageType.SqlGuid)]
        public void SqlGuidShouldReturnSqlNullWhenSetToNullOfTypeIsCalled(int storageType)
        {
            _target.SetToNullOfType((SqlBuffer.StorageType)storageType);

            Assert.Equal(SqlGuid.Null, _target.SqlGuid);
        }

        [Fact]
        public void SqlGuidShouldReturnSqlGuidNullWhenSqlGuidNullIsSet()
        {
            _target.SqlGuid = SqlGuid.Null;

            Assert.Equal(SqlGuid.Null, _target.SqlGuid);
        }
        
        [Fact]
        public void SqlGuidShouldReturnExpectedWhenGuidIsSet()
        {
            var guid = Guid.NewGuid();
            SqlGuid expected = guid;
            _target.Guid = guid;

            Assert.Equal(expected, _target.SqlGuid);
        }

        [Fact]
        public void SqlGuidShouldReturnExpectedWhenSqlGuidIsSet()
        {
            SqlGuid expected = Guid.NewGuid();
            _target.SqlGuid = expected;

            Assert.Equal(expected, _target.SqlGuid);
        }

        [Fact]
        public void SqlValueShouldReturnExpectedWhenGuidIsSet()
        {
            var guid = Guid.NewGuid();
            SqlGuid expected = guid;
            _target.Guid = guid;

            Assert.Equal(expected, _target.SqlValue);
        }

        [Fact]
        public void SqlValueShouldReturnExpectedWhenSqlGuidIsSet()
        {
            SqlGuid expected = Guid.NewGuid();
            _target.SqlGuid = expected;

            Assert.Equal(expected, _target.SqlValue);
        }
    }
}