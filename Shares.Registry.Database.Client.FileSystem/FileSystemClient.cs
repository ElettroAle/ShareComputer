
using Shares.Registry.Abstraction.Database.Connections;

using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Shares.Registry.Database.FileSystem
{
    public class FileSystemClient : IClient
    {
        private readonly string root = "C://db";
        public FileSystemClient()
        {
            string[] tables = Directory.GetFiles(root, "table_*.json", SearchOption.AllDirectories);
        }

        public bool IsOpen => true;

        public void Close()
        {
        }

        public IQueryable CreateQuery(Expression expression)
        {
            
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new Container<TElement>
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
            return this;
        }        

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
