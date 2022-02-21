using System.Collections.Generic;

namespace Todo.Domains.Common
{
    public class MembershipSetting
    {
        public string Title { get; set; }

        public int MaxTasksPerDay { get; set; }
    }
    
    public class MembershipConfigs : List<MembershipSetting>
    {
        
    }
}