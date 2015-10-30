using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RepeaterPagerItem
{
    public string PageNumber { get; set; }
    public string DisplayText { get; set; }

    public RepeaterPagerItem(string pageNumber, string displayText)
    {
        this.PageNumber = pageNumber;
        this.DisplayText = displayText;
    }
}
