using System;

namespace PluralSight.Moq.Code.Demo13
{
//    public delegate void NotifySalesTeamDelegate(
//        string name, 
//        bool broadcastToAllEmployees);

    public interface ICustomerRepository
    {
        void Save(Customer customer);
        event EventHandler<NotifySalesTeamEventArgs> NotifySalesTeam;
//        event NotifySalesTeamDelegate NotifySalesTeam;
    }
}