using Microsoft.EntityFrameworkCore;
using Moq;
using PMS.DataEFCore.Test.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PMS.DataEFCore.Test.TestData
{
    public static class DbSetData
    {
        public static Mock<DbSet<T>> GetDbSet<T>(IQueryable<T> TestData) where T : class
        {
            CancellationToken cancellationToken = default;
            var MockSet = new Mock<DbSet<T>>();
            MockSet.As<IAsyncEnumerable<T>>().Setup(x => x.GetAsyncEnumerator(cancellationToken)).Returns(new ITestAsyncEnumerator<T>(TestData.GetEnumerator()));
            MockSet.As<IQueryable<T>>().Setup(x => x.Provider).Returns(new TestAsyncQueryProvider<T>(TestData.Provider));
            MockSet.As<IQueryable<T>>().Setup(x => x.Expression).Returns(TestData.Expression);
            MockSet.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(TestData.ElementType);
            MockSet.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(TestData.GetEnumerator());            
            return MockSet;
        }

        internal static Mock<DbSet<T>> GetDbSet<T>(T TestData) where T : class
        {
            CancellationToken cancellationToken = default;
            var MockSet = new Mock<DbSet<T>>();
            MockSet.As<T>().Setup(x => x).Returns(TestData);
            //MockSet.As<T>().Setup(x => x.Provider).Returns(new TestAsyncQueryProvider<T>(TestData.Provider));
            //MockSet.As<T>().Setup(x => x.Expression).Returns(TestData.Expression);
            MockSet.As<T>().Setup(x => x.GetType()).Returns(TestData.GetType());
            //MockSet.As<T>().Setup(x => x.GetEnumerator()).Returns(TestData.GetEnumerator());
            return MockSet;
        }
    }
}
