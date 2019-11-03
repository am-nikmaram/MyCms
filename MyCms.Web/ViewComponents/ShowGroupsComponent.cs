using Microsoft.AspNetCore.Mvc;
using MyCms.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCms.Web.ViewComponents
{
    public class ShowGroupsComponent:ViewComponent
    {
        private IPageGroupRepository _groupRepository;
        public ShowGroupsComponent(IPageGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ShowGroupsComponent",_groupRepository.GetListGroups()));
        }

    }
}
