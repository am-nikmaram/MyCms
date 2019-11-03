using MyCms.DomainClasses.PageGroup;
using MyCms.ViewModels.Page;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCms.Services.Repositories
{
    public interface IPageGroupRepository
    {
        List<PageGroup> GetAllPageGroups();
        PageGroup GetPageGroupById(int groupid);
        void InsertPageGroup(PageGroup pageGroup);
        void UpdatePageGroup(PageGroup pageGroup);
        void DeletePageGroup(int groupId);
        void DeletePageGroup(PageGroup pageGroup);
        bool PageGroupExists(int pagegroupid);
        List<ShowGroupsViewModel> GetListGroups();
        void save();

               
    }
}
