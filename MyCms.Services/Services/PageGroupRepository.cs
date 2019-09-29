using MyCms.DataLayer.Context;
using MyCms.DomainClasses.PageGroup;
using MyCms.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCms.Services.Services
{
    public class PageGroupRepository : IPageGroupRepository
    {
        private MyCmsDbContext _db;

        public PageGroupRepository(MyCmsDbContext db)
        {
            this._db = db; 

        }

        public void DeletePageGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public void DeletePageGroup(PageGroup pageGroup)
        {
            throw new NotImplementedException();
        }

        public List<PageGroup> GetAllPageGroups()
        {
            throw new NotImplementedException();
        }

        public PageGroup GetPageGroupById(int groupid)
        {
            throw new NotImplementedException();
        }

        public int InsertPageGroup(PageGroup pageGroup)
        {
            throw new NotImplementedException();
        }

        public void UpdatePageGroup(PageGroup pageGroup)
        {
            throw new NotImplementedException();
        }
    }
}
