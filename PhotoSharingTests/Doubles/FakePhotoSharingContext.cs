using PhotoSharingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharingTests.Doubles
{
    class FakePhotoSharingContext : IPhotoSharingContext
    {
        SetMap _map = new SetMap();
        public IQueryable<Comment> Comments
        {
            get { return _map.Get<Comment>().AsQueryable(); }
            set { _map.Use<Comment>(value); }
        
        }

        public IQueryable<Photo> Photos
        {
            get { return _map.Get<Photo>().AsQueryable(); }
            set { _map.Use<Photo>(value); }
        }

        public T Add<T>(T entity) where T : class
        {
            _map.Get<T>().Add(entity);
            return entity;
        }

        public T Delete<T>(T entity) where T : class
        {
            _map.Get<T>().Remove(entity);
            return entity;
        }

        public Comment FindCommentById(string ID)
        {
            Comment item = (from c in this.Comments
                            where c.CommentID == ID
                            select c).First();
            return item;
        }

        public Photo FindPhotoById(int ID)
        {
            Photo item = (from p in this.Photos
                            where p.PhotoID == ID
                            select p).First();
            return item;
        }

        public Photo FindPhotoByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
        class SetMap : KeyedCollection<Type, object>
        {
            public HashSet<T> Use<T>(IEnumerable<T> sourceData)
            {
                var set = new HashSet<T>(sourceData);
                if (Contains(typeof(T)))
                {
                    Remove(typeof(T));
                }
                Add(set);
                return set;
            }
            public HashSet<T> Get<T>() { return (HashSet<T>)this[typeof(T)]; }
            protected override Type GetKeyForItem(object item)
            {
                return item.GetType().GetGenericArguments().Single();
            }
        }
    }
}
