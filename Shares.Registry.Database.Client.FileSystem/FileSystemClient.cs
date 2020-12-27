
using Shares.Registry.Abstraction.Database.Connections;

using System;
using System.Linq;
using System.Linq.Expressions;

namespace Shares.Registry.Database.FileSystem
{
    public class FileSystemClient : IClient
    {
        public bool IsOpen => throw new NotImplementedException();

        public void Close()
        {
            throw new NotImplementedException();
        }

        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            throw new NotImplementedException();
        }

        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }

        public IClient Open()
        {
            throw new NotImplementedException();
        }        

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
