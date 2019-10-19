using Microsoft.EntityFrameworkCore;
using MyCms.DataLayer.Context;
using MyCms.DomainClasses.Page;
using MyCms.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCms.Services.Services
{
    public class PageRepository : IPageRepository
    {
        MyCmsDbContext _db;
        public PageRepository(MyCmsDbContext db)
        {
            _db = db;
        }

        public void DeletePage(Page page)
        {
            _db.Entry(page).State = EntityState.Deleted;
        }

        public void DeletePage(int PageId)
        {
            var page = GetPageById(PageId);
            DeletePage(page);
        }

        public IEnumerable<Page> GetAllPage()
        {
            return _db.Pages.ToList();
        }

        public Page GetPageById(int pageId)
        {
            return _db.Pages.Find(pageId);
        }

        public void InsertPage(Page page)
        {
            _db.Pages.Add(page);
        }

        public void save()
        {
            _db.SaveChanges();
        }

        public void UpdatePage(Page page)
        {
            _db.Entry(page).State=EntityState.Modified;
        }
    }
}
