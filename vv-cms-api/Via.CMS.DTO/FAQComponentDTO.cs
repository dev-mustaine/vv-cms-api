using System.Collections.Generic;

namespace Via.CMS.DTO
{
    public class FAQComponentDTO : ComponentBaseDTO
    {
        public FAQComponentDTO()
        {
            Faqs = new List<FAQItemDTO>();
        }
        public List<FAQItemDTO> Faqs { get; set; }
    }

    public class FAQItemDTO
    {
        public string Ask { get; set; }
        public string Answer { get; set; }
    }

}
