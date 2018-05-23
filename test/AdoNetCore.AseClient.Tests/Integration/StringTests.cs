﻿using System;
using System.Data;
using AdoNetCore.AseClient.Internal;
using Dapper;
using NUnit.Framework;

namespace AdoNetCore.AseClient.Tests.Integration
{
    /// <summary>
    /// NOTE: these tests rely on the server encoding (UTF-8). Behaviour is consistent when run against the reference driver.
    /// </summary>
    [TestFixture]
    [Category("basic")]
    public class StringTests
    {
        private IDbConnection GetConnection()
        {
            Logger.Enable();
            return new AseConnection(ConnectionStrings.Pooled);
        }

        [Test]
        public void CharEncoding_ShouldWork()
        {
            using (var connection = GetConnection())
            {
                var result = connection.ExecuteScalar<string>("select convert(char(3), 'Àa')");
                Assert.AreEqual("Àa", result);
            }
        }

        [Test]
        public void VarcharEncoding_ShouldWork()
        {
            using (var connection = GetConnection())
            {
                var result = connection.ExecuteScalar<string>("select convert(varchar(10), 'Àa')");
                Assert.AreEqual("Àa", result);
            }
        }

        [Test]
        public void NcharEncoding_ShouldWork()
        {
            using (var connection = GetConnection())
            {
                var result = connection.ExecuteScalar<string>("select convert(nchar(1), 'Àa')");
                Assert.AreEqual("Àa", result);
            }
        }

        [Test]
        public void NvarcharEncoding_ShouldWork()
        {
            using (var connection = GetConnection())
            {
                var result = connection.ExecuteScalar<string>("select convert(nvarchar(10), 'Àa')");
                Assert.AreEqual("Àa", result);
            }
        }

        [Test]
        public void TextEncoding_ShouldWork()
        {
            using (var connection = GetConnection())
            {
                var result = connection.ExecuteScalar<string>("select convert(text, 'Àa')");
                Assert.AreEqual("Àa", result);
            }
        }

        [Test]
        public void UnicharEncoding_ShouldWork()
        {
            using (var connection = GetConnection())
            {
                var result = connection.ExecuteScalar<string>("select convert(unichar(2), 'Àa')");
                Assert.AreEqual("Àa", result);
            }
        }

        [Test]
        public void UnivarcharEncoding_ShouldWork()
        {
            using (var connection = GetConnection())
            {
                var result = connection.ExecuteScalar<string>("select convert(univarchar(2), 'Àa')");
                Assert.AreEqual("Àa", result);
            }
        }

        [Test]
        public void UnitextEncoding_ShouldWork()
        {
            using (var connection = GetConnection())
            {
                var result = connection.ExecuteScalar<string>("select convert(unitext, 'Àa')");
                Assert.AreEqual("Àa", result);
            }
        }

        [TestCase("select '['+@input+']'", "", "[ ]")]
        [TestCase("select @input", "", " ")]
        [TestCase("select convert(char, @input)", null, null)]
        [TestCase("select '['+convert(char, @input)+']'", null, "[]")]
        [TestCase("select convert(char, '['+@input+']')", null, "[]                            ")]
        public void Select_StringParameter(string sql, object input, object expected)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    var p = command.CreateParameter();
                    p.ParameterName = "@input";
                    p.Value = input ?? DBNull.Value;
                    p.DbType = DbType.AnsiString;
                    command.Parameters.Add(p);

                    Assert.AreEqual(expected ?? DBNull.Value, command.ExecuteScalar());
                }
            }
        }

        [TestCase("select ''", " ")]
        [TestCase("select convert(char, '')", "                              ")]
        [TestCase("select convert(char(1), '')", " ")]
        [TestCase("select convert(nchar(1), '')", "   ")]
        [TestCase("select convert(unichar(1), '')", " ")]
        [TestCase("select convert(varchar(1), '')", " ")]
        [TestCase("select convert(univarchar(1), '')", " ")]
        [TestCase("select convert(nvarchar(1), '')", " ")]
        [TestCase("select convert(char, null)", null)]
        [TestCase("select convert(char(1), null)", null)]
        [TestCase("select convert(unichar(1), null)", null)]
        [TestCase("select convert(nchar(1), null)", null)]
        [TestCase("select convert(varchar(1), null)", null)]
        [TestCase("select convert(univarchar(1), null)", null)]
        [TestCase("select convert(nvarchar(1), null)", null)]
        public void Select_StringLiteral(string sql, object expected)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    var result = command.ExecuteScalar();
                    Console.WriteLine($"[{result}]");
                    Assert.AreEqual(expected ?? DBNull.Value, result);
                }
            }
        }
    }
}
