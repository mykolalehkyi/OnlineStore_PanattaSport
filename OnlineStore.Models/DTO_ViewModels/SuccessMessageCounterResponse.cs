using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.DTO_ViewModels
{
    public class SuccessMessageCounterResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Counter { get; set; }
    }
}
