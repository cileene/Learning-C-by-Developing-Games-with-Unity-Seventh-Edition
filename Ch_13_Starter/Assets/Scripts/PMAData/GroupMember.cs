using System;

namespace PMAData
{
    [Serializable]
    public class GroupMember
    {
        public string firstName;
        public string dateOfBirth;
        public string favoriteColor;
        
        public GroupMember() {}
        
        
        public GroupMember(string firstName, string dateOfBirth, string favoriteColor)
        {
            this.firstName = firstName;
            this.dateOfBirth = dateOfBirth;
            this.favoriteColor = favoriteColor;
        }
    }
}