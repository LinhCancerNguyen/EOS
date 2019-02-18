using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Service
{
    public interface ITagService
    {
        IEnumerable<Tag> GetTags();
        Tag GetTag(int Id);
        void CreateTag(Tag tag);
        void SaveTag();
        void UpdateTag(Tag tag);
        void DeleteTag(Tag tag);
    }

    public class TagService : ITagService
    {
        public void CreateTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public void DeleteTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetTags()
        {
            throw new NotImplementedException();
        }

        public Tag GetTag(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveTag()
        {
            throw new NotImplementedException();
        }

        public void UpdateTag(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
