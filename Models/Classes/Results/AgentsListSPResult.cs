using Microsoft.EntityFrameworkCore;

namespace Models.Classes
{
    [Keyless]
    public class AgentsListSPResult
    {
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string PhoneNum { get; set; }
    }
}
