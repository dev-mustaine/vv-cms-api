using System.Collections.Generic;
using Via.CMS.DTO;

namespace Via.CMS.API.Results
{
    public class FaqResponse
    {
        #region Construtores

        public FaqResponse(List<FAQComponentDTO> faqs)
        {
            Faqs = faqs;
        }

        public List<FAQComponentDTO> Faqs { get; set; }

        #endregion
    }
}
