using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMessage
    {
        void Sms(string message, int userId);
        void Email(string message, int userId);
    }

    public enum Messagetype
    {
        Sms,
        Email
    }
}
