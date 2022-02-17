using System.Collections.Generic;

namespace Todo.Api.Configs
{
    public class MembershipConfig
    {
        public string Title { get; set; }
        public int MaxTasksPerDay { get; set; }
    }

    public class MembershipConfigs : List<MembershipConfig>
    {
        
    }
}