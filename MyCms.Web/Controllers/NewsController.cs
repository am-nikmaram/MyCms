using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCms.Services.Repositories;

namespace MyCms.Web.Controllers
{
    public class NewsController : Controller
    {
        private IPageRepository _pageRepository;
        public NewsController(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        [Route("News/{newsId}")]
        public IActionResult ShowNews(int newsId)
        {
            var page = _pageRepository.GetPageById(newsId);
            if (page!=null)
            {
                page.PageVisit += 1;
                _pageRepository.UpdatePage(page);
                _pageRepository.save();
            }
            return View(page);
        }
        [Route("Groups/{groupId}/{title}")]
        public IActionResult ShowNewsByGroupId(int groupId, string title)
        {
            ViewData["GroupTitle"] = title;
            return View(_pageRepository.GetPagesByGroupId(groupId));
        }
        [Route("search")]
        public IActionResult search(string q)
        {
            return View(_pageRepository.Search(q));
        }

    }
}