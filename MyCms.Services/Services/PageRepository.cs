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

        public IEnumerable<Page> GetLatestPage()
        {
            return _db.Pages.OrderByDescending(p => p.CreateDate).Take(4).ToList();
        }

        public Page GetPageById(int pageId)
        {
            return _db.Pages.Find(pageId);
        }

        public IEnumerable<Page> GetPagesByGroupId(int groupId)
        {
            return _db.Pages.Where(p => p.GroupID == groupId).ToList();
        }

        public IEnumerable<Page> GetPagesinSlider()
        {
            return _db.Pages.Where(p => p.ShowInSlider).ToList();
        }

        public IEnumerable<Page> GetTopPage(int take = 4)
        {
            return _db.Pages.OrderByDescending(p => p.PageTitle).Take(take).ToList();
        }

        public void InsertPage(Page page)
        {
            _db.Pages.Add(page);
        }

        public bool PageExists(int pageId)
        {
            return _db.Pages.Any(p => p.PageID == pageId);
        }

        public void save()
        {
            _db.SaveChanges();
        }

        public IEnumerable<Page> Search(string q)
        {
            var result = _db.Pages.Where(p => p.PageTitle.Contains(q) || p.ShortDescription.Contains(q) || p.PageText.Contains(q) || p.PageTags.Contains(q)).ToList();
            return result.Distinct();
        }

        public void UpdatePage(Page page)
        {
            _db.Entry(page).State=EntityState.Modified;
        }
    }
}
