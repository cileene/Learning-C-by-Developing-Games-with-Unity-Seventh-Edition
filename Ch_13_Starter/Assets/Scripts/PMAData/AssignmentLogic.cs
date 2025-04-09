using UnityEngine;

namespace PMAData
{
    public class AssignmentLogic : MonoBehaviour
    {
        private GroupMember _diana;
        private GroupMember _ingrid;
        private GroupMember _nanna;
        private GroupMember _nick;
        private GroupMember _valdemar;
        
        private void Start()
        {
            DataManager.DataPathName = "Group_Members";
            DataManager.InitFileSystem();
            InitGroupMembers();
            
            HandleGroupMembers(_diana);
            HandleGroupMembers(_ingrid);
            HandleGroupMembers(_nanna);
            HandleGroupMembers(_nick);
            HandleGroupMembers(_valdemar);
        }

        private void HandleGroupMembers(GroupMember groupMember)
        {
            if (groupMember == null) return;

            string memberName = groupMember.firstName;
            DataManager.SaveXmlToFile(memberName, groupMember);

            groupMember = DataManager.LoadFromFile<GroupMember>($"{memberName}.xml");
            if (groupMember == null)
            {
                Debug.LogError($"Failed to load group member: {memberName}");
                return;
            }

            DataManager.SaveJsonToFile(memberName, groupMember);
        }

        private void InitGroupMembers()
        {
            _diana = new GroupMember(
                "Diana", 
                "UnknownDate4", 
                "Purple"
                );
            _ingrid = new GroupMember(
                "Ingrid", 
                "UnknownDate1", 
                "Blue"
                );
            _nanna = new GroupMember(
                "Nanna", 
                "UnknownDate2", 
                "Green"
                );
            _nick = new GroupMember(
                "Nick", 
                "1991/04/06", 
                "Red"
                );
            _valdemar = new GroupMember(
                "Valdemar", 
                "UnknownDate3", 
                "Yellow"
                );
        }
    }
}