using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RepeaterPager
{
    public readonly int MAX_PAGER_ITEMS = 10;

    public int PageSize { get; protected set; }
    public int CurrentPage { get; set; }
    public int ObjectsCount { get; set; }
    public int TotalPages { get; set; }
    public IList<RepeaterPagerItem> Items { get; set; }

    public RepeaterPager(int currentPage, int objectsCount, int pageSize = 20)
    {
        this.PageSize = pageSize;
        this.CurrentPage = currentPage;
        this.ObjectsCount = objectsCount;
        this.TotalPages = (int)Math.Ceiling((double)objectsCount / pageSize);
        this.Items = new List<RepeaterPagerItem>();

        int incrementor = (int)Math.Floor((double)currentPage / this.MAX_PAGER_ITEMS) * 10;

        if (currentPage > this.MAX_PAGER_ITEMS)
        {
            RepeaterPagerItem prevSequence = new RepeaterPagerItem((incrementor - 1).ToString(), "...");
            this.Items.Add(prevSequence);
        }

        int lastItem = this.MAX_PAGER_ITEMS < this.TotalPages ? this.MAX_PAGER_ITEMS : this.TotalPages;
        for (int i = 1; i <= lastItem; i++)
        {
            int page = (i + incrementor);
            if (page > this.TotalPages)
            {
                break;
            }

            string pageNumberAsString = page.ToString();
            RepeaterPagerItem item = new RepeaterPagerItem(pageNumberAsString, pageNumberAsString);
            this.Items.Add(item);
        }

        int lastInPager = incrementor + this.MAX_PAGER_ITEMS;
        if (lastInPager < this.TotalPages)
        {
            RepeaterPagerItem nextSequence = new RepeaterPagerItem((lastInPager + 1).ToString(), "...");
            this.Items.Add(nextSequence);
        }
    }

    public string GetItemsCountText()
    {
        return string.Format("{0} items in {1} {2}", this.ObjectsCount, this.TotalPages, this.TotalPages > 1 ? "pages" : "page");
    }
}
