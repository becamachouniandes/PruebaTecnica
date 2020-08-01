using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfUsuarios.Entities;

namespace WcfUsuarios
{
    [ServiceContract]
    public interface IServiceUser
    {
        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        void CreateUser(User user);

        [OperationContract]
        void UpdateUser(User user);

        [OperationContract]
        void DeleteUser(int id);
    }
}
