using System.Collections.Generic;
using Via.CMS.Domain.Base;

namespace Via.CMS.Domain
{
    public class Faq : Document
    {
        public List<FAQItem> Faqs { get; set; }
    }

    public class FAQItem
    {
        public string Ask { get; set; }
        public string Answer { get; set; }
    }
}