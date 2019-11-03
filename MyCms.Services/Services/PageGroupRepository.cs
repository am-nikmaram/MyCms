using Microsoft.EntityFrameworkCore;
using MyCms.DataLayer.Context;
using MyCms.DomainClasses.PageGroup;
using MyCms.Services.Repositories;
using MyCms.ViewModels.Page;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var group = GetPageGroupById(groupId);
            DeletePageGroup(group);
        }

        public void DeletePageGroup(PageGroup pageGroup)
        {
            _db.Entry(pageGroup).State = EntityState.Deleted;
        }

        public List<PageGroup> GetAllPageGroups()
        {
            return _db.PageGroups.ToList();
        }

        public List<ShowGroupsViewModel> GetListGroups()
        {
            return _db.PageGroups.Select(g => new ShowGroupsViewModel()
            {
                GroupID = g.GroupID,
                GroupTitle = g.GroupTitle,
                PageCount = g.Pages.Count
            }).ToList();
        }

        public PageGroup GetPageGroupById(int groupid)
        {
            return _db.PageGroups.Find(groupid);
        }

        public void  InsertPageGroup(PageGroup pageGroup)
        {
            _db.PageGroups.Add(pageGroup);
        }

        public bool PageGroupExists(int pagegroupid)
        {
            return _db.PageGroups.Any(p => p.GroupID == pagegroupid);
        }

        public void save()
        {
            _db.SaveChanges();
        }

        public void UpdatePageGroup(PageGroup pageGroup)
        {
            _db.Entry(pageGroup).State = EntityState.Modified;
        }
    }
}
